using Automatic_updating_of_seniority.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Automatic_updating_of_seniority
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Thread thread = new Thread(UpdateSeniority);
            thread.Start();

            RequestService requestService = new RequestService();
            var requests = requestService.GetAll().Where(p => p.RequestStatus == 1 && p.CurrentITSupporter_Id == null).OrderBy(p => p.CreateDate).OrderBy(p => p.Priority).ToList();
            var input = 0;
            var itsupporterService = new ITSupporterService();
            var itName = "";
            bool acceptRequest = false;
            if (requests != null)
            {
                foreach(var requestItem in requests)
                {
                    Console.WriteLine($"Yeu cau {requestItem.RequestId} chua duoc xu li");
                }
                Console.WriteLine("===============================");
                foreach (var item in requests)
                {
                    if (itsupporterService.GetAll().Any(a => a.IsBusy == false && a.IsOnline == true))
                    {
                        input = item.RequestId;
                        var result = FindITSupporterByRequestId(input);
                        Console.WriteLine($"Dang tim ho tro vien cho yeu cau {input}");
                        if (result.ObjReturn == 0)
                        {
                            itName = "Chua co ho tro vien nao";
                        }
                        else
                        {
                            itName = itsupporterService.GetAll().SingleOrDefault(i => i.ITSupporterId == result.ObjReturn).ITSupporterName;
                        }

                        if (!result.IsError && result.ObjReturn > 0)
                        {
                            FirebaseService firebaseService = new FirebaseService();
                            firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(result.ObjReturn, input);
                            Console.WriteLine($"Dang doi ho tro vien {itName} phan hoi:");
                            int counter = 60;

                            while (counter > 0)
                            {
                                var itsupporterIsOnline = itsupporterService.GetAll().SingleOrDefault(i => i.ITSupporterId == result.ObjReturn).IsOnline;
                                var itsupporterIsBusy = itsupporterService.GetAll().SingleOrDefault(i => i.ITSupporterId == result.ObjReturn).IsBusy;
                                if (itsupporterIsOnline == false)
                                {
                                    goto Stop;
                                }
                                else if(itsupporterIsBusy == true)
                                {
                                    goto Accept;
                                }
                                Console.WriteLine($"Đang chờ phản hồi trong {counter} giây");
                                counter--;
                                Thread.Sleep(1000);
                            }
                            Accept:
                            var accept = AcceptRequestFromITSupporter(result.ObjReturn, input, false);
                            acceptRequest = accept.ObjReturn;

                        }
                        Stop:
                        if (acceptRequest == false)
                        {
                            
                            Console.WriteLine("Ho tro vien " + itName + " da khong xac nhan yeu cau " + input);
                        }
                        else
                            Console.WriteLine("Ho tro vien " + itName + " da xac nhan yeu cau " + input);

                    }
                }

                Thread threadSleep = new Thread(CounterSleep);
                threadSleep.Start();

                Thread.Sleep(60000);
                Console.WriteLine("===============================");
                Console.WriteLine("Moi ngu day sau 60s");
            }
            goto Start;
        }

        public static void CounterSleep()
        {
            int counterSleep = 60;

            while (counterSleep > 0)
            {
                Console.WriteLine($"Sleep {counterSleep} giây");
                counterSleep--;
                Thread.Sleep(1000);
            }
        }
        //public static string CallRestMethod(string url)
        //{
        //    try
        //    {
        //        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
        //        webrequest.Method = "GET";
        //        webrequest.ContentType = "application/json";
        //        webrequest.Headers.Add("Username", "ssa");
        //        webrequest.Headers.Add("Password", "se62036@123");
        //        HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
        //        Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
        //        StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
        //        string result = string.Empty;
        //        result = responseStream.ReadToEnd();
        //        webresponse.Close();
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        return e.ToString();
        //    }
        //}

        public static void UpdateSeniority()
        {
            SkillService skillService = new SkillService();
            var skills = skillService.GetAll();
            var now = DateTime.UtcNow.AddHours(7);
            var first = now.Date.AddDays(-(now.Date.Day - 1));
            var last = first.AddMonths(1).AddTicks(-1);

            while (now != last)
            {
                var minutesToSleep = (int)(new DateTime(last.Year, last.Month, last.Day, 0, 0, 0) - DateTime.Now).TotalMinutes;
                Thread.Sleep(minutesToSleep);
            }

            foreach (var skillItem in skills)
            {
                if (skillItem.MonthExperience != null)
                {
                    skillItem.MonthExperience++;
                }
                skillService.Update(skillItem);
            }
        }



        public static ResponseObject<int> FindITSupporterByRequestId(int requestId)
        {
            try
            {
                var requestService = new RequestService();
                var itSupporterService = new ITSupporterService();
                var agencyService = new AgencyService();
                var comService = new CompanyService();
                var skillService = new SkillService();
                var serviceItemService = new ServiceItemService();

                var request = requestService.GetAll().SingleOrDefault(p => p.RequestId == requestId);
                var serviceItemId = request.ServiceItemId;
                var serviceITSupportId = serviceItemService.GetAll().SingleOrDefault(p => p.ServiceItemId == serviceItemId).ServiceITSupportId;
                var skills = skillService.GetAll().Where(a => a.ServiceITSupportId == serviceITSupportId);
                var agency = agencyService.GetAll().SingleOrDefault(p => p.AgencyId == request.AgencyId);
                var company = comService.GetAll().SingleOrDefault(p => p.CompanyId == agency.CompanyId); ;
                List<RenderITSupporterListWithWeight> itSupporterListWithWeights = new List<RenderITSupporterListWithWeight>();
                foreach (var item in skills)
                {
                    var itSupporter = itSupporterService.GetAll().SingleOrDefault(p => p.ITSupporterId == item.ITSupporterId && p.IsBusy == false && p.IsOnline == true);
                    if (itSupporter != null)
                    {
                        double weightForITSupporter = 0;
                        var a = requestService.GetAll().Where(p => p.CurrentITSupporter_Id == itSupporter.ITSupporterId && p.AgencyId == request.AgencyId).Count();
                        var weightForITSupporterFamiliarWithAgency = a * ((company.PercentForITSupporterFamiliarWithAgency != null && company.PercentForITSupporterFamiliarWithAgency.Value != 0) ? company.PercentForITSupporterFamiliarWithAgency.Value : 30);
                        var weightForITSupporterRate = (itSupporter.RatingAVG ?? 0) * ((company.PercentForITSupporterRate != null && company.PercentForITSupporterRate.Value != 0) ? company.PercentForITSupporterRate.Value : 40);
                        var weightForITSupporterExp = (item.MonthExperience ?? 0) * ((company.PercentForITSupporterExp != null && company.PercentForITSupporterExp.Value != 0) ? company.PercentForITSupporterExp.Value : 30);
                        weightForITSupporter = weightForITSupporterFamiliarWithAgency + weightForITSupporterRate + weightForITSupporterExp;
                        var renderITSupporterListWithWeight = new RenderITSupporterListWithWeight()
                        {
                            ITSupporterId = itSupporter.ITSupporterId,
                            ITSupporterName = itSupporter.ITSupporterName,
                            ITSupporterListWeight = weightForITSupporter,
                            TimesReject = 0
                        };
                        itSupporterListWithWeights.Add(renderITSupporterListWithWeight);
                    }
                }
                // Add redis
                itSupporterListWithWeights = itSupporterListWithWeights.OrderByDescending(p => p.ITSupporterListWeight).ToList();
                //MemoryCacher memoryCacher = new MemoryCacher();
                //memoryCacher.Add("ITSupporterListWithWeights", itSupporterListWithWeights, DateTimeOffset.UtcNow.AddHours(1));
                Queue<RenderITSupporterListWithWeight> itSupporterListWithWeightQueue = new Queue<RenderITSupporterListWithWeight>(itSupporterListWithWeights);

                RedisTools redisTools = new RedisTools();
                redisTools.Save("ITSupporterListWithWeights", itSupporterListWithWeightQueue);
                // Get first
                var itSupporterNameFound = itSupporterListWithWeights.FirstOrDefault().ITSupporterName;
                int itSupporterIdFound = itSupporterListWithWeights.FirstOrDefault().ITSupporterId;
                if (itSupporterIdFound > 0)
                {
                    return new ResponseObject<int> { IsError = false, SuccessMessage = $"Tìm được Hero {itSupporterNameFound}! Vùi lòng đợi xác nhận", ObjReturn = itSupporterIdFound };
                }
                return new ResponseObject<int> { IsError = true, WarningMessage = "Chưa tìm được Hero nào thích hợp!" };
            }
            catch (Exception ex)
            {
                return new ResponseObject<int> { IsError = true, WarningMessage = "Chưa tìm được Hero nào thích hợp!", ErrorMessage = ex.ToString() };
            }
        }



        public static ResponseObject<bool> AcceptRequestFromITSupporter(int itSupporterId, int requestId, bool isAccept)
        {
            //MemoryCacher memoryCacher = new MemoryCacher();
            RedisTools redisTools = new RedisTools();
            try
            {
                var requestService = new RequestService();
                var itSupporterService = new ITSupporterService();
                var requestHistoryService = new RequestHistoryService();
                var ticketService = new TicketService();
                if (isAccept)
                {
                    var request = requestService.GetAll().SingleOrDefault(p => p.RequestId == requestId);
                    var itSupporter = itSupporterService.GetAll().SingleOrDefault(p => p.ITSupporterId == itSupporterId);

                    if (request != null && itSupporter != null)
                    {
                        request.RequestStatus = (int)RequestStatusEnum.Processing;
                        request.CurrentITSupporter_Id = itSupporter.ITSupporterId;
                        request.StartTime = DateTime.UtcNow.AddHours(7);
                        requestService.Update(request);

                        itSupporterService.Update(itSupporter);
                        itSupporter.IsBusy = true;

                        var ticketsOfRequest = ticketService.GetAll().Where(p => p.RequestId == requestId).ToList();
                        foreach (var ticket in ticketsOfRequest)
                        {
                            ticket.UpdateDate = DateTime.UtcNow;
                            ticketService.Update(ticket);
                        }
                        //memoryCacher.Delete("ITSupporterListWithWeights");
                        redisTools.Clear("ITSupporterListWithWeights");
                        return new ResponseObject<bool> { IsError = false, SuccessMessage = "Nhận thành công", ObjReturn = true };
                    }
                }
                else
                {
                    //var itSupporterFound = memoryCacher.GetValue("ITSupporterListWithWeights");
                    var itSupporterFound = redisTools.Get("ITSupporterListWithWeights");
                    Queue<RenderITSupporterListWithWeight> idSupporterListWithWeights;
                    if (itSupporterFound != null)
                    {
                        idSupporterListWithWeights = JsonConvert.DeserializeObject<Queue<RenderITSupporterListWithWeight>>(itSupporterFound);

                        if (idSupporterListWithWeights.Count > 1)
                        {
                            var rejected = idSupporterListWithWeights.Dequeue();
                            rejected.TimesReject++;
                            var requestHistory = new RequestHistory()
                            {
                                IsITSupportAccept = false,
                                IsDelete = false,
                                Pre_It_SupporterId = rejected.ITSupporterId,
                                RequestId = requestId,
                                CreateDate = DateTime.UtcNow.AddHours(7)
                            };
                            requestHistoryService.Add(requestHistory);

                            var idSupporterListWithWeightNext = idSupporterListWithWeights.FirstOrDefault();
                            Console.WriteLine($"REjecct --- {rejected.TimesReject}");
                            if (rejected.TimesReject < 3)
                            {
                                Console.WriteLine($"Ho tro vien {rejected.ITSupporterName} da tu choi {rejected.TimesReject} lan");
                                idSupporterListWithWeights.Enqueue(rejected);
                            }
                            else
                            {
                                Console.WriteLine($"Reject ho tro vien {rejected.ITSupporterName}");
                                var itSupporter = itSupporterService.GetAll().SingleOrDefault(p => p.ITSupporterId == rejected.ITSupporterId);
                                itSupporter.IsOnline = false;
                                itSupporterService.Update(itSupporter);

                                FirebaseService firebaseService = new FirebaseService();
                                firebaseService.SendNotificationFromFirebaseCloudForITSupporterOffline(rejected.ITSupporterId);
                                Console.WriteLine($"ho tro vien {rejected.ITSupporterName} da offline");
                            }
                            //memoryCacher.Add("ITSupporterListWithWeights", idSupporterListWithWeights, DateTimeOffset.UtcNow.AddHours(1));
                            redisTools.Save("ITSupporterListWithWeights", idSupporterListWithWeights);
                            if (idSupporterListWithWeightNext != null)
                            {
                                FirebaseService firebaseService = new FirebaseService();
                                firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(idSupporterListWithWeightNext.ITSupporterId, requestId);

                                int counter = 60;

                                while (counter > 0)
                                {
                                    Console.WriteLine($"Gui lai sau khi tu choi trong {counter} giây");
                                    counter--;
                                    Thread.Sleep(1000);
                                }
                                AcceptRequestFromITSupporter(idSupporterListWithWeightNext.ITSupporterId, requestId, false);


                                return new ResponseObject<bool> { IsError = false, WarningMessage = "Nhận duoc thong tin ho tro vien", ObjReturn = true };
                            }
                            else
                            {
                                //memoryCacher.Delete("ITSupporterListWithWeights");
                                redisTools.Clear("ITSupporterListWithWeights");
                                var agencyService = new AgencyService();
                                var result = FindITSupporterByRequestId(requestId);
                                if (!result.IsError && result.ObjReturn > 0)
                                {
                                    FirebaseService firebaseService = new FirebaseService();
                                    firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(result.ObjReturn, requestId);

                                    int counter = 60;

                                    while (counter > 0)
                                    {
                                        Console.WriteLine($"gui lai yeu cau trong {counter} giay");
                                        counter--;
                                        Thread.Sleep(1000);
                                    }
                                    AcceptRequestFromITSupporter(result.ObjReturn, requestId, false);
                                }
                            }
                        }
                        else
                        {
                            var rejected = idSupporterListWithWeights.Dequeue();
                            rejected.TimesReject++;
                            var requestHistory = new RequestHistory()
                            {
                                IsITSupportAccept = false,
                                IsDelete = false,
                                Pre_It_SupporterId = rejected.ITSupporterId,
                                RequestId = requestId,
                                CreateDate = DateTime.UtcNow.AddHours(7)
                            };
                            requestHistoryService.Add(requestHistory);

                            var idSupporterListWithWeightNext = idSupporterListWithWeights.FirstOrDefault();
                            Console.WriteLine($"REjecct --- {rejected.TimesReject}");
                            if (rejected.TimesReject < 3)
                            {
                                Console.WriteLine($"Ho tro vien {rejected.ITSupporterName} da tu choi {rejected.TimesReject} lan!");
                                idSupporterListWithWeights.Enqueue(rejected);
                            }
                            else
                            {
                                Console.WriteLine($"Chuyen trang thai ho tro vien {rejected.ITSupporterName} thanh offline!");
                                var itSupporter = itSupporterService.GetAll().SingleOrDefault(p => p.ITSupporterId == rejected.ITSupporterId);
                                itSupporter.IsOnline = false;
                                itSupporterService.Update(itSupporter);

                                FirebaseService firebaseService2 = new FirebaseService();
                                firebaseService2.SendNotificationFromFirebaseCloudForITSupporterOffline(rejected.ITSupporterId);
                                Console.WriteLine($"ho tro vien {rejected.ITSupporterName} da offline");
                            }
                            //memoryCacher.Add("ITSupporterListWithWeights", idSupporterListWithWeights, DateTimeOffset.UtcNow.AddHours(1));
                            redisTools.Save("ITSupporterListWithWeights", idSupporterListWithWeights);
                            FirebaseService firebaseService = new FirebaseService();
                            idSupporterListWithWeightNext = idSupporterListWithWeights.FirstOrDefault();
                            firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(idSupporterListWithWeightNext.ITSupporterId, requestId);

                            int counter = 60;

                            while (counter > 0)
                            {
                                Console.WriteLine($"Gui lại sau khi tu choi trong {counter} giây");
                                counter--;
                                Thread.Sleep(1000);
                            }
                            AcceptRequestFromITSupporter(idSupporterListWithWeightNext.ITSupporterId, requestId, false);
                        }

                    }
                }


                return new ResponseObject<bool> { IsError = true, WarningMessage = "Nhận thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Nhận thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public enum RequestStatusEnum
        {
            [Display(Name = "Chờ Xử lý")]
            Pending = 1,
            [Display(Name = "Đang xử lý")]
            Processing = 2,
            [Display(Name = "Hoàn thành")]
            Done = 3,
            [Display(Name = "Hủy bỏ")]
            Cancel = 4
        }

        public enum TicketStatusEnum
        {
            [Display(Name = "Đang chờ xử lý")]
            Await = 1,
            [Display(Name = "Đang xử lý")]
            In_Process = 2,
            [Display(Name = "Hoàn thành")]
            Done = 3,
            [Display(Name = "Hủy bỏ")]
            Cancel = 4
        }
    }
}

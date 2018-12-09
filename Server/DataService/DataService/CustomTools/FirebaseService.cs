using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Models.Entities.Services;
using DataService.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataService.CustomTools
{
    public class FirebaseService
    {
        public const string fcmKey = "AIzaSyCKceBvEIUixxsE77aNJot5oRYsSCZs7Zg";
        public const string webAddr = "https://fcm.googleapis.com/fcm/send";

        public String SendNotificationFromFirebaseCloudForITSupporterReceive(int itSupporterId, int requestId)
        {
            var result = "-1";            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + fcmKey);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var data = RenderDataForITSupporterReceive(itSupporterId, requestId);
                var noti = new Notification()
                {
                    title = $"Chi nhánh {data.AgencyName} cần sửa {data.RequestName}",
                    text = $"Số lượng: {data.NumberOfTicket}",
                    sound = "default"
                };

                string strNJson = ConverMessageJsonForITSupporterReceiveFirebaseViewModel(data, noti);
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public String SendNotificationFromFirebaseCloudForITSupporterOffline(int itSupporterId)
        {
            var result = "-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + fcmKey);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var data = RenderDataForITSupporterOffline(itSupporterId);
                var noti = new Notification()
                {
                    title = $"Thông báo offline",
                    text = $"Bạn đã hủy 3 lần! Hệ thống tự động offline cho bạn",
                    sound = "default"
                };

                string strNJson = ConverMessageJsonForITSupporterOfflineFirebaseViewModel(data, noti);
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public String SendNotificationFromFirebaseCloudForApproveRequestDone(int itSupporterId, string requestName, string agencyName, string doneAt)
        {
            var result = "-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + fcmKey);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {                
                var noti = new Notification()
                {
                    title = $"Sự cố {requestName} đã xác nhận hoàn thành ",
                    text = $"Xác nhận lúc: {doneAt} - Thuộc cửa hàng: {agencyName}",
                    sound = "default"
                };

                string strNJson = ConverMessageJsonForITSupporterApproveRequestDone(itSupporterId, noti);
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public string ConverMessageJsonForITSupporterReceiveFirebaseViewModel(ITSupporterReceiveFirebaseViewModel data, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", $"/topics/{data.ITSupporterId}");
            androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public string ConverMessageJsonForITSupporterApproveRequestDone(int itSupporterId, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", $"/topics/{itSupporterId}");
            //androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public string ConverMessageJsonForITSupporterOfflineFirebaseViewModel(ITSupporterOfflineFirebaseViewModel data, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", $"/topics/{data.ITSupporterId}");
            androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public ITSupporterReceiveFirebaseViewModel RenderDataForITSupporterReceive(int itSupporterId, int requestId)
        {
            var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
            var itSupporterService = new ITSupporterService();
            var request = requestRepo.GetActive().SingleOrDefault(p => p.RequestId == requestId);
            var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(p => p.ITSupporterId == itSupporterId);
            var itSupporterReceiveFirebaseViewModel = new ITSupporterReceiveFirebaseViewModel()
            {
                AgencyName = request.Agency.AgencyName,
                AgencyAddress = request.Agency.Address,
                RequestId = request.RequestId,
                RequestName = request.RequestName,
                NumberOfTicket = request.Tickets.Count(),
                ITSupporterId = itSupporter.ITSupporterId,
                ITSupporterName = itSupporter.ITSupporterName,
                AccountId = itSupporter.AccountId,
                Username = itSupporter.Account.Username
            };
            StringBuilder ticketInfo = new StringBuilder();
            foreach (var item in request.Tickets)
            {
                ticketInfo.AppendLine($"Thiết bị: {item.Device.DeviceType.DeviceTypeName} - {item.Device.DeviceName}");
            }
            itSupporterReceiveFirebaseViewModel.TicketsInfo = ticketInfo.ToString();
            itSupporterReceiveFirebaseViewModel.DateSend = DateTime.UtcNow.AddHours(7).ToString("HH:mm:ss");
            return itSupporterReceiveFirebaseViewModel;
        }

        public ITSupporterOfflineFirebaseViewModel RenderDataForITSupporterOffline(int itSupporterId)
        {
            var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(p => p.ITSupporterId == itSupporterId);


            var itSupporterOfflineFirebaseViewModel = new ITSupporterOfflineFirebaseViewModel()
            {
                ITSupporterName = itSupporter.ITSupporterName,
                ITSupporterId = itSupporter.ITSupporterId,
                isOnline =  itSupporter.IsOnline ?? false,
                AccountId = itSupporter.AccountId,
                Username = itSupporter.Account.Username
            };
            

            return itSupporterOfflineFirebaseViewModel;
        }
    }

    public class Notification
    {
        public string title { get; set; }
        public string text { get; set; }
        public string sound { get; set; }

        //public Notification(string title, string text, string sound = null)
        //{
        //    Title = title;
        //    Text = text;
        //    Sound = sound ?? "default";
        //}
    }

    public class ITSupporterReceiveFirebaseViewModel
    {      
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string AgencyName { get; set; }
        public string AgencyAddress { get; set; }
        public int NumberOfTicket { get; set; }
        public string TicketsInfo { get; set; }
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string DateSend { get; set; }
    }

    public class ITSupporterOfflineFirebaseViewModel
    {        
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public bool isOnline { get; set; }
    }
}

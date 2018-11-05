﻿using DataService.APIViewModels;
using DataService.CustomTools;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DataService.Models.Entities.Services
{
    public partial interface IRequestService
    {
        ResponseObject<List<RequestAPIViewModel>> GetAllRequest();

        ResponseObject<RequestAPIViewModel> GetTicketByRequestId(int requestId);

        ResponseObject<List<RequestAPIViewModel>> GetRequestWithStatus(int status);

        ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAllRequestByAgencyIDAndStatus(int acency_id, int status);

        ResponseObject<bool> CreateFeedbackForRequest(int RequestId, string feedbackContent);

        ResponseObject<bool> UpdateStatusRequest(int request_id, int status);

        ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> ViewRequestDetail(int requestId);

        ResponseObject<bool> AcceptRequestFromITSupporter(int itSupporterId, int requestId, bool isAccept);

        ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> GetRequestByRequestIdAndITSupporterId(int requestId, int itSupporterId);

    }

    public partial class RequestService
    {
        public ResponseObject<List<RequestAPIViewModel>> GetAllRequest()
        {
            try
            {
                List<RequestAPIViewModel> rsList = new List<RequestAPIViewModel>();
                var RequestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var requests = RequestRepo.GetActive().ToList();
                if (requests.Count <= 0)
                {
                    return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, WarningMessage = "Hiển thị yêu cầu thất bại" };
                }
                foreach (var item in requests)
                {
                    var timeAgo = TimeAgo(item.CreateDate);
                    foreach (int enumm in Enum.GetValues(typeof(RequestStatusEnum)))
                    {
                        if (item.RequestStatus == enumm)
                        {
                            var a = new RequestAPIViewModel()
                            {
                                RequestId = item.RequestId,
                                RequestName = item.RequestName,
                                CreateDate = timeAgo,
                                AgencyName = item.Agency.AgencyName,
                                StatusName = Enum.GetNames(typeof(RequestStatusEnum))[enumm - 1],
                            };
                            rsList.Add(a);
                        }
                    }
                }
                return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, SuccessMessage = "Hiển thị yêu cầu thành công", ObjReturn = rsList };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, WarningMessage = "Hiển thị yêu cầu thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }


        public ResponseObject<List<RequestAPIViewModel>> GetRequestWithStatus(int status)
        {
            try
            {
                List<RequestAPIViewModel> rsList = new List<RequestAPIViewModel>();
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var requests = requestRepo.GetActive(x => x.RequestStatus == status).ToList();
                if (requests.Count <= 0)
                {
                    return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, WarningMessage = "Không lấy được" };
                }
                foreach (var item in requests)
                {
                    var timeAgo = TimeAgo(item.CreateDate);
                    var a = new RequestAPIViewModel()
                    {
                        RequestId = item.RequestId,
                        RequestName = item.RequestName,
                        CreateDate = timeAgo,
                        RequestStatus = item.RequestStatus,
                    };
                    rsList.Add(a);
                }

                return new ResponseObject<List<RequestAPIViewModel>> { IsError = false, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, WarningMessage = "Không lấy được", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<RequestAPIViewModel> GetTicketByRequestId(int requestId)
        {
            try
            {
                RequestAPIViewModel rsList = new RequestAPIViewModel();
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var ServiceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
                var ITRepo = DependencyUtils.Resolve<IITSupporterRepository>();

                var request = requestRepo.GetActive().FirstOrDefault(x => x.RequestId == requestId);
                var service = ServiceItemRepo.GetActive().ToList();
                var it = ITRepo.GetActive().ToList();
                var tickets = ticketRepo.GetActive().ToList();

                var listIssue = new List<String>();
                var listIT = new List<String>();
                for (int i = 0; i < tickets.Count; i++)
                {
                    var serviceId = tickets[i].Request.ServiceItemId;
                    var IssueName = service.Find((x => x.ServiceItemId == serviceId)).ServiceItemName;
                    var ITId = tickets[i].CurrentITSupporter_Id;
                    var ITName = it.Find((x => x.ITSupporterId == ITId)).ITSupporterName;
                    listIssue.Add(IssueName);
                    listIT.Add(ITName);
                }


                var timeAgo = TimeAgo(request.CreateDate);
                var requestAPIViewModel = new RequestAPIViewModel()
                {
                    RequestId = request.RequestId,
                    RequestName = request.RequestName,
                    CreateDate = timeAgo,
                    AgencyName = request.Agency.AgencyName,
                    IssueName = listIssue,
                    ITName = listIT,
                    RequestStatus = request.RequestStatus,

                };

                return new ResponseObject<RequestAPIViewModel> { IsError = false, SuccessMessage = "Lấy thành công", ObjReturn = requestAPIViewModel };
            }
            catch (Exception e)
            {

                return new ResponseObject<RequestAPIViewModel> { IsError = false, WarningMessage = "Lấy thành công", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        private string TimeAgo(DateTime dateTime)
        {
            try
            {
                string result = string.Empty;
                var timeSpan = DateTime.UtcNow.AddHours(7).Subtract(dateTime);

                if (timeSpan <= TimeSpan.FromSeconds(60))
                {
                    result = string.Format("{0} seconds ago", timeSpan.Seconds);
                }
                else if (timeSpan <= TimeSpan.FromMinutes(60))
                {
                    result = timeSpan.Minutes > 1 ?
                        String.Format("about {0} minutes ago", timeSpan.Minutes) :
                        "about a minute ago";
                }
                else if (timeSpan <= TimeSpan.FromHours(24))
                {
                    result = timeSpan.Hours > 1 ?
                        String.Format("about {0} hours ago", timeSpan.Hours) :
                        "about an hour ago";
                }
                else if (timeSpan <= TimeSpan.FromDays(30))
                {
                    result = timeSpan.Days > 1 ?
                        String.Format("about {0} days ago", timeSpan.Days) :
                        "yesterday";
                }
                else if (timeSpan <= TimeSpan.FromDays(365))
                {
                    result = timeSpan.Days > 30 ?
                        String.Format("about {0} months ago", timeSpan.Days / 30) :
                        "about a month ago";
                }
                else
                {
                    result = timeSpan.Days > 365 ?
                        String.Format("about {0} years ago", timeSpan.Days / 365) :
                        "about a year ago";
                }

                return result;
            }
            catch (Exception e)
            {

                return e.ToString();
            }

        }

        public ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAllRequestByAgencyIDAndStatus(int acency_id, int status)
        {
            try
            {
                List<RequestAllTicketWithStatusAgencyAPIViewModel> requestList = new List<RequestAllTicketWithStatusAgencyAPIViewModel>();

                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var requests = requestRepo.GetActive(x => x.RequestStatus == status && x.AgencyId == acency_id).ToList();

                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();



                if (requests.Count <= 0)

                {
                    return new ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> { IsError = true, WarningMessage = "Thất bại", ObjReturn = requestList };
                }
                foreach (var item in requests)
                {
                    List<TicketForRequestAllTicketStatusAPIViewModel> ticketList = new List<TicketForRequestAllTicketStatusAPIViewModel>();
                    var tickets = ticketRepo.GetActive(p => p.RequestId == item.RequestId).ToList();
                    foreach (var ticketItem in tickets)
                    {
                        var ticket = new TicketForRequestAllTicketStatusAPIViewModel();

                        ticket.TicketId = ticketItem.TicketId;
                        ticket.ITSupporterId = ticketItem.CurrentITSupporter_Id != null ? ticketItem.CurrentITSupporter_Id.Value : 0;
                        ticket.DeviceId = ticketItem.DeviceId;
                        ticket.DeviceName = ticketItem.Device.DeviceName;
                        ticket.StartTime = ticketItem.StartTime != null ? ticketItem.StartTime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                        ticket.EndTime = ticketItem.Endtime != null ? ticketItem.Endtime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                        ticket.Current_TicketStatus = ticketItem.Current_TicketStatus != null ? ticketItem.Current_TicketStatus.Value : 0;
                        ticket.Desciption = ticketItem.Desciption;
                        ticket.CreateDate = ticketItem.CreateDate != null ? ticketItem.CreateDate.ToString("dd/MM/yyyy HH:mm") : string.Empty;

                        ticketList.Add(ticket);
                    }
                    var timeAgo = TimeAgo(item.CreateDate);
                    var request = new RequestAllTicketWithStatusAgencyAPIViewModel()

                    {
                        RequestId = item.RequestId,
                        RequestName = item.RequestName,
                        CreateDate = timeAgo,
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy HH:mm") : string.Empty,
                        AgencyName = item.Agency.AgencyName,
                        RequestStatus = item.RequestStatus,
                        RequestEstimationTime = item.CreateDate.AddHours(item.Estimation ?? 0).ToString("dd/MM/yyyy HH:mm"),
                        NumberOfTicketDone = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.Done),
                        NumberTicketInProcessing = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.In_Process),
                        NumberOfTicket = ticketList.Count,
                        Tickets = ticketList
                    };
                    requestList.Add(request);
                }

                return new ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> { IsError = false, SuccessMessage = "Thành công", ObjReturn = requestList };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> { IsError = true, WarningMessage = "Thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> CreateFeedbackForRequest(int requestId, string feedbackContent)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();

                var request = requestRepo.GetActive().SingleOrDefault(p => p.RequestId == requestId);

                if (request != null)
                {
                    request.Feedback = feedbackContent;
                    requestRepo.Edit(request);
                    requestRepo.Save();

                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Đánh giá thành công", ObjReturn = true };
                }
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Đánh giá thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Đánh giá thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> UpdateStatusRequest(int request_id, int status)
        {
            try
            {
                var requestHistoryRepo = DependencyUtils.Resolve<IRequestHistoryRepository>();
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var request = requestRepo.GetActive().SingleOrDefault(a => a.RequestId == request_id);
                if (request != null)
                {
                    if (status == (int)RequestStatusEnum.Done)
                    {
                        var requestHistory = new RequestHistoryAPIViewModel();
                        requestHistory.RequestId = request_id;

                        request.RequestStatus = status;
                        request.ITSupporter.IsBusy = false;
                        request.EndTime = DateTime.UtcNow.AddHours(7);
                        request.UpdateDate = DateTime.UtcNow.AddHours(7);
                        foreach (var item in request.Tickets)
                        {
                            item.Current_TicketStatus = (int)TicketStatusEnum.Done;
                            item.Endtime = DateTime.UtcNow.AddHours(7);
                        }
                    }
                    else
                    {
                        request.RequestStatus = status;
                        request.UpdateDate = DateTime.UtcNow.AddHours(7);

                    }
                    requestRepo.Edit(request);
                    requestRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Cập nhật trạng thái thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật trạng thái thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Hủy yêu cầu thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> ViewRequestDetail(int requestId)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var request = requestRepo.GetActive().FirstOrDefault(x => x.RequestId == requestId);
                if (request != null)
                {
                    List<TicketForRequestAllTicketStatusAPIViewModel> ticketList = new List<TicketForRequestAllTicketStatusAPIViewModel>();
                    var tickets = ticketRepo.GetActive(p => p.RequestId == requestId).ToList();
                    foreach (var ticketItem in tickets)
                    {
                        var ticket = new TicketForRequestAllTicketStatusAPIViewModel();

                        ticket.TicketId = ticketItem.TicketId;
                        ticket.ITSupporterId = ticketItem.CurrentITSupporter_Id != null ? ticketItem.CurrentITSupporter_Id.Value : 0;
                        ticket.DeviceId = ticketItem.DeviceId;
                        ticket.DeviceName = ticketItem.Device.DeviceName;
                        ticket.StartTime = ticketItem.StartTime != null ? ticketItem.StartTime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                        ticket.EndTime = ticketItem.Endtime != null ? ticketItem.Endtime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                        ticket.Current_TicketStatus = ticketItem.Current_TicketStatus != null ? ticketItem.Current_TicketStatus.Value : 0;
                        ticket.Desciption = ticketItem.Desciption;
                        ticket.CreateDate = ticketItem.CreateDate != null ? ticketItem.CreateDate.ToString("dd/MM/yyyy HH:mm") : string.Empty;

                        ticketList.Add(ticket);
                    }
                    var timeAgo = TimeAgo(request.CreateDate);
                    var requestMd = new RequestAllTicketWithStatusAgencyAPIViewModel()

                    {
                        RequestId = request.RequestId,
                        RequestName = request.RequestName,
                        CreateDate = timeAgo,
                        UpdateDate = request.UpdateDate != null ? request.UpdateDate.Value.ToString("MM/dd/yyyy HH:mm") : string.Empty,
                        AgencyName = request.Agency.AgencyName,
                        RequestStatus = request.RequestStatus,
                        ITSupporterName = request.ITSupporter != null ? request.ITSupporter.ITSupporterName : string.Empty,
                        RequestEstimationTime = request.CreateDate.AddHours(request.Estimation ?? 0).ToString("dd/MM/yyyy HH:mm"),
                        NumberOfTicketDone = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.Done),
                        NumberTicketInProcessing = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.In_Process),
                        NumberOfTicket = ticketList.Count,
                        Tickets = ticketList
                    };
                    return new ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> { IsError = false, ObjReturn = requestMd, SuccessMessage = "Tìm thấy thông tin yêu cầu!" };
                }
                return new ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy thông tin yêu cầu!" };
            }
            catch (Exception e)
            {

                return new ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> { IsError = false, WarningMessage = "Lấy thất bại!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> AcceptRequestFromITSupporter(int itSupporterId, int requestId, bool isAccept)
        {
            //MemoryCacher memoryCacher = new MemoryCacher();
            RedisTools redis = new RedisTools();
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                if (isAccept)
                {
                    var request = requestRepo.GetActive().SingleOrDefault(p => p.RequestId == requestId);
                    var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(p => p.ITSupporterId == itSupporterId);

                    if (request != null && itSupporter != null)
                    {
                        request.RequestStatus = (int)RequestStatusEnum.Processing;
                        request.CurrentITSupporter_Id = itSupporter.ITSupporterId;
                        request.StartTime = DateTime.UtcNow.AddHours(7);
                        requestRepo.Edit(request);

                        itSupporterRepo.Edit(itSupporter);
                        itSupporter.IsBusy = true;

                        var ticketsOfRequest = ticketRepo.GetActive(p => p.RequestId == requestId).ToList();
                        foreach (var ticket in ticketsOfRequest)
                        {
                            ticket.Current_TicketStatus = (int)TicketStatusEnum.In_Process;
                            ticket.CurrentITSupporter_Id = itSupporter.ITSupporterId;
                            ticket.StartTime = DateTime.UtcNow.AddHours(7);
                            ticket.UpdateDate = DateTime.UtcNow;
                            ticketRepo.Edit(ticket);
                        }
                        ticketRepo.Save();
                        requestRepo.Save();
                        itSupporterRepo.Save();
                        //memoryCacher.Delete("ITSupporterListWithWeights");
                        redis.Clear("ITSupporterListWithWeights");
                        return new ResponseObject<bool> { IsError = false, SuccessMessage = "Nhận thành công", ObjReturn = true };
                    }
                }
                else
                {

                    var itsupporter = itSupporterRepo.GetActive().SingleOrDefault(i => i.ITSupporterId == itSupporterId);
                    var requestHistory = new RequestHistoryAPIViewModel();
                    requestHistory.RequestId = requestId;
                    requestHistory.PreStatus = (int)RequestStatusEnum.Processing;
                    requestHistory.PreSupporter_Name = itsupporter.ITSupporterName;

                    //var its = memoryCacher.GetValue("ITSupporterListWithWeights");
                    var itSupporterFound = redis.Get("ITSupporterListWithWeights");
                    List<RenderITSupporterListWithWeight> idSupporterListWithWeights;
                    if (itSupporterFound != null)
                    {
                        idSupporterListWithWeights = (List<RenderITSupporterListWithWeight>)itSupporterFound;
                        if (idSupporterListWithWeights.Count > 0)
                        {
                            idSupporterListWithWeights.RemoveAt(0);
                            var idSupporterListWithWeightNext = idSupporterListWithWeights.FirstOrDefault();
                            //memoryCacher.Add("ITSupporterListWithWeights", idSupporterListWithWeights, DateTimeOffset.UtcNow.AddHours(1));
                            redis.Save("ITSupporterListWithWeights", idSupporterListWithWeights);
                            if (idSupporterListWithWeightNext != null)
                            {
                                FirebaseService firebaseService = new FirebaseService();
                                firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(idSupporterListWithWeightNext.ITSupporterId, requestId);

                                int counter = 30;

                                while (counter > 0)
                                {
                                    counter--;
                                    Thread.Sleep(1000);
                                }
                                var a = this.AcceptRequestFromITSupporter(idSupporterListWithWeightNext.ITSupporterId, requestId, false);


                                return new ResponseObject<bool> { IsError = false, WarningMessage = "Nhận oki", ObjReturn = true };
                            }
                            else
                            {
                                redis.Clear("ITSupporterListWithWeights");
                                var agencyService = new AgencyService();
                                var result = agencyService.FindITSupporterByRequestId(requestId);
                                if (!result.IsError && result.ObjReturn > 0)
                                {
                                    FirebaseService firebaseService = new FirebaseService();
                                    firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(result.ObjReturn, requestId);

                                    int counter = 30;

                                    while (counter > 0)
                                    {
                                        counter--;
                                        Thread.Sleep(1000);
                                    }
                                    var a = this.AcceptRequestFromITSupporter(result.ObjReturn, requestId, false);
                                }
                            }
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

        public ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> GetRequestByRequestIdAndITSupporterId(int requestId, int itSupporterId)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var request = requestRepo.GetActive(x => x.RequestId == requestId
                && x.CurrentITSupporter_Id == itSupporterId
                && x.RequestStatus != (int)RequestStatusEnum.Done 
                && x.RequestStatus != (int)RequestStatusEnum.Cancel).SingleOrDefault();

                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                               
                if (request == null)
                {
                    return new ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> { IsError = true, WarningMessage = "Thất bại", ObjReturn = null };
                }

                List<TicketForRequestAllTicketStatusAPIViewModel> ticketList = new List<TicketForRequestAllTicketStatusAPIViewModel>();
                var tickets = ticketRepo.GetActive(p => p.RequestId == requestId).ToList();
                foreach (var ticketItem in tickets)
                {
                    var ticket = new TicketForRequestAllTicketStatusAPIViewModel();

                    ticket.TicketId = ticketItem.TicketId;
                    ticket.ITSupporterId = ticketItem.CurrentITSupporter_Id != null ? ticketItem.CurrentITSupporter_Id.Value : 0;
                    ticket.DeviceId = ticketItem.DeviceId;
                    ticket.DeviceName = ticketItem.Device.DeviceName;
                    ticket.StartTime = ticketItem.StartTime != null ? ticketItem.StartTime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                    ticket.EndTime = ticketItem.Endtime != null ? ticketItem.Endtime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                    ticket.Current_TicketStatus = ticketItem.Current_TicketStatus != null ? ticketItem.Current_TicketStatus.Value : 0;
                    ticket.Desciption = ticketItem.Desciption;
                    ticket.CreateDate = ticketItem.CreateDate != null ? ticketItem.CreateDate.ToString("dd/MM/yyyy HH:mm") : string.Empty;

                    ticketList.Add(ticket);
                }
                var timeAgo = TimeAgo(request.CreateDate);
                var requestViewModel = new RequestAllTicketWithStatusAgencyAPIViewModel()
                {
                    RequestId = request.RequestId,
                    RequestName = request.RequestName,
                    CreateDate = timeAgo,
                    UpdateDate = request.UpdateDate != null ? request.UpdateDate.Value.ToString("MM/dd/yyyy HH:mm") : string.Empty,
                    AgencyName = request.Agency.AgencyName,
                    RequestStatus = request.RequestStatus,
                    RequestEstimationTime = request.CreateDate.AddHours(request.Estimation ?? 0).ToString("dd/MM/yyyy HH:mm"),
                    NumberOfTicketDone = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.Done),
                    NumberTicketInProcessing = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.In_Process),
                    NumberOfTicket = ticketList.Count,
                    Tickets = ticketList
                };


                return new ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> { IsError = false, SuccessMessage = "Thành công", ObjReturn = requestViewModel };
            }
            catch (Exception e)
            {
                return new ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> { IsError = true, WarningMessage = "Thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

    }
}

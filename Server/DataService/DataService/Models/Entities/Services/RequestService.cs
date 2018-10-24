using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IRequestService
    {
        ResponseObject<List<RequestAPIViewModel>> GetAllRequest();

        ResponseObject<RequestAPIViewModel> GetTicketByRequestId(int requestId);

        ResponseObject<List<RequestAPIViewModel>> GetRequestWithStatus(int status);

        ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAllRequestByAgencyIDAndStatus(int acency_id, int status);

        ResponseObject<bool> CreateFeedbackForRequest(int RequestId, string feedbackContent);

        ResponseObject<bool> CancelRequest(RequestCancelAPIViewModel model);

        ResponseObject<RequestDetailAPIViewModel> ViewRequestDetail(int requestId);

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
                if (requests.Count < 0)
                {
                    return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, WarningMessage = "Hiển thị yêu cầu thất bại" };
                }
                foreach (var item in requests)
                {
                    var timeAgo = TimeAgo(item.CreateDate.Value);
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
                if (requests.Count < 0)
                {
                    return new ResponseObject<List<RequestAPIViewModel>> { IsError = true, WarningMessage = "Không lấy được" };
                }
                foreach (var item in requests)
                {
                    var timeAgo = TimeAgo(item.CreateDate.Value);
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


                var timeAgo = TimeAgo(request.CreateDate.Value);
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
                var timeSpan = DateTime.Now.Subtract(dateTime);

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
                List<TicketForRequestAllTicketStatusAPIViewModel> ticketList = new List<TicketForRequestAllTicketStatusAPIViewModel>();
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var requests = requestRepo.GetActive(x => x.RequestStatus == status && x.AgencyId == acency_id).ToList();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();

                if (requests.Count < 0)
                {
                    return new ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> { IsError = true, WarningMessage = "Thất bại", ObjReturn = requestList };
                }
                foreach (var item in requests)
                {
                    var tickets = ticketRepo.GetActive(p => p.RequestId == item.RequestId).ToList();
                    foreach (var ticketItem in tickets)
                    {
                        var ticket = new TicketForRequestAllTicketStatusAPIViewModel()
                        {
                            TicketId = ticketItem.TicketId,
                            ITSupporterId = ticketItem.CurrentITSupporter_Id,
                            DeviceId = ticketItem.DeviceId,
                            DeviceName = ticketItem.Device.DeviceName,
                            StartTime = ticketItem.StartTime != null ? ticketItem.StartTime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty,
                            EndTime = ticketItem.Endtime != null ? ticketItem.Endtime.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty,
                            ITSupporterName = ticketItem.ITSupporter.ITSupporterName,
                            TicketEstimationTime = ticketItem.StartTime != null ? ticketItem.StartTime.Value.AddHours(ticketItem.Estimation ?? 0).ToString("dd/MM/yyyy HH:mm") : string.Empty,
                            Current_TicketStatus = ticketItem.Current_TicketStatus != null ? ticketItem.Current_TicketStatus.Value : 0,
                            Desciption = ticketItem.Desciption,
                            Estimation = ticketItem.Estimation ?? 0,
                            CreateDate = ticketItem.CreateDate != null ? ticketItem.CreateDate.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty
                        };
                        ticketList.Add(ticket);
                    }
                    var timeAgo = TimeAgo(item.CreateDate.Value);
                    var request = new RequestAllTicketWithStatusAgencyAPIViewModel()
                    {
                        RequestId = item.RequestId,
                        RequestName = item.RequestName,
                        CreateDate = timeAgo,
                        AgencyName = item.Agency.AgencyName,
                        RequestStatus = item.RequestStatus,
                        RequestEstimationTime = item.CreateDate.Value.AddHours(ticketList.Sum(p => p.Estimation)).ToString("dd/MM/yyyy HH:mm"),
                        NumberOfTicketDone = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.Done),
                        NumberTicketInProcessing = ticketList.Count(p => p.Current_TicketStatus == (int)TicketStatusEnum.In_Process),
                        NumberOfTicket = ticketList.Count,
                        TicketList = ticketList
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

                var request = requestRepo.Get(requestId);

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

        public ResponseObject<bool> CancelRequest(RequestCancelAPIViewModel model)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var cancelTicket = requestRepo.GetActive().SingleOrDefault(a => a.RequestId == model.RequestId);
                if (cancelTicket.RequestId == model.RequestId)
                {

                    cancelTicket.RequestId = model.RequestId;
                    cancelTicket.RequestStatus = model.CurrentStatus;

                    requestRepo.Edit(cancelTicket);
                    requestRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Hủy yêu cầu thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Hủy yêu cầu thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Hủy yêu cầu thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<RequestDetailAPIViewModel> ViewRequestDetail(int requestId)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var request = requestRepo.GetActive().FirstOrDefault(x => x.RequestId == requestId);
                if (request != null)
                {
                    var RequestDetailAPIViewModel = new RequestDetailAPIViewModel
                    {
                        RequestId = request.RequestId,
                        AgencyId = request.AgencyId,
                        ServiceItemId = request.ServiceItemId,
                        RequestCategoryId = request.RequestCategoryId,
                        RequestStatus = request.RequestStatus,
                        RequestName = request.RequestName,
                        StartDate = request.StartDate != null ? request.StartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        EndDate = request.EndDate != null ? request.EndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Feedback = request.Feedback,
                        CreateDate = request.CreateDate != null ? request.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateDate = request.UpdateDate != null ? request.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    };
                    return new ResponseObject<RequestDetailAPIViewModel> { IsError = false, ObjReturn = RequestDetailAPIViewModel, SuccessMessage = "Tìm thấy thông tin yêu cầu!" };
                }
                return new ResponseObject<RequestDetailAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy thông tin yêu cầu!" };
            }
            catch (Exception e)
            {

                return new ResponseObject<RequestDetailAPIViewModel> { IsError = false, WarningMessage = "Lấy thất bại!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
    }
}

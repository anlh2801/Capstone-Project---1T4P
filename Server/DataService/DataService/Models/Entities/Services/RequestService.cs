using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
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
        List<RequestAPIViewModel> GetAllRequest();

        List<RequestAPIViewModel> GetTicketByRequestId(int requestId);

        List<RequestAPIViewModel> GetRequestWithStatus(int status);

        List<RequestAPIViewModel> GetAllRequestByAgencyIDAndStatus(int acency_id, int status);

        bool CreateFeedbackForRequest(int RequestId, string feedbackContent);

        bool CancelRequest(RequestCancelAPIViewModel model);

    }

    public partial class RequestService
    {
        public List<RequestAPIViewModel> GetAllRequest()
        {
            List<RequestAPIViewModel> rsList = new List<RequestAPIViewModel>();
            var RequestRepo = DependencyUtils.Resolve<IRequestRepository>();
            var requests = RequestRepo.GetActive().ToList();
            foreach (var item in requests)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new RequestAPIViewModel()
                {
                    RequestId = item.RequestId,
                    RequestName = item.RequestName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }


        public List<RequestAPIViewModel> GetRequestWithStatus(int status)
        {
            List<RequestAPIViewModel> rsList = new List<RequestAPIViewModel>();
            var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
            var requests = requestRepo.GetActive().ToList();
            var listStatus = requests.FindAll(x => x.RequestStatus == status);
            foreach (var item in listStatus)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new RequestAPIViewModel()
                {
                    RequestId = item.RequestId,
                    RequestName = item.RequestName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }

        public List<RequestAPIViewModel> GetTicketByRequestId(int requestId)
        {
            List<RequestAPIViewModel> rsList = new List<RequestAPIViewModel>();
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
                var serviceId = tickets[i].ServiceItemId;
                var IssueName = service.Find((x => x.ServiceItemId == serviceId)).IssueName;
                var ITId = tickets[i].CurrentITSupporter_Id;
                var ITName = it.Find((x => x.ITSupporterId == ITId)).ITSupporterName;
                listIssue.Add(IssueName);
                listIT.Add(ITName);
            }
            

            var timeAgo = TimeAgo(request.CreateDate.Value);
            var a = new RequestAPIViewModel()
            {
                RequestId = request.RequestId,
                RequestName = request.RequestName,
                CreateDate = timeAgo,
                AgencyName = request.Agency.AgencyName,
                //ITSupporterName = list.ITSupporter.ITSupporterName,
                //IssueName = IssueName.IssueName.ToString(),
                IssueName = listIssue,
                ITName = listIT,

            };
            rsList.Add(a);


            return rsList;
        }

        public static string TimeAgo(DateTime dateTime)
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

        public List<RequestAPIViewModel> GetAllRequestByAgencyIDAndStatus(int acency_id, int status)
        {
            List<RequestAPIViewModel> rsList = new List<RequestAPIViewModel>();
            var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
            var requests = requestRepo.GetActive().ToList();
            var listStatus = requests.FindAll(x => x.RequestStatus == status && x.AgencyId == acency_id);
            foreach (var item in listStatus)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new RequestAPIViewModel()
                {
                    RequestId = item.RequestId,
                    RequestName = item.RequestName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }

        public bool CreateFeedbackForRequest(int requestId, string feedbackContent)
        {
            var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                        
            var request = requestRepo.Get(requestId);

            if (request != null)
            {
                request.Feedback = feedbackContent;
                requestRepo.Edit(request);
                requestRepo.Save();

                return true;
            }
            return false;
        }

        public bool CancelRequest(RequestCancelAPIViewModel model)
        {
            var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
            var cancelTicket = requestRepo.GetActive().SingleOrDefault(a => a.RequestId == model.RequestId);
            if (cancelTicket.RequestId == model.RequestId)
            {

                cancelTicket.RequestId = model.RequestId;
                cancelTicket.RequestStatus = model.CurrentStatus;

                requestRepo.Edit(cancelTicket);
                requestRepo.Save();
                return true;
            }

            return false;
        }
    }
}

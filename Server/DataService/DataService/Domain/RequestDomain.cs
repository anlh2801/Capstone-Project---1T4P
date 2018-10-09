using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public  interface IRequestDomain
    {
        List<RequestAPIViewModel> GetAllRequest();

        RequestAPIViewModel GetTicketByRequestId(int RequestId);

        List<RequestAPIViewModel> GetRequestWithStatus(int status);

        List<RequestAPIViewModel> GetAllRequestByAgencyIDAndStatus(int acency_id, int status);

        bool CreateFeedbackForRequest(FeedbackAPIViewModel feedback);

        bool CancelRequest(RequestCancelAPIViewModel model);
    }

    public  class RequestDomain : BaseDomain, IRequestDomain
    {
        public List<RequestAPIViewModel> GetAllRequest()
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetAllRequest();
            
            return result;
        }

        public List<RequestAPIViewModel> GetRequestWithStatus(int status)
        {
            var requestService = this.Service<IRequestService>();
            
            var result = requestService.GetRequestWithStatus(status);

            return result;
        }

        public RequestAPIViewModel GetTicketByRequestId(int requestId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetTicketByRequestId(requestId);

            return result;
        }

        public List<RequestAPIViewModel> GetAllRequestByAgencyIDAndStatus(int acency_id, int status)
        {
            var requestService = this.Service<IRequestService>();
            
            var result = requestService.GetAllRequestByAgencyIDAndStatus(acency_id, status);

            return result;

        }

        public bool CreateFeedbackForRequest(FeedbackAPIViewModel feedback)
        {          
            var requestService = this.Service<IRequestService>();

            var rs = requestService.CreateFeedbackForRequest(feedback.TicketId, feedback.FeedbackContent);

            return rs;

        }

        public bool CancelRequest(RequestCancelAPIViewModel model)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.CancelRequest(model);

            return result;
        }

    }
}

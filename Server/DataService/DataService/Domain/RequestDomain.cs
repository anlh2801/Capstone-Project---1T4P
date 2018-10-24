using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
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
        ResponseObject<List<RequestAPIViewModel>> GetAllRequest();

        ResponseObject<RequestAPIViewModel> GetTicketByRequestId(int RequestId);

        ResponseObject<List<RequestAPIViewModel>> GetRequestWithStatus(int status);

        ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAllRequestByAgencyIDAndStatus(int acency_id, int status);

        ResponseObject<bool> CreateFeedbackForRequest(FeedbackAPIViewModel feedback);

        ResponseObject<bool> CancelRequest(int request_id, int status);

        ResponseObject<RequestDetailAPIViewModel> ViewRequestDetail(int requestId);
    }

    public  class RequestDomain : BaseDomain, IRequestDomain
    {
        public ResponseObject<List<RequestAPIViewModel>> GetAllRequest()
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetAllRequest();
            
            return result;
        }

        public ResponseObject<List<RequestAPIViewModel>> GetRequestWithStatus(int status)
        {
            var requestService = this.Service<IRequestService>();
            
            var result = requestService.GetRequestWithStatus(status);

            return result;
        }

        public ResponseObject<RequestAPIViewModel> GetTicketByRequestId(int requestId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetTicketByRequestId(requestId);

            return result;
        }

        public ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAllRequestByAgencyIDAndStatus(int acency_id, int status)
        {
            var requestService = this.Service<IRequestService>();
            
            var result = requestService.GetAllRequestByAgencyIDAndStatus(acency_id, status);

            return result;

        }

        public ResponseObject<bool> CreateFeedbackForRequest(FeedbackAPIViewModel feedback)
        {          
            var requestService = this.Service<IRequestService>();

            var rs = requestService.CreateFeedbackForRequest(feedback.TicketId, feedback.FeedbackContent);

            return rs;

        }

        public ResponseObject<bool> CancelRequest(int request_id, int status)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.CancelRequest(request_id, status);

            return result;
        }

        public ResponseObject<RequestDetailAPIViewModel> ViewRequestDetail(int requestId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.ViewRequestDetail(requestId);

            return result;
        }
    }
}

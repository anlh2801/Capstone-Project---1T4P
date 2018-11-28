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
        ResponseObject<List<RequestAPIViewModel>> GetAllRequest(int companyId, int serviceItemId, string start = null, string end = null);

        ResponseObject<RequestAPIViewModel> GetTicketByRequestId(int RequestId);

        ResponseObject<List<RequestAPIViewModel>> GetRequestWithStatus(int status);

        ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAllRequestByAgencyIDAndStatus(int acency_id, int status);

        ResponseObject<bool> CreateFeedbackForRequest(FeedbackAPIViewModel feedback);

        ResponseObject<bool> UpdateStatusRequest(int request_id, int status);

        ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> ViewRequestDetail(int requestId);

        ResponseObject<bool> AcceptRequestFromITSupporter(int itSupporterId, int requestId, bool isAccept, string check = null);

        ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> GetRequestByRequestIdAndITSupporterId(int itSupporterId);

        ResponseObject<List<StatusAPIViewModel>> GetRequestStatistic();

        ResponseObject<List<RequestGroupMonth>> GetAllRequestByAgencyIDAndStatus2(int acency_id, int status);

        ResponseObject<List<RequestAPIViewModel>> GetAllRequestForMonth(int month, int year);

        ResponseObject<bool> ApproveCancelRequest(int request_id, int status);

        ResponseObject<RequestAPIViewModel> GetRequestBytRequestId(int requestId);

        ResponseObject<int> SetPriority(int requestId, int priority);

        ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAgencyRequests(int acency_id);

        ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> GetRequestById(int requestId);

        ResponseObject<int> UpdateRequest(int requestId, int priority, int status);
    }

    public  class RequestDomain : BaseDomain, IRequestDomain
    {
        public ResponseObject<List<RequestAPIViewModel>> GetAllRequest(int companyId, int serviceItemId, string start = null, string end = null)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetAllRequest(companyId, serviceItemId, start, end);
            
            return result;
        }

        public ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> GetRequestById(int requestId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetRequestById(requestId);

            return result;
        }

        public ResponseObject<int> UpdateRequest(int requestId, int priority, int status)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.UpdateRequest(requestId, priority, status);

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

        public ResponseObject<List<RequestAllTicketWithStatusAgencyAPIViewModel>> GetAgencyRequests(int acency_id)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetAgencyRequests(acency_id);

            return result;

        }

        public ResponseObject<List<RequestGroupMonth>> GetAllRequestByAgencyIDAndStatus2(int acency_id, int status)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetAllRequestByAgencyIDAndStatus2(acency_id, status);

            return result;

        }

        public ResponseObject<bool> CreateFeedbackForRequest(FeedbackAPIViewModel feedback)
        {          
            var requestService = this.Service<IRequestService>();

            var rs = requestService.CreateFeedbackForRequest(feedback.TicketId, feedback.FeedbackContent);

            return rs;

        }

        public ResponseObject<bool> UpdateStatusRequest(int request_id, int status)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.UpdateStatusRequest(request_id, status);

            return result;
        }

        public ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> ViewRequestDetail(int requestId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.ViewRequestDetail(requestId);

            return result;
        }

        public ResponseObject<bool> AcceptRequestFromITSupporter(int itSupporterId, int requestId, bool isAccept, string check = null)
        {
            var requestService = this.Service<IRequestService>();
            var result = new ResponseObject<bool>();
            if (string.IsNullOrEmpty(check))
            {
                result = requestService.AcceptRequestFromITSupporter(itSupporterId, requestId, isAccept);
            }
            else
            {
                result = requestService.AcceptRequestFromITSupporter(itSupporterId, requestId, isAccept, check);
            }
            return result;
        }

        public ResponseObject<RequestAllTicketWithStatusAgencyAPIViewModel> GetRequestByRequestIdAndITSupporterId(int itSupporterId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetRequestByRequestIdAndITSupporterId(itSupporterId);

            return result;
        }

        public ResponseObject<List<StatusAPIViewModel>> GetRequestStatistic()
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetRequestStatistic();

            return result;
        }

        public ResponseObject<List<StatusAPIViewModel>> GetRequestStatisticForMonth(int month, int year)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetRequestStatisticForMonth(month, year);

            return result;
        }

        public ResponseObject<List<RequestAPIViewModel>> GetAllRequestForMonth(int month, int year)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetAllRequestForMonth(month, year);

            return result;
        }

        public ResponseObject<bool> ApproveCancelRequest(int request_id, int status)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.ApproveCancelRequest(request_id, status);

            return result;
        }

        public ResponseObject<RequestAPIViewModel> GetRequestBytRequestId(int requestId)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.GetRequestBytRequestId(requestId);

            return result;
        }

        public ResponseObject<int> SetPriority(int requestId, int priority)
        {
            var requestService = this.Service<IRequestService>();

            var result = requestService.SetPriority(requestId, priority);

            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DataService.APIViewModels;
using DataService.Domain;

namespace CapstoneProject_ODTS.ControllersApi
{
    public interface IRequestDomain
    {
        HttpResponseMessage GetAllRequest();
        HttpResponseMessage GetTicketWithStatus();
        HttpResponseMessage GetAllTicketByAgencyIDAndStatus(Int32 agency_id, Int32 status);
        HttpResponseMessage GetRequestHistoryByRequestId(int requestid);
        HttpResponseMessage GetAllRequestHistory();
        HttpResponseMessage CreateRatingForHero(RatingAPIViewModel rate);
        HttpResponseMessage FeedbackTicket(FeedbackAPIViewModel feedback);
        HttpResponseMessage UpdateStatusRequest(int request_id, int status);
        HttpResponseMessage ViewRequestDetail(int requestId);
        HttpResponseMessage AcceptRequest(int itSupporterId, int requestId, bool isAccept);
        HttpResponseMessage GetRequestByRequestIdAndITSupporterId(int itSupporterId);
        HttpResponseMessage GetAgencyRequests(int agency_id);
        HttpResponseMessage AddDevicesForRequest(int requestId, List<int> deviceIds);
    }

    public class RequestController : ApiController, IRequestDomain
    {
        private RequestDomain _requestDomain;
        private TicketDomain _ticketDomain;
        private RequestHistoryDomain _requestHistoryDomain;

        public RequestController()
        {
            _requestDomain = new RequestDomain();
            _ticketDomain = new TicketDomain();
            _requestHistoryDomain = new RequestHistoryDomain();
        }

        [HttpGet]
        [Route("ticket/all_ticket")]
        public HttpResponseMessage GetAllRequest()
        {
            // 0, 0, 0 là 2 default param cho MVC
            var result = _requestDomain.GetAllRequest(0, 0, 0);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_with_status")]
        public HttpResponseMessage GetTicketWithStatus()
        {
            var result = _requestDomain.GetRequestWithStatus(3);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_with_status_agency")]
        public HttpResponseMessage GetAllTicketByAgencyIDAndStatus(int agency_id, int status)
        {
            var result = _requestDomain.GetAllRequestByAgencyIDAndStatus(agency_id, status);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_with_status_agency2")]
        public HttpResponseMessage GetAllTicketByAgencyIDAndStatus2(int agency_id, int status)
        {
            var result = _requestDomain.GetAllRequestByAgencyIDAndStatus2(agency_id, status);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("request/request_history_by_agency")]
        public HttpResponseMessage GetAgencyRequests(int agency_id)
        {
            var result = _requestDomain.GetAgencyRequests(agency_id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/request_history_in_request")]
        public HttpResponseMessage GetRequestHistoryByRequestId(int ticketid)
        {
            var result = _requestHistoryDomain.GetRequestHistoryByRequestId(ticketid);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_request_history")]
        public HttpResponseMessage GetAllRequestHistory()
        {
            var result = _requestHistoryDomain.GetAllRequestHistory();
           
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("request/rate_ITSupporter")]
        public HttpResponseMessage CreateRatingForHero(RatingAPIViewModel rate)
        {
            var result = _ticketDomain.CreateRatingForHero(rate);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/feedback")]
        public HttpResponseMessage FeedbackTicket(FeedbackAPIViewModel feedback)
        {
            var result = _requestDomain.CreateFeedbackForRequest(feedback);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/update_status_ticket")]
        public HttpResponseMessage UpdateStatusRequest(int request_id, int status)
        {            
            var result = _requestDomain.UpdateStatusRequest(request_id, status);           
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("request/view_request_detail")]
        public HttpResponseMessage ViewRequestDetail(int requestId)
        {
            var result = _requestDomain.ViewRequestDetail(requestId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("request/accept_request/{itSupporterId}/{requestId}/{isAccept}")]
        public HttpResponseMessage AcceptRequest(int itSupporterId, int requestId, bool isAccept)
        {
            var result = _requestDomain.AcceptRequestFromITSupporter(itSupporterId, requestId, isAccept);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("request/request_by_id_and_ITSupporterId/{itSupporterId}")]
        public HttpResponseMessage GetRequestByRequestIdAndITSupporterId(int itSupporterId)
        {
            var result = _requestDomain.GetRequestByRequestIdAndITSupporterId(itSupporterId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("request/view_request_statistic")]
        public HttpResponseMessage ITSuppoterStatistic(int year, int month)
        {
            var result = _requestDomain.GetRequestStatisticForMonth(month, year);
            //var result = _ITSupporterDomain.ServiceITSuppoterStatistic(year, month);
            //var r = new RequestDomain();
            //var result = r.GetRequestStatistic(month, year);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("request/view_request_details")]
        public HttpResponseMessage GetRequestById(int requestId)
        {
            var result = _requestDomain.GetRequestById(requestId);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("request/add_device_for_request")]
        public HttpResponseMessage AddDevicesForRequest(int requestId, List<int> deviceIds)
        {
            var result = _requestDomain.AddDevicesForRequest(requestId, deviceIds);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
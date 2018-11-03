﻿using System;
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
        HttpResponseMessage GetTicketHistoryByTicketId(int ticketid);
        HttpResponseMessage GetAllTicketHistory();
        HttpResponseMessage GetAllCompany(RatingAPIViewModel rate);
        HttpResponseMessage FeedbackTicket(FeedbackAPIViewModel feedback);
        HttpResponseMessage UpdateStatusRequest(int request_id, int status);
        HttpResponseMessage ViewRequestDetail(int requestId);
        HttpResponseMessage AcceptRequest(int itSupporterId, int requestId, bool isAccept);
    }

    public class RequestController : ApiController, IRequestDomain
    {
        private RequestDomain _requestDomain;
        private TicketDomain _ticketDomain;
        private TicketHistoryDomain _ticketHistoryDomain;

        public RequestController()
        {
            _requestDomain = new RequestDomain();
            _ticketDomain = new TicketDomain();
            _ticketHistoryDomain = new TicketHistoryDomain();
        }

        [HttpGet]
        [Route("ticket/all_ticket")]
        public HttpResponseMessage GetAllRequest()
        {
            var result = _requestDomain.GetAllRequest();
            
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
        public HttpResponseMessage GetAllTicketByAgencyIDAndStatus(Int32 agency_id, Int32 status)
        {
            var result = _requestDomain.GetAllRequestByAgencyIDAndStatus(agency_id, status);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/ticket_history_in_ticket")]
        public HttpResponseMessage GetTicketHistoryByTicketId(int ticketid)
        {
            var result = _ticketHistoryDomain.GetTicketHistoryByTicketId(ticketid);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_history")]
        public HttpResponseMessage GetAllTicketHistory()
        {
            var result = _ticketHistoryDomain.GetAllTicketHistory();
           
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/ticketDetail/rate_ITSupporter")]
        public HttpResponseMessage GetAllCompany(RatingAPIViewModel rate)
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
        [Route("ticket/cancel_ticket")]
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

            return Request.CreateResponse(HttpStatusCode.OK, "Cancel Thành Công!");
        }

    }
}
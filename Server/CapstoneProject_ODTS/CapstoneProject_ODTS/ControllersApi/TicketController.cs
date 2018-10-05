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
    public class TicketController : ApiController
    {
        private TicketDomain _ticketDomain;
        private TicketDetailDomain _ticketDetailDomain;
        private TicketHistoryDomain _ticketHistoryDomain;

        public TicketController()
        {
            _ticketDomain = new TicketDomain();
            _ticketDetailDomain = new TicketDetailDomain();
            _ticketHistoryDomain = new TicketHistoryDomain();
        }

        [HttpGet]
        [Route("ticket/all_ticket")]
        public HttpResponseMessage GetAllCompany(TicketAPIViewModel agency_id)
        {
            var result = _ticketDomain.GetAllTicket();
            if (result.Count() < 0)
            {
                //return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_with_status")]
        public HttpResponseMessage GetTicketWithStatus()
        {
            var result = _ticketDomain.GetTicketWithStatus(3);
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_with_status_agency")]
        public HttpResponseMessage GetAllTicketByAgencyIDAndStatus(Int32 agency_id, Int32 status)
        {
            var result = _ticketDomain.GetAllTicketByAgencyIDAndStatus(agency_id, status);
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/ticket_history_in_ticket")]
        public HttpResponseMessage GetTicketHistoryByTicketId(int ticketid)
        {
            var result = _ticketHistoryDomain.GetTicketHistoryByTicketId(ticketid);
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ticket/all_ticket_history")]
        public HttpResponseMessage GetAllTicketHistory()
        {
            var result = _ticketHistoryDomain.GetAllTicketHistory();
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/ticketDetail/rate_ITSupporter")]
        public HttpResponseMessage GetAllCompany(RatingAPIViewModel rate)
        {
            var result = _ticketDetailDomain.CreateRatingForHero(rate);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/feedback")]
        public HttpResponseMessage FeedbackTicket(FeedbackAPIViewModel feedback)
        {
            var result = _ticketDomain.CreateFeedbackForTicket(feedback);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/cancel_ticket")]
        public HttpResponseMessage CancelTicket(TicketCancelAPIViewModel model)
        {
            _ticketDomain.CancelTicket(model);
            var result = _ticketDomain.CancelTicket(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Cancel Thành Công!");
        }
    }
}
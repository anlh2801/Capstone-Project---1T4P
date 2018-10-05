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
    public class ProblemController : ApiController
    {
        private ProblemDomain _problemDomain;
        private TicketDomain _ticketDomain;
        private TicketHistoryDomain _ticketHistoryDomain;

        public ProblemController()
        {
            _problemDomain = new ProblemDomain();
            _ticketDomain = new TicketDomain();
            _ticketHistoryDomain = new TicketHistoryDomain();
        }

        [HttpGet]
        [Route("ticket/all_ticket")]
        public HttpResponseMessage GetAllCompany(ProblemAPIViewModel agency_id)
        {
            var result = _problemDomain.GetAllProblem();
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
            var result = _problemDomain.GetProblemWithStatus(3);
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
            var result = _problemDomain.GetAllProblemByAgencyIDAndStatus(agency_id, status);
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
            var result = _ticketDomain.CreateRatingForHero(rate);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/feedback")]
        public HttpResponseMessage FeedbackTicket(FeedbackAPIViewModel feedback)
        {
            var result = _problemDomain.CreateFeedbackForProblem(feedback);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ticket/cancel_ticket")]
        public HttpResponseMessage CancelTicket(ProblemCancelAPIViewModel model)
        {            
            var result = _problemDomain.CancelProblem(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Cancel Thành Công!");
        }
    }
}
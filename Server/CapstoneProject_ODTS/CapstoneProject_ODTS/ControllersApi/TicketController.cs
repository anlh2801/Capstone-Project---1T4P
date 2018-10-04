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

        public TicketController()
        {
            _ticketDomain = new TicketDomain();
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
        public HttpResponseMessage GetAllTicketByAgencyIDAndStatus()
        {
            var result = _ticketDomain.GetAllTicketByAgencyIDAndStatus(3, 3);
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
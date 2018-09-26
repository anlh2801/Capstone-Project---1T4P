using CapstoneProject_ODTS.API.Models;
using CapstoneProject_ODTS.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.API.Controllers
{
    public class TicketController : ApiController
    {
        private TicketService _ticketService;

        public TicketController()
        {
            _ticketService = new TicketService();
        }

        [HttpGet]
        [Route("ticket/all_ticket")]
        public HttpResponseMessage GetAllTicket()
        {
            var result = _ticketService.GetTickets();
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }
            List<TicketDTO> dtos = new List<TicketDTO>();
            foreach (var item in result)
            {
                var dto = new TicketDTO() { TicketName = item.TicketName};
                dtos.Add(dto);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dtos);
        }
    }
}

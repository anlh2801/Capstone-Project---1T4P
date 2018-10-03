using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.ControllersApi
{
    public class TicketDetailController : ApiController
    {
        private TicketDetailDomain _ticketDetailDomain;

        public TicketDetailController()
        {
            _ticketDetailDomain = new TicketDetailDomain();
        }

        [HttpPost]
        [Route("ticketDetail/rate_ITSupporter")]
        public HttpResponseMessage GetAllCompany(RatingAPIViewModel rate)
        {
            var result = _ticketDetailDomain.CreateRatingForHero(rate);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}

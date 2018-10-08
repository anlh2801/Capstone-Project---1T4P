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
    public class ITSupporterController : ApiController
    {
        private ITSupporterDomain _ITSupporterDomain;

        public ITSupporterController()
        {
            _ITSupporterDomain = new ITSupporterDomain();
        }

        [HttpPut]
        [Route("ITsuportter/update_ticket_status")]
        public HttpResponseMessage UpdateProfile(ITSupporterUpdateAPIViewModel model)
        {           
            var result = _ITSupporterDomain.UpdateTicketStatus(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật Thành Công!");
        }

        [HttpGet]
        [Route("ITsupporter/view_profile_ITsupporter")]
        public HttpResponseMessage ViewProfileITSupporter(int itSupporter_id)
        {
            var result = _ITSupporterDomain.ViewProfileITSupporter(itSupporter_id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/view_all_owner_ticket")]
        public HttpResponseMessage ViewAllOwnerTicket(int ITsupporter_id)
        {
            var result = _ITSupporterDomain.ViewAllOwnerTicket(ITsupporter_id);
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsuportter/update_estimate_time_ticket")]
        public HttpResponseMessage EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {
            var result = _ITSupporterDomain.EstimateTimeTicket(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật Thành Công!");
        }
    }
}


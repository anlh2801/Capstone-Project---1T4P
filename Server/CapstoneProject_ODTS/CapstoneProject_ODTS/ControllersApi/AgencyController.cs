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
    public interface IAgencyController
    {
        HttpResponseMessage ViewProfile(int agency_id);

        HttpResponseMessage UpdateProfile(AgencyUpdateAPIViewModel model);

        HttpResponseMessage ViewAllDevice(int agency_id);

        HttpResponseMessage CreateRequest(AgencyCreateRequestAPIViewModel model);


    }

    public class AgencyController : ApiController, IAgencyController
    {
        private AgencyDomain _agencyDomain;

        public AgencyController()
        {
            _agencyDomain = new AgencyDomain();
        }

        [HttpGet]
        [Route("agency/view_profile_agency")]
        public HttpResponseMessage ViewProfile(int agency_id)
        {
            var result = _agencyDomain.ViewProfile(agency_id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("agency/update_profile_agency")]
        public HttpResponseMessage UpdateProfile(AgencyUpdateAPIViewModel model)
        {            
            var result = _agencyDomain.UpdateProfile(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Update Thành Công!");
        }

        [HttpGet]
        [Route("agency/view_all_device")]
        public HttpResponseMessage ViewAllDevice(int agency_id)
        {
            var result = _agencyDomain.ViewAllDeviceByAgencyId(agency_id);
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("agency/create_request")]
        public HttpResponseMessage CreateRequest(AgencyCreateRequestAPIViewModel model)
        {
            var result = _agencyDomain.CreateRequest(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Tạo Thành Công!");

        }
    }
}


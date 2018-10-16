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

        HttpResponseMessage GetDeviceDetails(int deviceId);
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

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("agency/update_profile_agency")]
        public HttpResponseMessage UpdateProfile(AgencyUpdateAPIViewModel model)
        {            
            var result = _agencyDomain.UpdateProfile(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/view_all_device")]
        public HttpResponseMessage ViewAllDevice(int agency_id)
        {
            var result = _agencyDomain.ViewAllDeviceByAgencyId(agency_id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("agency/create_request")]
        public HttpResponseMessage CreateRequest(AgencyCreateRequestAPIViewModel model)
        {
            var result = _agencyDomain.CreateRequest(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpGet]
        [Route("agency/get_device_details")]
        public HttpResponseMessage GetDeviceDetails(int deviceId)
        {
            var result = _agencyDomain.ViewProfile(deviceId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
    }
}


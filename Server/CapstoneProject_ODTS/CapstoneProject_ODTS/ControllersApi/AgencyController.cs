﻿using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.Controllers
{
    public class AgencyController : ApiController
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
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("agency/update_profile_agency")]
        public HttpResponseMessage UpdateProfile(UpdateAgencyAPIViewModel model)
        {
            _agencyDomain.UpdateProfile(model);
            var result = _agencyDomain.UpdateProfile(model);
            if (result == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Update Thành Công!");
        }

    }
}

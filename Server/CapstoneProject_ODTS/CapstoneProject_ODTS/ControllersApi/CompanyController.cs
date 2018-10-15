using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {
        private CompanyDomain _companyDomain;

        public CompanyController()
        {
            _companyDomain = new CompanyDomain();
        }

        [HttpGet]
        [Route("findall")]
        public HttpResponseMessage GetAllCompany()
        {
            var list = _companyDomain.GetAllCompany();
            if (list.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }            

            return Request.CreateResponse(HttpStatusCode.OK, new {result = list});
        }
    }
}


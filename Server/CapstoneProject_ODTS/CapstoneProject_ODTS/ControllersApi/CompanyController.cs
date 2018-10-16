using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.Controllers
{
    public interface ICompanyController
    {
        HttpResponseMessage GetAllCompany();
    }

    public class CompanyController : ApiController, ICompanyController
    {
        private CompanyDomain _companyDomain;

        public CompanyController()
        {
            _companyDomain = new CompanyDomain();
        }

        [HttpGet]
        [Route("company/all_company")]
        public HttpResponseMessage GetAllCompany()
        {
            var result = _companyDomain.GetAllCompany();
            if (result.IsError)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.ErrorMessage);
            }            

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}


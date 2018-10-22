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
        private AccountDomain _accountDomain;

        public CompanyController()
        {
            _companyDomain = new CompanyDomain();
            _accountDomain = new AccountDomain();
        }

        [HttpGet]
        [Route("company/all_company")]
        public HttpResponseMessage GetAllCompany()
        {
            var result = _companyDomain.GetAllCompany();
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage checkLogin(string username, string password, int roleId) { 
            var result = _accountDomain.CheckLogin(username, password, roleId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}


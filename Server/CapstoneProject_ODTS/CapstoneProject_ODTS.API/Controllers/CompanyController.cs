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
    public class CompanyController : ApiController
    {
        private CompanyService _companyService;

        public CompanyController()
        {
            _companyService = new CompanyService();
        }

        [HttpGet]
        [Route("company/all_company")]
        public HttpResponseMessage GetAllCompany()
        {
            var result = _companyService.GetCompanies();
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }
            List<CompanyDTO> dtos = new List<CompanyDTO>();
            foreach (var item in result)
            {
                var dto = new CompanyDTO() { CompanyName = item.CompanyName, CompanyDescription = item.Description };
                dtos.Add(dto);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dtos);
        }
    }
}

﻿using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.Controllers
{
    public class CompanyController : ApiController
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
            if (result.Count() < 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Loi nek");
            }
            //List<CompanyDTO> dtos = new List<CompanyDTO>();
            //foreach (var item in result)
            //{
            //    var dto = new CompanyDTO() { CompanyName = item.CompanyName, CompanyDescription = item.Description };
            //    dtos.Add(dto);
            //}

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}


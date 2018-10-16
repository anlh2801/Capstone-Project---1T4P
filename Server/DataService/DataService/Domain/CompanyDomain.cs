﻿using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface ICompanyDomain
    {

        ResponseObject<List<CompanyAPIViewModel>> GetAllCompany();
    }

    public class CompanyDomain : BaseDomain, ICompanyDomain
    {
        public ResponseObject<List<CompanyAPIViewModel>> GetAllCompany()
        {          
            var companyService = this.Service<ICompanyService>();

            var companies = companyService.GetAllCompany();
           
            return companies;
        }
    }
}

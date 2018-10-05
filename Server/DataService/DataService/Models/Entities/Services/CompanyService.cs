﻿using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface ICompanyService
    {
        List<CompanyAPIViewModel> GetAllCompany();
    }

    public partial class CompanyService
    {
        public List<CompanyAPIViewModel> GetAllCompany()
        {
            List<CompanyAPIViewModel> rsList = new List<CompanyAPIViewModel>();
            var companyRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var companies = companyRepo.GetActive().ToList();

            foreach (var item in companies)
            {                
                rsList.Add(new CompanyAPIViewModel
                {
                    CompanyId = item.CompanyId,
                    CompanyName = item.CompanyName,
                    Description = item.Description,
                    CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                });
            }

            return rsList;
        }
}
}

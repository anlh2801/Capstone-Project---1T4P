using DataService.APIViewModels;
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
        List<CompanyViewModel> GetAllCompany();
    }

    public partial class CompanyService
    {
        public List<CompanyViewModel> GetAllCompany()
        {
            List<CompanyViewModel> rsList = new List<CompanyViewModel>();
            var companyRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var companies = companyRepo.GetActive().ToList();
            foreach (var item in companies)
            {
                var a = new CompanyViewModel(item);
                rsList.Add(a);
            }

            return rsList;
        }
}
}

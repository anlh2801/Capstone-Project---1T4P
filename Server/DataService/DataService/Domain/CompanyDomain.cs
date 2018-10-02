using DataService.APIViewModels;
using DataService.Models.Entities.Services;
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
       
        List<CompanyAPIViewModel> GetAllCompany();
    }

    public class CompanyDomain : BaseDomain, ICompanyDomain
    {
        public List<CompanyAPIViewModel> GetAllCompany()
        {          
            var companyService = this.Service<ICompanyService>();

            var companies = companyService.GetAllCompany();
           
            return companies;
        }
    }
}

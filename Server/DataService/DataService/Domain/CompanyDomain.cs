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
            var companyList = new List<CompanyAPIViewModel>();            
            
            var companyService = this.Service<ICompanyService>();

            var companies = companyService.GetAllCompany();
            foreach (var item in companies)
            {
                companyList.Add(new CompanyAPIViewModel
                {
                    CompanyId = item.CompanyId,
                    CompanyName = item.CompanyName,
                    Description = item.Description,
                    CreateDate = item.CreatedAt.Value.ToString("MM/dd/yyyy"),
                    UpdateDate = item.UpdateAt.Value.ToString("MM/dd/yyyy")
                });
            }
            return companyList;
        }
    }
}

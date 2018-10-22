using DataService.APIViewModels;
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
        ResponseObject<CompanyAPIViewModel> ViewDetail(int company_id);
        ResponseObject<bool> CreateCompany(CompanyAPIViewModel model);
        ResponseObject<bool> UpdateCompany(CompanyAPIViewModel model);
        ResponseObject<bool> RemoveCompany(int company_id);
    }

    public class CompanyDomain : BaseDomain, ICompanyDomain
    {        
        public ResponseObject<CompanyAPIViewModel> ViewDetail(int company_id)
        {
            var companyService = this.Service<ICompanyService>();

            var company = companyService.ViewDetail(company_id);

            return company;
        }
        public ResponseObject<List<CompanyAPIViewModel>> GetAllCompany()
        {          
            var companyService = this.Service<ICompanyService>();

            var companies = companyService.GetAllCompany();
           
            return companies;
        }

        public ResponseObject<bool> CreateCompany(CompanyAPIViewModel model)
        {
            var companyService = this.Service<ICompanyService>();

            var result = companyService.CreateCompany(model);

            return result;
        }
        public ResponseObject<bool> UpdateCompany(CompanyAPIViewModel model)
        {
            var companyService = this.Service<ICompanyService>();

            var result = companyService.UpdateCompany(model);

            return result; 
        }
        public ResponseObject<bool> RemoveCompany(int company_id)
        {
            var companyList = new List<CompanyAPIViewModel>();

            var companyService = this.Service<ICompanyService>();
            var rs = companyService.RemoveCompany(company_id);
            return rs;
        }


        public ResponseObject<List<AgencyAPIViewModel>> ViewAllAgencyByCompanyId(int company_id)
        {
            var agencyDeviceService = this.Service<IAgencyService>();

            var agencies = agencyDeviceService.ViewAllAgencyByCompanyId(company_id);

            return agencies;
        }
    }
}

using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
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
        ResponseObject<List<CompanyAPIViewModel>> GetAllCompany();
    }

    public partial class CompanyService
    {
        public ResponseObject<List<CompanyAPIViewModel>> GetAllCompany()
        {
            List<CompanyAPIViewModel> rsList = new List<CompanyAPIViewModel>();
            var companyRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var companies = companyRepo.GetActive().ToList();
            
            if (companies.Count > 0)
            {
                int count = 1;
                foreach (var item in companies)
                {
                    if (!item.IsDelete)
                    {
                        rsList.Add(new CompanyAPIViewModel
                        {
                            NumericalOrder = count,
                            CompanyId = item.CompanyId,
                            CompanyName = item.CompanyName,
                            Description = item.Description,
                            CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                            UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                        });
                    }
                    count++;
                }
            }
            else
            {
                return new ResponseObject<List<CompanyAPIViewModel>> { IsError = true, ErrorMessage = "Không có công ty nào", ObjReturn = rsList };
            }
            

            return new ResponseObject<List<CompanyAPIViewModel>> { IsError = false, ObjReturn = rsList };
        }
}
}

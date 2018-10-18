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
        ResponseObject<CompanyAPIViewModel> ViewDetail(int company_id);
        ResponseObject<bool> CreateCompany(CompanyAPIViewModel model);
        ResponseObject<bool> UpdateCompany(CompanyAPIViewModel model);
        ResponseObject<bool> RemoveCompany(int company_id);
    }

    public partial class CompanyService
    {
        public ResponseObject<List<CompanyAPIViewModel>> GetAllCompany()
        {
            try
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
                    return new ResponseObject<List<CompanyAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy công ty!" };
                }
                else
                {
                    return new ResponseObject<List<CompanyAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy công ty!", ObjReturn = rsList };
                }
            }
            catch (Exception e)
            {

                return new ResponseObject<List<CompanyAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy công ty!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<CompanyAPIViewModel> ViewDetail(int company_id)
        {
            var companyRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var company = companyRepo.GetActive().SingleOrDefault(a => a.CompanyId == company_id);
            if (company != null)
            {
                var companyAPIViewModel = new CompanyAPIViewModel
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    Description = company.Description,
                    CreateDate = company.CreateDate.Value.ToString("dd/MM/yyyy"),
                    UpdateDate = company.UpdateDate.Value.ToString("dd/MM/yyyy"),
                };
                return new ResponseObject<CompanyAPIViewModel> { IsError = false, ObjReturn = companyAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
            }
            return new ResponseObject<CompanyAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại loại thiết bị này" };
        }
        public ResponseObject<bool> CreateCompany(CompanyAPIViewModel model)
        {

            var companyeRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var createCompany = new Company();

            try
            {
                createCompany.CompanyId = model.CompanyId;
                createCompany.CompanyName = model.CompanyName;
                createCompany.Description = model.Description;
                createCompany.IsDelete = false;
                createCompany.CreateDate = DateTime.Now;
                createCompany.UpdateDate = DateTime.Now;

                companyeRepo.Add(createCompany);

                companyeRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm công ty thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm công ty thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
        public ResponseObject<bool> UpdateCompany(CompanyAPIViewModel model)
        {
            var companyeRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var updateCompany = companyeRepo.GetActive().SingleOrDefault(a => a.CompanyId == model.CompanyId);

            if (updateCompany != null)
            {
                updateCompany.CompanyName = model.CompanyName;
                updateCompany.Description = model.Description;
                updateCompany.UpdateDate = DateTime.Now;

                companyeRepo.Edit(updateCompany);
                companyeRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa công ty thành công", ObjReturn = true };
            }

            return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa công ty thất bại", ObjReturn = false };
        }
        public ResponseObject<bool> RemoveCompany(int company_id)
        {
            var companyeRepo = DependencyUtils.Resolve<ICompanyRepository>();
            var company = companyeRepo.GetActive().SingleOrDefault(a => a.CompanyId == company_id);
            try
            {
                Deactivate(company);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa loại công ty thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa loại công ty thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
    }
}

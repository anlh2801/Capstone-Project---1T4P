using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IServiceITSupportService
    {
        ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport();
        ResponseObject<ServiceITSupportAPIViewModel> ViewDetail(int serviceitsupport_id);
        ResponseObject<bool> CreateServiceITSupport(ServiceITSupportAPIViewModel model);
        ResponseObject<bool> UpdateServiceITSupport(ServiceITSupportAPIViewModel model);
        ResponseObject<bool> RemoveServiceITSupport(int serviceitsupport_id);
        ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupportByAgencyId(int agencyId);
    }
    public partial class ServiceITSupportService
    {
        public ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport()
        {
            List<ServiceITSupportAPIViewModel> rsList = new List<ServiceITSupportAPIViewModel>();
            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var serviceITSupports = serviceITSupportRepo.GetActive().ToList();
            if (serviceITSupports.Count <= 0)
            {
                return new ResponseObject<List<ServiceITSupportAPIViewModel>> { IsError = true, WarningMessage = "Không có hợp đồng" };
            }
            int count = 1;
            foreach (var item in serviceITSupports)
            {
                if (!item.IsDelete)
                {
                    rsList.Add(new ServiceITSupportAPIViewModel
                    {
                        NumericalOrder = count,
                        ServiceITSupportId = item.ServiceITSupportId,
                        ServiceName = item.ServiceName,
                        Description = item.Description,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("dd/MM/yyyy")
                    });
                }
                count++;
            }

            return new ResponseObject<List<ServiceITSupportAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị hợp đồng thành công" };
        }

        public ResponseObject<ServiceITSupportAPIViewModel> ViewDetail(int serviceitsupport_id)
        {
            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var serviceitsupport = serviceITSupportRepo.GetActive().SingleOrDefault(a => a.ServiceITSupportId == serviceitsupport_id);
            if (serviceitsupport != null)
            {
                var devicetypeAPIViewModel = new ServiceITSupportAPIViewModel
                {
                    ServiceITSupportId = serviceitsupport.ServiceITSupportId,
                    ServiceName = serviceitsupport.ServiceName,
                    Description = serviceitsupport.Description,
                    CreateDate = serviceitsupport.CreateDate.ToString("dd/MM/yyyy"),
                    UpdateDate = serviceitsupport.UpdateDate.Value.ToString("dd/MM/yyyy"),
                };
                return new ResponseObject<ServiceITSupportAPIViewModel> { IsError = false, ObjReturn = devicetypeAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
            }
            return new ResponseObject<ServiceITSupportAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại loại dịch vụ bị này" };
        }
        public ResponseObject<bool> CreateServiceITSupport(ServiceITSupportAPIViewModel model)
        {

            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var createServiceitsupport = new ServiceITSupport();

            try
            {
                createServiceitsupport.ServiceITSupportId = model.ServiceITSupportId;
                createServiceitsupport.ServiceName = model.ServiceName;
                createServiceitsupport.Description = model.Description;
                createServiceitsupport.IsDelete = false;
                createServiceitsupport.CreateDate = DateTime.Now;
                createServiceitsupport.UpdateDate = DateTime.Now;

                serviceITSupportRepo.Add(createServiceitsupport);

                serviceITSupportRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm loại dịch vụ thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm loại dịch vụ thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
        public ResponseObject<bool> UpdateServiceITSupport(ServiceITSupportAPIViewModel model)
        {
            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var updateServiceitsupport = serviceITSupportRepo.GetActive().SingleOrDefault(a => a.ServiceITSupportId == model.ServiceITSupportId);

            if (updateServiceitsupport != null)
            {
                updateServiceitsupport.ServiceName = model.ServiceName;
                updateServiceitsupport.Description = model.Description;
                updateServiceitsupport.UpdateDate = DateTime.Now;

                serviceITSupportRepo.Edit(updateServiceitsupport);
                serviceITSupportRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa loại dịch vụ thành công", ObjReturn = true };
            }

            return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa loại dịch vụ thất bại", ObjReturn = false };
        }
        public ResponseObject<bool> RemoveServiceITSupport(int serviceitsupport_id)
        {
            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var serviceitsupport = serviceITSupportRepo.GetActive().SingleOrDefault(a => a.ServiceITSupportId == serviceitsupport_id);
            try
            {
                Deactivate(serviceitsupport);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa loại dịch vụ thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa loại dịch vụ thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }

        public ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupportByAgencyId(int agencyId)
        {
            List<ServiceITSupportAPIViewModel> rsList = new List<ServiceITSupportAPIViewModel>();
            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var serviceITSupports = serviceITSupportRepo.GetActive(
                p => p.ContractServiceITSupports.Any(
                    c => (c.EndDate == null || c.EndDate > DateTime.Now) && c.Contract.Company.Agencies.Any(a => a.AgencyId == agencyId))).ToList();
            if (serviceITSupports.Count <= 0)
            {
                return new ResponseObject<List<ServiceITSupportAPIViewModel>> { IsError = true, WarningMessage = "Không có hợp đồng" };
            }
            int count = 1;
            foreach (var item in serviceITSupports)
            {
                if (!item.IsDelete)
                {
                    rsList.Add(new ServiceITSupportAPIViewModel
                    {
                        NumericalOrder = count,
                        ServiceITSupportId = item.ServiceITSupportId,
                        ServiceName = item.ServiceName,
                        Description = item.Description,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("dd/MM/yyyy")
                    });
                }
                count++;
            }

            return new ResponseObject<List<ServiceITSupportAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị hợp đồng thành công" };
        }

    }
}

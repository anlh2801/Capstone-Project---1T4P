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
    public partial interface IServiceItemService
    {

        ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId);

        ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceITSupportId(int serviceITSupportId = 0);

        ResponseObject<ServiceItemAPIViewModel> ViewDetail(int ServiceItemId);

        ResponseObject<bool> UpdateServiceItem(ServiceItemUpdateAPIViewModel model);

        ResponseObject<bool> RemoveServiceItem(int serviceItem_Id);

        ResponseObject<bool> CreateServiceItem(ServiceItemAPIViewModel model);
    }
    public partial class ServiceItemService
    {
        public ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId)
        {
            List<ServiceItemAPIViewModel> rsList = new List<ServiceItemAPIViewModel>();
            var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
            var serviceItems = serviceItemRepo.GetActive(p => p.ServiceITSupportId == serviceId).ToList();
            if (serviceItems.Count <= 0)
            {
                return new ResponseObject<List<ServiceItemAPIViewModel>> { IsError = true, WarningMessage = "Không có dịch vụ nào hỗ trợ" };
            }
            int count = 1;
            foreach (var item in serviceItems)
            {
                rsList.Add(new ServiceItemAPIViewModel
                {
                    NumericalOrder = count,
                    ServiceId = item.ServiceITSupportId,
                    ServiceItemId = item.ServiceItemId,
                    ServiceItemName = item.ServiceItemName,
                    Description = item.Description != null ? item.Description : string.Empty,
                    CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                });

                count++;
            }

            return new ResponseObject<List<ServiceItemAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị danh sách dịch vụ" };
        }

        public ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceITSupportId(int serviceITSupportId = 0)
        {
            List<ServiceItemAPIViewModel> rsList = new List<ServiceItemAPIViewModel>();
            var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
            var serviceItems = serviceItemRepo.GetActive().OrderByDescending(p => p.ServiceITSupportId).ToList();

            if (serviceITSupportId > 0)
            {
                serviceItems = serviceItems.Where(p => p.ServiceITSupportId == serviceITSupportId).ToList();
            }
            if (serviceItems.Count <= 0)
            {
                return new ResponseObject<List<ServiceItemAPIViewModel>> { IsError = true, WarningMessage = "Không có dịch vụ nào hỗ trợ" };
            }
            int count = 1;
            foreach (var item in serviceItems)
            {
                rsList.Add(new ServiceItemAPIViewModel
                {
                    NumericalOrder = count,
                    ServiceItemId = item.ServiceItemId,
                    ServiceItemName = item.ServiceItemName,
                    Description = item.Description,
                    CreateDate = item.CreateDate.ToString("dd/MM/yyyy")
                });

                count++;
            }

            return new ResponseObject<List<ServiceItemAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị danh sách dịch vụ" };
        }

        public ResponseObject<ServiceItemAPIViewModel> ViewDetail(int ServiceItemId)
        {
            try
            {
                var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
                var serviceItem = serviceItemRepo.GetActive().SingleOrDefault(a => a.ServiceItemId == ServiceItemId);
                if (serviceItem != null)
                {
                    var ServiceItemAPIViewModel = new ServiceItemAPIViewModel
                    {
                        ServiceName = serviceItem.ServiceITSupport.ServiceName,
                        ServiceItemName = serviceItem.ServiceItemName,
                        ServiceItemId = serviceItem.ServiceItemId,
                        Description = serviceItem.Description,
                        CreateDate = serviceItem.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = serviceItem.UpdateDate != null ? serviceItem.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                    };
                    return new ResponseObject<ServiceItemAPIViewModel> { IsError = false, ObjReturn = ServiceItemAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
                }
                return new ResponseObject<ServiceItemAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại dịch vụ này" };
            }
            catch (Exception e)
            {

                return new ResponseObject<ServiceItemAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại dịch vụ này", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> UpdateServiceItem(ServiceItemUpdateAPIViewModel model)
        {
            try
            {
                var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
                var updateServiceItem = serviceItemRepo.GetActive().SingleOrDefault(a => a.ServiceItemId == model.ServiceItemId);

                if (updateServiceItem != null)
                {
                    updateServiceItem.ServiceItemName = model.ServiceItemName;
                    updateServiceItem.Description = model.Description;
                    updateServiceItem.UpdateDate = DateTime.UtcNow.AddHours(7);

                    serviceItemRepo.Edit(updateServiceItem);
                    serviceItemRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa dịch vụ thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa dịch vụ thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa dịch vụ thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> RemoveServiceItem(int serviceItem_Id)
        {
            var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
            var serviceItem = serviceItemRepo.GetActive().SingleOrDefault(a => a.ServiceItemId == serviceItem_Id);
            try
            {
                Deactivate(serviceItem);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa dịch vụ thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa dịch vụ thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }
        }

        public ResponseObject<bool> CreateServiceItem(ServiceItemAPIViewModel model)
        {
            try
            {
                var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
                var serviceItem = new ServiceItem();

                serviceItem.ServiceITSupportId = model.ServiceId;
                serviceItem.ServiceItemName = model.ServiceItemName;
                serviceItem.Description = model.Description;
                serviceItem.CreateDate = DateTime.UtcNow.AddHours(7);
                serviceItem.UpdateDate = DateTime.UtcNow.AddHours(7);
                serviceItemRepo.Add(serviceItem);
                serviceItemRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Tạo dịch vụ thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa dịch vụ thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }
    }
}

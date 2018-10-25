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

    public partial interface IDeviceTypeService
    {
        ResponseObject<List<DeviceTypeAPIViewModel>> GetAllDeviceType();
        ResponseObject<DeviceTypeAPIViewModel> ViewDetail(int devicetype_id);
        ResponseObject<bool> CreateDeviceType(DeviceTypeAPIViewModel model);
        ResponseObject<bool> UpdateDeviceType(DeviceTypeAPIViewModel model);
        ResponseObject<bool> RemoveDeviceType(int devicetype_id);
    }

    public partial class DeviceTypeService
    {
        public ResponseObject<List<DeviceTypeAPIViewModel>> GetAllDeviceType()
        {
            try
            {
                List<DeviceTypeAPIViewModel> rsList = new List<DeviceTypeAPIViewModel>();
                var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
                var devicetypes = devicetypeRepo.GetActive().ToList();
                if (devicetypes.Count <= 0)
                {
                    return new ResponseObject<List<DeviceTypeAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy loại thiết bị nào" };
                }
                int count = 1;
                foreach (var item in devicetypes)
                {
                    if (!item.IsDelete)
                    {
                        rsList.Add(new DeviceTypeAPIViewModel
                        {
                            NumericalOrder = count,
                            DeviceTypeId = item.DeviceTypeId,
                            DeviceTypeName = item.DeviceTypeName,
                            ServiceId = item.ServiceId,
                            ServiceName = item.ServiceITSupport.ServiceName,
                            Description = item.Description,
                            IsDelete = item.IsDelete,
                            CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                            UpdateDate = item.UpdateDate.Value.ToString("dd/MM/yyyy"),
                        });
                    }
                    count++;
                }
                return new ResponseObject<List<DeviceTypeAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<DeviceTypeAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy loại thiết bị nào", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<DeviceTypeAPIViewModel> ViewDetail(int devicetype_id)
        {
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetype = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == devicetype_id);
            if (devicetype != null)
            {
                var devicetypeAPIViewModel = new DeviceTypeAPIViewModel
                {
                    DeviceTypeId = devicetype.DeviceTypeId,
                    DeviceTypeName = devicetype.DeviceTypeName,
                    ServiceId = devicetype.ServiceId,
                    ServiceName = devicetype.ServiceITSupport.ServiceName,
                    Description = devicetype.Description,
                    CreateDate = devicetype.CreateDate.ToString("dd/MM/yyyy"),
                    UpdateDate = devicetype.UpdateDate.Value.ToString("dd/MM/yyyy"),
                };
                return new ResponseObject<DeviceTypeAPIViewModel> { IsError = false, ObjReturn = devicetypeAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
            }
            return new ResponseObject<DeviceTypeAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại loại thiết bị này" };
        }
        public ResponseObject<bool> CreateDeviceType(DeviceTypeAPIViewModel model)
        {

            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var createDeviceType = new DeviceType();

            try
            {
                createDeviceType.DeviceTypeId = model.DeviceTypeId;
                createDeviceType.ServiceId = model.ServiceId;
                createDeviceType.DeviceTypeName = model.DeviceTypeName ;
                createDeviceType.Description = model.Description;
                createDeviceType.IsDelete = false;
                createDeviceType.CreateDate = DateTime.UtcNow.AddHours(7);
                createDeviceType.UpdateDate = DateTime.UtcNow.AddHours(7);

                devicetypeRepo.Add(createDeviceType);

                devicetypeRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm loại thiết bị thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm loại thiết bị thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
        public ResponseObject<bool> UpdateDeviceType(DeviceTypeAPIViewModel model)
        {
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var updateDeviceType = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == model.DeviceTypeId);

            if (updateDeviceType != null)
            {
                updateDeviceType.ServiceId = model.ServiceId;
                updateDeviceType.DeviceTypeName = model.DeviceTypeName;
                updateDeviceType.Description = model.Description;
                updateDeviceType.UpdateDate = DateTime.UtcNow.AddHours(7);

                devicetypeRepo.Edit(updateDeviceType);
                devicetypeRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa loại thiết bị thành công", ObjReturn = true };
            }

            return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa loại thiết bị thất bại", ObjReturn = false };
        }
        public ResponseObject<bool> RemoveDeviceType(int devicetype_id)
        {
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetype = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == devicetype_id);
            try
            {
                Deactivate(devicetype);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa loại thiết bị thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa loại thiết bị thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
    }
}

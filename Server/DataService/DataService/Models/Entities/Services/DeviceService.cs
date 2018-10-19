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
    public partial interface IDeviceService
    {
        ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyId(int agency_id);
        ResponseObject<List<DeviceAPIViewModel>> GetAllDevice();
        ResponseObject<DeviceAPIViewModel> ViewDetail(int device_id);
        ResponseObject<bool> CreateDevice(DeviceAPIViewModel model);
        ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyIdAndServiceId(int agencyId, int serviceId);
    }

    public partial class DeviceService
    {
        public ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyId(int agency_id)
        {
            try
            {
                List<AgencyDeviceAPIViewModel> rsList = new List<AgencyDeviceAPIViewModel>();
                var agencyDeviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var agencyDevices = agencyDeviceRepo.GetActive(p => p.AgencyId == agency_id).ToList();
                if (agencyDevices.Count < 0)
                {
                    return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!" };
                }
                foreach (var item in agencyDevices)
                {
                    rsList.Add(new AgencyDeviceAPIViewModel
                    {
                        DeviceId = item.DeviceId,
                        AgencyId = item.AgencyId,
                        DeviceTypeId = item.DeviceTypeId,
                        DeviceName = item.DeviceName,
                        DeviceCode = item.DeviceCode,
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        GuarantyEndDate = item.GuarantyEndDate != null ? item.GuarantyEndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate != null ? item.SettingDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Other = item.Other,
                        CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }

                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy thiết bị" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<List<DeviceAPIViewModel>> GetAllDevice()
        {
            try
            {
                List<DeviceAPIViewModel> rsList = new List<DeviceAPIViewModel>();
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var devices = deviceRepo.GetActive().ToList();
                if (devices.Count < 0)
                {
                    return new ResponseObject<List<DeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào" };
                }
                foreach (var item in devices)
                {
                    rsList.Add(new DeviceAPIViewModel
                    {
                        DeviceId = item.DeviceId,
                        DeviceName = item.DeviceName,
                        AgencyId = item.AgencyId,
                        DeviceTypeId = item.DeviceTypeId,
                        DeviceCode = item.DeviceCode,
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("MM/dd/yyyy") : "Chưa có ngày",
                        GuarantyEndDate = item.GuarantyEndDate.Value.ToString("MM/dd/yyyy"),
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate.Value.ToString("MM/dd/yyyy"),
                        Other = item.Other,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("MM/dd/yyyy"),
                    });
                }

                return new ResponseObject<List<DeviceAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<DeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }
        public ResponseObject<DeviceAPIViewModel> ViewDetail(int device_id)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var device = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceId == device_id);
                if (device != null)
                {
                    var deviceAPIViewModel = new DeviceAPIViewModel
                    {
                        DeviceId = device.DeviceId,
                        DeviceName = device.DeviceName,
                        AgencyId = device.AgencyId,
                        DeviceTypeId = device.DeviceTypeId,
                        DeviceTypeName = device.DeviceType.DeviceTypeName,
                        DeviceCode = device.DeviceCode,
                        GuarantyStartDate = device.GuarantyStartDate.Value.ToString("MM/dd/yyyy"),
                        GuarantyEndDate = device.GuarantyEndDate.Value.ToString("MM/dd/yyyy"),
                        Ip = device.Ip,
                        Port = device.Port,
                        DeviceAccount = device.DeviceAccount,
                        DevicePassword = device.DevicePassword,
                        SettingDate = device.SettingDate.Value.ToString("MM/dd/yyyy"),
                        Other = device.Other,
                        IsDelete = device.IsDelete,
                        CreateDate = device.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateDate = device.UpdateDate.Value.ToString("MM/dd/yyyy"),
                    };
                    return new ResponseObject<DeviceAPIViewModel> { IsError = false, ObjReturn = deviceAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
                }
                return new ResponseObject<DeviceAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại hợp đồng này" };
            }
            catch (Exception e)
            {

                return new ResponseObject<DeviceAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại hợp đồng này", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }
        public ResponseObject<bool> CreateDevice(DeviceAPIViewModel model)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var createDevice = new Device();
                createDevice.DeviceId = model.DeviceId;
                createDevice.DeviceTypeId = model.DeviceTypeId;
                createDevice.AgencyId = model.AgencyId;
                createDevice.DeviceName = model.DeviceName;
                createDevice.DeviceCode = model.DeviceCode;
                createDevice.GuarantyStartDate = model.GuarantyStartDate.ToDateTime();
                createDevice.GuarantyEndDate = model.GuarantyEndDate.ToDateTime();
                createDevice.Ip = model.Ip;
                createDevice.Port = model.Port;
                createDevice.DeviceAccount = model.DeviceAccount;
                createDevice.DevicePassword = model.DevicePassword;
                createDevice.SettingDate = model.SettingDate.ToDateTime();
                createDevice.Other = model.Other;
                createDevice.IsDelete = false;
                createDevice.CreateDate = DateTime.Now;
                createDevice.UpdateDate = DateTime.Now;

                deviceRepo.Add(createDevice);

                deviceRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm loại thiết bị thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm loại thiết bị thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }     
        }

        public ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyIdAndServiceId(int agencyId, int serviceId)
        {
            try
            {
                List<AgencyDeviceAPIViewModel> rsList = new List<AgencyDeviceAPIViewModel>();
                var agencyDeviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var agencyDevices = agencyDeviceRepo.GetActive(p => p.AgencyId == agencyId && p.DeviceType.ServiceId == serviceId).ToList();
                if (agencyDevices.Count < 0)
                {
                    return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!" };
                }
                foreach (var item in agencyDevices)
                {
                    rsList.Add(new AgencyDeviceAPIViewModel
                    {
                        DeviceId = item.DeviceId,
                        AgencyId = item.AgencyId,
                        DeviceTypeId = item.DeviceTypeId,
                        DeviceName = item.DeviceName,
                        DeviceCode = item.DeviceCode,
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        GuarantyEndDate = item.GuarantyEndDate != null ? item.GuarantyEndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate != null ? item.SettingDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Other = item.Other,
                        CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }

                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy thiết bị" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
        //public ResponseObject<bool> RemoveDevice(int device_id)
        //{
        //    var devicetypeRepo = DependencyUtils.Resolve<IDeviceRepository>();
        //    var devicetype = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == device_id);
        //    try
        //    {
        //        Deactivate(devicetype);
        //        return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa loại thiết bị thành công", ObjReturn = true };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa loại thiết bị thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
        //    }

        //}
        //public ResponseObject<bool> UpdateDeviceType(DeviceTypeAPIViewModel model)
        //{
        //    var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
        //    var updateDeviceType = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == model.DeviceTypeId);

        //    if (updateDeviceType != null)
        //    {
        //        updateDeviceType.ServiceId = model.ServiceId;
        //        updateDeviceType.DeviceTypeName = model.DeviceTypeName;
        //        updateDeviceType.Description = model.Description;
        //        updateDeviceType.UpdateDate = DateTime.Now;

        //        devicetypeRepo.Edit(updateDeviceType);
        //        devicetypeRepo.Save();
        //        return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa loại thiết bị thành công", ObjReturn = true };
        //    }

        //    return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa loại thiết bị thất bại", ObjReturn = false };
        //}
    }
}

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
        ResponseObject<DeviceAPIViewModel> GetDeviceDetailByDeviceCode(string deviceCode);
        ResponseObject<bool> CreateDevice(DeviceAPIViewModel model);
        ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyIdAndServiceId(int agencyId, int serviceId);
        ResponseObject<bool> RemoveDevice(int device_id);
        ResponseObject<bool> UpdateDevice(AgencyDeviceAPIViewModel model);
        ResponseObject<bool> UpdateDeviceForAgency(DeviceAPIViewModel model);
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
                if (agencyDevices.Count <= 0)
                {
                    return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!" };
                }
                foreach (var item in agencyDevices)
                {
                    rsList.Add(new AgencyDeviceAPIViewModel
                    {
                        AgencyName = item.Agency.AgencyName,
                        CompanyName = item.Agency.Company.CompanyName,
                        DeviceId = item.DeviceId,
                        AgencyId = item.AgencyId,
                        DeviceTypeId = item.DeviceTypeId,
                        DeviceName = item.DeviceName,
                        DeviceCode = item.DeviceCode,
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        GuarantyEndDate = item.GuarantyEndDate != null ? item.GuarantyEndDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate != null ? item.SettingDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        Other = item.Other,
                        CreateDate = item.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty
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
                if (devices.Count <= 0)
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
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("HH:mm dd/MM/yyyy") : "Chưa có ngày",
                        GuarantyEndDate = item.GuarantyEndDate.Value.ToString("HH:mm dd/MM/yyyy"),
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate.Value.ToString("HH:mm dd/MM/yyyy"),
                        Other = item.Other,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy"),
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
                        CompanyId = device.Agency.CompanyId,
                        CompanyName = device.Agency.Company.CompanyName,
                        DeviceTypeId = device.DeviceTypeId,
                        DeviceTypeName = device.DeviceType.DeviceTypeName,
                        DeviceCode = device.DeviceCode,
                        GuarantyStartDate = device.GuarantyStartDate != null ? device.GuarantyStartDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        GuarantyEndDate = device.GuarantyEndDate != null ? device.GuarantyEndDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        Ip = device.Ip,
                        Port = device.Port,
                        DeviceAccount = device.DeviceAccount,
                        DevicePassword = device.DevicePassword,
                        SettingDate = device.SettingDate != null ? device.SettingDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        Other = device.Other,
                        IsDelete = device.IsDelete,
                        CreateDate = device.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = device.UpdateDate != null ? device.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                    };
                    return new ResponseObject<DeviceAPIViewModel> { IsError = false, ObjReturn = deviceAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
                }
                return new ResponseObject<DeviceAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại thiết bị này" };
            }
            catch (Exception e)
            {

                return new ResponseObject<DeviceAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại thiết bị này", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<DeviceAPIViewModel> GetDeviceDetailByDeviceCode(string deviceCode)
        {
            try
            {
                var ticketList = new List<TicketAPIViewModel>();
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var device = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceCode == deviceCode);
                var ticket = ticketRepo.GetActive().Where(t => t.DeviceId == device.DeviceId);
                if (device != null)
                {
                    if(ticket != null)
                    {
                        foreach (var ticketItem in ticket)
                        {
                            var ticketViewModel = new TicketAPIViewModel
                            {
                                TicketId = ticketItem.TicketId,
                                DeviceId = ticketItem.DeviceId,
                                RequestId = ticketItem.RequestId,
                                ServiceItemName = ticketItem.Request.ServiceItem.ServiceItemName,
                                Desciption = ticketItem.Desciption,
                                CreateDate = ticketItem.CreateDate.ToString("HH:mm dd/MM/yyyy")
                            };
                            ticketList.Add(ticketViewModel);
                        }
                    }
                    var deviceAPIViewModel = new DeviceAPIViewModel
                    {
                        DeviceId = device.DeviceId,
                        DeviceName = device.DeviceName,
                        AgencyId = device.AgencyId,
                        AgencyName = device.Agency.AgencyName,
                        CompanyId = device.Agency.CompanyId,
                        CompanyName = device.Agency.Company.CompanyName,
                        DeviceTypeId = device.DeviceTypeId,
                        DeviceTypeName = device.DeviceType.DeviceTypeName,
                        DeviceCode = device.DeviceCode,
                        GuarantyStartDate = device.GuarantyStartDate != null ? device.GuarantyStartDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        GuarantyEndDate = device.GuarantyEndDate != null ? device.GuarantyEndDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        GuarantyStatus = device.GuarantyEndDate != null && device.GuarantyEndDate.Value.Date >= DateTime.Now.Date ? "Còn bảo hành" : "Hết bảo hành",
                        Ip = device.Ip,
                        Port = device.Port,
                        DeviceAccount = device.DeviceAccount,
                        DevicePassword = device.DevicePassword,
                        SettingDate = device.SettingDate.Value.ToString("HH:mm dd/MM/yyyy"),
                        Other = device.Other,
                        TicketList = ticketList,
                        IsDelete = device.IsDelete,
                        CreateDate = device.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = device.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy"),
                    };
                    return new ResponseObject<DeviceAPIViewModel> { IsError = false, ObjReturn = deviceAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
                }
                return new ResponseObject<DeviceAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại thiết bị này" };
            }
            catch (Exception e)
            {

                return new ResponseObject<DeviceAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại thiết bị này", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> CreateDevice(DeviceAPIViewModel model)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var device = deviceRepo.GetActive(p => p.DeviceCode == model.DeviceCode).SingleOrDefault();
                if (device != null)
                {
                    return new ResponseObject<bool> { IsError = true, WarningMessage = "Trùng mã thiết bị vui lòng nhập lại", ObjReturn = false };
                }

                var createDevice = new Device();
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
                createDevice.CreateDate = DateTime.UtcNow.AddHours(7);

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
                if (agencyDevices.Count <= 0)
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
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        GuarantyEndDate = item.GuarantyEndDate != null ? item.GuarantyEndDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate != null ? item.SettingDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty,
                        Other = item.Other,
                        CreateDate = item.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy") : string.Empty
                    });
                }

                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy thiết bị" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<bool> RemoveDevice(int device_id)
        {
            var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
            var device = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceId == device_id);
            try
            {
                Deactivate(device);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa thiết bị thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa thiết bị thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
        public ResponseObject<bool> UpdateDevice(AgencyDeviceAPIViewModel model)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var updateDevice = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceId == model.DeviceId);

                if (updateDevice != null)
                {
                    updateDevice.DeviceTypeId = model.DeviceTypeId;
                    updateDevice.DeviceName = model.DeviceName;
                    updateDevice.DeviceCode = model.DeviceCode;
                    updateDevice.GuarantyStartDate = model.GuarantyStartDate.ToDateTime();
                    updateDevice.GuarantyEndDate = model.GuarantyEndDate.ToDateTime();
                    updateDevice.Ip = model.Ip;
                    updateDevice.Port = model.Port;
                    updateDevice.DeviceAccount = model.DeviceAccount;
                    updateDevice.DevicePassword = model.DevicePassword;
                    updateDevice.Other = model.Other;
                    updateDevice.UpdateDate = DateTime.UtcNow.AddHours(7);

                    deviceRepo.Edit(updateDevice);
                    deviceRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa thiết bị thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa thiết bị thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa thiết bị thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }            
        }

        public ResponseObject<bool> UpdateDeviceForAgency(DeviceAPIViewModel model)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var updateDevice = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceId == model.DeviceId);

                if (updateDevice != null)
                {
                    updateDevice.DeviceTypeId = model.DeviceTypeId;
                    updateDevice.DeviceName = model.DeviceName;
                    updateDevice.DeviceCode = model.DeviceCode;
                    updateDevice.GuarantyStartDate = model.GuarantyStartDate.ToDateTime();
                    updateDevice.GuarantyEndDate = model.GuarantyEndDate.ToDateTime();
                    updateDevice.Ip = model.Ip;
                    updateDevice.Port = model.Port;
                    updateDevice.DeviceAccount = model.DeviceAccount;
                    updateDevice.DevicePassword = model.DevicePassword;
                    updateDevice.Other = model.Other;
                    updateDevice.UpdateDate = DateTime.UtcNow.AddHours(7);

                    deviceRepo.Edit(updateDevice);
                    deviceRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa thiết bị thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa thiết bị thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa thiết bị thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }        
    }
}

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

    }
}

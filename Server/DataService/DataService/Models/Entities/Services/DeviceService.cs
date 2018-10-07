using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
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
        List<AgencyDeviceAPIViewModel> ViewAllDevice(int agency_id);
    }

    public partial class DeviceService
    {
        public List<AgencyDeviceAPIViewModel> ViewAllDevice(int agency_id)
        {
            List<AgencyDeviceAPIViewModel> rsList = new List<AgencyDeviceAPIViewModel>();
            var agencyDeviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
            var agencyDevices = agencyDeviceRepo.GetActive().ToList();
            foreach (var item in agencyDevices)
            {
                if (agency_id == item.AgencyId)
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

            }

            return rsList;
        }

    }
}

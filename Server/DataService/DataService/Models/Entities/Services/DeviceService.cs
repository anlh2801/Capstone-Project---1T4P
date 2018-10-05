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
            var agencyDevice = agencyDeviceRepo.GetActive().ToList();
            foreach (var item in agencyDevice)
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
                        GuarantyStartDate = item.GuarantyStartDate.Value.ToString("MM/dd/yyyy"),
                        GuarantyEndDate = item.GuarantyEndDate.Value.ToString("MM/dd/yyyy"),
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate.Value.ToString("MM/dd/yyyy"),
                        Other = item.Other,
                        CreateDate = item.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("MM/dd/yyyy")
                    });
                }

            }

            return rsList;
        }

    }
}

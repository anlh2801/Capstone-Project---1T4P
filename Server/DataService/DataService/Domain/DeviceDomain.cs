using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
 
    public interface IDeviceDomain
    {
        ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyId(int agency_id);
        ResponseObject<List<DeviceAPIViewModel>> GetAllDevice();
        ResponseObject<bool> CreateDevice(DeviceAPIViewModel model);
        ResponseObject<DeviceAPIViewModel> ViewDetail(int device_id);
    }

    public class DeviceDomain : BaseDomain, IDeviceDomain
    {
        public ResponseObject<bool> CreateDevice(DeviceAPIViewModel model)
        {
                var deviceService = this.Service<IDeviceService>();

                var result = deviceService.CreateDevice(model);

                return result;
        }

        public ResponseObject<List<DeviceAPIViewModel>> GetAllDevice()
        {
            var deviceService = this.Service<IDeviceService>();

            var devices = deviceService.GetAllDevice();

            return devices;
        }

        public ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyId(int agency_id)
        {
            var deviceService = this.Service<IDeviceService>();

            var devices = deviceService.ViewAllDeviceByAgencyId(agency_id);

            return devices;
        }

        public ResponseObject<DeviceAPIViewModel> ViewDetail(int device_id)
        {
            var deviceService = this.Service<IDeviceService>();

            var contract = deviceService.ViewDetail(device_id);

            return contract;
        }
    }
    
}

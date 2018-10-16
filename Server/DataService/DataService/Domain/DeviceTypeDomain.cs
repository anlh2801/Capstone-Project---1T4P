using System;
using DataService.APIViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Models.Entities.Services;

namespace DataService.Domain
{

    public interface IDeviceTypeDomain
    {

        List<DeviceTypeAPIViewModel> GetAllDeviceType();
        DeviceTypeAPIViewModel ViewDetail(int devicetype_id);
        bool CreateDeviceType(DeviceTypeAPIViewModel model);
        bool UpdateDeviceType(DeviceTypeAPIViewModel model);
        bool RemoveDeviceType(int devicetype_id);
    }

    public class DeviceTypeDomain : BaseDomain, IDeviceTypeDomain
    {
        public bool CreateDeviceType(DeviceTypeAPIViewModel model)
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var result = deviceTypeService.CreateDeviceType(model);

            return result;
        }

        public List<DeviceTypeAPIViewModel> GetAllDeviceType()
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var deviceTypes = deviceTypeService.GetAllDeviceType();
            
            return deviceTypes;
        }

        public bool RemoveDeviceType(int devicetype_id)
        {
            var devicetypeList = new List<DeviceTypeAPIViewModel>();

            var deviceTypeService = this.Service<IDeviceTypeService>();
            bool a = deviceTypeService.RemoveDeviceType(devicetype_id);
            return a;
        }

        public bool UpdateDeviceType(DeviceTypeAPIViewModel model)
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var result = deviceTypeService.UpdateDeviceType(model);

            return result;
        }

        public DeviceTypeAPIViewModel ViewDetail(int devicetype_id)
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var devicetype = deviceTypeService.ViewDetail(devicetype_id);

            return devicetype;
        }
    }
}

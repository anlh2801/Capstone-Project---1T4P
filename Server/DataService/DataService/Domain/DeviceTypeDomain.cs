using System;
using DataService.APIViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;

namespace DataService.Domain
{
    public interface IDeviceTypeDomain
    {

        ResponseObject<List<DeviceTypeAPIViewModel>> GetAllDeviceType();
        ResponseObject<bool> CreateDeviceType(DeviceTypeAPIViewModel model);
        ResponseObject<bool> UpdateDeviceType(DeviceTypeAPIViewModel model);
        ResponseObject<DeviceTypeAPIViewModel> ViewDetail(int devicetype_id);
        ResponseObject<bool> RemoveDeviceType(int devicetype_id);
    }

    public class DeviceTypeDomain : BaseDomain, IDeviceTypeDomain
    {
        public ResponseObject<List<DeviceTypeAPIViewModel>> GetAllDeviceType()
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var deviceTypes = deviceTypeService.GetAllDeviceType();

            return deviceTypes;
        }
        public ResponseObject<bool> CreateDeviceType(DeviceTypeAPIViewModel model)
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var result = deviceTypeService.CreateDeviceType(model);

            return result;
        }
        public ResponseObject<bool> UpdateDeviceType(DeviceTypeAPIViewModel model)
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var result = deviceTypeService.UpdateDeviceType(model);

            return result;
        }

        public ResponseObject<DeviceTypeAPIViewModel> ViewDetail(int devicetype_id)
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var devicetype = deviceTypeService.ViewDetail(devicetype_id);

            return devicetype;
        }
        public ResponseObject<bool> RemoveDeviceType(int devicetype_id)
        {
            var devicetypeList = new List<DeviceTypeAPIViewModel>();

            var devicetypeService = this.Service<IDeviceTypeService>();
            var rs = devicetypeService.RemoveDeviceType(devicetype_id);
            return rs;
        }
    }
}

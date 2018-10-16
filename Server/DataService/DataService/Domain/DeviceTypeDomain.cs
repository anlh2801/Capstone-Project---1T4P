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
    }

    public class DeviceTypeDomain : BaseDomain, IDeviceTypeDomain
    {
        public ResponseObject<List<DeviceTypeAPIViewModel>> GetAllDeviceType()
        {
            var deviceTypeService = this.Service<IDeviceTypeService>();

            var deviceTypes = deviceTypeService.GetAllDeviceType();

            return deviceTypes;
        }
    }
}

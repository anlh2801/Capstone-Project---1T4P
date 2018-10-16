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
    }

    public partial class DeviceTypeService
    {
        public ResponseObject<List<DeviceTypeAPIViewModel>> GetAllDeviceType()
        {
            List<DeviceTypeAPIViewModel> rsList = new List<DeviceTypeAPIViewModel>();
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetypes = devicetypeRepo.GetActive().ToList();
            if (devicetypes.Count < 0)
            {
                return new ResponseObject<List<DeviceTypeAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy loại thiết bị nào" };
            }
            foreach (var item in devicetypes)
            {
                rsList.Add(new DeviceTypeAPIViewModel
                {
                    DeviceTypeId = item.DeviceTypeId,
                    DeviceTypeName = item.DeviceTypeName,

                });
            }

            return new ResponseObject<List<DeviceTypeAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
        }
    }
}

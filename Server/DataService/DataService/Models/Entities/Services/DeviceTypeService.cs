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

    public partial interface IDeviceTypeService
    {
        List<DeviceTypeAPIViewModel> GetAllDeviceType();
    }

    public partial class DeviceTypeService
    {
        public List<DeviceTypeAPIViewModel> GetAllDeviceType()
        {
            List<DeviceTypeAPIViewModel> rsList = new List<DeviceTypeAPIViewModel>();
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetypes = devicetypeRepo.GetActive().ToList();
            foreach (var item in devicetypes)
            {
                rsList.Add(new DeviceTypeAPIViewModel
                {
                    DeviceTypeId = item.DeviceTypeId,
                    DeviceTypeName = item.DeviceTypeName,

                });
            }

            return rsList;
        }
    }
}

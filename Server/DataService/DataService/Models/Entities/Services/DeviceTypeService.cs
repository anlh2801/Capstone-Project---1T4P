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
        List<DeviceTypeViewModel> GetAllDeviceType();
    }

    public partial class DeviceTypeService
    {
        public List<DeviceTypeViewModel> GetAllDeviceType()
        {
            List<DeviceTypeViewModel> rsList = new List<DeviceTypeViewModel>();
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetypes = devicetypeRepo.GetActive().ToList();
            foreach (var item in devicetypes)
            {
                var a = new DeviceTypeViewModel(item);
                rsList.Add(a);
            }

            return rsList;
        }
    }
}

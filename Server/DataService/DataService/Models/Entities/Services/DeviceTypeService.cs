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
        DeviceTypeAPIViewModel ViewDetail(int devicetype_id);
        bool CreateDeviceType(DeviceTypeAPIViewModel model);
        bool UpdateDeviceType(DeviceTypeAPIViewModel model);
        bool RemoveDeviceType(int devicetype_id);

    }

    public partial class DeviceTypeService
    {
        public List<DeviceTypeAPIViewModel> GetAllDeviceType()
        {
            List<DeviceTypeAPIViewModel> rsList = new List<DeviceTypeAPIViewModel>();
            var contractRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var contracts = contractRepo.GetActive().ToList();
            int count = 1;
            foreach (var item in contracts)
            {
                if (!item.IsDelete)
                {
                    rsList.Add(new DeviceTypeAPIViewModel
                    {
                        NumericalOrder = count,
                        DeviceTypeId = item.DeviceTypeId,
                        DeviceTypeName = item.DeviceTypeName,
                        Description = item.Description,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.Value.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("dd/MM/yyyy"),
                    });
                }
                count++;
            }

            return rsList;
        }
        public DeviceTypeAPIViewModel ViewDetail(int devicetype_id)
        {
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetype = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == devicetype_id);
            if (devicetype != null)
            {
                var deviceTypeAPIViewModel = new DeviceTypeAPIViewModel
                {
                    DeviceTypeId = devicetype.DeviceTypeId,
                    DeviceTypeName = devicetype.DeviceTypeName,
                    Description = devicetype.Description,
                    CreateDate = devicetype.CreateDate.Value.ToString("dd/MM/yyyy"),
                    UpdateDate = devicetype.UpdateDate.Value.ToString("dd/MM/yyyy"),
                };
                return deviceTypeAPIViewModel;
            }
            return null;
        }
        public bool CreateDeviceType(DeviceTypeAPIViewModel model)
        {

            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var createDeviceType = new DeviceType();

            try
            {
                createDeviceType.DeviceTypeId = model.DeviceTypeId;
                createDeviceType.DeviceTypeName = model.DeviceTypeName;
                createDeviceType.Description = model.Description;
                createDeviceType.IsDelete = false;
                createDeviceType.CreateDate = DateTime.Now;
                createDeviceType.UpdateDate = DateTime.Now;

                devicetypeRepo.Add(createDeviceType);

                devicetypeRepo.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        public bool UpdateDeviceType(DeviceTypeAPIViewModel model)
        {
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var updateDeviceType = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == model.DeviceTypeId);

            if (updateDeviceType != null)
            {
                updateDeviceType.DeviceTypeName = model.DeviceTypeName;
                updateDeviceType.Description = model.Description;
                updateDeviceType.UpdateDate = DateTime.Now;

                devicetypeRepo.Edit(updateDeviceType);
                devicetypeRepo.Save();
                return true;
            }

            return false;
        }
        public bool RemoveDeviceType(int devicetype_id)
        {
            var devicetypeRepo = DependencyUtils.Resolve<IDeviceTypeRepository>();
            var devicetype = devicetypeRepo.GetActive().SingleOrDefault(a => a.DeviceTypeId == devicetype_id);
            Deactivate(devicetype);
            return true;
        }
    }
}

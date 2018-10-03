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
    }

    public class DeviceTypeDomain : BaseDomain, IDeviceTypeDomain
    {
        public List<DeviceTypeAPIViewModel> GetAllDeviceType()
        {
            var companyList = new List<DeviceTypeAPIViewModel>();

            var companyService = this.Service<IDeviceTypeService>();

            var companies = companyService.GetAllDeviceType();
            foreach (var item in companies)
            {
                companyList.Add(new DeviceTypeAPIViewModel
                {
                    DeviceTypeId = item.DeviceTypeId,
                    DeviceTypeName = item.DeviceTypeName,
                    
                });
            }
            return companyList;
        }
    }
}

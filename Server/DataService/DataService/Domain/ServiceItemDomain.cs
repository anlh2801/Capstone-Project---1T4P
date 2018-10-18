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
    public interface IServiceItemDomain
    {
        ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId);

    }

    public class ServiceItemDomain : BaseDomain, IServiceItemDomain
    {

        public ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId)
        {
            var serviceITSupportService = this.Service<IServiceItemService>();

            var serviceITSupports = serviceITSupportService.GetAllServiceItemByServiceId(serviceId);

            return serviceITSupports;
        }

    }
}


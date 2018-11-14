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
        ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceITSupportId(int serviceITSupportId);

        ResponseObject<ServiceItemAPIViewModel> ViewDetail(int ServiceItemId);

        ResponseObject<bool> UpdateServiceItem(ServiceItemUpdateAPIViewModel model);

        ResponseObject<bool> RemoveServiceItem(int serviceItem_Id);
    }

    public class ServiceItemDomain : BaseDomain, IServiceItemDomain
    {
        public ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId)
        {
            var serviceITSupportService = this.Service<IServiceItemService>();

            var serviceITSupports = serviceITSupportService.GetAllServiceItemByServiceId(serviceId);

            return serviceITSupports;
        }
        public ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceITSupportId(int serviceITSupportId)
        {
            var serviceITSupportService = this.Service<IServiceItemService>();

            var serviceITSupports = serviceITSupportService.GetAllServiceItemByServiceITSupportId(serviceITSupportId);

            return serviceITSupports;
        }

        public ResponseObject<ServiceItemAPIViewModel> ViewDetail(int ServiceItemId)
        {
            var serviceITSupportService = this.Service<IServiceItemService>();

            var serviceITSupports = serviceITSupportService.ViewDetail(ServiceItemId);

            return serviceITSupports;
        }

        public ResponseObject<bool> UpdateServiceItem(ServiceItemUpdateAPIViewModel model)
        {
            var serviceItemService = this.Service<IServiceItemService>();

            var result = serviceItemService.UpdateServiceItem(model);

            return result;
        }

        public ResponseObject<bool> RemoveServiceItem(int serviceItem_Id)
        {
            var serviceItemList = new List<ServiceItemAPIViewModel>();

            var serviceItemService = this.Service<IServiceItemService>();
            var rs = serviceItemService.RemoveServiceItem(serviceItem_Id);
            return rs;
        }
    }
}


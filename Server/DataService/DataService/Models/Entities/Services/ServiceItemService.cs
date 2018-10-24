using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IServiceItemService
    {
        ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId);

    }
    public partial class ServiceItemService
    {
        public ResponseObject<List<ServiceItemAPIViewModel>> GetAllServiceItemByServiceId(int serviceId)
        {
            List<ServiceItemAPIViewModel> rsList = new List<ServiceItemAPIViewModel>();
            var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
            var serviceItems = serviceItemRepo.GetActive(p => p.ServiceITSupportId == serviceId).ToList();
            if (serviceItems.Count <= 0)
            {
                return new ResponseObject<List<ServiceItemAPIViewModel>> { IsError = true, WarningMessage = "Không có dịch vụ nào hỗ trợ" };
            }
            int count = 1;
            foreach (var item in serviceItems)
            {
                rsList.Add(new ServiceItemAPIViewModel
                {
                    NumericalOrder = count,
                    ServiceId = item.ServiceITSupportId,
                    ServiceItemId = item.ServiceItemId,
                    ServiceItemName = item.ServiceItemName,
                    ServiceItemPrice = item.Price ?? item.Price.Value,
                    Description = item.Description,
                    CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                    UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                });

                count++;
            }

            return new ResponseObject<List<ServiceItemAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị danh sách dịch vụ" };
        }

    }
}

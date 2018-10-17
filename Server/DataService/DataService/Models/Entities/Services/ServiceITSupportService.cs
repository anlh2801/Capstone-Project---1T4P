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
    public partial interface IServiceITSupportService
    {
        ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport();
    }
    public partial class ServiceITSupportService
    {
        public ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport()
        {
            List<ServiceITSupportAPIViewModel> rsList = new List<ServiceITSupportAPIViewModel>();
            var serviceITSupportRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
            var serviceITSupports = serviceITSupportRepo.GetActive().ToList();
            if (serviceITSupports.Count < 0)
            {
                return new ResponseObject<List<ServiceITSupportAPIViewModel>> { IsError = true, WarningMessage = "Không có hợp đồng" };
            }
            int count = 1;
            foreach (var item in serviceITSupports)
            {
                if (!item.IsDelete)
                {
                    rsList.Add(new ServiceITSupportAPIViewModel
                    {
                        NumericalOrder = count,
                        ServiceITSupportId = item.ServiceITSupportId,
                        ServiceName = item.ServiceName,
                        Description = item.Description,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.Value.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("dd/MM/yyyy")
                    });
                }
                count++;
            }

            return new ResponseObject<List<ServiceITSupportAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị hợp đồng thành công" };
        }

    }
}

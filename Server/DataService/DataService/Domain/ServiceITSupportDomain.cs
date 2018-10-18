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
    public interface IServiceITSupportDomain
    {
        ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport();
        ResponseObject<ServiceITSupportAPIViewModel> ViewDetail(int serviceitsupport_id);
        ResponseObject<bool> CreateServiceITSupport(ServiceITSupportAPIViewModel model);
        ResponseObject<bool> UpdateServiceITSupport(ServiceITSupportAPIViewModel model);
        ResponseObject<bool> RemoveServiceITSupport(int serviceitsupport_id);
        ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupportByAgencyId(int agencyId);
    }

    public class ServiceITSupportDomain : BaseDomain, IServiceITSupportDomain
    {
        
        public ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport()
        {
            var serviceITSupportService = this.Service<IServiceITSupportService>();

            var serviceITSupports = serviceITSupportService.GetAllServiceITSupport();

            return serviceITSupports;
        }

        public ResponseObject<bool> CreateServiceITSupport(ServiceITSupportAPIViewModel model)
        {
            var serviceITSupportService = this.Service<IServiceITSupportService>();

            var result = serviceITSupportService.CreateServiceITSupport(model);

            return result;
        }

        public ResponseObject<bool> RemoveServiceITSupport(int serviceitsupport_id)
        {
            var serviceitsupportList = new List<ServiceITSupportAPIViewModel>();

            var serviceITSupportService = this.Service<IServiceITSupportService>();
            var rs = serviceITSupportService.RemoveServiceITSupport(serviceitsupport_id);
            return rs;
        }

        public ResponseObject<bool> UpdateServiceITSupport(ServiceITSupportAPIViewModel model)
        {
            var serviceITSupportService = this.Service<IServiceITSupportService>();

            var result = serviceITSupportService.UpdateServiceITSupport(model);

            return result;
        }

        public ResponseObject<ServiceITSupportAPIViewModel> ViewDetail(int serviceitsupport_id)
        {
            var serviceITSupportService = this.Service<IServiceITSupportService>();

            var serviceitsupport = serviceITSupportService.ViewDetail(serviceitsupport_id);

            return serviceitsupport;
        }

        public ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupportByAgencyId(int agencyId)
        {
            var serviceITSupportService = this.Service<IServiceITSupportService>();

            var serviceITSupports = serviceITSupportService.GetAllServiceITSupportByAgencyId(agencyId);

            return serviceITSupports;
        }
    }
}


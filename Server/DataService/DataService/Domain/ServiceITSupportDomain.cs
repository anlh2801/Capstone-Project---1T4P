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
    }

    public class ServiceITSupportDomain : BaseDomain, IServiceITSupportDomain
    {
        public ResponseObject<List<ServiceITSupportAPIViewModel>> GetAllServiceITSupport()
        {
            var serviceITSupportService = this.Service<IServiceITSupportService>();

            var serviceITSupports = serviceITSupportService.GetAllServiceITSupport();

            return serviceITSupports;
        }
    }
}


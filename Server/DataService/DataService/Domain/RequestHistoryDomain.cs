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
    
    public interface IRequestHistoryDomain
    {
        ResponseObject<List<RequestHistoryAPIViewModel>> GetRequestHistoryByRequestId(int requestId);

        ResponseObject<List<RequestHistoryAPIViewModel>> GetAllRequestHistory();
    };

    public class RequestHistoryDomain : BaseDomain, IRequestHistoryDomain
    {
        public ResponseObject<List<RequestHistoryAPIViewModel>> GetRequestHistoryByRequestId(int requestId)
        {
            var requestHistoryService = this.Service<IRequestHistoryService>();
            var rs = requestHistoryService.GetRequestHistoryByRequestId(requestId);
            return rs;
        }

        public ResponseObject<List<RequestHistoryAPIViewModel>> GetAllRequestHistory()
        {
            var requestHistoryService = this.Service<IRequestHistoryService>();
            var rs = requestHistoryService.GetAllRequestHistory();
            return rs;
        }
    }
}

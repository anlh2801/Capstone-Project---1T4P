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
    public partial interface IRequestHistoryService
    {
        ResponseObject<List<RequestHistoryAPIViewModel>> GetRequestHistoryByRequestId(int requestId);

        ResponseObject<List<RequestHistoryAPIViewModel>> GetAllRequestHistory();
    }

    public partial class RequestHistoryService
    {
        public ResponseObject<List<RequestHistoryAPIViewModel>> GetRequestHistoryByRequestId(int requestId)
        {
            try
            {
                List<RequestHistoryAPIViewModel> rsList = new List<RequestHistoryAPIViewModel>();
                var requestHistoryRepo = DependencyUtils.Resolve<IRequestHistoryRepository>();
                var requestHistoryOfRequest = requestHistoryRepo.GetActive().Where(p => p.RequestId == requestId).ToList();
                if (requestHistoryOfRequest.Count <= 0)
                {
                    return new ResponseObject<List<RequestHistoryAPIViewModel>> { IsError = false, WarningMessage = "Lịch sử yêu cầu thất bại" };
                }
                foreach (var item in requestHistoryOfRequest)
                {
                    rsList.Add(new RequestHistoryAPIViewModel
                    {
                        RequestHistoryId = item.RequestHistoryId,
                        RequestId = item.RequestId,
                        PreSupporter_Name = item.ITSupporter != null ? item.ITSupporter.ITSupporterName : string.Empty,
                        StartDate = item.StartTime != null ? item.StartTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        EndDate = item.EndTime != null ? item.EndTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                    });
                }

                return new ResponseObject<List<RequestHistoryAPIViewModel>> { IsError = false, SuccessMessage = "Lịch sử yêu cầu thành công", ObjReturn = rsList };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<RequestHistoryAPIViewModel>> { IsError = false, WarningMessage = "Lịch sử yêu cầu thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<RequestHistoryAPIViewModel>> GetAllRequestHistory()
        {
            try
            {
                List<RequestHistoryAPIViewModel> rsList = new List<RequestHistoryAPIViewModel>();
                var requestHistoryRepo = DependencyUtils.Resolve<IRequestHistoryRepository>();
                var requestHistoryOfTicket = requestHistoryRepo.GetActive().ToList();
                if (requestHistoryOfTicket.Count <= 0)
                {
                    return new ResponseObject<List<RequestHistoryAPIViewModel>> { IsError = true, SuccessMessage = "Lấy lịch sử thất bại" };
                }
                foreach (var item in requestHistoryOfTicket)
                {
                    rsList.Add(new RequestHistoryAPIViewModel
                    {
                        RequestHistoryId = item.RequestHistoryId,
                        RequestId = item.RequestId,
                        PreSupporter_Name = item.ITSupporter != null ? item.ITSupporter.ITSupporterName : string.Empty,
                        StartDate = item.StartTime != null ? item.StartTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        EndDate = item.EndTime != null ? item.EndTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                    });
                }

                return new ResponseObject<List<RequestHistoryAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Lấy lịch sử thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<RequestHistoryAPIViewModel>> { IsError = true, SuccessMessage = "Lấy lịch sử thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
    }
}

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
    public partial interface ITicketHistoryService
    {
        ResponseObject<List<TicketHistoryAPIViewModel>> GetTicketHistoryByTicketId(int ticketId);

        ResponseObject<List<TicketHistoryAPIViewModel>> GetAllTicketHistory();
    }

    public partial class TicketHistoryService
    {
        public ResponseObject<List<TicketHistoryAPIViewModel>> GetTicketHistoryByTicketId(int ticketId)
        {
            try
            {
                List<TicketHistoryAPIViewModel> rsList = new List<TicketHistoryAPIViewModel>();
                var ticketHistoryRepo = DependencyUtils.Resolve<ITicketHistoryRepository>();
                var ticketHistoryOfTicket = ticketHistoryRepo.GetActive().Where(p => p.TicketId == ticketId).ToList();
                if (ticketHistoryOfTicket.Count <= 0)
                {
                    return new ResponseObject<List<TicketHistoryAPIViewModel>> { IsError = false, WarningMessage = "Lịch sử yêu cầu thất bại" };
                }
                foreach (var item in ticketHistoryOfTicket)
                {
                    rsList.Add(new TicketHistoryAPIViewModel
                    {
                        TicketHistoryId = item.TicketHistoryId,
                        TicketId = item.TicketId,
                        PreSupporter_Name = item.ITSupporter != null ? item.ITSupporter.ITSupporterName : string.Empty,
                        StartDate = item.StartTime != null ? item.StartTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        EndDate = item.EndTime != null ? item.EndTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                    });
                }

                return new ResponseObject<List<TicketHistoryAPIViewModel>> { IsError = false, SuccessMessage = "Lịch sử yêu cầu thành công", ObjReturn = rsList };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<TicketHistoryAPIViewModel>> { IsError = false, WarningMessage = "Lịch sử yêu cầu thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<TicketHistoryAPIViewModel>> GetAllTicketHistory()
        {
            try
            {
                List<TicketHistoryAPIViewModel> rsList = new List<TicketHistoryAPIViewModel>();
                var ticketHistoryRepo = DependencyUtils.Resolve<ITicketHistoryRepository>();
                var ticketHistoryOfTicket = ticketHistoryRepo.GetActive().ToList();
                if (ticketHistoryOfTicket.Count <= 0)
                {
                    return new ResponseObject<List<TicketHistoryAPIViewModel>> { IsError = true, SuccessMessage = "Lấy lịch sử thất bại" };
                }
                foreach (var item in ticketHistoryOfTicket)
                {
                    rsList.Add(new TicketHistoryAPIViewModel
                    {
                        TicketHistoryId = item.TicketHistoryId,
                        TicketId = item.TicketId,
                        PreSupporter_Name = item.ITSupporter != null ? item.ITSupporter.ITSupporterName : string.Empty,
                        StartDate = item.StartTime != null ? item.StartTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        EndDate = item.EndTime != null ? item.EndTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                    });
                }

                return new ResponseObject<List<TicketHistoryAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Lấy lịch sử thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<TicketHistoryAPIViewModel>> { IsError = true, SuccessMessage = "Lấy lịch sử thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
    }
}

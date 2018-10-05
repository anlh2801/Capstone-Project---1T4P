using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
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
        List<TicketHistoryAPIViewModel> GetTicketHistoryByTicketId(int ticketId);

        List<TicketHistoryAPIViewModel> GetAllTicketHistory();
    }

    public partial class TicketHistoryService
    {
        public List<TicketHistoryAPIViewModel> GetTicketHistoryByTicketId(int ticketId)
        {
            List<TicketHistoryAPIViewModel> rsList = new List<TicketHistoryAPIViewModel>();
            var ticketHistoryRepo = DependencyUtils.Resolve<ITicketHistoryRepository>();
            var ticketHistoryOfTicket = ticketHistoryRepo.GetActive().Where(p => p.TicketId == ticketId).ToList();

            foreach (var item in ticketHistoryOfTicket)
            {
                rsList.Add(new TicketHistoryAPIViewModel
                {
                    TicketHistoryId = item.TicketHistoryId,
                    TicketId = item.TicketId,
                    PreSupporter_Name = item.ITSupporter != null ? item.ITSupporter.ITSupporterName : string.Empty,
                    StartDate = item.StartDate != null ? item.StartDate.Value.ToString("MM/dd/yyyy"): string.Empty,
                    EndDate = item.EndDate != null ? item.EndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                });
            }

            return rsList;
        }

        public List<TicketHistoryAPIViewModel> GetAllTicketHistory()
        {
            List<TicketHistoryAPIViewModel> rsList = new List<TicketHistoryAPIViewModel>();
            var ticketHistoryRepo = DependencyUtils.Resolve<ITicketHistoryRepository>();
            var ticketHistoryOfTicket = ticketHistoryRepo.GetActive().ToList();

            foreach (var item in ticketHistoryOfTicket)
            {
                rsList.Add(new TicketHistoryAPIViewModel
                {
                    TicketHistoryId = item.TicketHistoryId,
                    TicketId = item.TicketId,
                    PreSupporter_Name = item.ITSupporter != null ? item.ITSupporter.ITSupporterName : string.Empty,
                    StartDate = item.StartDate != null ? item.StartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    EndDate = item.EndDate != null ? item.EndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                });
            }

            return rsList;
        }
    }
}

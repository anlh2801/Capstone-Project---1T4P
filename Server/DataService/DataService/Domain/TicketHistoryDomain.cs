using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    
    public interface ITicketHistoryDomain
    {
        List<TicketHistoryAPIViewModel> GetTicketHistoryByTicketId(int ticketId);

        List<TicketHistoryAPIViewModel> GetAllTicketHistory();
    };

    public class TicketHistoryDomain : BaseDomain, ITicketHistoryDomain
    {
        public List<TicketHistoryAPIViewModel> GetTicketHistoryByTicketId(int ticketId)
        {
            var ticketHistoryService = this.Service<ITicketHistoryService>();
            var rs = ticketHistoryService.GetTicketHistoryByTicketId(ticketId);
            return rs;
        }

        public List<TicketHistoryAPIViewModel> GetAllTicketHistory()
        {
            var ticketHistoryService = this.Service<ITicketHistoryService>();
            var rs = ticketHistoryService.GetAllTicketHistory();
            return rs;
        }
    }
}

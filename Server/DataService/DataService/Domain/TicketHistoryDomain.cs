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
    
    public interface ITicketHistoryDomain
    {
        ResponseObject<List<TicketHistoryAPIViewModel>> GetTicketHistoryByTicketId(int ticketId);

        ResponseObject<List<TicketHistoryAPIViewModel>> GetAllTicketHistory();
    };

    public class TicketHistoryDomain : BaseDomain, ITicketHistoryDomain
    {
        public ResponseObject<List<TicketHistoryAPIViewModel>> GetTicketHistoryByTicketId(int ticketId)
        {
            var ticketHistoryService = this.Service<ITicketHistoryService>();
            var rs = ticketHistoryService.GetTicketHistoryByTicketId(ticketId);
            return rs;
        }

        public ResponseObject<List<TicketHistoryAPIViewModel>> GetAllTicketHistory()
        {
            var ticketHistoryService = this.Service<ITicketHistoryService>();
            var rs = ticketHistoryService.GetAllTicketHistory();
            return rs;
        }
    }
}

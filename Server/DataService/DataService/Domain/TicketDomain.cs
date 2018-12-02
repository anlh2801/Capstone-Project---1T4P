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
    
    public interface ITicketDetailDomain
    {
        ResponseObject<bool> CreateRatingForHero(RatingAPIViewModel rate);
        ResponseObject<bool> DeleteTicket(int ticketId);
    };

    public class TicketDomain : BaseDomain, ITicketDetailDomain
    {
        public ResponseObject<bool> CreateRatingForHero(RatingAPIViewModel rate)
        {
            var ticketService = this.Service<ITicketService>();
            var rs = ticketService.CreateRatingForHero(rate);
            return rs;
        }

        public ResponseObject<bool> DeleteTicket(int ticketId)
        {
            var ticketService = this.Service<ITicketService>();
            var rs = ticketService.DeleteTicket(ticketId);
            return rs;
        }
    }
}

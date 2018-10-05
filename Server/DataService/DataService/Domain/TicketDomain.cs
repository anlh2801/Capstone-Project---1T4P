using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    
    public interface ITicketDetailDomain
    {
        bool CreateRatingForHero(RatingAPIViewModel rate);
    };

    public class TicketDomain : BaseDomain, ITicketDetailDomain
    {
        public bool CreateRatingForHero(RatingAPIViewModel rate)
        {
            var ticketDetailService = this.Service<ITicketService>();
            var rs = ticketDetailService.CreateRatingForHero(rate);
            return rs;
        }
    }
}

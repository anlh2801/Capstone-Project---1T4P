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
    public partial interface ITicketDetailService
    {
        bool CreateRatingForHero(RatingAPIViewModel rate);
    }

    public partial class TicketDetailService
    {
        public bool CreateRatingForHero(RatingAPIViewModel rate)
        {
            var ticketDetailRepo = DependencyUtils.Resolve<ITicketDetailRepository>();
            var itSupporterlRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var ticketDetails = ticketDetailRepo.GetActive(p => p.TicketId == rate.TicketId &&
                                                           p.CurrentITSupporter_Id == rate.CurrentITSupporter_Id &&
                                                           p.ServiceItemId == rate.ServiceItemId).SingleOrDefault();
            var itupporter = itSupporterlRepo.Get(rate.CurrentITSupporter_Id);

            if (ticketDetails != null && itupporter != null)
            {
                ticketDetails.Rating = rate.Rating;
                ticketDetails.Desciption = rate.Description;
                ticketDetailRepo.Edit(ticketDetails);
                ticketDetailRepo.Save();

                itupporter.RatingAVG = itupporter.RatingAVG != null ? (itupporter.RatingAVG + rate.Rating) / 2 : rate.Rating;
                itSupporterlRepo.Edit(itupporter);
                itSupporterlRepo.Save();

                return true;
            }
            return false;
        }
    }
}

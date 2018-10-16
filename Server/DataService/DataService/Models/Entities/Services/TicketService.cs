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
    public partial interface ITicketService
    {
        ResponseObject<bool> CreateRatingForHero(RatingAPIViewModel rate);
    }

    public partial class TicketService
    {
        public ResponseObject<bool> CreateRatingForHero(RatingAPIViewModel rate)
        {
            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var itSupporterlRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var ticketDetails = ticketRepo.GetActive(p => p.TicketId == rate.TicketId &&
                                                           p.CurrentITSupporter_Id == rate.CurrentITSupporter_Id &&
                                                           p.Request.ServiceItemId == rate.ServiceItemId).SingleOrDefault();
            var itupporter = itSupporterlRepo.Get(rate.CurrentITSupporter_Id);

            if (ticketDetails != null && itupporter != null)
            {
                ticketDetails.Rating = rate.Rating;
                ticketDetails.Desciption = rate.Description;
                ticketDetails.UpdateDate = DateTime.Now;
                ticketRepo.Edit(ticketDetails);
                ticketRepo.Save();

                itupporter.RatingAVG = itupporter.RatingAVG != null ? (itupporter.RatingAVG + rate.Rating) / 2 : rate.Rating;
                itupporter.UpdateDate = DateTime.Now;
                itSupporterlRepo.Edit(itupporter);
                itSupporterlRepo.Save();

                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Đánh giá thành công"};
            }
            return new ResponseObject<bool> { IsError = true, ObjReturn = false, SuccessMessage = "Đánh giá thất bại" }; 
        }
    }
}

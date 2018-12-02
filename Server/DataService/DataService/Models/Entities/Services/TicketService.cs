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

        ResponseObject<bool> DeleteTicket(int ticketId);
    }

    public partial class TicketService
    {
        public ResponseObject<bool> CreateRatingForHero(RatingAPIViewModel rate)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var itSupporterlRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var request = requestRepo.GetActive(p => p.RequestId == rate.RequestId
                                                            && p.RequestStatus == (int)RequestStatusEnum.Done).SingleOrDefault();
                if (request != null)
                {
                    var itupporter = itSupporterlRepo.Get(request.CurrentITSupporter_Id);

                    if (request != null && itupporter != null)
                    {
                        request.Rating = rate.Rating;
                        request.Feedback = rate.Description;
                        request.UpdateDate = DateTime.UtcNow.AddHours(7);
                        requestRepo.Edit(request);
                        requestRepo.Save();

                        itupporter.RatingAVG = itupporter.RatingAVG != null && itupporter.RatingAVG != 0 ? (itupporter.RatingAVG + rate.Rating) / 2 : rate.Rating;
                        itupporter.UpdateDate = DateTime.UtcNow.AddHours(7);
                        itSupporterlRepo.Edit(itupporter);
                        itSupporterlRepo.Save();

                        return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Đánh giá thành công" };
                    }
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, SuccessMessage = "Đánh giá thất bại" };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, ObjReturn = false, SuccessMessage = "Đánh giá thất bại", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> DeleteTicket(int ticketId)
        {
            try
            {
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var ticket = ticketRepo.GetActive(p => p.TicketId == ticketId).SingleOrDefault();
                if (ticket != null)
                {
                    ticketRepo.Deactivate(ticket);
                    ticketRepo.Save();
                    return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Đã xóa thiết bị khỏi báo cáo" };
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, SuccessMessage = "Yêu cầu thất bại" };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, ObjReturn = false, SuccessMessage = "Yêu cầu thất bại", ErrorMessage = e.ToString() };
            }
        }
    }
}

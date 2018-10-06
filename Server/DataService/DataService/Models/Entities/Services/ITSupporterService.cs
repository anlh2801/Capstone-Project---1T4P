using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IITSupporterService
    {
        
        bool UpdateTicketStatus(ITSupporterUpdateAPIViewModel model);

        List<ITSupporterAPIViewModel> ViewProfileITSupporter(int ITsupporter_id);

        List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id);

    }

    public partial class ITSupporterService
    {

        public bool UpdateTicketStatus(ITSupporterUpdateAPIViewModel model)
        {

            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var updateTicketStatus = ticketRepo.GetActive().SingleOrDefault(a => a.CurrentITSupporter_Id == model.ITSupporterId && a.TicketId == model.Ticket_Id);
            if (updateTicketStatus != null)
            {
                updateTicketStatus.Current_TicketStatus = model.Current_TicketStatus;
            
                ticketRepo.Edit(updateTicketStatus);

                ticketRepo.Save();
                return true;
            }

            return false;
        }

        public List<ITSupporterAPIViewModel> ViewProfileITSupporter(int ITsupporter_id)
        {
            List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var ITSupporter = ITSupporterRepo.GetActive().ToList();
            foreach (var item in ITSupporter)
            {
                if (ITsupporter_id == item.ITSupporterId)
                {
                    rsList.Add(new ITSupporterAPIViewModel
                    {
                        ITSupporterId = item.ITSupporterId,
                        ITSupporterName = item.ITSupporterName,
                        AccountId = item.AccountId ?? 0,
                        Telephone = item.Telephone,
                        Email = item.Email,
                        Gender = item.Gender,
                        Address = item.Address,
                        RatingAVG = item.RatingAVG ?? 0,
                        IsBusy = item.IsBusy,
                        CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }

            }

            return rsList;
        }

        public List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id)
        {
            List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var ticket = ticketRepo.GetActive().ToList();
            foreach (var item in ticket)
            {
                if (ITsupporter_id == item.CurrentITSupporter_Id)
                {
                    rsList.Add(new TicketAPIViewModel
                    {
                        TicketId = item.TicketId,
                        ServiceItemId = item.ServiceItemId,
                        RequestId = item.RequestId,
                        DeviceId = item.DeviceId,
                        Desciption = item.Desciption,
                        Current_TicketStatus = item.Current_TicketStatus ?? 0,
                        CurrentITSupporter_Id = item.CurrentITSupporter_Id,
                        Rating = item.Rating ?? 0,
                        Estimation = item.Estimation ?? 0,
                        StartTime = item.StartTime != null ? item.StartTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Endtime = item.Endtime != null ? item.Endtime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }

            }

            return rsList;
        }
    }
}

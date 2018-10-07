using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;

namespace DataService.Models.Entities.Services
{
    public partial interface IITSupporterService
    {
        List<ITSupporterAPIViewModel> GetAllITSupporter();

        bool UpdateTicketStatus(ITSupporterUpdateAPIViewModel model);

        ITSupporterAPIViewModel ViewProfileITSupporter(int itSupporter_id);

        List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id);
    }

    public partial class ITSupporterService
    {
        public List<ITSupporterAPIViewModel> GetAllITSupporter()
        {
            List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var companies = ITSupporterRepo.GetActive().ToList();

            foreach (var item in companies)
            {                
                rsList.Add(new ITSupporterAPIViewModel
                {
                    ITSupporterId = item.ITSupporterId,
                    ITSupporterName = item.ITSupporterName,
                    Username = item.Account.Username,
                    Telephone = item.Telephone,
                    Email = item.Email,
                    Gender = item.Gender,
                    Address = item.Address,
                    RatingAVG = item.RatingAVG,
                    IsBusy = item.IsBusy,
                    CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                });
            }

            return rsList;
        }

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

        public ITSupporterAPIViewModel ViewProfileITSupporter(int itSupporter_id)
        {
            
            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var itSupporter = ITSupporterRepo.GetActive().SingleOrDefault(i => i.ITSupporterId == itSupporter_id);
            if (itSupporter != null)
            {
                var itSupporterAPIViewModel = new ITSupporterAPIViewModel
                {
                    ITSupporterId = itSupporter.ITSupporterId,
                    ITSupporterName = itSupporter.ITSupporterName,
                    AccountId = itSupporter.AccountId ?? 0,
                    Telephone = itSupporter.Telephone,
                    Email = itSupporter.Email,
                    Gender = itSupporter.Gender,
                    Address = itSupporter.Address,
                    RatingAVG = itSupporter.RatingAVG ?? 0,
                    IsBusy = itSupporter.IsBusy,
                    CreateDate = itSupporter.CreateDate != null ? itSupporter.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    UpdateDate = itSupporter.UpdateDate != null ? itSupporter.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                };
                return itSupporterAPIViewModel;
            }

            return null;
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
                        Current_TicketStatus = item.Current_TicketStatus != null ? Enum.GetName(typeof(TicketStatusEnum), item.Current_TicketStatus) : string.Empty,
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

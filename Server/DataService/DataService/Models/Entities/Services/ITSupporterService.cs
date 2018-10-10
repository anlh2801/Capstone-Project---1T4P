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

        bool EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model);

        bool UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model);

        bool UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        bool CreateTask(ITSupporterCreateTaskAPIViewModel model);

        bool SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        bool SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        GuidelineAPIViewModel GetGuidelineByServiceItemID(int service_item_Id);

    }

    public partial class ITSupporterService
    {
        public List<ITSupporterAPIViewModel> GetAllITSupporter()
        {
            List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var itSupporters = ITSupporterRepo.GetActive().ToList();

            foreach (var item in itSupporters)
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
                    RatingAVG = item.RatingAVG ?? 0,
                    IsBusy = item.IsBusy.Value == true ? "Đang bận!" : "Chờ việc",
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
                    IsBusy = itSupporter.IsBusy.Value == true ? "Đang bận!" : "Chờ việc",
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

        public bool EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {

            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var updateEstimateTimeTicket = ticketRepo.GetActive().SingleOrDefault(a => a.CurrentITSupporter_Id == model.CurrentITSupporter_Id && a.TicketId == model.TicketId);
            if (updateEstimateTimeTicket != null)
            {
                updateEstimateTimeTicket.Estimation = model.Estimation;

                ticketRepo.Edit(updateEstimateTimeTicket);

                ticketRepo.Save();
                return true;
            }

            return false;
        }

        public bool UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model)
        {

            var ticketTaskRepo = DependencyUtils.Resolve<ITicketTaskRepository>();
            var updateTicketTaskStatus = ticketTaskRepo.GetActive().SingleOrDefault(a => a.TicketTaskId == model.TicketTaskId);
            if (updateTicketTaskStatus != null)
            {
                updateTicketTaskStatus.TaskStatus = model.TaskStatus;

                ticketTaskRepo.Edit(updateTicketTaskStatus);

                ticketTaskRepo.Save();
                return true;
            }

            return false;
        }

        public bool UpdateProfile(ITSupporterUpdateProfileAPIViewModel model)
        {

            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var updateProfile = ITSupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == model.ITSupporterId);
            if (updateProfile != null)
            {
                updateProfile.ITSupporterName = model.ITSupporterName;
                updateProfile.Telephone = model.ITSupporterName;
                updateProfile.Email = model.Email;
                updateProfile.Gender = model.Gender;
                updateProfile.Address = model.Address;
                updateProfile.UpdateDate = DateTime.Now;

                ITSupporterRepo.Edit(updateProfile);

                ITSupporterRepo.Save();
                return true;
            }

            return false;
        }

        public bool CreateTask(ITSupporterCreateTaskAPIViewModel model)
        {
            try
            {

                var ticketTaskRepo = DependencyUtils.Resolve<ITicketTaskRepository>();
                var createTask = new TicketTask();

                createTask.TicketId = model.TicketId;
                createTask.TaskStatus = model.TaskStatus;
                createTask.CreateByITSupporter = model.CreateByITSupporter;
                createTask.StartTime = DateTime.Parse(model.StartTime);
                createTask.EndTime = DateTime.Parse(model.EndTime);
                createTask.Priority = model.Priority;
                createTask.PreTaskCondition = model.PreTaskCondition;
                createTask.CreateDate = DateTime.Now;

                ticketTaskRepo.Add(createTask);

                ticketTaskRepo.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            
        }

        public bool SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model)
        {

                var ticketTaskRepo = DependencyUtils.Resolve<ITicketTaskRepository>();
                var setTimeTask = ticketTaskRepo.GetActive().SingleOrDefault(a => a.TicketTaskId == model.TicketTaskId);

                if (setTimeTask != null)
                {
                    setTimeTask.TicketTaskId = model.TicketTaskId;
                    setTimeTask.StartTime = DateTime.Parse(model.StartTime);
                    setTimeTask.EndTime = DateTime.Parse(model.EndTime);

                    ticketTaskRepo.Edit(setTimeTask);

                    ticketTaskRepo.Save();
                    return true;
                }

                return false;

            }

        public bool SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model)
        {

            var ticketTaskRepo = DependencyUtils.Resolve<ITicketTaskRepository>();
            var setPriorityTask = ticketTaskRepo.GetActive().SingleOrDefault(a => a.TicketTaskId == model.TicketTaskId);

            if (setPriorityTask != null)
            {
                setPriorityTask.TicketTaskId = model.TicketTaskId;
                setPriorityTask.Priority = model.Priority;

                ticketTaskRepo.Edit(setPriorityTask);

                ticketTaskRepo.Save();
                return true;
            }

            return false;

        }

        public GuidelineAPIViewModel GetGuidelineByServiceItemID(int service_item_Id)
        {

            var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
            var guideline = guidelineRepo.GetActive().SingleOrDefault(a => a.ServiceItemId == service_item_Id);
            if (guideline != null)
            {
                var GuidelineAPIViewModel = new GuidelineAPIViewModel
                {
                    GuidelineId = guideline.GuidelineId,
                    ServiceItemId = guideline.ServiceItemId ?? 0,
                    GuidelineName = guideline.GuidelineName,
                    StartDate = guideline.StartDate != null ? guideline.StartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    EndDate = guideline.EndDate != null ? guideline.EndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    CreateDate = guideline.CreateDate != null ? guideline.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    UpdateDate = guideline.UpdateDate != null ? guideline.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                };
                return GuidelineAPIViewModel;
            }

            return null;
        }

        
    }
}

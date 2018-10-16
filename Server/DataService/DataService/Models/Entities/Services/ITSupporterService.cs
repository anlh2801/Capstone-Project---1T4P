﻿using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
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
        ResponseObject<List<ITSupporterAPIViewModel>> GetAllITSupporter();

        ResponseObject<bool> UpdateTicketStatus(ITSupporterUpdateAPIViewModel model);

        ResponseObject<ITSupporterAPIViewModel> ViewProfileITSupporter(int itSupporter_id);

        ResponseObject<List<TicketAPIViewModel>> ViewAllOwnerTicket(int ITsupporter_id);

        ResponseObject<bool> EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model);

        ResponseObject<bool> UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model);

        ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model);

        ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        ResponseObject<GuidelineAPIViewModel> GetGuidelineByServiceItemID(int service_item_Id);

    }

    public partial class ITSupporterService
    {
        public ResponseObject<List<ITSupporterAPIViewModel>> GetAllITSupporter()
        {
            List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
            var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();

            try
            {
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
                        CreateDate = item.CreateDate != null ? item.CreateDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                    });
                }
                return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công"};
            }
            catch (Exception ex)
            {
                return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = true, ErrorMessage = ex.ToString(), WarningMessage = "Không tìm thấy người hỗ trợ" };
            }


        }

        public ResponseObject<bool> UpdateTicketStatus(ITSupporterUpdateAPIViewModel model)
        {
            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var updateTicketStatus = ticketRepo.GetActive().SingleOrDefault(a => a.CurrentITSupporter_Id == model.ITSupporterId && a.TicketId == model.Ticket_Id);
            if (updateTicketStatus != null)
            {
                updateTicketStatus.Current_TicketStatus = model.Current_TicketStatus;

                ticketRepo.Edit(updateTicketStatus);

                ticketRepo.Save();
                return new ResponseObject<bool> { IsError = false, ObjReturn = true , SuccessMessage = "Cập nhật trạng thái thành công"};
            }

            return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại" };
        }

        public ResponseObject<ITSupporterAPIViewModel> ViewProfileITSupporter(int itSupporter_id)
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
                return new ResponseObject<ITSupporterAPIViewModel> { IsError = false, ObjReturn = itSupporterAPIViewModel, SuccessMessage = "Thành công" };
            }

            return new ResponseObject<ITSupporterAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy người hỗ trợ" };
        }

        public ResponseObject<List<TicketAPIViewModel>> ViewAllOwnerTicket(int ITsupporter_id)
        {
            List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var ticket = ticketRepo.GetActive(p => p.CurrentITSupporter_Id == ITsupporter_id).ToList();
            if (ticket.Count < 0)
            {
                return new ResponseObject<List<TicketAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy" };
            }
            foreach (var item in ticket)
            {
                rsList.Add(new TicketAPIViewModel
                {
                    TicketId = item.TicketId,
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

            return new ResponseObject<List<TicketAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
        }

        public ResponseObject<bool> EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {

            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var updateEstimateTimeTicket = ticketRepo.GetActive().SingleOrDefault(a => a.CurrentITSupporter_Id == model.CurrentITSupporter_Id && a.TicketId == model.TicketId);
            if (updateEstimateTimeTicket != null)
            {
                updateEstimateTimeTicket.Estimation = model.Estimation;

                ticketRepo.Edit(updateEstimateTimeTicket);

                ticketRepo.Save();
                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật giờ dự kiến thành công" };
                }

            return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật giờ dự kiến thất bại" };
        }

        public ResponseObject<bool> UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model)
        {

            var ticketTaskRepo = DependencyUtils.Resolve<ITicketTaskRepository>();
            var updateTicketTaskStatus = ticketTaskRepo.GetActive().SingleOrDefault(a => a.TicketTaskId == model.TicketTaskId);
            if (updateTicketTaskStatus != null)
            {
                updateTicketTaskStatus.TaskStatus = model.TaskStatus;

                ticketTaskRepo.Edit(updateTicketTaskStatus);

                ticketTaskRepo.Save();
                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật trạng thái thành công" };
            }

            return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại" };
        }

        public ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model)
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
                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật profile thành công" };
            }

            return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật profile thất bại" };
        }

        public ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model)
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
                return new ResponseObject<bool> { IsError = false, ObjReturn = true , SuccessMessage = "Tạo mới việc thành công"};
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Tạo mới việc thất bại" };
            }

        }

        public ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model)
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
                return new ResponseObject<bool> { IsError = false, ObjReturn = true , SuccessMessage = "Gán thời gian thành công" };
            }

            return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Gán thời gian thất bại" };

        }

        public ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model)
        {

            var ticketTaskRepo = DependencyUtils.Resolve<ITicketTaskRepository>();
            var setPriorityTask = ticketTaskRepo.GetActive().SingleOrDefault(a => a.TicketTaskId == model.TicketTaskId);

            if (setPriorityTask != null)
            {
                setPriorityTask.TicketTaskId = model.TicketTaskId;
                setPriorityTask.Priority = model.Priority;

                ticketTaskRepo.Edit(setPriorityTask);

                ticketTaskRepo.Save();
                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật độ ưu thành công" };
            }

            return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật độ ưu thất bại" };

        }

        public ResponseObject<GuidelineAPIViewModel> GetGuidelineByServiceItemID(int service_item_Id)
        {

            var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
            var guideline = guidelineRepo.GetActive().SingleOrDefault(a => a.ServiceItemId == service_item_Id);
            if (guideline != null)
            {
                var guidelineAPIViewModel = new GuidelineAPIViewModel
                {
                    GuidelineId = guideline.GuidelineId,
                    ServiceItemId = guideline.ServiceItemId ?? 0,
                    GuidelineName = guideline.GuidelineName,
                    StartDate = guideline.StartDate != null ? guideline.StartDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                    EndDate = guideline.EndDate != null ? guideline.EndDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                    CreateDate = guideline.CreateDate != null ? guideline.CreateDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                    UpdateDate = guideline.UpdateDate != null ? guideline.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                };
                return new ResponseObject<GuidelineAPIViewModel> { IsError = false, ObjReturn = guidelineAPIViewModel, SuccessMessage = "Thành công" };
            }

            return new ResponseObject<GuidelineAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy hướng dẫn nào" }; ;
        }


    }
}

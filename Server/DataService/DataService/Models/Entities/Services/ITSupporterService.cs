using DataService.APIViewModels;
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

        ResponseObject<ITSupporterStatisticAPIViewModel> ITSuppoterStatistic(int itsupporterId);


    }

    public partial class ITSupporterService
    {
        public ResponseObject<List<ITSupporterAPIViewModel>> GetAllITSupporter() { 

                try
                {
                    List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
                    var skillRepo = DependencyUtils.Resolve<ISkillRepository>();
                    var skill = skillRepo.GetActive().ToList();
                    var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                    var itSupporters = ITSupporterRepo.GetActive().ToList();

                    if (itSupporters.Count > 0)
                    {
                        int count = 1;
                        foreach (var item in itSupporters)
                        {
                            if (!item.IsDelete)
                            {
                            var itemskill = skill.SingleOrDefault(i => i.ITSupporterId == item.ITSupporterId);

                            rsList.Add(new ITSupporterAPIViewModel
                            {
                                NumericalOrder = count,
                                ITSupporterId = item.ITSupporterId,
                                ITSupporterName = item.ITSupporterName,
                                Username = item.Account.Username,
                                Telephone = item.Telephone,
                                Email = item.Email,
                                Gender = item.Gender != null ? Enum.GetName(typeof(TicketStatusEnum), item.Gender) : string.Empty,
                                Address = item.Address,
                                RatingAVG = item.RatingAVG ?? 0,
                                IsOnline = item.IsOnline != null && item.IsOnline.Value == true ? "Online" : "Ofline",
                                Skill = itemskill.MonthExperience + " Tháng",
                                IsBusy = item.IsBusy.Value == true ? "Đang bận!" : "Chờ việc",
                                CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                                UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                                    
                                });
                                
                            }
                            count++;
                        }
                        return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy nhân viên!" };
                    }
                    else
                    {
                        return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy nhân viên!", ObjReturn = rsList };
                    }
                }
                catch (Exception e)
                {

                    return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy nhân viên!", ObjReturn = null, ErrorMessage = e.ToString() };
                }
            }

        public ResponseObject<bool> UpdateTicketStatus(ITSupporterUpdateAPIViewModel model)
        {
            try
            {
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var updateTicketStatus = ticketRepo.GetActive().SingleOrDefault(a => a.CurrentITSupporter_Id == model.ITSupporterId && a.TicketId == model.Ticket_Id);
                if (updateTicketStatus != null)
                {
                    updateTicketStatus.Current_TicketStatus = model.Current_TicketStatus;

                    ticketRepo.Edit(updateTicketStatus);

                    ticketRepo.Save();
                    return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật trạng thái thành công" };
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại" };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<ITSupporterAPIViewModel> ViewProfileITSupporter(int itSupporter_id)
        {
            try
            {
                var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itSupporter = ITSupporterRepo.GetActive().SingleOrDefault(i => i.ITSupporterId == itSupporter_id);
                if (itSupporter != null)
                {
                    var itSupporterAPIViewModel = new ITSupporterAPIViewModel
                    {
                        ITSupporterId = itSupporter.ITSupporterId,
                        ITSupporterName = itSupporter.ITSupporterName,
                        AccountId = itSupporter.AccountId,
                        Telephone = itSupporter.Telephone,
                        Email = itSupporter.Email,
                        Gender = itSupporter.Gender != null ? Enum.GetName(typeof(TicketStatusEnum), itSupporter.Gender) : string.Empty,
                        Address = itSupporter.Address,
                        RatingAVG = itSupporter.RatingAVG ?? 0,
                        IsBusy = itSupporter.IsBusy.Value == true ? "Đang bận!" : "Chờ việc",
                        CreateDate = itSupporter.CreateDate.ToString("MM/dd/yyyy"),
                        UpdateDate = itSupporter.UpdateDate != null ? itSupporter.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    };
                    return new ResponseObject<ITSupporterAPIViewModel> { IsError = false, ObjReturn = itSupporterAPIViewModel, SuccessMessage = "Thành công" };
                }

                return new ResponseObject<ITSupporterAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy người hỗ trợ" };
            }
            catch (Exception e)
            {

                return new ResponseObject<ITSupporterAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy người hỗ trợ", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<TicketAPIViewModel>> ViewAllOwnerTicket(int ITsupporter_id)
        {
            try
            {
                List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var ticket = ticketRepo.GetActive(p => p.CurrentITSupporter_Id == ITsupporter_id).ToList();
                if (ticket.Count <= 0)
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
                        CurrentITSupporter_Id = item.CurrentITSupporter_Id ?? 0,
                        StartTime = item.StartTime != null ? item.StartTime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Endtime = item.Endtime != null ? item.Endtime.Value.ToString("MM/dd/yyyy") : string.Empty,
                        CreateDate = item.CreateDate.ToString("MM/dd/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }

                return new ResponseObject<List<TicketAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<TicketAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {
            try
            {
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var updateEstimateTimeTicket = ticketRepo.GetActive().SingleOrDefault(a => a.CurrentITSupporter_Id == model.CurrentITSupporter_Id && a.TicketId == model.TicketId);
                if (updateEstimateTimeTicket != null)
                {
                    ticketRepo.Edit(updateEstimateTimeTicket);

                    ticketRepo.Save();
                    return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật giờ dự kiến thành công" };
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật giờ dự kiến thất bại" };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật giờ dự kiến thất bại", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model)
        {
            try
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
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại", ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model)
        {
            try
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
                    updateProfile.UpdateDate = DateTime.UtcNow.AddHours(7);

                    ITSupporterRepo.Edit(updateProfile);

                    ITSupporterRepo.Save();
                    return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật profile thành công" };
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật profile thất bại" };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật profile thất bại", ErrorMessage = e.ToString() };
            }
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
                createTask.CreateDate = DateTime.UtcNow.AddHours(7);

                ticketTaskRepo.Add(createTask);

                ticketTaskRepo.Save();
                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Tạo mới việc thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Tạo mới việc thất bại", ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model)
        {
            try
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
                    return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Gán thời gian thành công" };
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Gán thời gian thất bại" };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Gán thời gian thất bại", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model)
        {
            try
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
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật độ ưu thất bại", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<GuidelineAPIViewModel> GetGuidelineByServiceItemID(int service_item_Id)
        {
            try
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
                        CreateDate = guideline.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = guideline.UpdateDate != null ? guideline.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                    };
                    return new ResponseObject<GuidelineAPIViewModel> { IsError = false, ObjReturn = guidelineAPIViewModel, SuccessMessage = "Thành công" };
                }

                return new ResponseObject<GuidelineAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy hướng dẫn nào" };
            }
            catch (Exception e)
            {
                return new ResponseObject<GuidelineAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy hướng dẫn nào", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<ITSupporterStatisticAPIViewModel> ITSuppoterStatistic(int itsupporterId)
        {
            try
            {
                var itsupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itsupporter  = itsupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);
                var supportTime = 0;
                var totalSupportTime = new TimeSpan();
                var averageTime = 0.0;
                if (itsupporter != null)
                {
                    List<ITSupporterStatisticServiceTimeAPIViewModel> rsList = new List<ITSupporterStatisticServiceTimeAPIViewModel>();
                    var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                    var ticketInMonth = ticketRepo.GetActive().Where(t => t.CurrentITSupporter_Id == itsupporterId && t.CreateDate.Year == DateTime.Now.Year && t.CreateDate.Month == DateTime.Now.Month);

                    if (ticketInMonth.Count() > 0)
                    {
                        foreach (var ticketItem in ticketInMonth)
                        {
                            supportTime++;
                        }
                    }

                    var ticket = ticketRepo.GetActive().Where(t => t.CurrentITSupporter_Id == itsupporterId && t.CreateDate.Year == DateTime.Now.Year && t.CreateDate.Month == DateTime.Now.Month).ToList();

                    if (ticket.Count() > 0)
                    {
                        var ticketCount = 0;
                        foreach (var ticketItem in ticket)
                        {
                            if(ticketItem.StartTime != null && ticketItem.Endtime != null)
                            {
                                ticketCount++;
                                var time = new TimeSpan();
                                time = (ticketItem.StartTime - ticketItem.Endtime).Value.Duration();
                                totalSupportTime += time;
                                rsList.Add(new ITSupporterStatisticServiceTimeAPIViewModel
                                {
                                    ServiceName = ticketItem.Device.DeviceType.ServiceITSupport.ServiceName,

                                });
                            }
                        }
                        averageTime = totalSupportTime.TotalHours / ticketCount;
                    }


                    var ITSupporterAssumptionAPIViewModel = new ITSupporterStatisticAPIViewModel
                    {
                        ITSupporterName = itsupporter.ITSupporterName,
                        SupportTimeInMonth = supportTime,
                        //TotalTimeEveryService =,
                        AverageTimeSupport = averageTime
                    };
                    return new ResponseObject<ITSupporterStatisticAPIViewModel> { IsError = false, ObjReturn = ITSupporterAssumptionAPIViewModel, SuccessMessage = "Thành công" };
                }

                return new ResponseObject<ITSupporterStatisticAPIViewModel> { IsError = true, WarningMessage = "Không có thống kê nào!" };
            }
            catch (Exception e)
            {
                return new ResponseObject<ITSupporterStatisticAPIViewModel> { IsError = true, WarningMessage = "Không có thống kê nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

    }
}

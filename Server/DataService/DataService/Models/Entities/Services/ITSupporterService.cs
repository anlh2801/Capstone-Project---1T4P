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

        ResponseObject<List<GuidelineAPIViewModel>> GetGuidelineByServiceItemID(int service_item_Id);

        ResponseObject<ITSupporterStatisticAPIViewModel> ITSuppoterStatistic(int itsupporterId, int year, int month);

        ResponseObject<bool> UpdateStatusIT(int itsupporter_id, bool isOnline);

        ResponseObject<bool> UpdateStartTime(int request_id, DateTime start_time);

        ResponseObject<bool> UpdateEndTime(int request_id, DateTime end_time);

        ResponseObject<bool> GetIsOnlineOFITSupporter(int itsupporterId);

        ResponseObject<bool> GetIsBusyOFITSupporter(int itsupporterId);

    }

    public partial class ITSupporterService
    {
        public ResponseObject<List<ITSupporterAPIViewModel>> GetAllITSupporter()
        {
            try
            {
                List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
                var ITSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itSupporters = ITSupporterRepo.GetActive().ToList();
                if (itSupporters.Count <= 0)
                {
                    return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy người hỗ trợ" };
                }
                int count = 1;
                foreach (var item in itSupporters)
                {
                    var i = 1;
                    var genderStatus = "";
                    foreach (Gender genderItem in Enum.GetValues(typeof(Gender)))
                    {
                        if (item.Gender == i)
                        {
                            genderStatus = genderItem.DisplayName();
                        }
                        i++;
                    }
                    if (!item.IsDelete)
                    {
                        rsList.Add(new ITSupporterAPIViewModel
                        {
                            NumericalOrder = count,
                            ITSupporterId = item.ITSupporterId,
                            ITSupporterName = item.ITSupporterName,
                            Username = item.Account.Username,
                            Telephone = item.Telephone,
                            Email = item.Email,
                            Gender = genderStatus,
                            Address = item.Address,
                            RatingAVG = item.RatingAVG ?? 0,
                            IsOnline = item.IsOnline.Value == true ? "Online" : "Offline",
                            IsBusy = item.IsBusy.Value == true ? "Đang bận!" : "Chờ việc",
                            CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                            UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty,

                        });
                    }
                    count++;
                }
                return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
            }
            catch (Exception ex)
            {
                return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = true, ErrorMessage = ex.ToString(), WarningMessage = "Không tìm thấy người hỗ trợ", ObjReturn = null };
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
                    var i = 1;
                    var genderStatus = "";
                    foreach (Gender genderItem in Enum.GetValues(typeof(Gender)))
                    {
                        if (itSupporter.Gender == i)
                        {
                            genderStatus = genderItem.DisplayName();
                        }
                        i++;
                    }
                    var itSupporterAPIViewModel = new ITSupporterAPIViewModel
                    {
                        ITSupporterId = itSupporter.ITSupporterId,
                        ITSupporterName = itSupporter.ITSupporterName,
                        AccountId = itSupporter.AccountId,
                        Telephone = itSupporter.Telephone,
                        Email = itSupporter.Email,
                        Gender = genderStatus,
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
                    var i = 1;
                    var ticketStatus = "";
                    foreach (TicketStatusEnum ticketItem in Enum.GetValues(typeof(TicketStatusEnum)))
                    {
                        if (item.Current_TicketStatus == i)
                        {
                            ticketStatus = ticketItem.DisplayName();
                        }
                        i++;
                    }
                    rsList.Add(new TicketAPIViewModel
                    {
                        TicketId = item.TicketId,
                        RequestId = item.RequestId,
                        DeviceId = item.DeviceId,
                        Desciption = item.Desciption,
                        Current_TicketStatus = ticketStatus,
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

        public ResponseObject<List<GuidelineAPIViewModel>> GetGuidelineByServiceItemID(int service_item_Id)
        {
            try
            {
                var guidelineRepo = DependencyUtils.Resolve<IGuidelineRepository>();
                var guidelines = guidelineRepo.GetActive(a => a.ServiceItemId == service_item_Id).ToList();
                List<GuidelineAPIViewModel> rsList = new List<GuidelineAPIViewModel>();
                if (guidelines.Count <= 0)
                {
                    return new ResponseObject<List<GuidelineAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy hướng dẫn nào" };
                }
                foreach (var item in guidelines)
                {
                    var guidelineAPIViewModel = new GuidelineAPIViewModel
                    {
                        GuidelineId = item.GuidelineId,
                        ServiceItemId = item.ServiceItemId ?? 0,
                        GuidelineName = item.GuidelineName,
                        StartDate = item.StartDate != null ? item.StartDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        EndDate = item.EndDate != null ? item.EndDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                    };
                    rsList.Add(guidelineAPIViewModel);
                }

                return new ResponseObject<List<GuidelineAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<GuidelineAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy hướng dẫn nào", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<ITSupporterStatisticAPIViewModel> ITSuppoterStatistic(int itsupporterId, int year, int month)
        {
            try
            {
                var itsupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var servieceRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
                var itsupporter = itsupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);
                var supportTime = 0;
                var totalSupportTime = new TimeSpan();
                var averageTime = 0.0;
                if (itsupporter != null)
                {
                    List<ITSupporterStatisticServiceTimeAPIViewModel> rsList = new List<ITSupporterStatisticServiceTimeAPIViewModel>();
                    var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                    var requestInMonth = requestRepo.GetActive().Where(r => r.CurrentITSupporter_Id == itsupporterId && (r.StartTime != null && r.StartTime.Value.Year == year) && (r.EndTime != null && r.EndTime.Value.Month == month)).ToList();

                    if (requestInMonth.Count() > 0)
                    {
                        foreach (var requestItem in requestInMonth)
                        {
                            supportTime++;
                        }
                    }

                    var request = requestRepo.GetActive().Where(r => r.CurrentITSupporter_Id == itsupporterId && (r.StartTime != null && r.StartTime.Value.Year == year) && (r.StartTime != null && r.StartTime.Value.Month == month)).ToList();
                    //var serviceGroup = requestRepo.GetActive().Where(r => r.CurrentITSupporter_Id == itsupporterId && (r.StartTime != null && r.StartTime.Value.Year == DateTime.Now.Year) && (r.EndTime != null && r.EndTime.Value.Month == DateTime.Now.Month)).ToList();
                    var requestGroupBy = request.GroupBy(a => a.ServiceItem.ServiceITSupport.ServiceITSupportId);
                    var requestSelect = requestGroupBy.Select(b => new { ServiceId = b.Key, ServiceItems = b.ToList() }).ToList();
                    //var s = w.Sum(a => a.)


                    if (request.Count() > 0)
                    {
                        foreach (var item in requestSelect)
                        {
                            var totalServiceSupportTime = new TimeSpan();
                            foreach (var item2 in item.ServiceItems)
                            {
                                if (item2.StartTime != null && item2.EndTime != null)
                                {
                                    var time = new TimeSpan();
                                    time = (item2.StartTime - item2.EndTime).Value.Duration();
                                    totalServiceSupportTime += time;
                                }
                            }
                            rsList.Add(new ITSupporterStatisticServiceTimeAPIViewModel
                            {
                                ServiceName = servieceRepo.GetActive().SingleOrDefault(q => q.ServiceITSupportId == item.ServiceId).ServiceName,
                                SupportTimeByDay = totalServiceSupportTime.TotalDays,
                                SupportTimeByHour = totalServiceSupportTime.TotalHours
                            });
                        }

                    }
                    if (request.Count() > 0)
                    {
                        var requestCount = 0;
                        foreach (var requestItem in request)
                        {
                            if (requestItem.StartTime != null && requestItem.EndTime != null)
                            {
                                requestCount++;
                                var time = new TimeSpan();
                                time = (requestItem.StartTime - requestItem.EndTime).Value.Duration();
                                totalSupportTime += time;
                            }
                        }
                        averageTime = totalSupportTime.TotalHours / requestCount;
                    }

                    var requestHistoryRepo = DependencyUtils.Resolve<IRequestHistoryRepository>();
                    var requestHistory = requestHistoryRepo.GetActive().Where(r => r.Pre_It_SupporterId == itsupporterId && r.IsITSupportAccept == false && (r.StartTime != null && r.StartTime.Value.Year == DateTime.Now.Year) && (r.EndTime != null && r.EndTime.Value.Month == DateTime.Now.Month)).ToList();
                    var totalRejectTime = 0;
                    if (requestHistory.Count > 0)
                    {
                        foreach (var item in requestHistory)
                        {
                            totalRejectTime++;
                        }
                    }

                    var ITSupporterAssumptionAPIViewModel = new ITSupporterStatisticAPIViewModel
                    {
                        ITSupporterName = itsupporter.ITSupporterName,
                        SupportTimeInMonth = supportTime,
                        TotalTimeEveryService = rsList,
                        AverageTimeSupport = averageTime,
                        TotalRejectTime = totalRejectTime
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

        public ResponseObject<bool> UpdateStatusIT(int itsupporter_id, bool isOnline)
        {
            try
            {
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itsupporter = itSupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporter_id);
                if (itsupporter != null)
                {
                    itsupporter.IsOnline = isOnline;
                    itSupporterRepo.Edit(itsupporter);
                    itSupporterRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Cập nhật trạng thái thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật trạng thái thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Hủy yêu cầu thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<bool> UpdateStartTime(int request_id, DateTime start_time)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var request = requestRepo.GetActive().SingleOrDefault(a => a.RequestId == request_id);
                if (request != null)
                {
                    request.StartTime = start_time;
                    requestRepo.Edit(request);
                    requestRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Cập nhật thời gian thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật thời gian thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật thời gian thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> UpdateEndTime(int request_id, DateTime end_time)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var request = requestRepo.GetActive().SingleOrDefault(a => a.RequestId == request_id);
                if (request != null)
                {
                    request.EndTime = end_time;
                    requestRepo.Edit(request);
                    requestRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Cập nhật thời gian thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật thời gian thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật thời gian thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> GetIsOnlineOFITSupporter(int itsupporterId)
        {
            try
            {
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);
                if (itSupporter != null && itSupporter.IsOnline != null)
                {
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Lấy trạng trạng thái thành công", ObjReturn = itSupporter.IsOnline.Value };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật trạng thái thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Hủy yêu cầu thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> GetIsBusyOFITSupporter(int itsupporterId)
        {
            try
            {
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);
                if (itSupporter != null && itSupporter.IsBusy != null)
                {
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Lấy trạng trạng thái thành công", ObjReturn = itSupporter.IsBusy.Value };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật trạng thái thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Hủy yêu cầu thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }
    }
}

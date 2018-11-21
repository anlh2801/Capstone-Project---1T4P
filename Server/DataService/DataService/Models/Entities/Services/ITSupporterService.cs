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

        ResponseObject<bool> UpdateTaskStatus(int requestTaskId, bool isDone);

        ResponseObject<bool> DeleteTaskStatus(int requestTaskId);

        ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> GetAllTaskByRequestId(int requestId);

        ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model);

        ResponseObject<bool> CreateTaskFromGuidline(List<ITSupporterCreateTaskAPIViewModel> model);

        ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        ResponseObject<List<GuidelineAPIViewModel>> GetGuidelineByServiceItemID(int service_item_Id);

        ResponseObject<List<ITSupporterStatisticAPIViewModel>> ITSuppoterStatistic(int year, int month);

        ResponseObject<bool> UpdateStatusIT(int itsupporter_id, bool isOnline);

        ResponseObject<bool> UpdateStartTime(int request_id, DateTime start_time);

        ResponseObject<bool> UpdateEndTime(int request_id, DateTime end_time);

        ResponseObject<bool> GetIsOnlineOFITSupporter(int itsupporterId);

        ResponseObject<bool> GetIsBusyOFITSupporter(int itsupporterId);

        ResponseObject<List<ITSupporterAPIViewModel>> ViewSkillITSupporter(int itSupporter_id);

        ResponseObject<bool> CreateITSuport(ITSupporterAPIViewModel model);

        ResponseObject<bool> AddSkill(SkillAPIViewModel model);

        ResponseObject<bool> RemoveSkill(int itsupporterId, int serviceITSupportId);

        ResponseObject<bool> RemoveITSuporter(int itsupporterId);

        ResponseObject<bool> UpdateITSup(ITSupporterAPIViewModel model);

        ResponseObject<int> UpdateIsBusyOFITSupporter(int itsupporterId);

        ResponseObject<ITSupporterStatisticForMobileAPIViewModel> ITSuppoterStatisticAll(int itsupporterId);

        ResponseObject<List<RequestGroupMonth>> ViewRequestITSupporter(int itSupporter_id);

        ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> ServiceITSuppoterStatistic(int year, int month);
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
                        Username = itSupporter.Account.Username,
                        Password = itSupporter.Account.Password,
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
        public ResponseObject<List<RequestGroupMonth>> ViewRequestITSupporter(int itSupporter_id)
        {
            try
            {
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var requests = requestRepo.GetActive(i => i.CurrentITSupporter_Id == itSupporter_id)
                             .GroupBy(o => new { MonthGroupByStartTime = o.CreateDate.Month, YearGroupByStartTime = o.CreateDate.Year })
                        .Select(g => new { MonthSelect = g.Key.MonthGroupByStartTime, YearSelect = g.Key.YearGroupByStartTime, RequestList = g })
                        .OrderByDescending(a => a.YearSelect)
                        .ThenByDescending(a => a.MonthSelect)
                    .ToList();
                if (requests.Count <= 0)
                {
                    return new ResponseObject<List<RequestGroupMonth>> { IsError = true, WarningMessage = "Thất bại" };
                }
                var requestListGroup = new List<RequestGroupMonth>();
                    List<RequestAllTicketWithStatusAgencyAPIViewModel> rsList = new List<RequestAllTicketWithStatusAgencyAPIViewModel>();
                    foreach (var item in requests)
                    {
                        foreach (var itemRequest in item.RequestList)
                        {
                            if (itemRequest.RequestStatus == (int)RequestStatusEnum.Done)
                            {
                                if (itemRequest.Rating != null)
                                {
                                    rsList.Add(new RequestAllTicketWithStatusAgencyAPIViewModel
                                    {
                                        RequestId = itemRequest.RequestId,
                                        FeedBack = itemRequest.Feedback,
                                        Rating = itemRequest.Rating.Value,
                                        AgencyName = itemRequest.Agency.AgencyName,
                                        RequestName = itemRequest.RequestName,
                                        CreateDate = itemRequest.CreateDate != null ? itemRequest.CreateDate.ToString("MM/dd/yyyy") : string.Empty,
                                    });
                                }
                            }
                        }
                    var requestGroupMonthViewModel = new RequestGroupMonth();
                    requestGroupMonthViewModel.MonthYearGroup = $"Tháng {item.MonthSelect}/{item.YearSelect}";
                    requestGroupMonthViewModel.RequestOfITSupporter = rsList;
                    requestListGroup.Add(requestGroupMonthViewModel);

                }

                    return new ResponseObject<List<RequestGroupMonth>> { IsError = false, ObjReturn = requestListGroup, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<RequestGroupMonth>> { IsError = true, WarningMessage = "Không tìm thấy feedback", ObjReturn = null, ErrorMessage = e.ToString() };
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

        public ResponseObject<bool> UpdateTaskStatus(int requestTaskId, bool isDone)
        {
            try
            {
                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();
                var updateRequestTaskStatus = requestTaskRepo.GetActive().SingleOrDefault(a => a.RequestTaskId == requestTaskId);
                if (updateRequestTaskStatus != null)
                {
                    updateRequestTaskStatus.TaskStatus = isDone ? (int)RequestTaskEnum.Done : (int)RequestTaskEnum.In_Process;
                    updateRequestTaskStatus.UpdateDate = DateTime.UtcNow.AddHours(7);
                    requestTaskRepo.Edit(updateRequestTaskStatus);

                    requestTaskRepo.Save();
                    return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Cập nhật trạng thái thành công" };
                }

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại" };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Cập nhật trạng thái thất bại", ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> DeleteTaskStatus(int requestTaskId)
        {
            try
            {
                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();
                var requesrtask = requestTaskRepo.GetActive().SingleOrDefault(a => a.RequestTaskId == requestTaskId);
                if (requesrtask != null)
                {

                    requestTaskRepo.Deactivate(requesrtask);
                    requestTaskRepo.Save();
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

        public ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> GetAllTaskByRequestId(int requestId)
        {
            try
            {
                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();
                var taskList = requestTaskRepo.GetActive(p => p.RequestId == requestId).ToList();

                if (taskList.Count() <= 0)
                {
                    return new ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy việc cần làm nào" };
                }

                var rsList = new List<ITSupporterCreateTaskAPIViewModel>();
                foreach (var item in taskList)
                {
                    var taskViewModel = new ITSupporterCreateTaskAPIViewModel()
                    {
                        RequestId = item.RequestId,
                        RequestTaskId = item.RequestTaskId,
                        CreateByITSupporter = item.CreateByITSupporter ?? 0,
                        TaskStatus = item.TaskStatus ?? (int)RequestTaskEnum.In_Process,
                        TaskDetail = item.TaskDetails != null ? item.TaskDetails : string.Empty
                    };
                    rsList.Add(taskViewModel);
                }

                return new ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Lấy việc cần làm thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> { IsError = true, ErrorMessage = e.ToString(), WarningMessage = "Không tìm thấy việc cần làm nào" };
            }
        }

        public ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model)
        {
            try
            {

                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();
                var createTask = new RequestTask();

                createTask.RequestId = model.RequestId;
                createTask.TaskStatus = (int)RequestTaskEnum.In_Process;
                createTask.CreateByITSupporter = model.CreateByITSupporter;
                createTask.StartTime = DateTime.UtcNow.AddHours(7);
                createTask.TaskDetails = model.TaskDetail;
                //createTask.EndTime = DateTime.Parse(item.EndTime);
                //createTask.Priority = item.Priority;
                //createTask.PreTaskCondition = model.PreTaskCondition;
                createTask.CreateDate = DateTime.UtcNow.AddHours(7);

                requestTaskRepo.Add(createTask);

                requestTaskRepo.Save();
                return new ResponseObject<bool> { IsError = false, ObjReturn = true, SuccessMessage = "Tạo mới việc thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Tạo mới việc thất bại", ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> CreateTaskFromGuidline(List<ITSupporterCreateTaskAPIViewModel> model)
        {
            try
            {

                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();

                foreach (var item in model)
                {
                    var createTask = new RequestTask();

                    createTask.RequestId = item.RequestId;
                    createTask.TaskStatus = (int)RequestTaskEnum.In_Process;
                    createTask.CreateByITSupporter = item.CreateByITSupporter;
                    createTask.StartTime = DateTime.UtcNow.AddHours(7);
                    createTask.TaskDetails = item.TaskDetail;
                    //createTask.EndTime = DateTime.Parse(item.EndTime);
                    //createTask.Priority = item.Priority;
                    //createTask.PreTaskCondition = model.PreTaskCondition;
                    createTask.CreateDate = DateTime.UtcNow.AddHours(7);

                    requestTaskRepo.Add(createTask);
                }


                requestTaskRepo.Save();
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
                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();
                var setTimeTask = requestTaskRepo.GetActive().SingleOrDefault(a => a.RequestTaskId == model.RequestTaskId);

                if (setTimeTask != null)
                {
                    setTimeTask.RequestTaskId = model.RequestTaskId;
                    setTimeTask.StartTime = DateTime.Parse(model.StartTime);
                    setTimeTask.EndTime = DateTime.Parse(model.EndTime);

                    requestTaskRepo.Edit(setTimeTask);

                    requestTaskRepo.Save();
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
                var requestTaskRepo = DependencyUtils.Resolve<IRequestTaskRepository>();
                var setPriorityTask = requestTaskRepo.GetActive().SingleOrDefault(a => a.RequestTaskId == model.RequestTaskId);

                if (setPriorityTask != null)
                {
                    setPriorityTask.RequestTaskId = model.RequestTaskId;
                    setPriorityTask.Priority = model.Priority;

                    requestTaskRepo.Edit(setPriorityTask);

                    requestTaskRepo.Save();
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
                        ServiceItemId = item.ServiceItemId,
                        GuidelineName = item.GuidelineName,
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

        public ResponseObject<List<ITSupporterStatisticAPIViewModel>> ITSuppoterStatistic(int year, int month)
        {
            try
            {
                var itsupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var servieceRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
                var itsupporters = itsupporterRepo.GetActive().ToList();

                if (itsupporters.Count() <= 0)
                {
                    return new ResponseObject<List<ITSupporterStatisticAPIViewModel>> { IsError = true, WarningMessage = "Không có thống kê nào!" };
                }
                var rs = new List<ITSupporterStatisticAPIViewModel>();
                foreach (var itsupporter in itsupporters)
                {
                    var supportTime = 0;
                    var totalSupportTime = new TimeSpan();
                    var averageTime = 0.0;
                    if (itsupporter != null)
                    {
                        List<ITSupporterStatisticServiceTimeAPIViewModel> rsList = new List<ITSupporterStatisticServiceTimeAPIViewModel>();
                        var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                        var requestInMonth = requestRepo.GetActive().Where(r => r.CurrentITSupporter_Id == itsupporter.ITSupporterId && (r.StartTime != null && r.StartTime.Value.Year == year) && (r.EndTime != null && r.EndTime.Value.Month == month)).ToList();

                        if (requestInMonth.Count() > 0)
                        {
                            foreach (var requestItem in requestInMonth)
                            {
                                supportTime++;
                            }
                        }

                        var request = requestRepo.GetActive().Where(r => r.CurrentITSupporter_Id == itsupporter.ITSupporterId && (r.StartTime != null && r.StartTime.Value.Year == year) && (r.StartTime != null && r.StartTime.Value.Month == month)).ToList();
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

                                var totalTimeSupportString = totalServiceSupportTime.ToString(@"dd\.hh\:mm");
                                var totalTimeSupportStringGetDays = totalTimeSupportString.Split('.');
                                var totalTimeSupportStringGetTimes = totalTimeSupportStringGetDays[1].ToString().Split(':');

                                rsList.Add(new ITSupporterStatisticServiceTimeAPIViewModel
                                {
                                    ServiceName = servieceRepo.GetActive().SingleOrDefault(q => q.ServiceITSupportId == item.ServiceId).ServiceName,

                                    SupportTimeByHour = $"{int.Parse(totalTimeSupportStringGetDays[0]) * 24 + int.Parse(totalTimeSupportStringGetTimes[0])} giờ {totalTimeSupportStringGetTimes[1]} phút"
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
                        var requestHistory = requestHistoryRepo.GetActive().Where(r => r.Pre_It_SupporterId == itsupporter.ITSupporterId && r.IsITSupportAccept == false && (r.StartTime != null && r.StartTime.Value.Year == year && r.StartTime.Value.Month == month) && (r.EndTime != null && r.EndTime.Value.Year == year && r.EndTime.Value.Month == month)).ToList();
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
                            ITSupporterId = itsupporter.ITSupporterId,
                            ITSupporterName = itsupporter.ITSupporterName,
                            SupportTimeInMonth = supportTime,
                            TotalTimeEveryService = rsList,
                            AverageTimeSupport = averageTime,
                            TotalTimeSupport = totalSupportTime.TotalHours,
                            TotalRejectTime = totalRejectTime
                        };
                        rs.Add(ITSupporterAssumptionAPIViewModel);
                    }

                }
                return new ResponseObject<List<ITSupporterStatisticAPIViewModel>> { IsError = false, ObjReturn = rs, SuccessMessage = "Thành công" };

            }
            catch (Exception e)
            {
                return new ResponseObject<List<ITSupporterStatisticAPIViewModel>> { IsError = true, WarningMessage = "Không có thống kê nào!", ErrorMessage = e.ToString() };
            }
        }


        public ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> ServiceITSuppoterStatistic(int year, int month)
        {
            try
            {
                List<ITSupporterStatisticServiceTimeAPIViewModel> rsList = new List<ITSupporterStatisticServiceTimeAPIViewModel>();
                var servieceRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();

                var request = requestRepo.GetActive().Where(r => (r.StartTime != null && r.StartTime.Value.Year == year) && (r.StartTime != null && r.StartTime.Value.Month == month)).ToList();

                if (request.Count() <= 0)
                {
                    return new ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> { IsError = true, WarningMessage = "Không có thống kê nào!"};
                }

                var requestGroupBy = request.GroupBy(a => a.ServiceItem.ServiceITSupport.ServiceITSupportId);
                var requestSelect = requestGroupBy.Select(b => new { ServiceId = b.Key, ServiceItems = b.ToList() }).ToList();


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

                        var totalTimeSupportString = totalServiceSupportTime.ToString(@"dd\.hh\:mm");
                        var totalTimeSupportStringGetDays = totalTimeSupportString.Split('.');
                        var totalTimeSupportStringGetTimes = totalTimeSupportStringGetDays[1].ToString().Split(':');

                        var service = servieceRepo.GetActive().Where(s => s.ServiceITSupportId != item.ServiceId).ToList();

                        foreach (var otherServiceItem in service)
                        {
                            if(otherServiceItem.ServiceName != servieceRepo.GetActive().SingleOrDefault(q => q.ServiceITSupportId == item.ServiceId).ServiceName)
                            {
                                rsList.Add(new ITSupporterStatisticServiceTimeAPIViewModel
                                {
                                    ServiceName = otherServiceItem.ServiceName,
                                    SupportTimeByTimes = 0,
                                    SupportTimeByHour = "0"
                                });
                            }
                        }

                        rsList.Add(new ITSupporterStatisticServiceTimeAPIViewModel
                        {
                            ServiceName = servieceRepo.GetActive().SingleOrDefault(q => q.ServiceITSupportId == item.ServiceId).ServiceName,
                            SupportTimeByTimes = item.ServiceItems.Count(),
                            SupportTimeByHour = $"{int.Parse(totalTimeSupportStringGetDays[0]) * 24 + int.Parse(totalTimeSupportStringGetTimes[0])}.{totalTimeSupportStringGetTimes[1]}"
                        });
                    }
                }
                return new ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> { IsError = true, WarningMessage = "Không có thống kê nào!", ErrorMessage = e.ToString() };
            }
        }


        public ResponseObject<ITSupporterStatisticForMobileAPIViewModel> ITSuppoterStatisticAll(int itsupporterId)
        {
            try
            {
                var itsupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var servieceRepo = DependencyUtils.Resolve<IServiceITSupportRepository>();
                var itsupporter = itsupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);

                if (itsupporter != null)
                {
                    var result = new ITSupporterStatisticForMobileAPIViewModel();

                    result.ITSupporterId = itsupporter.ITSupporterId;
                    result.ITSupporterName = itsupporter.ITSupporterName;

                    var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                    var requests = requestRepo.GetActive().Where(r => r.CurrentITSupporter_Id == itsupporterId)
                        .GroupBy(o => new { MonthGroupByStartTime = o.StartTime.Value.Month, YearGroupByStartTime = o.StartTime.Value.Year })
                        .Select(g => new { MonthSelect = g.Key.MonthGroupByStartTime, YearSelect = g.Key.YearGroupByStartTime, RequestList = g })
                        .OrderByDescending(a => a.YearSelect)
                        .ThenByDescending(a => a.MonthSelect)
                        .ToList();
                    var totalTimeSupport = new TimeSpan();
                    var totalTimeSupportInThisMonth = new TimeSpan();
                    int totalTimesSupport = 0;
                    int totalTimesSupportInThisMonth = 0;
                    var requestListGroup = new List<RequestGroupMonth>();
                    foreach (var item in requests)
                    {
                        var requestList = new List<RequestAllTicketWithStatusAgencyAPIViewModel>();
                        foreach (var itemRequest in item.RequestList)
                        {
                            totalTimesSupport++;
                            totalTimeSupport += itemRequest.EndTime != null ? (itemRequest.EndTime.Value - itemRequest.StartTime.Value).Duration() : new TimeSpan(0, 0, 0);
                            var requestViewModel = new RequestAllTicketWithStatusAgencyAPIViewModel();
                            requestViewModel.RequestName = itemRequest.RequestName;
                            requestViewModel.AgencyName = itemRequest.Agency.AgencyName;
                            requestViewModel.CreateDate = itemRequest.CreateDate.ToString("dd/MM/yyyy HH:mm");
                            requestViewModel.EndTime = itemRequest.EndTime != null ? itemRequest.EndTime.Value.ToString("dd/MM/yyyy HH:mm") : "Chờ xác nhận";

                            requestList.Add(requestViewModel);
                        }

                        if (item.MonthSelect == DateTime.Now.Month && item.YearSelect == DateTime.Now.Year)
                        {
                            foreach (var itemRequest in item.RequestList)
                            {
                                totalTimesSupportInThisMonth++;
                                totalTimeSupportInThisMonth += itemRequest.EndTime != null ? (itemRequest.EndTime.Value - itemRequest.StartTime.Value).Duration() : new TimeSpan(0, 0, 0);
                            }
                        }
                        var requestGroupMonthViewModel = new RequestGroupMonth();
                        requestGroupMonthViewModel.MonthYearGroup = $"Tháng {item.MonthSelect}/{item.YearSelect}";
                        requestGroupMonthViewModel.RequestOfITSupporter = requestList;
                        requestListGroup.Add(requestGroupMonthViewModel);
                    }
                    var totalTimeSupportString = totalTimeSupport.ToString(@"dd\.hh\:mm");
                    var totalTimeSupportStringGetDays = totalTimeSupportString.Split('.');
                    var totalTimeSupportStringGetTimes = totalTimeSupportStringGetDays[1].ToString().Split(':');

                    var totalTimeSupportInThisMonthString = totalTimeSupportInThisMonth.ToString(@"dd\.hh\:mm");
                    var totalTimeSupportInThisMonthGetDays = totalTimeSupportInThisMonthString.Split('.');
                    var totalTimeSupportInThisMonthGetTimes = totalTimeSupportInThisMonthGetDays[1].ToString().Split(':');

                    result.TotalTimesSupport = totalTimesSupport;
                    result.TotalTimesSupportInThisMonth = totalTimesSupportInThisMonth;
                    result.TotalTimeSupport = $"{int.Parse(totalTimeSupportStringGetDays[0]) * 24 + int.Parse(totalTimeSupportStringGetTimes[0])} giờ {totalTimeSupportStringGetTimes[1]} phút";
                    result.TotalTimeSupportInThisMonth = $"{int.Parse(totalTimeSupportInThisMonthGetDays[0]) * 24 + int.Parse(totalTimeSupportInThisMonthGetTimes[0])} giờ {totalTimeSupportInThisMonthGetTimes[1]} phút";
                    result.RequestOfITSupporter = requestListGroup;

                    return new ResponseObject<ITSupporterStatisticForMobileAPIViewModel> { IsError = false, ObjReturn = result, SuccessMessage = "Thành công" };
                }

                return new ResponseObject<ITSupporterStatisticForMobileAPIViewModel> { IsError = true, WarningMessage = "Không có thống kê nào!" };
            }
            catch (Exception e)
            {
                return new ResponseObject<ITSupporterStatisticForMobileAPIViewModel> { IsError = true, WarningMessage = "Không có thống kê nào!", ErrorMessage = e.ToString() };
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

        public ResponseObject<List<ITSupporterAPIViewModel>> ViewSkillITSupporter(int itSupporter_id)
        {
            var SkillITSupporterRepo = DependencyUtils.Resolve<ISkillRepository>();
            var skillITSupporter = SkillITSupporterRepo.GetActive(i => i.ITSupporterId == itSupporter_id).ToList();
            List<ITSupporterAPIViewModel> rsList = new List<ITSupporterAPIViewModel>();
            if (skillITSupporter != null)
            {
                foreach (var item in skillITSupporter)
                {
                    var skillAPIViewModel = new ITSupporterAPIViewModel
                    {
                        ServiceITSupportId = item.ServiceITSupportId.Value,
                        ServiceITSupportName = item.ServiceITSupport.ServiceName,
                        MonthExperience = item.MonthExperience + " tháng"
                    };
                    rsList.Add(skillAPIViewModel);
                }
                return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Lấy chi tiết thành công" };
            }
            return new ResponseObject<List<ITSupporterAPIViewModel>> { IsError = true, WarningMessage = "Không tồn tại nhân viên này" };
        }

        public ResponseObject<bool> CreateITSuport(ITSupporterAPIViewModel model)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var account = new Account();
                account.RoleId = model.RoleId;
                account.Username = model.Username.ToString();
                account.Password = model.Password.ToString();
                account.IsDelete = false;
                account.CreateDate = DateTime.UtcNow.AddHours(7);
                account.UpdateDate = DateTime.UtcNow.AddHours(7);

                accountRepo.Add(account);
                accountRepo.Save();

                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var createitSupporter = new ITSupporter();

                createitSupporter.AccountId = accountRepo.GetActive().SingleOrDefault(a => a.Username == model.Username).AccountId;
                createitSupporter.ITSupporterName = model.ITSupporterName.ToString();
                createitSupporter.Telephone = model.Telephone.ToString();
                createitSupporter.Email = model.Email.ToString();
                createitSupporter.Address = model.Address.ToString();
                createitSupporter.IsBusy = false;
                createitSupporter.IsOnline = true;
                createitSupporter.Gender = 1;
                createitSupporter.IsDelete = false;
                createitSupporter.CreateDate = DateTime.UtcNow.AddHours(7);
                createitSupporter.UpdateDate = DateTime.UtcNow.AddHours(7);

                itSupporterRepo.Add(createitSupporter);
                itSupporterRepo.Save();

                var skillRepo = DependencyUtils.Resolve<ISkillRepository>();
                var createSkill = new Skill();

                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm nhân viên thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm nhân viên thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }

        public ResponseObject<bool> AddSkill(SkillAPIViewModel model)
        {
            try
            {
                var SkillRepo = DependencyUtils.Resolve<ISkillRepository>();
                var curSkill = SkillRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == model.ITSupporterId && a.ServiceITSupportId == model.ServiceITSupportId);

                if (curSkill != null)
                {
                    curSkill.MonthExperience = model.MonthExperience;
                    curSkill.UpdateDate = DateTime.UtcNow.AddHours(7);

                    SkillRepo.Edit(curSkill);
                    SkillRepo.Save();
                }
                else
                {
                    var Skill = new Skill();

                    Skill.ITSupporterId = model.ITSupporterId;
                    Skill.ServiceITSupportId = model.ServiceITSupportId;
                    Skill.MonthExperience = model.MonthExperience;
                    Skill.IsDelete = false;
                    Skill.CreateDate = DateTime.UtcNow.AddHours(7);
                    Skill.UpdateDate = DateTime.UtcNow.AddHours(7);
                    SkillRepo.Add(Skill);
                    SkillRepo.Save();
                }
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Tạo kinh nghiệm thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Tạo kinh nghiệm thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<bool> RemoveSkill(int itsupporterId, int serviceITSupportId)
        {
            {
                try
                {
                    var SkillRepo = DependencyUtils.Resolve<ISkillRepository>();
                    var curSkill = SkillRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId && a.ServiceITSupportId == serviceITSupportId);
                    if (curSkill == null)
                    {
                        return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa kinh nghiệm thất bại!", ObjReturn = false };
                    }
                    Deactivate(curSkill);
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa kinh nghiệm thành công!", ObjReturn = true };
                }
                catch (Exception e)
                {
                    return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa kinh nghiệm thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
                }
            }
        }

        public ResponseObject<bool> RemoveITSuporter(int itsupporterId)
        {
            {
                try
                {
                    var SkillRepo = DependencyUtils.Resolve<ISkillRepository>();
                    var ITSupRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                    var AccountRepo = DependencyUtils.Resolve<IAccountRepository>();
                    var Skills = SkillRepo.GetActive(p => p.ITSupporterId == itsupporterId).ToList();
                    var ITSup = ITSupRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);
                    var ITAccount = AccountRepo.GetActive().SingleOrDefault(a => a.AccountId == ITSup.AccountId);

                    foreach (var item in Skills)
                    {
                        if (item == null)
                        {
                            return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa kinh nghiệm nhân viên thất bại!", ObjReturn = false };
                        }
                        item.IsDelete = true;
                    }
                    if (ITAccount == null)
                    {
                        return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa tài khoản nhân viên thất bại!", ObjReturn = false };
                    }
                    ITAccount.IsDelete = true;
                    if (ITSup == null)
                    {
                        return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa nhân viên thất bại!", ObjReturn = false };
                    }
                    Deactivate(ITSup);

                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa nhân viên thành công!", ObjReturn = true };
                }
                catch (Exception e)
                {
                    return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa nhân viên thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
                }
            }
        }

        public ResponseObject<bool> UpdateITSup(ITSupporterAPIViewModel model)
        {
            var ITSupRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var AccountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var ITSupUpdate = ITSupRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == model.ITSupporterId);
            var ITAccountUpdate = AccountRepo.GetActive().SingleOrDefault(a => a.Username == model.OldUsername);

            if (ITAccountUpdate != null)
            {
                ITAccountUpdate.RoleId = model.RoleId;
                ITAccountUpdate.Username = model.Username;
                ITAccountUpdate.Password = model.Password;
                ITAccountUpdate.UpdateDate = DateTime.UtcNow.AddHours(7);

                AccountRepo.Edit(ITAccountUpdate);
                AccountRepo.Save();
            }
            if (ITSupUpdate != null)
            {
                ITSupUpdate.ITSupporterName = model.ITSupporterName;
                ITSupUpdate.Telephone = model.Telephone;
                ITSupUpdate.Email = model.Email;
                ITSupUpdate.Address = model.Address;
                ITSupUpdate.UpdateDate = DateTime.UtcNow.AddHours(7);

                ITSupRepo.Edit(ITSupUpdate);
                ITSupRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa nhân viên thành công", ObjReturn = true };
            }

            return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa nhân viên thất bại", ObjReturn = false };
        }
        public ResponseObject<int> UpdateIsBusyOFITSupporter(int itsupporterId)
        {
            try
            {
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(a => a.ITSupporterId == itsupporterId);
                if (itSupporter != null && itSupporter.IsBusy == true)
                {
                    itSupporter.IsBusy = false;
                    itSupporterRepo.Edit(itSupporter);
                    itSupporterRepo.Save();
                    return new ResponseObject<int> { IsError = false, SuccessMessage = "Lấy trạng trạng thái thành công", ObjReturn = itSupporter.ITSupporterId };
                }

                return new ResponseObject<int> { IsError = true, WarningMessage = "Cập nhật trạng thái thất bại" };
            }
            catch (Exception e)
            {
                return new ResponseObject<int> { IsError = true, WarningMessage = "Cập nhật trạng thái thất bại" };
            }
        }
    }
}

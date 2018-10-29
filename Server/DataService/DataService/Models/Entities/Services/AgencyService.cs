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

namespace DataService.Models.Entities.Services
{
    public partial interface IAgencyService
    {

        ResponseObject<AgencyAPIViewModel> ViewProfile(int agency_id);

        ResponseObject<bool> UpdateProfile(AgencyUpdateAPIViewModel model);

        ResponseObject<List<AgencyAPIViewModel>> GetAllAgency();

        ResponseObject<int> CreateRequest(AgencyCreateRequestAPIViewModel model);

        ResponseObject<bool> CreateTicket(List<AgencyCreateTicketAPIViewModel> listTicket, int RequestId);

        ResponseObject<int> FindITSupporterByRequestId(int requestId);

        ResponseObject<bool> RemoveAgency(int agency_id);

        ResponseObject<bool> CreateAgency(AgencyAPIViewModel model);

        ResponseObject<AgencyDeviceAPIViewModel> GetDeviceByDeviceId(int deviceId);

        ResponseObject<List<TicketAPIViewModel>> GetTicketByRequestId(int requestId);

        ResponseObject<List<AgencyDeviceAPIViewModel>> GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId);

        ResponseObject<bool> AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id);

        ResponseObject<List<AgencyAPIViewModel>> ViewAllAgencyByCompanyId(int agency_id);
    }

    public partial class AgencyService
    {
        public ResponseObject<List<AgencyAPIViewModel>> ViewAllAgencyByCompanyId(int company_id)
        {
            try
            {
                List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
                var agencyDeviceRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var agencyDevices = agencyDeviceRepo.GetActive(p => p.CompanyId == company_id).ToList();
                if (agencyDevices.Count <= 0)
                {
                    return new ResponseObject<List<AgencyAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!" };
                }
                foreach (var item in agencyDevices)
                {
                    rsList.Add(new AgencyAPIViewModel
                    {
                        AgencyId = item.AgencyId,
                        CompanyId = item.CompanyId,
                        CompanyName = item.Company.CompanyName,
                        AccountId = item.AccountId,
                        UserName = item.Account.Username,
                        AgencyName = item.AgencyName,
                        Address = item.Address,
                        Telephone = item.Telephone,
                        CreateAt = item.CreateDate.ToString("MM/dd/yyyy"),
                        UpdateAt = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty

                    });
                }

                return new ResponseObject<List<AgencyAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy thiết bị" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<AgencyAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy thiết bị nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }


        public ResponseObject<AgencyAPIViewModel> ViewProfile(int agency_id)
        {
            try
            {
                var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
                if (agency != null)
                {
                    var agencyAPIViewModel = new AgencyAPIViewModel
                    {
                        AgencyId = agency.AgencyId,
                        CompanyId = agency.CompanyId ?? 0,
                        CompanyName = agency.Company.CompanyName,
                        AccountId = agency.AccountId,
                        UserName = agency.Account.Username,
                        AgencyName = agency.AgencyName,
                        Address = agency.Address,
                        Telephone = agency.Telephone,
                        CreateAt = agency.CreateDate.ToString("MM/dd/yyyy"),
                        UpdateAt = agency.UpdateDate != null ? agency.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    };
                    return new ResponseObject<AgencyAPIViewModel> { IsError = false, ObjReturn = agencyAPIViewModel, SuccessMessage = "Tìm thấy thông tin chi nhánh!" };
                }
                return new ResponseObject<AgencyAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy thông tin chi nhánh!" };
            }
            catch (Exception e)
            {

                return new ResponseObject<AgencyAPIViewModel> { IsError = true, ErrorMessage = e.ToString(), WarningMessage = "Không tìm thấy thông tin chi nhánh!" };
            }
        }

        public ResponseObject<bool> UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            try
            {
                var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var updateAgency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == model.AgencyId);

                if (updateAgency != null)
                {
                    updateAgency.AgencyName = model.AgencyName;
                    updateAgency.Address = model.Address;
                    updateAgency.Telephone = model.Telephone;
                    updateAgency.UpdateDate = DateTime.UtcNow.AddHours(7);

                    agencyRepo.Edit(updateAgency);
                    agencyRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Cập nhật thành công!", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật chi nhánh thất bại!", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật chi nhánh thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<AgencyAPIViewModel>> GetAllAgency()
        {
            try
            {
                List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
                var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var agencies = agencyRepo.GetActive().ToList();
                if (agencies.Count <= 0)
                {
                    return new ResponseObject<List<AgencyAPIViewModel>> { IsError = true, WarningMessage = "Lấy thông tin tất cả công ty thất bại!" };
                }
                foreach (var item in agencies)
                {
                    rsList.Add(new AgencyAPIViewModel
                    {
                        AgencyId = item.AgencyId,
                        CompanyName = item.Company.CompanyName,
                        UserName = item.Account.Username,
                        AgencyName = item.AgencyName,
                        Address = item.Address,
                        Telephone = item.Telephone,
                        CreateAt = item.CreateDate.ToString("MM/dd/yyyy"),
                        UpdateAt = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }

                return new ResponseObject<List<AgencyAPIViewModel>> { IsError = false, SuccessMessage = "Lấy thông tin danh sách công ty thành công!", ObjReturn = rsList };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<AgencyAPIViewModel>> { IsError = true, WarningMessage = "Lấy thông tin danh sách công ty thất bại!", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> RemoveAgency(int agency_id)
        {
            try
            {
                var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
                if (agency == null)
                {
                    return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa chi nhánh thất bại!", ObjReturn = false };
                }
                Deactivate(agency);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa chi nhánh thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa chi nhánh thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> CreateAgency(AgencyAPIViewModel model)
        {
            try
            {
                var ticketTaskRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var createTask = new Agency();

                createTask.CompanyId = model.CompanyId;
                createTask.AccountId = model.AccountId;
                createTask.AgencyName = model.AgencyName;
                createTask.Address = model.Address;
                createTask.Telephone = model.Telephone;
                createTask.IsDelete = false;
                createTask.CreateDate = DateTime.UtcNow.AddHours(7);
                ticketTaskRepo.Add(createTask);
                ticketTaskRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Tạo chi nhánh thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa chi nhánh thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<int> CreateRequest(AgencyCreateRequestAPIViewModel model)
        {
            try
            {

                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();

                var createRequest = new Request();

                createRequest.AgencyId = model.AgencyId;
                createRequest.RequestCategoryId = model.RequestCategoryId;
                createRequest.RequestStatus = (int)RequestStatusEnum.Pending;
                createRequest.RequestName = model.RequestName;
                createRequest.RequestDesciption = model.RequestDesciption;
                createRequest.ServiceItemId = model.ServiceItemId;
                createRequest.CreateDate = DateTime.UtcNow.AddHours(7);
                requestRepo.Add(createRequest);
                requestRepo.Save();

                CreateTicket(model.Ticket, createRequest.RequestId);
                
                return new ResponseObject<int> { IsError = false, SuccessMessage = "Tạo yêu cầu thành công!", ObjReturn = createRequest.RequestId };
            }
            catch (Exception e)
            {

                return new ResponseObject<int> { IsError = true, WarningMessage = "Tạo yêu cầu thất bại!", ObjReturn = 0, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> CreateTicket(List<AgencyCreateTicketAPIViewModel> listTicket, int RequestId)
        {
            try
            {
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();

                foreach (var item in listTicket)
                {
                    var createTicket = new Ticket();
                    createTicket.RequestId = RequestId;
                    createTicket.DeviceId = item.DeviceId;
                    createTicket.Current_TicketStatus = (int)TicketStatusEnum.Await;
                    createTicket.Desciption = item.Desciption;
                    createTicket.CreateDate = DateTime.UtcNow.AddHours(7);                    
                    
                    ticketRepo.Add(createTicket);                    
                }
                ticketRepo.Save();

                return new ResponseObject<bool> { IsError = false, WarningMessage = "Tạo thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Tạo thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }


        }

        public ResponseObject<int> FindITSupporterByRequestId(int requestId)
        {
            int itSupporterIdFound = 0;
            string itSupporterNameFound = "";
            try
            {
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
                var skillRepo = DependencyUtils.Resolve<ISkillRepository>();
                var serviceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
                var serviceItemId = requestRepo.GetActive(p => p.RequestId == requestId).SingleOrDefault().ServiceItemId;
                var serviceITSupportId = serviceItemRepo.GetActive(p => p.ServiceItemId == serviceItemId).SingleOrDefault().ServiceITSupportId;
                var skills = skillRepo.GetActive(a => a.ServiceITSupportId == serviceITSupportId).OrderByDescending(p => p.MonthExperience);                
                
                foreach (var item in skills)
                {
                    var itSupporter = itSupporterRepo.GetActive(p => p.ITSupporterId == item.ITSupporterId && p.IsBusy == false).FirstOrDefault();
                    if (itSupporter != null)
                    {
                        itSupporterIdFound = itSupporter.ITSupporterId;
                        break;
                    }

                }
                if (itSupporterIdFound > 0)
                {
                    return new ResponseObject<int> { IsError = false, SuccessMessage = $"Tìm được Hero {itSupporterNameFound}! Vùi lòng đợi xác nhận", ObjReturn = itSupporterIdFound };
                }
                return new ResponseObject<int> { IsError = true, WarningMessage = "Chưa tìm được Hero nào thích hợp!" };
            }
            catch (Exception ex)
            {
                return new ResponseObject<int> { IsError = true, WarningMessage = "Chưa tìm được Hero nào thích hợp!", ErrorMessage = ex.ToString() };
            }

        }

        public ResponseObject<AgencyDeviceAPIViewModel> GetDeviceByDeviceId(int deviceId)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var devices = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceId == deviceId);
                if (devices == null)
                {
                    return new ResponseObject<AgencyDeviceAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy thiết bị!", ObjReturn = null };
                }
                var agencyDeviceAPIViewModel = new AgencyDeviceAPIViewModel
                {
                    DeviceId = devices.DeviceId,
                    AgencyId = devices.AgencyId,
                    DeviceTypeId = devices.DeviceTypeId,
                    DeviceName = devices.DeviceName,
                    DeviceCode = devices.DeviceCode,
                    GuarantyStartDate = devices.GuarantyStartDate != null ? devices.GuarantyStartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    GuarantyEndDate = devices.GuarantyEndDate != null ? devices.GuarantyEndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    Ip = devices.Ip,
                    Port = devices.Port,
                    DeviceAccount = devices.DeviceAccount,
                    DevicePassword = devices.DevicePassword,
                    SettingDate = devices.SettingDate != null ? devices.SettingDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    Other = devices.Other,
                    CreateDate = devices.CreateDate.ToString("MM/dd/yyyy"),
                    UpdateDate = devices.UpdateDate != null ? devices.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                };
                return new ResponseObject<AgencyDeviceAPIViewModel> { IsError = false, SuccessMessage = "Tìm thấy thiết bị!", ObjReturn = agencyDeviceAPIViewModel };
            }
            catch (Exception e)
            {
                return new ResponseObject<AgencyDeviceAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy thiết bị!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<TicketAPIViewModel>> GetTicketByRequestId(int requestId)
        {
            try
            {
                List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var tickets = ticketRepo.GetActive().Where(a => a.RequestId == requestId).ToList();
                if (tickets.Count <= 0)
                {
                    return new ResponseObject<List<TicketAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy danh sách!", ObjReturn = null };
                }
                foreach (var item in tickets)
                {
                    rsList.Add(new TicketAPIViewModel
                    {
                        TicketId = item.TicketId,
                        RequestId = item.RequestId,
                        DeviceId = item.DeviceId,
                        Desciption = item.Desciption,
                        Current_TicketStatus = item.Current_TicketStatus != null ? Enum.GetName(typeof(TicketStatusEnum), item.Current_TicketStatus) : string.Empty,
                        CurrentITSupporter_Id = item.CurrentITSupporter_Id ?? 0,
                        Rating = item.Rating ?? 0,
                        Estimation = item.Estimation ?? 0,
                        StartTime = item.StartTime != null ? item.StartTime.Value.ToString("dd/MM/yyyy") : string.Empty,
                        Endtime = item.Endtime != null ? item.Endtime.Value.ToString("dd/MM/yyyy") : string.Empty,
                        CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("dd/MM/yyyy") : string.Empty
                    });
                }
                return new ResponseObject<List<TicketAPIViewModel>> { IsError = false, SuccessMessage = "Tìm thấy danh sách!", ObjReturn = rsList };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<TicketAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy danh sách!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<AgencyDeviceAPIViewModel>> GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId)
        {
            try
            {
                List<AgencyDeviceAPIViewModel> rsList = new List<AgencyDeviceAPIViewModel>();
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var devices = deviceRepo.GetActive().Where(a => a.DeviceTypeId == deviceTypeId && a.AgencyId == agencyId).ToList();
                if (devices.Count <= 0)
                {
                    return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy danh sách thiết bị!", ObjReturn = null };
                }
                foreach (var item in devices)
                {
                    rsList.Add(new AgencyDeviceAPIViewModel
                    {
                        DeviceId = item.DeviceId,
                        AgencyId = item.AgencyId,
                        DeviceTypeId = item.DeviceTypeId,
                        DeviceName = item.DeviceName,
                        DeviceCode = item.DeviceCode,
                        GuarantyStartDate = item.GuarantyStartDate != null ? item.GuarantyStartDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        GuarantyEndDate = item.GuarantyEndDate != null ? item.GuarantyEndDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Ip = item.Ip,
                        Port = item.Port,
                        DeviceAccount = item.DeviceAccount,
                        DevicePassword = item.DevicePassword,
                        SettingDate = item.SettingDate != null ? item.SettingDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        Other = item.Other,
                        CreateDate = item.CreateDate.ToString("MM/dd/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });
                }
                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = false, SuccessMessage = "Tìm thấy danh sách thiết bị!", ObjReturn = rsList };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<AgencyDeviceAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy danh sách thiết bị!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id)
        {
            try
            {
                var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                var assignITSupporter = ticketRepo.GetActive().SingleOrDefault(a => a.TicketId == ticket_id);

                if (assignITSupporter != null)
                {
                    assignITSupporter.CurrentITSupporter_Id = current_id_supporter_id;

                    ticketRepo.Edit(assignITSupporter);
                    ticketRepo.Save();
                    return new ResponseObject<bool> { IsError = false, WarningMessage = "Chỉ định người hỗ trợ thành công!", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉ định người hỗ trợ thất bại!", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉ định người hỗ trợ thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

    }
}

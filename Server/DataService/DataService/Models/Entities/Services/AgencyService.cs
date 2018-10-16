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

namespace DataService.Models.Entities.Services
{
    public partial interface IAgencyService
    {

        ResponseObject<AgencyAPIViewModel> ViewProfile(int agency_id);

        ResponseObject<bool> UpdateProfile(AgencyUpdateAPIViewModel model);

        ResponseObject<List<AgencyAPIViewModel>> GetAllAgency();

        ResponseObject<bool> CreateRequest(AgencyCreateRequestAPIViewModel model);

        ResponseObject<bool> CreateTicket(List<AgencyCreateTicketAPIViewModel> listTicket, int RequestId, int current_IT_supporter_Id);

        ResponseObject<bool> RemoveAgency(int agency_id);

        ResponseObject<bool> CreateAgency(AgencyAPIViewModel model);

        ResponseObject<AgencyDeviceAPIViewModel> GetDeviceByDeviceId(int deviceId);

    }

    public partial class AgencyService
    {
        public ResponseObject<AgencyAPIViewModel> ViewProfile(int agency_id)
        {            
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
            if  (agency != null)
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
                        CreateAt = agency.CreateDate != null ? agency.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateAt = agency.UpdateDate != null ? agency.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                   };
                return new ResponseObject<AgencyAPIViewModel> { IsError = false, ObjReturn = agencyAPIViewModel };
            }
            return new ResponseObject<AgencyAPIViewModel> { IsError = true, ErrorMessage ="Không tìm thấy thông tin chi nhánh!"};
        }

        public ResponseObject<bool> UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var updateAgency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == model.AgencyId);
            if (updateAgency.AgencyId == model.AgencyId)
            {
                updateAgency.AgencyName = model.AgencyName;
                updateAgency.Address = model.Address;
                updateAgency.Telephone = model.Telephone;
                updateAgency.UpdateDate = DateTime.Now;

                agencyRepo.Edit(updateAgency);
                agencyRepo.Save();
                return new ResponseObject<bool> { IsError = false, WarningMessage = "Cập nhật thành công!",ObjReturn = true };
            }

            return new ResponseObject<bool> { IsError = true, WarningMessage = "Cập nhật chi nhánh thất bại!", ObjReturn = false };
        }

        public ResponseObject<List<AgencyAPIViewModel>> GetAllAgency()
        {
            List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agencies = agencyRepo.GetActive().ToList();
            if(agencies.Count < 0)
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
                        CreateAt = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateAt = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    });              
            }

            return new ResponseObject<List<AgencyAPIViewModel>> { IsError = false, WarningMessage = "Lấy thông tin tất cả công ty thành công!", ObjReturn = rsList };
        }

        public ResponseObject<bool> RemoveAgency(int agency_id)
        {
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
            if(agency == null)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa chi nhánh thất bại!", ObjReturn = false };
            }
            Deactivate(agency);
            return new ResponseObject<bool> { IsError = false, WarningMessage = "Xóa chi nhánh thành công!", ObjReturn = true };
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
                createTask.CreateDate = DateTime.Now;
                ticketTaskRepo.Add(createTask);
                ticketTaskRepo.Save();
                return new ResponseObject<bool> { IsError = false, WarningMessage = "Tạo chi nhánh thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa chi nhánh thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> CreateRequest(AgencyCreateRequestAPIViewModel model)
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
                createRequest.ServiceItemId = model.ServiceItemId;
                requestRepo.Add(createRequest);
                requestRepo.Save();

                var current_IT_supporter_Id = AssignITSupporter(model.ServiceItemId);
                CreateTicket(model.Ticket, createRequest.RequestId, current_IT_supporter_Id);

                createRequest.RequestStatus = (int)RequestStatusEnum.Processing;

                requestRepo.Save();
                return new ResponseObject<bool> { IsError = false, WarningMessage = "Tạo yêu cầu thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Tạo yêu cầu thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> CreateTicket(List<AgencyCreateTicketAPIViewModel> listTicket, int RequestId, int current_IT_supporter_Id)
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

                    createTicket.CurrentITSupporter_Id = current_IT_supporter_Id;
                    ticketRepo.Add(createTicket);

                    createTicket.Current_TicketStatus = (int)TicketStatusEnum.In_Process;
                }
                ticketRepo.Save();

                return new ResponseObject<bool> { IsError = false, WarningMessage = "Tạo thành công!", ObjReturn = true };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Tạo thất bại!", ObjReturn = false, ErrorMessage = e.ToString() };
            }
            

        }

        private int AssignITSupporter(int ServiceItemId)
        {
            try
            {
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var itSupporter = itSupporterRepo.GetActive(p => (p.IsBusy == null || p.IsBusy == false)).FirstOrDefault(x => x.Skills.OrderByDescending(o => o.MonthExperience).Any(s => s.ServiceItemId == ServiceItemId));
                if (itSupporter != null)
                {
                    itSupporter.IsBusy = true;

                    itSupporterRepo.Edit(itSupporter);

                    itSupporterRepo.Save();

                }
                return itSupporter.ITSupporterId;
            }
            catch (Exception e)
            {

                return 0;
            }
            
        }

        public ResponseObject<AgencyDeviceAPIViewModel> GetDeviceByDeviceId(int deviceId)
        {
            try
            {
                var deviceRepo = DependencyUtils.Resolve<IDeviceRepository>();
                var devices = deviceRepo.GetActive().SingleOrDefault(a => a.DeviceId == deviceId);
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
                        CreateDate = devices.CreateDate != null ? devices.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                        UpdateDate = devices.UpdateDate != null ? devices.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                    };
                    return new ResponseObject<AgencyDeviceAPIViewModel> { IsError = false, WarningMessage = "Tìm thấy thiết bị!", ObjReturn = agencyDeviceAPIViewModel };
            }
            catch (Exception e)
            {
                return new ResponseObject<AgencyDeviceAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy thiết bị!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
    }
}

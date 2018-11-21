using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CapstoneProject_ODTS.ControllersApi
{
    public interface IITSupporterController
    {

        HttpResponseMessage ViewProfileITSupporter(int itSupporter_id);

        HttpResponseMessage ViewAllOwnerTicket(int ITsupporter_id);

        HttpResponseMessage EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model);

        HttpResponseMessage UpdateTaskStatus(int requestTaskId, bool isDone);

        HttpResponseMessage UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        HttpResponseMessage GetAllTaskByRequestId(int requestId);

        HttpResponseMessage CreateTask(ITSupporterCreateTaskAPIViewModel model);

        HttpResponseMessage SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        HttpResponseMessage SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        HttpResponseMessage GetGuidelineByServiceItemID(int service_item_Id);

        HttpResponseMessage LoginITSupporter(string username, string password, int roleId);

        HttpResponseMessage ITSuppoterStatistic(int year, int month);

        HttpResponseMessage UpdateStatusIT(int itsupporter_id, bool isOnline);

        HttpResponseMessage UpdateStartTime(int request_id, DateTime start_time);

        HttpResponseMessage UpdateEndTime(int request_id, DateTime end_time);

        HttpResponseMessage GetIsOnlineOFITSupporter(int itsupporter_id);

        HttpResponseMessage GetIsBusyOFITSupporter(int itsupporter_id);

        HttpResponseMessage UpdateIsBusyOFITSupporter(int itsupporter_id);

        HttpResponseMessage DeleteTaskStatus(int requestTaskId);

        HttpResponseMessage ITSuppoterStatisticAll(int itsupporterId);

        HttpResponseMessage ViewRequestITSupporter(int itsupporter_id);

        HttpResponseMessage GetDeviceDetailByDeviceCode(string devcieCode);
    }

    public class ITSupporterController : ApiController, IITSupporterController
    {
        private ITSupporterDomain _ITSupporterDomain;

        private AccountDomain _accountDomain;

        private DeviceDomain _deviceDomain;

        public ITSupporterController()
        {
            _ITSupporterDomain = new ITSupporterDomain();
            _accountDomain = new AccountDomain();
            _deviceDomain = new DeviceDomain();
        }

        [HttpPost]
        [Route("ITsuportter/login")]
        public HttpResponseMessage LoginITSupporter(string username, string password, int roleId)
        {
            var result = _accountDomain.CheckLoginForITSupporter(username, password, roleId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsuportter/update_ticket_status")]
        public HttpResponseMessage UpdateProfile(ITSupporterUpdateAPIViewModel model)
        {           
            var result = _ITSupporterDomain.UpdateTicketStatus(model);
            
            return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật Thành Công!");
        }

        [HttpGet]
        [Route("ITsupporter/view_profile_ITsupporter")]
        public HttpResponseMessage ViewProfileITSupporter(int itSupporter_id)
        {
            var result = _ITSupporterDomain.ViewProfileITSupporter(itSupporter_id);            

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/view_all_owner_ticket")]
        public HttpResponseMessage ViewAllOwnerTicket(int ITsupporter_id)
        {
            var result = _ITSupporterDomain.ViewAllOwnerTicket(ITsupporter_id);            

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsuportter/update_estimate_time_ticket")]
        public HttpResponseMessage EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {
            var result = _ITSupporterDomain.EstimateTimeTicket(model);            

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsuportter/update_task_status")]
        public HttpResponseMessage UpdateTaskStatus(int requestTaskId, bool isDone)
        {
            var result = _ITSupporterDomain.UpdateTaskStatus(requestTaskId, isDone);           

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsuportter/delete_task")]
        public HttpResponseMessage DeleteTaskStatus(int requestTaskId)
        {
            var result = _ITSupporterDomain.DeleteTaskStatus(requestTaskId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsuportter/update_profile")]
        public HttpResponseMessage UpdateProfile(ITSupporterUpdateProfileAPIViewModel model)
        {
            var result = _ITSupporterDomain.UpdateProfile(model);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ITsuportter/create_task")]
        public HttpResponseMessage CreateTask(ITSupporterCreateTaskAPIViewModel model)
        {
            var result = _ITSupporterDomain.CreateTask(model);
           
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpPost]
        [Route("ITsuportter/create_task_from_guidline")]
        public HttpResponseMessage CreateTaskFromGuidline(List<ITSupporterCreateTaskAPIViewModel> model)
        {
            var result = _ITSupporterDomain.CreateTaskFromGuidline(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpGet]
        [Route("ITsuportter/all_task_by_requestId/{requestId}")]
        public HttpResponseMessage GetAllTaskByRequestId(int requestId)
        {
            var result = _ITSupporterDomain.GetAllTaskByRequestId(requestId);

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpPost]
        [Route("ITsuportter/monitor_time_task")]
        public HttpResponseMessage SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model)
        {
            var result = _ITSupporterDomain.SetMonitorTimeTask(model);
            
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpPost]
        [Route("ITsuportter/set_priority_task")]
        public HttpResponseMessage SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model)
        {
            var result = _ITSupporterDomain.SetPriorityTask(model);            

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpGet]
        [Route("ITsupporter/view_guideline")]
        public HttpResponseMessage GetGuidelineByServiceItemID(int service_item_Id)
        {
            var result = _ITSupporterDomain.GetGuidelineByServiceItemID(service_item_Id);
           
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/view_itsupporter_statistic")]
        public HttpResponseMessage ITSuppoterStatistic(int year, int month)
        {
            var result = _ITSupporterDomain.ITSuppoterStatistic(year, month);
            //var result = _ITSupporterDomain.ServiceITSuppoterStatistic(year, month);
            //var r = new RequestDomain();
            //var result = r.GetRequestStatistic(month, year);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/view_itsupporter_statistic_all")]
        public HttpResponseMessage ITSuppoterStatisticAll(int itsupporterId)
        {
            var result = _ITSupporterDomain.ITSuppoterStatisticAll(itsupporterId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ITsupporter/update_status_it")]
        public HttpResponseMessage UpdateStatusIT(int itsupporter_id, bool isOnline)
        {
            var result = _ITSupporterDomain.UpdateStatusIT(itsupporter_id, isOnline);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ITsupporter/update_starttime")]
        public HttpResponseMessage UpdateStartTime(int request_id, DateTime start_time)
        {
            var result = _ITSupporterDomain.UpdateStartTime(request_id, start_time);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("ITsupporter/update_endtime")]
        public HttpResponseMessage UpdateEndTime(int request_id, DateTime end_time)
        {
            var result = _ITSupporterDomain.UpdateEndTime(request_id, end_time);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/get_Is_Online")]
        public HttpResponseMessage GetIsOnlineOFITSupporter(int itsupporter_id)
        {
            var result = _ITSupporterDomain.GetIsOnlineOFITSupporter(itsupporter_id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/get_Is_Busy")]
        public HttpResponseMessage GetIsBusyOFITSupporter(int itsupporter_id)
        {
            var result = _ITSupporterDomain.GetIsBusyOFITSupporter(itsupporter_id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("ITsupporter/update_Is_Busy_False")]
        public HttpResponseMessage UpdateIsBusyOFITSupporter(int itsupporter_id)
        {
            var result = _ITSupporterDomain.UpdateIsBusyOFITSupporter(itsupporter_id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("ITsupporter/view_all_feedback")]
        public HttpResponseMessage ViewRequestITSupporter(int itsupporter_id)
        {
            var result = _ITSupporterDomain.ViewRequestITSupporter(itsupporter_id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [Route("ITsupporter/check_device_info_by_code")]
        public HttpResponseMessage GetDeviceDetailByDeviceCode(string devcieCode)
        {
            var result = _deviceDomain.GetDeviceDetailByDeviceCode(devcieCode);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}


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

        HttpResponseMessage UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model);

        HttpResponseMessage UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        HttpResponseMessage CreateTask(ITSupporterCreateTaskAPIViewModel model);

        HttpResponseMessage SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        HttpResponseMessage SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        HttpResponseMessage GetGuidelineByServiceItemID(int service_item_Id);

        HttpResponseMessage LoginITSupporter(string username, string password, int roleId);

        HttpResponseMessage ITSuppoterStatistic(int itsupporterId, int year, int month);

        HttpResponseMessage UpdateStatusIT(int itsupporter_id, bool isOnline);

        HttpResponseMessage UpdateStartTime(int request_id, DateTime start_time);
    }

    public class ITSupporterController : ApiController, IITSupporterController
    {
        private ITSupporterDomain _ITSupporterDomain;

        private AccountDomain _accountDomain;

        public ITSupporterController()
        {
            _ITSupporterDomain = new ITSupporterDomain();
            _accountDomain = new AccountDomain();
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
        public HttpResponseMessage UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model)
        {
            var result = _ITSupporterDomain.UpdateTaskStatus(model);           

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
        public HttpResponseMessage ITSuppoterStatistic(int itsupporterId, int year, int month)
        {
            var result = _ITSupporterDomain.ITSuppoterStatistic(itsupporterId, year, month);

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

    }
}


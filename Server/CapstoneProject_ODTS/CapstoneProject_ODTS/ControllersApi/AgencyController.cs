using DataService.APIViewModels;
using DataService.CustomTools;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Timers;
using System.Web.Http;

namespace CapstoneProject_ODTS.ControllersApi
{
    public interface IAgencyController
    {
        HttpResponseMessage ViewProfile(int agency_id);

        HttpResponseMessage UpdateProfile(AgencyUpdateAPIViewModel model);

        HttpResponseMessage ViewAllDevice(int agency_id);

        HttpResponseMessage CreateRequest(RequestAllTicketWithStatusAgencyAPIViewModel model);

        HttpResponseMessage GetDeviceDetails(int deviceId);

        HttpResponseMessage GetTicketByRequestId(int requestId);

        HttpResponseMessage GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId);

        HttpResponseMessage AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id);

        HttpResponseMessage GetServiceITSupportByAgencyId(int agencyId);

        HttpResponseMessage GetAllServiceItemByServiceId(int serviceId);

        HttpResponseMessage GetAllDeviceByAgencyIdAndServiceId(int agencyId, int serviceId);

        HttpResponseMessage LoginAgency(string username, string password, int roleId);

        HttpResponseMessage FindITSupporterByRequestId(int requestId);

        HttpResponseMessage GetAgencyStatistic(int agencyId);
    }

    public class AgencyController : ApiController, IAgencyController
    {
        private AgencyDomain _agencyDomain;

        private ServiceITSupportDomain _serviceITSupportDomain;

        private ServiceItemDomain _serviceItemDomain;

        private DeviceDomain _deviceDomain;

        private AccountDomain _accountDomain;

        private RequestDomain _requestDomain;

        public AgencyController()
        {
            _agencyDomain = new AgencyDomain();
            _serviceITSupportDomain = new ServiceITSupportDomain();
            _serviceItemDomain = new ServiceItemDomain();
            _deviceDomain = new DeviceDomain();
            _accountDomain = new AccountDomain();
            _requestDomain = new RequestDomain();
        }

        [HttpPost]
        [Route("agency/login")]
        public HttpResponseMessage LoginAgency(string username, string password, int roleId)
        {
            var result = _accountDomain.CheckLoginForAgency(username, password, roleId);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/view_profile_agency")]
        public HttpResponseMessage ViewProfile(int agency_id)
        {
            var result = _agencyDomain.ViewProfile(agency_id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("agency/update_profile_agency")]
        public HttpResponseMessage UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            var result = _agencyDomain.UpdateProfile(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/view_all_device")]
        public HttpResponseMessage ViewAllDevice(int agency_id)
        {
            var result = _agencyDomain.ViewAllDeviceByAgencyId(agency_id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("agency/create_request")]
        public HttpResponseMessage CreateRequest(RequestAllTicketWithStatusAgencyAPIViewModel model)
        {
            var result = _agencyDomain.CreateRequest(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpGet]
        [Route("agency/get_device_details")]
        public HttpResponseMessage GetDeviceDetails(int deviceId)
        {
            var result = _agencyDomain.ViewProfile(deviceId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/get_ticket_by_requestId")]
        public HttpResponseMessage GetTicketByRequestId(int requestId)
        {
            var result = _agencyDomain.GetTicketByRequestId(requestId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/get_device_by_devicetypeId")]
        public HttpResponseMessage GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId)
        {
            var result = _agencyDomain.GetDevicesByDeviceTypeId(deviceTypeId, agencyId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        [Route("agency/assign_ticket_for_ITsupporter")]
        public HttpResponseMessage AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id)
        {
            var result = _agencyDomain.AssignTicketForITSupporter(ticket_id, current_id_supporter_id);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/serviceITSupport/{agencyId}")]
        public HttpResponseMessage GetServiceITSupportByAgencyId(int agencyId)
        {
            var result = _serviceITSupportDomain.GetAllServiceITSupportByAgencyId(agencyId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/serviceItem/{serviceId}")]
        public HttpResponseMessage GetAllServiceItemByServiceId(int serviceId)
        {
            var result = _serviceItemDomain.GetAllServiceItemByServiceId(serviceId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/device_in_agency_serviceGroup/{agencyId}/{serviceId}")]
        public HttpResponseMessage GetAllDeviceByAgencyIdAndServiceId(int agencyId, int serviceId)
        {
            var result = _deviceDomain.ViewAllDeviceByAgencyIdAndServiceId(agencyId, serviceId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/dashboard/{agencyId}")]
        public HttpResponseMessage GetAgencyStatistic(int agencyId)
        {
            var result = _agencyDomain.GetAgencyStatistic(agencyId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("agency/find_itSupporter_by_requestId/{requestId}")]
        public HttpResponseMessage FindITSupporterByRequestId(int requestId)
        {
            var result = _agencyDomain.FindITSupporterByRequestId(requestId);

            if (!result.IsError && result.ObjReturn > 0)
            {
                FirebaseService firebaseService = new FirebaseService();
                firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(result.ObjReturn, requestId);

                int counter = 60;

                while (counter > 0)
                {
                    counter--;
                    Thread.Sleep(1000);
                }
                _requestDomain.AcceptRequestFromITSupporter(result.ObjReturn, requestId, false);

                return Request.CreateResponse(HttpStatusCode.OK, result.SuccessMessage);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result.WarningMessage);

        }
    }
}


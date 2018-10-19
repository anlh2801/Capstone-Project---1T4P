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
    public interface IAgencyController
    {
        HttpResponseMessage ViewProfile(int agency_id);

        HttpResponseMessage UpdateProfile(AgencyUpdateAPIViewModel model);

        HttpResponseMessage ViewAllDevice(int agency_id);

        HttpResponseMessage CreateRequest(AgencyCreateRequestAPIViewModel model);

        HttpResponseMessage GetDeviceDetails(int deviceId);

        HttpResponseMessage GetTicketByRequestId(int requestId);

        HttpResponseMessage GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId);

        HttpResponseMessage AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id);

        HttpResponseMessage GetServiceITSupportByAgencyId(int agencyId);

        HttpResponseMessage GetAllServiceItemByServiceId(int serviceId);

        HttpResponseMessage GetAllDeviceByAgencyIdAndServiceItem(int agencyId, int serviceId);
    }

    public class AgencyController : ApiController, IAgencyController
    {
        private AgencyDomain _agencyDomain;

        private ServiceITSupportDomain _serviceITSupportDomain;

        private ServiceItemDomain _serviceItemDomain;

        private DeviceDomain _deviceDomain;

        public AgencyController()
        {
            _agencyDomain = new AgencyDomain();
            _serviceITSupportDomain = new ServiceITSupportDomain();
            _serviceItemDomain = new ServiceItemDomain();
            _deviceDomain = new DeviceDomain();
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
        public HttpResponseMessage CreateRequest(AgencyCreateRequestAPIViewModel model)
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
        public HttpResponseMessage GetAllDeviceByAgencyIdAndServiceItem(int agencyId, int serviceId)
        {
            var result = _deviceDomain.ViewAllDeviceByAgencyIdAndServiceId(agencyId, serviceId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
    }
}


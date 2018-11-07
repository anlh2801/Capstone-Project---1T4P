using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IAgencyDomain
    {
        ResponseObject<AgencyAPIViewModel> ViewProfile(int agency_id);

        ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyId(int agency_id);

        ResponseObject<bool> RemoveAgency(int agency_id);

        ResponseObject<bool> UpdateProfile(AgencyUpdateAPIViewModel model);

        ResponseObject<List<AgencyAPIViewModel>> GetAllAgency();

        ResponseObject<int> CreateRequest(AgencyCreateRequestAPIViewModel model);

        ResponseObject<AgencyDeviceAPIViewModel> GetDeviceDetails(int deviceId);

        ResponseObject<List<TicketAPIViewModel>> GetTicketByRequestId(int requestId);

        ResponseObject<List<AgencyDeviceAPIViewModel>> GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId);

        ResponseObject<bool> AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id);

        ResponseObject<int> FindITSupporterByRequestId(int requestId);

        ResponseObject<List<AgencyStatisticalAPIViewModel>> AgencyStatistic(int agencyId);
    }

    public class AgencyDomain : BaseDomain, IAgencyDomain
    {
        public ResponseObject<AgencyAPIViewModel> ViewProfile(int agency_id)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.ViewProfile(agency_id);

            return agency;
        }

        public ResponseObject<bool> UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            var agencyService = this.Service<IAgencyService>();

            var result = agencyService.UpdateProfile(model);

            return result;
        }

        public ResponseObject<List<AgencyDeviceAPIViewModel>> ViewAllDeviceByAgencyId(int agency_id)
        {
            var agencyDeviceService = this.Service<IDeviceService>();

            var agencies = agencyDeviceService.ViewAllDeviceByAgencyId(agency_id);

            return agencies;
        }

        public ResponseObject<List<AgencyAPIViewModel>> GetAllAgency()
        {
            var TicketList = new List<AgencyAPIViewModel>();

            var agencyService = this.Service<IAgencyService>();


            var agencies = agencyService.GetAllAgency();

            return agencies;
        }



        public ResponseObject<int> CreateRequest(AgencyCreateRequestAPIViewModel model)
        {
            var agencyService = this.Service<IAgencyService>();

            var result = agencyService.CreateRequest(model);
            return result;
        }
        public ResponseObject<bool> RemoveAgency(int agency_id)
        {
            var TicketList = new List<AgencyAPIViewModel>();

            var agencyService = this.Service<IAgencyService>();
            var agency = agencyService.RemoveAgency(agency_id);
            return agency;
        }

        public ResponseObject<bool> CreateAgency(AgencyAPIViewModel model)
        {
            var iTSupporterService = this.Service<IAgencyService>();

            var result = iTSupporterService.CreateAgency(model);

            return result;
        }

        public ResponseObject<AgencyDeviceAPIViewModel> GetDeviceDetails(int deviceId)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.GetDeviceByDeviceId(deviceId);

            return agency;
        }

        public ResponseObject<List<TicketAPIViewModel>> GetTicketByRequestId(int requestId)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.GetTicketByRequestId(requestId);

            return agency;
        }

        public ResponseObject<List<AgencyDeviceAPIViewModel>> GetDevicesByDeviceTypeId(int deviceTypeId, int agencyId)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.GetDevicesByDeviceTypeId(deviceTypeId, agencyId);

            return agency;
        }

        public ResponseObject<bool> AssignTicketForITSupporter(int ticket_id, int current_id_supporter_id)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.AssignTicketForITSupporter(ticket_id, current_id_supporter_id);

            return agency;
        }

        public ResponseObject<int> FindITSupporterByRequestId(int requestId)
        {
            var agencyService = this.Service<IAgencyService>();

            var itSupporter = agencyService.FindITSupporterByRequestId(requestId);
            return itSupporter;
        }

        public ResponseObject<List<AgencyStatisticalAPIViewModel>> AgencyStatistic(int agencyId)
        {
            var agencyService = this.Service<IAgencyService>();

            var itSupporter = agencyService.AgencyStatistic(agencyId);
           
            return itSupporter;
        }
    }
}

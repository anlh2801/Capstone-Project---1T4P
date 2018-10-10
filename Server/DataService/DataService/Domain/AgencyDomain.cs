using DataService.APIViewModels;
using DataService.Models.Entities.Services;
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
        AgencyAPIViewModel ViewProfile(int agency_id);

        List<AgencyDeviceAPIViewModel> ViewAllDeviceByAgencyId(int agency_id);

        bool UpdateProfile(AgencyUpdateAPIViewModel model);

        List<AgencyAPIViewModel> GetAllAgency();

        bool CreateRequest(AgencyCreateRequestAPIViewModel model);
    }

    public class AgencyDomain : BaseDomain, IAgencyDomain
    {
        public AgencyAPIViewModel ViewProfile(int agency_id)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.ViewProfile(agency_id);

            return agency;
        }

        public bool UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            var agencyService = this.Service<IAgencyService>();

            var result = agencyService.UpdateProfile(model);

            return result;
        }

        public List<AgencyDeviceAPIViewModel> ViewAllDeviceByAgencyId(int agency_id)
        {
            var agencyDeviceService = this.Service<IDeviceService>();

            var agencies = agencyDeviceService.ViewAllDeviceByAgencyId(agency_id);

            return agencies;
        }

        public List<AgencyAPIViewModel> GetAllAgency()
        {
            var TicketList = new List<AgencyAPIViewModel>();

            var agencyService = this.Service<IAgencyService>();


            var agencies = agencyService.GetAllAgency();

            return agencies;
        }



        public bool CreateRequest(AgencyCreateRequestAPIViewModel model)
        {
            var agencyService = this.Service<IAgencyService>();

            var result = agencyService.CreateRequest(model);
            return result;
        }
        public Boolean removeAgency(int agency_id)
        {
            var TicketList = new List<AgencyAPIViewModel>();

            var agencyService = this.Service<IAgencyService>();
            bool a = agencyService.removeAgency(agency_id);
            return a;
        }

        public bool CreateAgency(AgencyAPIViewModel model)
        {
            var iTSupporterService = this.Service<IAgencyService>();

            var result = iTSupporterService.CreateAgency(model);

            return result;
        }
    }
}

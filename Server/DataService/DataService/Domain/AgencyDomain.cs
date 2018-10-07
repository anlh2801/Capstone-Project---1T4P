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

        List<AgencyDeviceAPIViewModel> ViewAllDevice(int agency_id);

        bool UpdateProfile(AgencyUpdateAPIViewModel model);

        List<AgencyAPIViewModel> GetAllAgency();
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

        public List<AgencyDeviceAPIViewModel> ViewAllDevice(int agency_id)
        {
            var agencyDeviceService = this.Service<IDeviceService>();

            var agency = agencyDeviceService.ViewAllDevice(agency_id);

            return agency;
        }

        public List<AgencyAPIViewModel> GetAllAgency()
        {
            var TicketList = new List<AgencyAPIViewModel>();

            var TicketService = this.Service<IAgencyService>();


            var companies = TicketService.GetAllAgency();

            return companies;
        }
    }
}

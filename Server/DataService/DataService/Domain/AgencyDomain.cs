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

        List<AgencyAPIViewModel> ViewProfile(int agency_id);
    }

    public class AgencyDomain : BaseDomain, IAgencyDomain
    {
        public List<AgencyAPIViewModel> ViewProfile(int agency_id)
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.ViewProfile(agency_id);

            return agency;
        }
    }
}

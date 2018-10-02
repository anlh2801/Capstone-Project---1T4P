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

        List<AgencyAPIViewModel> GetAllAgency();
    }

    public class AgencyDomain : BaseDomain, IAgencyDomain
    {
        public List<AgencyAPIViewModel> GetAllAgency()
        {
            var agencyService = this.Service<IAgencyService>();

            var agency = agencyService.GetAllAgency();

            return agency;
        }
    }
}

using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
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
        List<AgencyViewModel> GetAllAgency();
    }

    public partial class AgencyService
    {
        public List<AgencyViewModel> GetAllAgency()
        {
            List<AgencyViewModel> rsList = new List<AgencyViewModel>();
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().ToList();
            foreach (var item in agency)
            {
                var a = new AgencyViewModel(item);
                rsList.Add(a);
            }

            return rsList;
        }
    }
}

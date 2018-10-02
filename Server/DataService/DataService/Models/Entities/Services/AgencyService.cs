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
        List<AgencyAPIViewModel> GetAllAgency();
    }

    public partial class AgencyService
    {
        public List<AgencyAPIViewModel> GetAllAgency()
        {
            List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().ToList();
            foreach (var item in agency)
            {

                rsList.Add(new AgencyAPIViewModel
                {
                    AgencyId = item.AgencyId,
                    CompanyId = item.CompanyId ?? 0,
                    AccountId = item.AccountId,
                    AgencyName = item.AgencyName,
                    Address = item.Address,
                    Telephone = item.Telephone,
                    CreateAt = item.CreateAt.Value.ToString("MM/dd/yyyy"),
                    UpdateAt = item.UpdateAt.Value.ToString("MM/dd/yyyy")
                });
            }

            return rsList;
        }
    }
}

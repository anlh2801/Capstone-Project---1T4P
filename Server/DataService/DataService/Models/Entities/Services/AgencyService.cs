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
        AgencyAPIViewModel ViewProfile(int agency_id);
        bool UpdateProfile(AgencyUpdateAPIViewModel model);
        List<AgencyAPIViewModel> GetAllAgency();
    }

    public partial class AgencyService
    {
        public AgencyAPIViewModel ViewProfile(int agency_id)
        {            
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == agency_id);
            if  (agency != null)
            {
                   var agencyAPIViewModel = new AgencyAPIViewModel
                    {
                        AgencyId = agency.AgencyId,
                        CompanyId = agency.CompanyId ?? 0,
                        AccountId = agency.AccountId,
                        AgencyName = agency.AgencyName,
                        Address = agency.Address,
                        Telephone = agency.Telephone,
                        CreateAt = agency.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateAt = agency.UpdateDate.Value.ToString("MM/dd/yyyy")
                    };
                return agencyAPIViewModel;
            }
            return null;
        }

        public bool UpdateProfile(AgencyUpdateAPIViewModel model)
        {
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var updateAgency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == model.AgencyId);
            if (updateAgency.AgencyId == model.AgencyId)
            {
                updateAgency.AgencyName = model.AgencyName;
                updateAgency.Address = model.Address;
                updateAgency.Telephone = model.Telephone;
                updateAgency.UpdateDate = DateTime.Now;

                agencyRepo.Edit(updateAgency);
                agencyRepo.Save();
                return true;
            }

            return false;
        }

        public List<AgencyAPIViewModel> GetAllAgency()
        {
            List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
            var companyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var companies = companyRepo.GetActive().ToList();

            foreach (var item in companies)
            {
                rsList.Add(new AgencyAPIViewModel
                {
                    AgencyId = item.AgencyId,
                    CompanyName = item.Company.CompanyName,
                    UserName = item.Account.Username,
                    AgencyName = item.AgencyName,
                    Address =  item.Address,
                    Telephone = item.Telephone,
                    CreateAt = item.CreateDate != null ? item.CreateDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    UpdateAt = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty
                });
            }

            return rsList;
        }

    }
}

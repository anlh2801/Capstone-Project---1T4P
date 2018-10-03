﻿using DataService.APIViewModels;
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
        List<AgencyAPIViewModel> ViewProfile(int agency_id);
        bool UpdateProfile(UpdateAgencyAPIViewModel model);
    }

    public partial class AgencyService
    {
        public List<AgencyAPIViewModel> ViewProfile(int agency_id)
        {
            List<AgencyAPIViewModel> rsList = new List<AgencyAPIViewModel>();
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var agency = agencyRepo.GetActive().ToList();
            foreach (var item in agency)
            {
                if(agency_id == item.AgencyId)
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
                
            }

            return rsList;
        }

        public bool UpdateProfile(UpdateAgencyAPIViewModel model)
        {
            var agencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
            var updateAgency = agencyRepo.GetActive().SingleOrDefault(a => a.AgencyId == model.AgencyId);
            if (updateAgency.AgencyId == model.AgencyId)
            {
                updateAgency.AgencyName = model.AgencyName;
                updateAgency.Address = model.Address;
                updateAgency.Telephone = model.Telephone;
                updateAgency.UpdateAt = DateTime.Now;

                agencyRepo.Edit(updateAgency);
                agencyRepo.Save();
                return true;
            }

            return false;
        }

    }
}

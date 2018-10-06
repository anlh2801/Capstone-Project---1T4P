﻿using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    
    public interface IITSupporterDomain
    {
       
        List<ITSupporterAPIViewModel> GetAllITSupporter();
    }

    public class ITSupporterDomain : BaseDomain, IITSupporterDomain
    {
        public List<ITSupporterAPIViewModel> GetAllITSupporter()
        {          
            var ITSupporterService = this.Service<IITSupporterService>();

            var companies = ITSupporterService.GetAllITSupporter();
           
            return companies;
        }
    }
}

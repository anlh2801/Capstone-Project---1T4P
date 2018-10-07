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

        bool UpdateTicketStatus(ITSupporterUpdateAPIViewModel model);

        List<ITSupporterAPIViewModel> ViewProfileITSupporter(int ITsupporter_id);

        List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id);
    }

    public class ITSupporterDomain : BaseDomain, IITSupporterDomain
    {
        public List<ITSupporterAPIViewModel> GetAllITSupporter()
        {          
            var ITSupporterService = this.Service<IITSupporterService>();

            var itSupporters = ITSupporterService.GetAllITSupporter();
           
            return itSupporters;
        }

        public bool UpdateTicketStatus(ITSupporterUpdateAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateTicketStatus(model);

            return result;
        }

        public List<ITSupporterAPIViewModel> ViewProfileITSupporter(int ITsupporter_id)
        {
            var ITSupporterService = this.Service<IITSupporterService>();

            var ITSupporter = ITSupporterService.ViewProfileITSupporter(ITsupporter_id);

            return ITSupporter;
        }

        public List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id)
        {
            var ITSupporterService = this.Service<IITSupporterService>();

            var ITSupporter = ITSupporterService.ViewAllOwnerTicket(ITsupporter_id);

            return ITSupporter;
        }
    }
}

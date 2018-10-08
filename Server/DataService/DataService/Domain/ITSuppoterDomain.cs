using DataService.APIViewModels;
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

        ITSupporterAPIViewModel ViewProfileITSupporter(int itSupporter_id);

        List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id);

        bool EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model);

        bool UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model);

        bool UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);
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

        public ITSupporterAPIViewModel ViewProfileITSupporter(int itSupporter_id)
        {
            var itSupporterService = this.Service<IITSupporterService>();

            var itSupporter = itSupporterService.ViewProfileITSupporter(itSupporter_id);

            return itSupporter;
        }

        public List<TicketAPIViewModel> ViewAllOwnerTicket(int ITsupporter_id)
        {
            var ITSupporterService = this.Service<IITSupporterService>();

            var ITSupporter = ITSupporterService.ViewAllOwnerTicket(ITsupporter_id);

            return ITSupporter;
        }

        public bool EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.EstimateTimeTicket(model);

            return result;
        }

        public bool UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateTaskStatus(model);

            return result;
        }

        public bool UpdateProfile(ITSupporterUpdateProfileAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateProfile(model);

            return result;
        }
    }
}

using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    
    public interface IITSupporterDomain
    {       
        ResponseObject<List<ITSupporterAPIViewModel>> GetAllITSupporter();

        ResponseObject<bool> UpdateTicketStatus(ITSupporterUpdateAPIViewModel model);

        ResponseObject<ITSupporterAPIViewModel> ViewProfileITSupporter(int itSupporter_id);

        ResponseObject<List<TicketAPIViewModel>> ViewAllOwnerTicket(int ITsupporter_id);

        ResponseObject<bool> EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model);

        ResponseObject<bool> UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model);

        ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model);

        ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        ResponseObject<GuidelineAPIViewModel> GetGuidelineByServiceItemID(int service_item_Id);

        ResponseObject<ITSupporterStatisticAPIViewModel> ITSuppoterStatistic(int itsupporterId, int year, int month);

        ResponseObject<bool> UpdateStatusIT(int itsupporter_id, bool isOnline);

        ResponseObject<bool> UpdateStartTime(int request_id, DateTime start_time);
    }

    public class ITSupporterDomain : BaseDomain, IITSupporterDomain
    {
        public ResponseObject<List<ITSupporterAPIViewModel>> GetAllITSupporter()
        {          
            var ITSupporterService = this.Service<IITSupporterService>();

            var itSupporters = ITSupporterService.GetAllITSupporter();
           
            return itSupporters;
        }

        public ResponseObject<bool> UpdateTicketStatus(ITSupporterUpdateAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateTicketStatus(model);

            return result;
        }

        public ResponseObject<ITSupporterAPIViewModel> ViewProfileITSupporter(int itSupporter_id)
        {
            var itSupporterService = this.Service<IITSupporterService>();

            var itSupporter = itSupporterService.ViewProfileITSupporter(itSupporter_id);

            return itSupporter;
        }

        public ResponseObject<List<TicketAPIViewModel>> ViewAllOwnerTicket(int ITsupporter_id)
        {
            var ITSupporterService = this.Service<IITSupporterService>();

            var ITSupporter = ITSupporterService.ViewAllOwnerTicket(ITsupporter_id);

            return ITSupporter;
        }

        public ResponseObject<bool> EstimateTimeTicket(ITSupporterUpdateEstimateTimeAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.EstimateTimeTicket(model);

            return result;
        }

        public ResponseObject<bool> UpdateTaskStatus(ITSupporterUpdateTaskStatusAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateTaskStatus(model);

            return result;
        }

        public ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateProfile(model);

            return result;
        }

        public ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.CreateTask(model);

            return result;
        }

        public ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.SetMonitorTimeTask(model);

            return result;
        }


        public ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.SetPriorityTask(model);

            return result;
        }

        public ResponseObject<GuidelineAPIViewModel> GetGuidelineByServiceItemID(int service_item_Id)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.GetGuidelineByServiceItemID(service_item_Id);

            return result;
        }

        public ResponseObject<ITSupporterStatisticAPIViewModel> ITSuppoterStatistic(int itsupporterId, int year, int month)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.ITSuppoterStatistic(itsupporterId, year, month);

            return result;
        }
        public ResponseObject<bool> UpdateStatusIT(int itsupporter_id, bool isOnline)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateStatusIT(itsupporter_id, isOnline);

            return result;
        }

        public ResponseObject<bool> UpdateStartTime(int request_id, DateTime start_time)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateStartTime(request_id, start_time);

            return result;
        }
    }
}

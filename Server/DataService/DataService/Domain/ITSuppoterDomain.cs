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

        ResponseObject<bool> UpdateTaskStatus(int requestTaskId, bool isDone);

        ResponseObject<bool> DeleteTaskStatus(int requestTaskId);

        ResponseObject<bool> UpdateProfile(ITSupporterUpdateProfileAPIViewModel model);

        ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> GetAllTaskByRequestId(int requestId);

        ResponseObject<bool> CreateTask(ITSupporterCreateTaskAPIViewModel model);

        ResponseObject<bool> CreateTaskFromGuidline(List<ITSupporterCreateTaskAPIViewModel> model);

        ResponseObject<bool> SetMonitorTimeTask(ITSupporterSetMonitorTimeTaskAPIViewModel model);

        ResponseObject<bool> SetPriorityTask(ITSupporterSetPriorityTaskAPIViewModel model);

        ResponseObject<List<GuidelineAPIViewModel>> GetGuidelineByServiceItemID(int service_item_Id);

        ResponseObject<List<ITSupporterStatisticAPIViewModel>> ITSuppoterStatistic(int year, int month);

        ResponseObject<bool> UpdateStatusIT(int itsupporter_id, bool isOnline);

        ResponseObject<bool> UpdateStartTime(int request_id, DateTime start_time);

        ResponseObject<bool> UpdateEndTime(int request_id, DateTime end_time);

        ResponseObject<bool> GetIsOnlineOFITSupporter(int itsupporterId);

        ResponseObject<bool> GetIsBusyOFITSupporter(int itsupporterId);

        ResponseObject<List<ITSupporterAPIViewModel>> ViewSkillITSupporter(int itSupporter_id);

        ResponseObject<bool> CreateITSuport(ITSupporterAPIViewModel model);

        ResponseObject<bool> RemoveSkill(int itsupporterId, int serviceITSupportId);

        ResponseObject<bool> UpdateITSup(ITSupporterAPIViewModel model);
        ResponseObject<int> UpdateIsBusyOFITSupporter(int itsupporterId);

        ResponseObject<ITSupporterStatisticForMobileAPIViewModel> ITSuppoterStatisticAll(int itsupporterId);

        ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> ServiceITSuppoterStatistic(int year, int month);
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

        public ResponseObject<bool> UpdateTaskStatus(int requestTaskId, bool isDone)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateTaskStatus(requestTaskId, isDone);

            return result;
        }

        public ResponseObject<bool> DeleteTaskStatus(int requestTaskId)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.DeleteTaskStatus(requestTaskId);

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

        public ResponseObject<bool> CreateTaskFromGuidline(List<ITSupporterCreateTaskAPIViewModel> model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.CreateTaskFromGuidline(model);

            return result;
        }

        public ResponseObject<List<ITSupporterCreateTaskAPIViewModel>> GetAllTaskByRequestId(int requestId)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.GetAllTaskByRequestId(requestId);

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

        public ResponseObject<List<GuidelineAPIViewModel>> GetGuidelineByServiceItemID(int service_item_Id)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.GetGuidelineByServiceItemID(service_item_Id);

            return result;
        }

        public ResponseObject<List<ITSupporterStatisticAPIViewModel>> ITSuppoterStatistic(int year, int month)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.ITSuppoterStatistic(year, month);

            return result;
        }

        public ResponseObject<ITSupporterStatisticForMobileAPIViewModel> ITSuppoterStatisticAll(int itsupporterId)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.ITSuppoterStatisticAll(itsupporterId);

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

        public ResponseObject<bool> UpdateEndTime(int request_id, DateTime end_time)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateEndTime(request_id, end_time);

            return result;
        }

        public ResponseObject<bool> GetIsOnlineOFITSupporter(int itsupporterId)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.GetIsOnlineOFITSupporter(itsupporterId);

            return result;
        }

        public ResponseObject<bool> GetIsBusyOFITSupporter(int itsupporterId)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.GetIsBusyOFITSupporter(itsupporterId);

            return result;
        }
        public ResponseObject<List<ITSupporterAPIViewModel>> ViewSkillITSupporter(int itSupporter_id)
        {
            var itSupporterService = this.Service<IITSupporterService>();

            var itSupporter = itSupporterService.ViewSkillITSupporter(itSupporter_id);

            return itSupporter;
        }

        public ResponseObject<bool> CreateITSuport(ITSupporterAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.CreateITSuport(model);

            return result;
        }
        public ResponseObject<bool> AddSkill(SkillAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.AddSkill(model);

            return result;
        }

        public ResponseObject<int> UpdateIsBusyOFITSupporter(int itsupporterId)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateIsBusyOFITSupporter(itsupporterId);

            return result;
        }


        public ResponseObject<bool> RemoveSkill(int itsupporterId, int serviceITSupportId)
        {
            var itSupporterService = this.Service<IITSupporterService>();

            var itSupporter = itSupporterService.RemoveSkill(itsupporterId, serviceITSupportId);

            return itSupporter;
        }
        public ResponseObject<bool> RemoveITSuporter(int itsupporterId)
        {
            var itSupporterService = this.Service<IITSupporterService>();

            var itSupporter = itSupporterService.RemoveITSuporter(itsupporterId);

            return itSupporter;
        }

        public ResponseObject<bool> UpdateITSup(ITSupporterAPIViewModel model)
        {
            var iTSupporterService = this.Service<IITSupporterService>();

            var result = iTSupporterService.UpdateITSup(model);

            return result;
        }

     
        public ResponseObject<List<ITSupporterStatisticServiceTimeAPIViewModel>> ServiceITSuppoterStatistic(int year, int month)
        {
            var itSupporterService = this.Service<IITSupporterService>();

            var statistic = itSupporterService.ServiceITSuppoterStatistic(year, month);

            return statistic;
        }
    }
}

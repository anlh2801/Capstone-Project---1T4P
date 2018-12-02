using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ResponseModel;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class RequestAllTicketWithStatusAgencyAPIViewModel
    {   
        public int RequestId { get; set; }
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string AgencyAddress { get; set; }
        public int RequestCategoryId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }
        public string RequestName { get; set; }
        public string RequestDesciption { get; set; }
        public string AgencyTelephone { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string RequestStatus { get; set; }
        public int RequestStatusValue { get; set; }
        public string RequestEstimationTime { get; set; }
        public int NumberOfTicketDone { get; set; }
        public int NumberTicketInProcessing { get; set; }
        public int NumberOfTicket { get; set; }
        public string ITSupporterName { get; set; }
        public string ITSupporterPhone { get; set; }
        public string FeedBack { get; set; }
        public int Rating { get; set; }
        public string Priority { get; set; }
        public int PriorityValue { get; set; }
        public List<AgencyCreateTicketAPIViewModel> Tickets { get; set; }
    }
}

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
        public string AgencyTelephone { get; set; }
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string AgencyName { get; set; }       
        public string RequestStatus { get; set; }
        public string RequestEstimationTime { get; set; }
        public int NumberOfTicketDone { get; set; }
        public int NumberTicketInProcessing { get; set; }
        public int NumberOfTicket { get; set; }
        public string ITSupporterName { get; set; }
        public List<TicketForRequestAllTicketStatusAPIViewModel> Tickets { get; set; }
    }
}

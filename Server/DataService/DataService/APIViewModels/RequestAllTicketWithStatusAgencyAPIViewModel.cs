using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class RequestAllTicketWithStatusAgencyAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Request>
    {
        public RequestAllTicketWithStatusAgencyAPIViewModel() : base() { }
        public RequestAllTicketWithStatusAgencyAPIViewModel(DataService.Models.Entities.Request entity) : base(entity) { }

        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string AgencyName { get; set; }       
        public int RequestStatus { get; set; }
        public string RequestEstimationTime { get; set; }
        public int NumberOfTicketDone { get; set; }
        public int NumberTicketInProcessing { get; set; }
        public int NumberOfTicket { get; set; }
        public List<TicketForRequestAllTicketStatusAPIViewModel> Ticket { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class TicketForRequestAllTicketStatusAPIViewModel
    {
        public int TicketId { get; set; }
        public Nullable <int> ITSupporterId { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ITSupporterName { get; set; }
        public string TicketEstimationTime { get; set; }
        public int Current_TicketStatus { get; set; }
        public double Estimation { get; set; }
        public string Desciption { get; set; }
        public string CreateDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AgencyCreateTicketAPIViewModel
    {
        public int TicketId { get; set; }
        public int DeviceId { get; set; }
        public string Desciption { get; set; }
        public string DeviceName { get; set; }        
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Current_TicketStatus { get; set; }
        public string CreateDate { get; set; }

    }
}

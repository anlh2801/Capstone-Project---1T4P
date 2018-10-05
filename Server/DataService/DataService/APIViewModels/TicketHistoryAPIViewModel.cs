using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class TicketHistoryAPIViewModel
    {
        public int TicketHistoryId { get; set; }
        public int TicketId { get; set; }
        public String PreSupporter_Name { get; set; }
        public int PreStatus { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }        
    }
}

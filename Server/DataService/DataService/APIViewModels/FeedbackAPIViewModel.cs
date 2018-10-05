using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class FeedbackAPIViewModel
    {
        public int TicketId { get; set; }
        
        public string FeedbackContent { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class RequestGroupMonth
    {
        public string MonthYearGroup { get; set; }
        public List<RequestAllTicketWithStatusAgencyAPIViewModel> RequestOfITSupporter { get; set; }
    }
}

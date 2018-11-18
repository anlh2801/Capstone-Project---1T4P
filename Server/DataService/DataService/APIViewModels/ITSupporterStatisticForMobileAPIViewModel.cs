using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterStatisticForMobileAPIViewModel
    {
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public string TotalTimeSupport { get; set; }
        public string TotalTimeSupportInThisMonth { get; set; }
        public List<RequestGroupMonth> RequestOfITSupporter { get; set; }
    }
}

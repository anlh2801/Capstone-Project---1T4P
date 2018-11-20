using DataService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterStatisticAPIViewModel
    {
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int SupportTimeInMonth { get; set; }
        public List<ITSupporterStatisticServiceTimeAPIViewModel> TotalTimeEveryService { get; set; }
        public double AverageTimeSupport { get; set; }
        public double TotalTimeSupport { get; set; }
        public int TotalRejectTime { get; set; }
    }
}

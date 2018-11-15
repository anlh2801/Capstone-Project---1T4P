using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterCreateTaskAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.RequestTask>
    {
        public int RequestId { get; set; }
        public int TaskStatus { get; set; }
        public int CreateByITSupporter { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Priority { get; set; }
        public int PreTaskCondition { get; set; }
    }
}

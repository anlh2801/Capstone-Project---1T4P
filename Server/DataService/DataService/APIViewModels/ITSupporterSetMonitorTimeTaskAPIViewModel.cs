using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterSetMonitorTimeTaskAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.RequestTask>
    {
        public ITSupporterSetMonitorTimeTaskAPIViewModel() : base() { }
        public ITSupporterSetMonitorTimeTaskAPIViewModel(DataService.Models.Entities.RequestTask entity) : base(entity) { }

        public int RequestTaskId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}

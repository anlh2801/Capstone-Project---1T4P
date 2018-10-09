using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterSetMonitorTimeTaskAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.TicketTask>
    {
        public ITSupporterSetMonitorTimeTaskAPIViewModel() : base() { }
        public ITSupporterSetMonitorTimeTaskAPIViewModel(DataService.Models.Entities.TicketTask entity) : base(entity) { }

        public int TicketTaskId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}

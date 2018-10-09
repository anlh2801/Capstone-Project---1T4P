using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterSetPriorityTaskAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.TicketTask>
    {
        public ITSupporterSetPriorityTaskAPIViewModel() : base() { }
        public ITSupporterSetPriorityTaskAPIViewModel(DataService.Models.Entities.TicketTask entity) : base(entity) { }

        public int TicketTaskId { get; set; }
        public int Priority { get; set; }
    }
}

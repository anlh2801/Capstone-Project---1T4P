using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterUpdateTaskStatusAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.TicketTask>
    {
        public ITSupporterUpdateTaskStatusAPIViewModel() : base() { }
        public ITSupporterUpdateTaskStatusAPIViewModel(DataService.Models.Entities.TicketTask entity) : base(entity) { }

        public int TicketTaskId { get; set; }
        public int TaskStatus { get; set; }
    }
}

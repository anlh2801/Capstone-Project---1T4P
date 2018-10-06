using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterUpdateAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ITSupporter>
    {
        public ITSupporterUpdateAPIViewModel() : base() { }
        public ITSupporterUpdateAPIViewModel(DataService.Models.Entities.ITSupporter entity) : base(entity) { }

        public int ITSupporterId { get; set; }
        public int Ticket_Id { get; set; }
        public int Current_TicketStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterUpdateEstimateTimeAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public ITSupporterUpdateEstimateTimeAPIViewModel() : base() { }
        public ITSupporterUpdateEstimateTimeAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int CurrentITSupporter_Id { get; set; }
        public int TicketId { get; set; }
    }
}

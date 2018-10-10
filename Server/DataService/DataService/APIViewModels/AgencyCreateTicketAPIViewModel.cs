using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AgencyCreateTicketAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public AgencyCreateTicketAPIViewModel() : base() { }
        public AgencyCreateTicketAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int ServiceItemId { get; set; }
        public int DeviceId { get; set; }
        public string Desciption { get; set; }
    }
}

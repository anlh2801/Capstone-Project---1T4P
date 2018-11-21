using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class TicketAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public TicketAPIViewModel() : base() { }
        public TicketAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int TicketId { get; set; }
        public int RequestId { get; set; }
        public int DeviceId { get; set; }
        public string Desciption { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}

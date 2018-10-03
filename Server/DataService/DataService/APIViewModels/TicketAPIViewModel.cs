using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class TicketAPIViewModel: DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public TicketAPIViewModel() : base() { }
        public TicketAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string CreateDate { get; set; }
        public string AgencyName { get; set; }
        public string ITSupporterName { get; set; }
        public List<String> IssueName { get; set; }

    }
}

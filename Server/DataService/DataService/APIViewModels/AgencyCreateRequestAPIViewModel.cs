using DataService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AgencyCreateRequestAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Request>
    {
        public AgencyCreateRequestAPIViewModel() : base() { }
        public AgencyCreateRequestAPIViewModel(DataService.Models.Entities.Request entity) : base(entity) { }

        public int AgencyId { get; set; }
        public int RequestCategoryId { get; set; }
        public int ServiceItemId { get; set; }
        public string RequestName { get; set; }
        public List<AgencyCreateTicketAPIViewModel> Ticket { get; set; }
    }
}

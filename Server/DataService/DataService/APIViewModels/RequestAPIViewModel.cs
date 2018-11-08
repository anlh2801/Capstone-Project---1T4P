using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class RequestAPIViewModel: DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public RequestAPIViewModel() : base() { }
        public RequestAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string CreateDate { get; set; }
        public string AgencyName { get; set; }
        public string ITSupporterName { get; set; }
        public List<String> IssueName { get; set; }
        public List<String> ITName { get; set; }
        public string RequestStatus { get; set; }
        public string StatusName { get; set; }


    }
}

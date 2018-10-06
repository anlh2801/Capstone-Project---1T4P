using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class RequestCancelAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public RequestCancelAPIViewModel() : base() { }
        public RequestCancelAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int RequestId { get; set; }
        public int CurrentStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterUpdateTaskStatusAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.RequestTask>
    {
        public ITSupporterUpdateTaskStatusAPIViewModel() : base() { }
        public ITSupporterUpdateTaskStatusAPIViewModel(DataService.Models.Entities.RequestTask entity) : base(entity) { }

        public int RequestTaskId { get; set; }
        public int TaskStatus { get; set; }
    }
}

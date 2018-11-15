using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterSetPriorityTaskAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.RequestTask>
    {
        public ITSupporterSetPriorityTaskAPIViewModel() : base() { }
        public ITSupporterSetPriorityTaskAPIViewModel(DataService.Models.Entities.RequestTask entity) : base(entity) { }

        public int RequestTaskId { get; set; }
        public int Priority { get; set; }
    }
}

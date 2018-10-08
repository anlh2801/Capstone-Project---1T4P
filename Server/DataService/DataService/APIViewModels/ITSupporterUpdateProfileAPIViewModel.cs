using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterUpdateProfileAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ITSupporter>
    {
        public ITSupporterUpdateProfileAPIViewModel() : base() { }
        public ITSupporterUpdateProfileAPIViewModel(DataService.Models.Entities.ITSupporter entity) : base(entity) { }

        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}

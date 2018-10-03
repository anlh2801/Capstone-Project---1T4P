using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class UpdateAgencyAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Agency>
    {
        public UpdateAgencyAPIViewModel() : base() { }
        public UpdateAgencyAPIViewModel(DataService.Models.Entities.Agency entity) : base(entity) { }

        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AgencyAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Agency>
    {
        public AgencyAPIViewModel() : base() { }
        public AgencyAPIViewModel(DataService.Models.Entities.Agency entity) : base(entity) { }

        public int AgencyId { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public string AgencyName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
        public string CompanyName { get; set; }
        public string UserName {get; set; }
    }
}

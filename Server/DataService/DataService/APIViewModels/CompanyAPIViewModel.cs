using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class CompanyAPIViewModel: DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Company>
    {
        public CompanyAPIViewModel() : base() { }
        public CompanyAPIViewModel(DataService.Models.Entities.Company entity) : base(entity) { }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int NumericalOrder { get; set; }
        public int PercentForITSupporterRate { get; set; }
        public int PercentForITSupporterExp { get; set; }
        public int PercentForITSupporterFamiliarWithAgency { get; set; }
    }
}

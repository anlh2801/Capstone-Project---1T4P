using DataService.Models.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class GuidelineAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Guideline>
    {
        public GuidelineAPIViewModel() : base() { }
        public GuidelineAPIViewModel(DataService.Models.Entities.Guideline entity) : base(entity) { }
        
        public int NumericalOrder { get; set; }
        public int GuidelineId { get; set; }
        public int ServiceItemId { get; set; }
        public string GuidelineName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}

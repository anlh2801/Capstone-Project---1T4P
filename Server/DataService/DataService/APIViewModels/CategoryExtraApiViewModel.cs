using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModel
{
    public class CategoryExtraApiViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.CategoryExtra>
    {

        public int CategoryExtraId { get; set; }
        public int PrimaryCategoryId { get; set; }
        public int ExtraCategoryId { get; set; }
        public bool IsEnable { get; set; }

        public CategoryExtraApiViewModel() : base() { }
        public CategoryExtraApiViewModel(DataService.Models.Entities.CategoryExtra entity) : base(entity) { }

    }
}

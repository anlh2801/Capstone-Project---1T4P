using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModel
{
    public class CategoryExtraMappingApiViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.CategoryExtraMapping>
    {
        public int Id { get; set; }
        public int PrimaryCategoryId { get; set; }
        public int ExtraCategoryId { get; set; }
        public bool IsEnable { get; set; }

        public CategoryExtraMappingApiViewModel() : base() { }
        public CategoryExtraMappingApiViewModel(DataService.Models.Entities.CategoryExtraMapping entity) : base(entity) { }
    }
}

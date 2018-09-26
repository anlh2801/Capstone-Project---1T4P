using DataService.APIViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Utilities;

namespace DataService.Models.Entities.Services
{
    public partial interface ICategoryExtraMappingService
    {
        IEnumerable<CategoryExtraMappingApiViewModel> GetCategoryExtraMapping(ProductCategoryApiViewModel productCategori);
    }
    public partial class CategoryExtraMappingService
    {
        public IEnumerable<CategoryExtraMappingApiViewModel> GetCategoryExtraMapping(ProductCategoryApiViewModel productCategori)
        {
            var cateExtraMapRepo = DependencyUtils.Resolve<ICategoryExtraMappingService>();            
            var categoryExtraMappings = this.repository
                .GetActive(cem=>cem.Id == productCategori.CateID)
                .Select(cem => new CategoryExtraMappingApiViewModel(cem));
            if (categoryExtraMappings.Count() > 0)
            {
                return categoryExtraMappings.AsEnumerable();
            }
            return null;
        }
    }
}

using DataService.APIViewModel;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public class CategoryExtraMappingDomain:BaseDomain
    {
        public IEnumerable<CategoryExtraMappingApiViewModel> GetCategoryExtraMapping(ProductCategoryApiViewModel productCategori)
        {
            var categoryExtraMappingService = this.Service<ICategoryExtraMappingService>();
            return categoryExtraMappingService.GetCategoryExtraMapping(productCategori);
        }
    }
}

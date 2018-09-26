using DataService.APIViewModel;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public class CategoryExtraDomain : BaseDomain
    {
        public IEnumerable<CategoryExtraApiViewModel> GetCategoryExtra(CategoryExtraMappingApiViewModel categoryExtraMapping)
        {
            var categoryExtraMappingService = this.Service<ICategoryExtraService>();
            return categoryExtraMappingService.GetCategoryExtra(categoryExtraMapping);
        }
    }
}

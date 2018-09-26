using DataService.APIViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Utilities;
namespace DataService.Models.Entities.Services
{
    public partial interface ICategoryExtraService
    {
        IEnumerable<CategoryExtraApiViewModel> GetCategoryExtra(CategoryExtraMappingApiViewModel categoryExtraMapping);
    }
    public partial class CategoryExtraService
    {
        IEnumerable<CategoryExtraApiViewModel> GetCategoryExtra(CategoryExtraMappingApiViewModel categoryExtraMapping)
        {
            var cateExtraRepo=DependencyUtils.Resolve<ICategoryExtraService>();
            var categoryExtras = this.repository
                .GetActive(ce => ce.ExtraCategoryId == categoryExtraMapping.Id)
                .Select(ce => new CategoryExtraApiViewModel(ce));
            if (categoryExtras.Count() > 0)
            {
                return categoryExtras.AsEnumerable();
            }
            return null;
        }
    }
}

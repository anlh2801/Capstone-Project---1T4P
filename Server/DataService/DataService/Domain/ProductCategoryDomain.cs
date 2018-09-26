using DataService.APIViewModel;
using DataService.Models.Entities.Services;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public class ProductCategoryDomain : BaseDomain
    {

        public IEnumerable<ProductCategoryApiViewModel> GetProductCategoryAPIByStoreId(int brandId)
        {
            var productCategoryService = this.Service<IProductCategoryService>();
            return productCategoryService.GetProductCategoryAPIByParams(brandId);
        }
    }
}

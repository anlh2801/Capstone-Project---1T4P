using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IProductCategoryService
    {
        //IQueryable<ProductCategory> GetCategory();

        ///// <summary>
        ///// Get all product category when:
        ///// Active == true
        ///// IsDisplay Website == true
        ///// BrandID == BrandID
        ///// </summary>
        ///// <param name="brandID">Brand ID</param>
        ///// <returns>List product category</returns>
        //IQueryable<ProductCategory> GetActiveDisplayWebsiteProductCategoryByBrand(int brandID);
    }
    public partial class ProductCategoryService : IProductCategoryService
    {
    //    public IQueryable<ProductCategory> GetCategory()
    //    {
    //        return this.Get(q => q.Active == true);
    //    }

    //    /// <summary>
    //    /// Get all product category when:
    //    /// Active == true
    //    /// IsDisplay Website == true
    //    /// BrandID == BrandID
    //    /// </summary>
    //    /// <param name="brandID">Brand ID</param>
    //    /// <returns>List product category</returns>
    //    public IQueryable<ProductCategory> GetActiveDisplayWebsiteProductCategoryByBrand(int brandID)
    //    {
    //        return this.Get(q => q.Active == true && q.IsDisplayedWebsite == true && q.BrandId == brandID);
    //    }

    }
}

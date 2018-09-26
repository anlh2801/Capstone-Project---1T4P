using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IProductDetailMappingService

    {
        IEnumerable<ProductDetailMappingAPIViewModel> GetProductAPIByStoreID(int storeId, int brandId);
        double GetDiscountByStore(int storeId, int productId);
        double GetPriceByStore(int storeId, int productId);
    }
    
    public partial class ProductDetailMappingService
    {
        public IEnumerable<ProductDetailMappingAPIViewModel> GetProductAPIByStoreID(int storeId, int brandId)
        {

            #region join product with productmaping
//          ProductService and ProductRepo
            var productService = DependencyUtils.Resolve<IProductService>();
            var productRepo = DependencyUtils.Resolve<IProductRepository>();
            var productDetailMappingRepo = DependencyUtils.Resolve<IProductDetailMappingRepository>();
            // get Product by BrandId
            var table1 = productRepo.GetActive(p =>
                p.ProductCategory.BrandId == brandId
                && p.ProductCategory.Active);

            #region old
            // Get Product by BrandId from Product Category
            //var table1 = productService
            //    .GetProductByBrandId(brandId);
            #endregion

            // get productdetail by storeId
            var table2 = productDetailMappingRepo
                .GetActive(a => a.StoreID == storeId);

            // get productdetailmapping ( join tb1 and tb2)
            var join = from t1 in table1
                       join t2 in table2
                       on t1.ProductID equals t2.ProductID
                       select t2;

            var result = join.ToList().Select(j => new ProductDetailMappingAPIViewModel(j)
            {
                Product = new ProductAPIViewModel(j.Product),
                Store = new StoreAPIViewModel(j.Store),
            });

            return result;
            #endregion
        }

        public double GetDiscountByStore(int storeId, int productId)
        {
            var product = this.repository.Get(a => a.ProductID == productId && a.StoreID == storeId).FirstOrDefault();

            if (product != null)
            {
                return product.DiscountPrice.GetValueOrDefault();
            }
            return 0;
        }

        public double GetPriceByStore(int storeId, int productId)
        {
            var productDetail = this.repository.Get(pd => pd.StoreID == storeId && pd.ProductID == productId).FirstOrDefault();

            if (productDetail != null)
            {
                return productDetail.Price.GetValueOrDefault();
            }

            return 0;
        }
    }
}

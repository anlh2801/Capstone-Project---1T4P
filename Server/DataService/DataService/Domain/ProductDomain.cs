using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Models.Entities.Services;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IProductDomain
    {
        /// <summary>
        /// Author: PhatPNH
        /// </summary>
        /// <param name="terminalId">It's StoreId</param>
        /// <param name="saleMethodEnum">May be EatIn , Delivery , TakeAway</param>
        /// <returns></returns>
        List<ProductAPIViewModel> GetProductListByTerminalIdAndSaleMethod(int terminalId, int saleMethodEnum);
    }
    public class ProductDomain : BaseDomain,IProductDomain
    {
        public List<ProductAPIViewModel> GetProductListByTerminalIdAndSaleMethod(int terminalId, int saleMethodEnum)
        {
            var productList = new List<ProductAPIViewModel>();
            // get ProductService and StoreProduct
            var productService = this.Service<IProductDetailMappingService>();
            var storeService = this.Service<IStoreService>();
            // get StoreViewModel by StoreId
            var store = storeService.GetStoreById(terminalId);

            // listProduct by 'and bit' saleMethodEnum
            var listP = productService
                .GetProductAPIByStoreID(terminalId, store.BrandId.Value)
                .Where(p => (saleMethodEnum == 0 || (p.Product.SaleMethodEnum.Value & saleMethodEnum) != 0))
                //.Take(10) // get 10 product
                ;
            foreach (var item in listP)
            {
                if (item.Product != null)
                {
                    // get each Product in List Product
                    var p = item.Product;
                    

                    if (p.IsFixedPrice == false)
                    {
                        // Fix Price if Price Change by Store
                        var priceProduct = productService.GetPriceByStore(terminalId, item.Product.ProductID);
                        if (priceProduct != 0)
                        {
                            p.Price = priceProduct;
                        }
                        else
                        {
                            p.Price = item.Product.Price;
                        }
                        // Update Discount by Storeid and ProductId
                        var discountProduct = productService.GetDiscountByStore(terminalId, item.Product.ProductID);
                        if (priceProduct != 0)
                        {
                            p.DiscountPercent = discountProduct;
                        }
                        else
                        {
                            p.DiscountPercent = item.Product.DiscountPercent;
                        }

                    }
                    productList.Add(p);
                }
            }

            return productList;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.BaseConnect;

namespace DataService.Models.Entities.Services
{

    public partial interface IProductService
    {
        IQueryable<Product> GetListProduct();
        Product GetProductBySeoName(string seoName);
        IQueryable<Product> GetListProductByCatId(int catId);
        Product GetProductById(int id);
    }

    public partial class ProductService : IProductService
    {
        //public IQueryable<Product> GetListProduct()
        //{
        //    return this.Get(p => p.Active == true && p.ProductType != 6);
        //}
        //public Product GetProductBySeoName(string seoName)
        //{
        //    return this.Get(p => p.SeoName == seoName).FirstOrDefault();
        //}

        //public Product GetProductById(int id)
        //{
        //    return this.Get(p => p.ProductID == id && p.ProductType != 6).FirstOrDefault();
        //}

        //public IQueryable<ProductViewModel> GetListProductByCatId(int catId)
        //{          
        //    return this.Get(p => p.CatID == catId);
        //}
        public IQueryable<Product> GetListProduct()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetListProductByCatId(int catId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductBySeoName(string seoName)
        {
            throw new NotImplementedException();
        }
    }
}

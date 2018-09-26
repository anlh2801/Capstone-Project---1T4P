using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IProductCollectionService
    {
        IQueryable<ProductCollection> GetCollection();
        ProductCollection GetCollectionBySeoName(string seoName);
    }
    public partial class ProductCollectionService : IProductCollectionService
    {
        public IQueryable<ProductCollection> GetCollection()
        {
            throw new NotImplementedException();
        }

        public ProductCollection GetCollectionBySeoName(string seoName)
        {
            throw new NotImplementedException();
        }
    }
    //{
    //    public IQueryable<ProductCollection> GetCollection()
    //    {
    //        return this.Get(q => q.Active == true);
    //    }

    //    public ProductCollection GetCollectionBySeoName(string seoName)
    //    {
    //        return this.Get(c => c.SEO == seoName).FirstOrDefault();
    //    }
}


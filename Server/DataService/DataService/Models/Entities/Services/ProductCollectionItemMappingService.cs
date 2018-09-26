using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IProductCollectionItemMappingService
    {
        IQueryable<ProductCollectionItemMapping> GetCollectionItemById(int Id);
        ProductCollectionItemMapping GetFirstCollection(int Id);
    }

    public partial class ProductCollectionItemMappingService : IProductCollectionItemMappingService
    {
        //public IQueryable<ProductCollectionItemMapping> GetCollectionItemById(int Id)
        //{
        //    return this.Get(q => q.ProductCollectionId == Id);
        //}

        //public ProductCollectionItemMapping GetFirstCollection(int Id)
        //{
        //    return this.Get(c => c.ProductCollectionId == Id).FirstOrDefault();
        //}
        public IQueryable<ProductCollectionItemMapping> GetCollectionItemById(int Id)
        {
            throw new NotImplementedException();
        }

        public ProductCollectionItemMapping GetFirstCollection(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

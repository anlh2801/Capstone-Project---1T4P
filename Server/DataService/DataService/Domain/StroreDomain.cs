using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IStoreDomain
    {
        StoreAPIViewModel GetStoreByStoreId(int storeid);
    }
    public class StoreDomain : BaseDomain,IStoreDomain
    {
        public StoreAPIViewModel GetStoreByStoreId(int storeid)
        {
            var storeService = this.Service<IStoreService>();
            return storeService.GetStoreById(storeid);
        }
    }
}

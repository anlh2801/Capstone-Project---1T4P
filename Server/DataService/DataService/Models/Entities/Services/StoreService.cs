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
    public partial interface IStoreService
    {
        StoreAPIViewModel GetStoreById(int storeId);
        StoreAPIViewModel GetActiveStoreByBrandId(int brandId);
    }
    public partial class StoreService
    {
        public StoreAPIViewModel GetStoreById(int storeId)
        {
            // StroreRepo
            var storeRepo = DependencyUtils.Resolve<IStoreRepository>();
            // get StoreViewModel
            return  new StoreAPIViewModel(storeRepo.Get(storeId));
        }
        public StoreAPIViewModel GetActiveStoreByBrandId(int brandId)
        {
            var store = Repository.FirstOrDefault(s => s.BrandId == brandId);
            return new StoreAPIViewModel(store);
        }
    }
}

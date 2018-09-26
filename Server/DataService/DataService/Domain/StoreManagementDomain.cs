using DataService.Models.Entities.Services;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public class StoreManagementDomain : BaseDomain
    {

        public StoreViewModel GetStoreByStoreId(int storeId)
        {
            return this.Service<IStoreService>().FirstOrDefaultActive(s=>s.ID == storeId);
        }

    }
}

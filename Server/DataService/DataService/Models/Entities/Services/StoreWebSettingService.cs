using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IStoreWebSettingService
    {
        StoreWebSetting GetValueByStoreId(int id);
    }
    public partial class StoreWebSettingService : IStoreWebSettingService
    {
        public StoreWebSetting GetValueByStoreId(int id)
        {
            return this.Get(id);
        }
    }
}

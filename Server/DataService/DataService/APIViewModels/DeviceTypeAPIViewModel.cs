using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class DeviceTypeAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.DeviceType>
    {
        public DeviceTypeAPIViewModel() : base() { }
        public DeviceTypeAPIViewModel(DataService.Models.Entities.DeviceType entity) : base(entity) { }

        public int NumericalOrder { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}

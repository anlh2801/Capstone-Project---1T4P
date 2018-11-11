using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class DeviceAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Device>
    {
        public DeviceAPIViewModel() : base() { }
        public DeviceAPIViewModel(DataService.Models.Entities.Device entity) : base(entity) { }

        public int NumericalOrder { get; set; }
        public int DeviceId { get; set; }
        public int AgencyId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public string GuarantyStartDate { get; set; }
        public string GuarantyEndDate { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string DeviceAccount { get; set; }
        public string DevicePassword { get; set; }
        public string SettingDate { get; set; }
        public string Other { get; set; }
        public bool IsDelete { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string CompanyName { get; set; }
    }
}

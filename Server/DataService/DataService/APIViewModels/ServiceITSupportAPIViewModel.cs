using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ServiceITSupportAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ServiceITSupport>
    {
        public ServiceITSupportAPIViewModel() : base() { }
        public ServiceITSupportAPIViewModel(DataService.Models.Entities.ServiceITSupport entity) : base(entity) { }

        public int NumericalOrder { get; set; }
        public int ServiceITSupportId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}

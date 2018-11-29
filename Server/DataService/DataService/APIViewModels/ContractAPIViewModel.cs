using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ContractAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Contract>
    {
        public ContractAPIViewModel() : base() { }
        public ContractAPIViewModel(DataService.Models.Entities.Contract entity) : base(entity) { }

        public int NumericalOrder { get; set; }
        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ContractName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ContractStatus { get; set; }
        public bool IsDelete { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string ContractPrice { get; set; }
        public string ContractServiceName { get; set; }
        public List<int> ServiceIdList { get; set; }
        public List<string> ServiceName { get; set; }
    }
}

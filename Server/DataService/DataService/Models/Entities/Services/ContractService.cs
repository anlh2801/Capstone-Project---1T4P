using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IContractService
    {
        List<ContractAPIViewModel> GetAllContract();
    }

    public partial class ContractService
    {
        public List<ContractAPIViewModel> GetAllContract()
        {
            List<ContractAPIViewModel> rsList = new List<ContractAPIViewModel>();
            var contractRepo = DependencyUtils.Resolve<IContractRepository>();
            var contracts = contractRepo.GetActive().ToList();
            foreach (var item in contracts)
            {

                rsList.Add(new ContractAPIViewModel
                {
                    ContractId = item.ContractId,
                    CompanyId = item.CompanyId,
                    ContractName = item.ContractName,
                    StartDate = item.StartDate.Value.ToString("MM/dd/yyyy"),
                    EndDate = item.EndDate.Value.ToString("MM/dd/yyyy"),
                    IsDelete = item.IsDelete,
                    CreatedAt = item.CreateDate.Value.ToString("MM/dd/yyyy"),
                    UpdateAt = item.UpdateDate.Value.ToString("MM/dd/yyyy")
                });
            }

            return rsList;
        }
    }
}

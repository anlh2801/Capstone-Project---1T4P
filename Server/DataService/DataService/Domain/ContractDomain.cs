using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IContractDomain
    {

        List<ContractAPIViewModel> GetAllContract();
        ContractAPIViewModel ViewDetail(int contract_id);
        bool CreateContract(ContractAPIViewModel model);
        bool UpdateContract(ContractAPIViewModel model);
    }

    public class ContractDomain : BaseDomain, IContractDomain
    {
        public bool CreateContract(ContractAPIViewModel model)
        {
            var ContractService = this.Service<IContractService>();

            var result = ContractService.CreateContract(model);

            return result;
        }

        public List<ContractAPIViewModel> GetAllContract()
        {
            var contractService = this.Service<IContractService>();

            var contracts = contractService.GetAllContract();

            return contracts;
        }

        public bool UpdateContract(ContractAPIViewModel model)
        {
            var contractService = this.Service<IContractService>();

            var result = contractService.UpdateContract(model);

            return result; 
        }

        public ContractAPIViewModel ViewDetail(int contract_id)
        {
            var contractService = this.Service<IContractService>();

            var contract = contractService.ViewDetail(contract_id);

            return contract;
        }
        public bool RemoveContract(int contract_id)
        {
            var contractList = new List<ContractAPIViewModel>();

            var contractService = this.Service<IContractService>();
            bool a = contractService.RemoveContract(contract_id);
            return a;
        }
    }
}

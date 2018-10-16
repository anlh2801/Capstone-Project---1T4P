using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IContractDomain
    {
        ResponseObject<List<ContractAPIViewModel>> GetAllContract();
        ResponseObject<ContractAPIViewModel> ViewDetail(int contract_id);
        ResponseObject<bool> CreateContract(ContractAPIViewModel model);
        ResponseObject<bool> UpdateContract(ContractAPIViewModel model);
    }

    public class ContractDomain : BaseDomain, IContractDomain
    {
        public ResponseObject<bool> CreateContract(ContractAPIViewModel model)
        {
            var ContractService = this.Service<IContractService>();

            var result = ContractService.CreateContract(model);

            return result;
        }

        public ResponseObject<List<ContractAPIViewModel>> GetAllContract()
        {
            var contractService = this.Service<IContractService>();

            var contracts = contractService.GetAllContract();

            return contracts;
        }

        public ResponseObject<bool> UpdateContract(ContractAPIViewModel model)
        {
            var contractService = this.Service<IContractService>();

            var result = contractService.UpdateContract(model);

            return result; 
        }

        public ResponseObject<ContractAPIViewModel> ViewDetail(int contract_id)
        {
            var contractService = this.Service<IContractService>();

            var contract = contractService.ViewDetail(contract_id);

            return contract;
        }
        public ResponseObject<bool> RemoveContract(int contract_id)
        {
            var contractList = new List<ContractAPIViewModel>();

            var contractService = this.Service<IContractService>();
            var rs = contractService.RemoveContract(contract_id);
            return rs;
        }
    }
}

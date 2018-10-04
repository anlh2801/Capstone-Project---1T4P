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
    }

    public class ContractDomain : BaseDomain, IContractDomain
    {
        public List<ContractAPIViewModel> GetAllContract()
        {
            var contractService = this.Service<IContractService>();

            var contracts = contractService.GetAllContract();

            return contracts;
        }
    }
}

using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IContractService
    {
        List<ContractAPIViewModel> GetAllContract();
        ContractAPIViewModel ViewDetail(int contract_id);
        bool CreateContract(ContractAPIViewModel model);
        bool UpdateContract(ContractAPIViewModel model);
        bool RemoveContract(int contract_id);
    }

    public partial class ContractService
    {
        public List<ContractAPIViewModel> GetAllContract()
        {
            List<ContractAPIViewModel> rsList = new List<ContractAPIViewModel>();
            var contractRepo = DependencyUtils.Resolve<IContractRepository>();
            var contracts = contractRepo.GetActive().ToList();
            int count = 1;
            foreach (var item in contracts)
            {
                if (!item.IsDelete)
                {
                    rsList.Add(new ContractAPIViewModel
                    {
                        NumericalOrder = count,
                        ContractId = item.ContractId,
                        CompanyId = item.CompanyId,
                        CompanyName = item.Company.CompanyName,
                        ContractName = item.ContractName,
                        StartDate = item.StartDate.Value.ToString("MM/dd/yyyy"),
                        EndDate = item.EndDate.Value.ToString("MM/dd/yyyy"),
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("MM/dd/yyyy")
                    });
                }
                count++;
            }

            return rsList;
        }
        public ContractAPIViewModel ViewDetail(int contract_id)
        {
            var contractRepo = DependencyUtils.Resolve<IContractRepository>();
            var contract = contractRepo.GetActive().SingleOrDefault(a => a.ContractId == contract_id);
            if (contract != null)
            {
                var contractAPIViewModel = new ContractAPIViewModel
                {
                    ContractId = contract.ContractId,
                    CompanyId = contract.CompanyId,
                    CompanyName = contract.Company.CompanyName,
                    ContractName = contract.ContractName,
                    StartDate = contract.StartDate.Value.ToString("MM/dd/yyyy"),
                    EndDate = contract.EndDate.Value.ToString("MM/dd/yyyy"),
                    UpdateDate = contract.UpdateDate.Value.ToString("MM/dd/yyyy"),
                };
                return contractAPIViewModel;
            }
            return null;
        }
        public bool CreateContract(ContractAPIViewModel model)
        {

            var contractRepo = DependencyUtils.Resolve<IContractRepository>();
            var createContract = new Contract();

            try
            {
                createContract.CompanyId = model.CompanyId;
                createContract.ContractName = model.ContractName;
                createContract.StartDate = DateTime.Parse(model.StartDate);
                createContract.EndDate = DateTime.Parse(model.EndDate);
                createContract.IsDelete = false;
                createContract.CreateDate = DateTime.Now;
                createContract.UpdateDate = DateTime.Now;

                contractRepo.Add(createContract);

                contractRepo.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
        public bool UpdateContract(ContractAPIViewModel model)
        {
            var contractRepo = DependencyUtils.Resolve<IContractRepository>();
            var updateContract = contractRepo.GetActive().SingleOrDefault(a => a.ContractId == model.ContractId);
            
            if (updateContract.ContractId == model.ContractId)
            {
                updateContract.ContractName = model.ContractName;
                //updateContract.StartDate = DateTime.ParseExact(model.CreateDate, "dd-MM-yyyy", CultureInfo.InvariantCulture); 
                //updateContract.EndDate = DateTime.ParseExact(model.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                updateContract.StartDate = DateTime.Parse(model.StartDate);
                updateContract.EndDate = DateTime.Parse(model.EndDate);

                updateContract.UpdateDate = DateTime.Now;

                contractRepo.Edit(updateContract);
                contractRepo.Save();
                return true;
            }

            return false;
        }
        public bool RemoveContract(int contract_id)
        {
            var contracttRepo = DependencyUtils.Resolve<IContractRepository>();
            var contract = contracttRepo.GetActive().SingleOrDefault(a => a.ContractId == contract_id);
            Deactivate(contract);
            return true;
        }
    }
}

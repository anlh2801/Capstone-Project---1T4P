using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
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
        ResponseObject<List<ContractAPIViewModel>> GetAllContract();
        ResponseObject<ContractAPIViewModel> ViewDetail(int contract_id);
        ResponseObject<bool> CreateContract(ContractAPIViewModel model);
        ResponseObject<bool> UpdateContract(ContractAPIViewModel model);
        ResponseObject<bool> RemoveContract(int contract_id);
    }

    public partial class ContractService
    {
        public ResponseObject<List<ContractAPIViewModel>> GetAllContract()
        {
            try
            {
                List<ContractAPIViewModel> rsList = new List<ContractAPIViewModel>();
                var contractRepo = DependencyUtils.Resolve<IContractRepository>();
                var contracts = contractRepo.GetActive().ToList();
                if (contracts.Count <= 0)
                {
                    return new ResponseObject<List<ContractAPIViewModel>> { IsError = true, WarningMessage = "Không có hợp đồng" };
                }
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
                            StartDate = item.StartDate.Value.ToString("dd/MM/yyyy"),
                            EndDate = item.EndDate.Value.ToString("dd/MM/yyyy"),
                            IsDelete = item.IsDelete,
                            CreateDate = item.CreateDate.Value.ToString("dd/MM/yyyy"),
                            UpdateDate = item.UpdateDate.Value.ToString("dd/MM/yyyy")
                        });
                    }
                    count++;
                }

                return new ResponseObject<List<ContractAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Hiển thị hợp đồng thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<ContractAPIViewModel>> { IsError = true, WarningMessage = "Không có hợp đồng!", ObjReturn = null, ErrorMessage = e.ToString() };

            }
        }
        public ResponseObject<ContractAPIViewModel> ViewDetail(int contract_id)
        {
            try
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
                        StartDate = contract.StartDate.Value.ToString("dd/MM/yyyy"),
                        EndDate = contract.EndDate.Value.ToString("dd/MM/yyyy"),
                        UpdateDate = contract.UpdateDate.Value.ToString("dd/MM/yyyy"),
                    };
                    return new ResponseObject<ContractAPIViewModel> { IsError = false, ObjReturn = contractAPIViewModel, SuccessMessage = "Lấy chi tiết thành công" };
                }
                return new ResponseObject<ContractAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại hợp đồng này" };
            }
            catch (Exception e)
            {

                return new ResponseObject<ContractAPIViewModel> { IsError = true, WarningMessage = "Không tồn tại hợp đồng này", ObjReturn = null, ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<bool> CreateContract(ContractAPIViewModel model)
        {
            try
            {
                var contractRepo = DependencyUtils.Resolve<IContractRepository>();
                var createContract = new Contract();

                createContract.CompanyId = model.CompanyId;
                createContract.ContractName = model.ContractName;
                createContract.StartDate = model.StartDate.ToDateTime();
                createContract.EndDate = model.EndDate.ToDateTime();
                createContract.IsDelete = false;
                createContract.CreateDate = DateTime.Now;
                createContract.UpdateDate = DateTime.Now;

                contractRepo.Add(createContract);

                contractRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm hợp đồng thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm hợp đồng thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }
        public ResponseObject<bool> UpdateContract(ContractAPIViewModel model)
        {
            try
            {
                var contractRepo = DependencyUtils.Resolve<IContractRepository>();
                var updateContract = contractRepo.GetActive().SingleOrDefault(a => a.ContractId == model.ContractId);

                if (updateContract != null)
                {
                    updateContract.ContractName = model.ContractName;
                    //updateContract.StartDate = DateTime.ParseExact(model.CreateDate, "dd-MM-yyyy", CultureInfo.InvariantCulture); 
                    //updateContract.EndDate = DateTime.ParseExact(model.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    updateContract.StartDate = model.StartDate.ToDateTime();
                    updateContract.EndDate = model.EndDate.ToDateTime();
                    updateContract.UpdateDate = DateTime.Now;

                    contractRepo.Edit(updateContract);
                    contractRepo.Save();
                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa hợp đồng thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa hợp đồng thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa hợp đồng thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> RemoveContract(int contract_id)
        {
            try
            {
                var contracttRepo = DependencyUtils.Resolve<IContractRepository>();
                var contract = contracttRepo.GetActive().SingleOrDefault(a => a.ContractId == contract_id);

                Deactivate(contract);

                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa hợp đồng thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa hợp đồng thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }
        }
    }
}

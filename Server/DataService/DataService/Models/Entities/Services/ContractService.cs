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
        ResponseObject<List<ContractAPIViewModel>> ViewAllContractByCompanyId(int company_id);
        ResponseObject<List<ContractAPIViewModel>> ViewAllContractServiceByContractId(int contract_id);
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
                            StartDate = item.StartDate != null ? item.StartDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                            EndDate = item.EndDate!= null ? item.EndDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                            ContractStatus = item.EndDate != null && item.EndDate.Value.Date < DateTime.Now.Date ? "Hợp đồng hết hạn" : string.Empty,
                            IsDelete = item.IsDelete,
                            CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
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
                var contractServiceRepo = DependencyUtils.Resolve<IContractServiceITSupportRepository>();
                var contract = contractRepo.GetActive().SingleOrDefault(a => a.ContractId == contract_id);
                var contractService = contractServiceRepo.GetActive().Where(a => a.ContractId == contract_id).ToList();
                if (contract != null)
                {
                    List<int> listId = new List<int>();
                    List<string> listName = new List<string>();

                    foreach (var item in contractService)
                    {
                        listId.Add(item.ServiceITSupportId);
                    }
                    foreach (var item in contractService)
                    {
                        listName.Add(item.ServiceITSupport.ServiceName);
                    }
                    var contractAPIViewModel = new ContractAPIViewModel
                    {
                        ContractId = contract.ContractId,
                        CompanyId = contract.CompanyId,
                        CompanyName = contract.Company.CompanyName,
                        ContractName = contract.ContractName,
                        ServiceIdList = listId,
                        ServiceName = listName,
                        StartDate = contract.StartDate.Value.ToString("dd/MM/yyyy"),
                        EndDate = contract.EndDate.Value.ToString("dd/MM/yyyy"),
                        ContractStatus = contract.EndDate != null && contract.EndDate.Value.Date < DateTime.Now.Date ? "Hợp đồng hết hạn" : string.Empty,
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
                createContract.CreateDate = DateTime.UtcNow.AddHours(7);
                createContract.UpdateDate = DateTime.UtcNow.AddHours(7);

                contractRepo.Add(createContract);
                contractRepo.Save();

                var contractServiceRepo = DependencyUtils.Resolve<IContractServiceITSupportRepository>();

                foreach (var item in model.ServiceIdList)
                {
                    var contractService = new ContractServiceITSupport()
                    {
                        ContractId = createContract.ContractId,
                        ServiceITSupportId = item,
                        IsDelete = false,
                        StartDate = model.StartDate.ToDateTime(),
                        EndDate = model.EndDate.ToDateTime(),
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        UpdateDate = DateTime.UtcNow.AddHours(7)
                    };

                    contractServiceRepo.Add(contractService);

                }
                contractServiceRepo.Save();

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
                var contractServiceRepo = DependencyUtils.Resolve<IContractServiceITSupportRepository>();
                var updateContract = contractRepo.GetActive().SingleOrDefault(a => a.ContractId == model.ContractId);
                var contractService = contractServiceRepo.GetActive().Where(a => a.ContractId == model.ContractId).ToList();

                foreach (var itemFE in model.ServiceIdList)
                {
                    if (!contractService.Select(x => x.ServiceITSupportId).ToList().Contains(itemFE))
                    {
                        var contractServiceNew = new ContractServiceITSupport()
                        {
                            ContractId = model.ContractId,
                            ServiceITSupportId = itemFE,
                            IsDelete = false,
                            StartDate = model.StartDate.ToDateTime(),
                            EndDate = model.EndDate.ToDateTime(),
                            CreateDate = DateTime.UtcNow.AddHours(7),
                            UpdateDate = DateTime.UtcNow.AddHours(7)
                        };
                        contractServiceRepo.Add(contractServiceNew);
                    }
                }

                foreach (var itemDB in contractService)
                {
                    if (!model.ServiceIdList.Contains(itemDB.ServiceITSupportId))
                    {
                        itemDB.UpdateDate = DateTime.UtcNow.AddHours(7);
                        contractServiceRepo.Deactivate(itemDB);
                    }
                }
                contractServiceRepo.Save();

                if (updateContract != null)
                {
                    updateContract.ContractName = model.ContractName;
                    updateContract.StartDate = model.StartDate.ToDateTime();
                    updateContract.EndDate = model.EndDate.ToDateTime();
                    updateContract.UpdateDate = DateTime.UtcNow.AddHours(7);

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
                var contractServiceRepo = DependencyUtils.Resolve<IContractServiceITSupportRepository>();
                var contract = contracttRepo.GetActive().SingleOrDefault(a => a.ContractId == contract_id);
                var contractServices = contractServiceRepo.GetActive().Where(a => a.ContractId == contract_id).ToList();

                Deactivate(contract);
                foreach (var itemDB in contractServices)
                {
                        itemDB.UpdateDate = DateTime.UtcNow.AddHours(7);
                        contractServiceRepo.Deactivate(itemDB);
                }
                contractServiceRepo.Save();

                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa hợp đồng thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa hợp đồng thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }
        }
        public ResponseObject<List<ContractAPIViewModel>> ViewAllContractByCompanyId(int company_id)
        {
            try
            {
                List<ContractAPIViewModel> rsList = new List<ContractAPIViewModel>();
                var contractRepo = DependencyUtils.Resolve<IContractRepository>();
                var companyContract = contractRepo.GetActive(p => p.CompanyId == company_id).ToList();
                if (companyContract.Count <= 0)
                {
                    return new ResponseObject<List<ContractAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy hợp đòng nào!" };
                }
                int count = 1;
                foreach (var item in companyContract)
                {
                    rsList.Add(new ContractAPIViewModel
                    {
                        NumericalOrder = count,
                        ContractId = item.ContractId,
                        CompanyId = item.CompanyId,
                        CompanyName = item.Company.CompanyName,
                        ContractName = item.ContractName,
                        StartDate = item.StartDate != null ? item.StartDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        EndDate = item.EndDate != null ? item.EndDate.Value.ToString("dd/MM/yyyy") : string.Empty,
                        ContractStatus = item.EndDate != null && item.EndDate.Value.Date < DateTime.Now.Date ? "Đã hết hạn hợp đồng" : string.Empty,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateDate = item.UpdateDate != null ? item.UpdateDate.Value.ToString("MM/dd/yyyy") : string.Empty

                    });
                    count++;
                }

                return new ResponseObject<List<ContractAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy hợp đòng" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<ContractAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy hợp đòng nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<List<ContractAPIViewModel>> ViewAllContractServiceByContractId(int contract_id)
        {
            try
            {
                List<ContractAPIViewModel> rsList = new List<ContractAPIViewModel>();
                var contractServiceRepo = DependencyUtils.Resolve<IContractServiceITSupportRepository>();
                var servicesOfContract = contractServiceRepo.GetActive(p => p.ContractId == contract_id).ToList();
                if (servicesOfContract.Count <= 0)
                {
                    return new ResponseObject<List<ContractAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy hợp đòng nào!" };
                }
                int count = 1;
                foreach (var item in servicesOfContract)
                {
                    rsList.Add(new ContractAPIViewModel
                    {
                        NumericalOrder = count,
                        ContractServiceName = item.ServiceITSupport.ServiceName,
                     });
                    count++;
                }

                return new ResponseObject<List<ContractAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Tìm thấy hợp đòng" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<ContractAPIViewModel>> { IsError = true, WarningMessage = "Không tìm thấy hợp đòng nào!", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
    }
}

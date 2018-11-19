using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
using DataService.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IAccountService
    {
        ResponseObject<AgencyAPIViewModel> CheckLoginForAgency(string username, string password, int roleid);
        ResponseObject<ITSupporterAPIViewModel> CheckLoginForITSupporter(string username, string password, int roleid);
        ResponseObject<List<AccountAPIViewModel>> GetAllAccount();
        ResponseObject<AccountAPIViewModel> ViewProfile(int account_id);
        ResponseObject<bool> CreateAccount(AccountAPIViewModel model);
        ResponseObject<bool> RemoveAccount(int account_id);
        ResponseObject<bool> UpdateProfile(AccountAPIViewModel model);

        ResponseObject<AccountAPIViewModel> CheckLogin(string username, string password, int roleId);
    }

    public partial class AccountService
    {
        public ResponseObject<AgencyAPIViewModel> CheckLoginForAgency(string username, string password, int roleid)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var aagencyRepo = DependencyUtils.Resolve<IAgencyRepository>();
                var account = accountRepo.GetActive(a => a.Username == username && a.Password == password && a.RoleId == roleid).SingleOrDefault();
                if (account != null)
                {
                    var agency = aagencyRepo.GetActive(b => b.AccountId == account.AccountId).SingleOrDefault();
                    var agencymodel = new AgencyAPIViewModel();
                    agencymodel.AgencyId = agency.AgencyId;
                    agencymodel.AccountId = agency.AccountId;
                    agencymodel.UserName = agency.Account.Username;
                    agencymodel.AgencyName = agency.AgencyName;
                    agencymodel.Address = agency.Address;
                    return new ResponseObject<AgencyAPIViewModel> { IsError = false, ObjReturn = agencymodel, SuccessMessage = "Đăng nhập thành công" };
                }
                                                   
                return new ResponseObject<AgencyAPIViewModel> { IsError = true, ObjReturn = null , WarningMessage = "Sai Tên Tài Khoản Hoặc Mật Khẩu." };

            }
            catch (Exception e)
            {
                return new ResponseObject<AgencyAPIViewModel> { IsError = true, ObjReturn = null, WarningMessage = "Sai Tên Tài Khoản Hoặc Mật Khẩu.", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<ITSupporterAPIViewModel> CheckLoginForITSupporter(string username, string password, int roleid)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
                var account = accountRepo.GetActive(a => a.Username == username && a.Password == password && a.RoleId == roleid).SingleOrDefault();
                if (account != null)
                {
                    var itSupporter = itSupporterRepo.GetActive(b => b.AccountId == account.AccountId).SingleOrDefault();
                    var itSupporterAPIViewModel = new ITSupporterAPIViewModel();
                    itSupporterAPIViewModel.ITSupporterId = itSupporter.ITSupporterId;
                    itSupporterAPIViewModel.AccountId = itSupporter.AccountId;
                    itSupporterAPIViewModel.Username = itSupporter.Account.Username;
                    itSupporterAPIViewModel.ITSupporterName = itSupporter.ITSupporterName;
                    return new ResponseObject<ITSupporterAPIViewModel> { IsError = false, ObjReturn = itSupporterAPIViewModel, SuccessMessage = "Đăng nhập thành công" };
                }

                return new ResponseObject<ITSupporterAPIViewModel> { IsError = true, ObjReturn = null, WarningMessage = "Sai Tên Tài Khoản Hoặc Mật Khẩu." };

            }
            catch (Exception e)
            {
                return new ResponseObject<ITSupporterAPIViewModel> { IsError = true, ObjReturn = null, WarningMessage = "Sai Tên Tài Khoản Hoặc Mật Khẩu.", ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<List<AccountAPIViewModel>> GetAllAccount()
        {
            try
            {
                List<AccountAPIViewModel> rsList = new List<AccountAPIViewModel>();
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var accounts = accountRepo.GetActive().ToList();
                if (accounts.Count <= 0)
                {
                    return new ResponseObject<List<AccountAPIViewModel>> { IsError = true, WarningMessage = "Không có tài khoản" };
                }
                int count = 1;
                foreach (var item in accounts)
                {
                    if (!item.IsDelete)
                    {
                        rsList.Add(new AccountAPIViewModel
                        {
                            NumericalOrder = count,
                            AccountId = item.AccountId,
                            RoleName = item.Role.RoleName,
                            Username = item.Username,
                            Password = item.Password,
                            CreateAt = item.CreateDate.ToString("dd/MM/yyyy"),
                            UpdateAt = item.UpdateDate.Value.ToString("dd/MM/yyyy"),

                        });

                    }
                    count++;
                }

                return new ResponseObject<List<AccountAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Lấy danh sách thành công!" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<AccountAPIViewModel>> { IsError = true, ObjReturn = null, WarningMessage = "Lấy danh sách thất bại!", ErrorMessage = e.ToString() };
            }

        }

        public ResponseObject<AccountAPIViewModel> ViewProfile(int account_id)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var account = accountRepo.GetActive().SingleOrDefault(a => a.AccountId == account_id);
                if (account != null)
                {
                    var accountAPIViewModel = new AccountAPIViewModel
                    {
                        AccountId = account.AccountId,
                        RoleId = account.RoleId,
                        RoleName = account.Role.RoleName,
                        Username = account.Username,
                        Password = account.Password,
                        CreateAt = account.CreateDate.ToString("dd/MM/yyyy"),
                        UpdateAt = account.UpdateDate.Value.ToString("dd/MM/yyyy"),
                    };
                    return new ResponseObject<AccountAPIViewModel> { IsError = false, ObjReturn = accountAPIViewModel, SuccessMessage = "Đã tìm thấy tài khoản" };
                }
                return new ResponseObject<AccountAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy chi tiết tài khoản" };
            }
            catch (Exception e)
            {

                return new ResponseObject<AccountAPIViewModel> { IsError = true, WarningMessage = "Không tìm thấy chi tiết tài khoản", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<bool> CreateAccount(AccountAPIViewModel model)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var createAccount = new Account();

                createAccount.RoleId = model.RoleId;
                createAccount.Username = model.Username;
                createAccount.Password = model.Password;
                createAccount.IsDelete = false;
                createAccount.CreateDate = DateTime.UtcNow.AddHours(7);
                createAccount.UpdateDate = DateTime.UtcNow.AddHours(7);

                accountRepo.Add(createAccount);

                accountRepo.Save();
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Thêm tài khoản thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Thêm tài khoản thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }

        }

        public ResponseObject<bool> RemoveAccount(int account_id)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var account = accountRepo.GetActive().SingleOrDefault(a => a.AccountId == account_id);

                Deactivate(account);
                return new ResponseObject<bool> { IsError = false, SuccessMessage = "Xóa tài khoản thành công", ObjReturn = true };
            }
            catch (Exception ex)
            {
                return new ResponseObject<bool> { IsError = true, WarningMessage = "Xóa tài khoản thất bại", ErrorMessage = ex.ToString(), ObjReturn = false };
            }
        }

        public ResponseObject<bool> UpdateProfile(AccountAPIViewModel model)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var updateAccount = accountRepo.GetActive().SingleOrDefault(a => a.AccountId == model.AccountId);
                if (updateAccount != null)
                {
                    updateAccount.Username = model.Username;
                    updateAccount.Password = model.Password;
                    updateAccount.UpdateDate = DateTime.UtcNow.AddHours(7);

                    accountRepo.Edit(updateAccount);
                    accountRepo.Save();

                    return new ResponseObject<bool> { IsError = false, SuccessMessage = "Chỉnh sửa tài khoản thành công", ObjReturn = true };
                }

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa tài khoản thất bại", ObjReturn = false };
            }
            catch (Exception e)
            {

                return new ResponseObject<bool> { IsError = true, WarningMessage = "Chỉnh sửa tài khoản thất bại", ObjReturn = false, ErrorMessage = e.ToString() };
            }
        }

        public ResponseObject<AccountAPIViewModel> CheckLogin(string username, string password, int roleId)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var account = accountRepo.GetActive(a => a.Username == username && a.Password == password && a.RoleId == roleId).SingleOrDefault();
                if (account != null)
                {
                    var accountmodel = new AccountAPIViewModel();
                    accountmodel.Username = account.Username;
                    accountmodel.Password = account.Password;
                    accountmodel.RoleId = account.RoleId;
                    return new ResponseObject<AccountAPIViewModel> { IsError = false, ObjReturn = accountmodel, SuccessMessage = "Đăng nhập thành công" };
                }

                return new ResponseObject<AccountAPIViewModel> { IsError = true, ObjReturn = null, WarningMessage = "Sai Tên Tài Khoản Hoặc Mật Khẩu." };

            }
            catch (Exception e)
            {
                return new ResponseObject<AccountAPIViewModel> { IsError = true, ObjReturn = null, WarningMessage = "Sai Tên Tài Khoản Hoặc Mật Khẩu.", ErrorMessage = e.ToString() };
            }
        }
    }
}

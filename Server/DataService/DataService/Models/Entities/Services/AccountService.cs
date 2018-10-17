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
        ResponseObject<bool> CheckLogin(string username, string password, int roleid);
        ResponseObject<List<AccountAPIViewModel>> GetAllAccount();
        ResponseObject<AccountAPIViewModel> ViewProfile(int account_id);
        ResponseObject<bool> CreateAccount(AccountAPIViewModel model);
        ResponseObject<bool> RemoveAccount(int account_id);
        ResponseObject<bool> UpdateProfile(AccountAPIViewModel model);
    }

    public partial class AccountService
    {
        public ResponseObject<bool> CheckLogin(string username, string password, int roleid)
        {
            try
            {
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var isLoginSucess = accountRepo.GetActive().Any(a => a.Username == username && a.Password == password && a.RoleId == roleid);

                return new ResponseObject<bool> { IsError = false, ObjReturn = isLoginSucess, SuccessMessage = "Đăng nhập thành công" };
            }
            catch (Exception e)
            {
                return new ResponseObject<bool> { IsError = true, ObjReturn = false, WarningMessage = "Đăng nhập thất bại", ErrorMessage = e.ToString() };
            }
        }
        public ResponseObject<List<AccountAPIViewModel>> GetAllAccount()
        {
            try
            {
                List<AccountAPIViewModel> rsList = new List<AccountAPIViewModel>();
                var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
                var accounts = accountRepo.GetActive().ToList();
                if (accounts.Count < 0)
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
                            CreateAt = item.CreateDate.Value.ToString("dd/MM/yyyy"),
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
                        CreateAt = account.CreateDate.Value.ToString("dd/MM/yyyy"),
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
                createAccount.CreateDate = DateTime.Now;
                createAccount.UpdateDate = DateTime.Now;

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
                    updateAccount.UpdateDate = DateTime.Now;

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
    }
}

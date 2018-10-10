using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
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
        bool CheckLogin(string username, string password,int roleid);
        List<AccountAPIViewModel> GetAllAccount();
        AccountAPIViewModel ViewProfile(int account_id);
        bool CreateAccount(AccountCreateAPIViewModel model);
    }

    public partial class AccountService
    {
        public bool CheckLogin(string username, string password, int roleid)
        {            
            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var isLoginSucess = accountRepo.GetActive().Any(a => a.Username == username && a.Password == password && a.RoleId == roleid);
            return isLoginSucess;
        }
        public List<AccountAPIViewModel> GetAllAccount()
        {
            List<AccountAPIViewModel> rsList = new List<AccountAPIViewModel>();
            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var accounts = accountRepo.GetActive().ToList();
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
                        CreateAt = item.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateAt = item.UpdateDate.Value.ToString("MM/dd/yyyy"),

                    });
                    
                }
                count++;
            }
           
            return rsList;
        }
        public AccountAPIViewModel ViewProfile(int account_id)
        {
            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var account = accountRepo.GetActive().SingleOrDefault(a => a.AccountId == account_id);
            if (account != null)
            {
                var accountAPIViewModel = new AccountAPIViewModel
                {
                    AccountId = account.AccountId,
                    RoleName = account.Role.RoleName,
                    Username = account.Username,
                    Password = account.Password,
                    CreateAt = account.CreateDate.Value.ToString("MM/dd/yyyy"),
                    UpdateAt = account.UpdateDate.Value.ToString("MM/dd/yyyy"),
                };
                return accountAPIViewModel;
            }
            return null;
        }
        public bool CreateAccount(AccountCreateAPIViewModel model)
        {

            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var createAccount = new Account();

            try
            {
                createAccount.AccountId = model.AccountId;
                createAccount.RoleId = model.RoleId;
                createAccount.Username = model.Username;
                createAccount.Password = model.Password;
                createAccount.CreateDate = DateTime.Now;
                createAccount.UpdateDate = DateTime.Now;

                accountRepo.Add(createAccount);

                accountRepo.Save();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
       
    }
}

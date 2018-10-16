using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    
    public interface IAccountDomain
    {
        AccountAPIViewModel ViewProfile(int account_id);
        bool CheckLogin(string username, string password, int roleid);
        List<AccountAPIViewModel> GetAllAccount();
        bool CreateAccount(AccountAPIViewModel model);
        bool RemoveAccount(int account_id);
        bool UpdateProfile(AccountAPIViewModel model);
    };

    public class AccountDomain : BaseDomain, IAccountDomain
    {
        public bool CheckLogin(string username, string password, int roleid)
        {

            var accountService = this.Service<IAccountService>();

            var isLoginSucess = accountService.CheckLogin(username,password,roleid);
            
            return isLoginSucess;
        }

        public bool CreateAccount(AccountAPIViewModel model)
        {
            var AccountService = this.Service<IAccountService>();

            var result = AccountService.CreateAccount(model);

            return result;
        }

        public List<AccountAPIViewModel> GetAllAccount()
        {
            var accountService = this.Service<IAccountService>();

            var accounts = accountService.GetAllAccount();

            return accounts;
        }

        public AccountAPIViewModel ViewProfile(int account_id)
        {
            var accountService = this.Service<IAccountService>();

            var account = accountService.ViewProfile(account_id);

            return account;
        }
        public bool RemoveAccount(int account_id)
        {
            var AccountList = new List<AccountAPIViewModel>();

            var accountService = this.Service<IAccountService>();
            bool a = accountService.RemoveAccount(account_id);
            return a;
        }

        public bool UpdateProfile(AccountAPIViewModel model)
        {
            var accountService = this.Service<IAccountService>();

            var result = accountService.UpdateProfile(model);

            return result;
        }
    }
}

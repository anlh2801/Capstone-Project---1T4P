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

        bool CheckLogin(string username, string password, int roleid);
        List<AccountAPIViewModel> GetAllAccount();
    };

    public class AccountDomain : BaseDomain, IAccountDomain
    {
        public bool CheckLogin(string username, string password, int roleid)
        {

            var accountService = this.Service<IAccountService>();

            var isLoginSucess = accountService.CheckLogin(username,password,roleid);
            
            return isLoginSucess;
        }

        public List<AccountAPIViewModel> GetAllAccount()
        {
            var accountService = this.Service<IAccountService>();

            var accounts = accountService.GetAllAccount();

            return accounts;
        }
    }
}

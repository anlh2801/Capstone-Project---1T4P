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
    }

    public partial class AccountService
    {
        public bool CheckLogin(string username, string password, int roleid)
        {            
            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var isLoginSucess = accountRepo.GetActive().Any(a => a.Username == username && a.Passwrod == password && a.RoleId == roleid);
            return isLoginSucess;
        }
        public List<AccountAPIViewModel> GetAllAccount()
        {
            List<AccountAPIViewModel> rsList = new List<AccountAPIViewModel>();
            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var accounts = accountRepo.GetActive().ToList();

            foreach (var item in accounts)
            {
                rsList.Add(new AccountAPIViewModel
                {
                    AccountId = item.AccountId,
                    RoleId = item.RoleId,
                    Username = item.Username,
                    Passwrod = item.Passwrod,

                });
            }

            return rsList;
        }
    }
}

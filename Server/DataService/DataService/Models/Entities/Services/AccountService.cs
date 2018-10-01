using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IAccountService
    {
        bool CheckLogin(string username, string password,int roleid);
    }

    public partial class AccountService
    {
        public bool CheckLogin(string username, string password, int roleid)
        {            
            var accountRepo = DependencyUtils.Resolve<IAccountRepository>();
            var isLoginSucess = accountRepo.GetActive().Any(a => a.Username == username && a.Passwrod == password && a.RoleId == roleid);
            return isLoginSucess;
        }
    }
}

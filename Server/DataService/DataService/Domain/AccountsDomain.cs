using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IAccountsDomain
    {
        AccountAPIViewModel GetAccountById(int id);
    }
    public class AccountDomain : BaseDomain,IAccountsDomain
    {
        public AccountAPIViewModel GetAccountById(int id)
        {
            var accountService = this.Service<IAccountService>();
           return accountService.GetAccountById(id);
        }
    }
}

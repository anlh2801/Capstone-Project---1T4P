using DataService.APIViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IAccountService
    {
        AccountAPIViewModel GetAccountById(int id);
    }
    public partial class AccountService
    {
        public AccountAPIViewModel GetAccountById(int id)
        {
            var account = Repository.FirstOrDefaultActive(a => a.AccountID == id);
            return new AccountAPIViewModel(account);

        }
    }
}

using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class AccountService
    {
        AccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public List<Account> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Account>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Account s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

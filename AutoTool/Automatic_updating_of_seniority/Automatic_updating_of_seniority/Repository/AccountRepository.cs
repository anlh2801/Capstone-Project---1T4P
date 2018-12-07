using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Repository
{
    public interface IAccountRepository
    {

    }
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {

    }
}

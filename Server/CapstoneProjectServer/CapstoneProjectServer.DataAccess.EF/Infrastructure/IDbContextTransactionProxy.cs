using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProjectServer.DataAccess.EF.Infrastructure
{
    public interface IDbContextTransactionProxy : IDisposable
    {
        void Commit();
        void Rollback();
    }
}

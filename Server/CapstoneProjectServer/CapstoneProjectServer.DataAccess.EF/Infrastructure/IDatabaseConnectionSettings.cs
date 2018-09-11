using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProjectServer.DataAccess.EF.Infrastructure
{
    public interface IDatabaseConnectionSettings
    {
        string ConnectionString { get; }
    }
}

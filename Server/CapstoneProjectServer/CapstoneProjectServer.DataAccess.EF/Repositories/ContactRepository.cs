using CapstoneProjectServer.DataAccess.EF.Infrastructure;
using CapstoneProjectServer.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProjectServer.DataAccess.EF.Repositories
{
    public interface IContactRepository : IRepository<tblContact>
    {
        Task<List<tblContact>> GetAllContact();
    }
    public class ContactRepository : RepositoryBase<tblContact>, IContactRepository
    {
        public async Task<List<tblContact>> GetAllContact()
        {
            return await DbSet.AsQueryable().ToListAsync();            
        }
    }
}

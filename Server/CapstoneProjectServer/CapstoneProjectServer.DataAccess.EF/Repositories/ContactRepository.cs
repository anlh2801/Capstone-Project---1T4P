using CapstoneProjectServer.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProjectServer.DataAccess.EF.Repositories
{
    public interface IContactRepository
    {
        Task<List<tblContact>> GetAllContact();
    }
    public class ContactRepository : IContactRepository
    {
        public async Task<List<tblContact>> GetAllContact()
        {
            
            using (var context = new CasptoneProjectContext())
            {
                return await context.Set<tblContact>().ToListAsync();
            }
        }
    }
}

using CapstoneProjectServer.BusinessLogic.Settings;
using CapstoneProjectServer.DataAccess.EF.Models;
using CapstoneProjectServer.DataAccess.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProjectServer.BusinessLogic.Services
{
    public interface IContactService
    {
        Task<BusinessLogicResult<tblContact>> GetLatestContact();
    }
    public class ContactService : IContactService
    {
        public async Task<BusinessLogicResult<tblContact>> GetLatestContact()
        {
            var repo = new ContactRepository();
            var contacts = await repo.GetAllContact();
            var result = contacts.OrderByDescending(x => x.publicDate).FirstOrDefault();
            return new BusinessLogicResult<tblContact> { Success = true, Result = result };
            
        }
    }
}

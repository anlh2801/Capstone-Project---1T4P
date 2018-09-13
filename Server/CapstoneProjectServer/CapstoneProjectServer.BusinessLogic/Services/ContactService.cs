using CapstoneProjectServer.BusinessLogic.Settings;
using CapstoneProjectServer.DataAccess.EF.Infrastructure;
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

        Task<BusinessLogicResult<IEnumerable<tblContact>>> GetAllContact();
    }
    public class ContactService : IContactService
    {
        public ContactService(IRepositoryHelper repositoryHelper)
        {
            this.RepositoryHelper = repositoryHelper;
            this.UnitOfWork = RepositoryHelper.GetUnitOfWork();
        }
        private readonly IUnitOfWork UnitOfWork;
        private readonly IRepositoryHelper RepositoryHelper;


        public async Task<BusinessLogicResult<tblContact>> GetLatestContact()
        {
            var repo = this.RepositoryHelper.GetRepository<IContactRepository>(UnitOfWork);
            var contacts = await repo.GetAllContact();
            var contact = contacts.OrderByDescending(x => x.publicDate).FirstOrDefault();
            return new BusinessLogicResult<tblContact> { Success = true, Result = contact };
        }

        public async Task<BusinessLogicResult<IEnumerable<tblContact>>> GetAllContact()
        {
            var repo = this.RepositoryHelper.GetRepository<IContactRepository>(UnitOfWork);
            var contacts = await repo.GetAllContact();
            
            return new BusinessLogicResult<IEnumerable<tblContact>> { Success = true, Result = contacts };
        }
    }
}

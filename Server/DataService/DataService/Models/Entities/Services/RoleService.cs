using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IAccountService
    {
        List<RoleAPIViewModel> GetAllRole();
    }

    public partial class AccountService
    {
        public List<RoleAPIViewModel> GetAllRole()
        {
            List<RoleAPIViewModel> rsList = new List<RoleAPIViewModel>();
            var roleRepo = DependencyUtils.Resolve<IRoleRepository>();
            var roles = roleRepo.GetActive().ToList();
            foreach (var item in roles)
            {
                if (!item.IsDelete)
                {
                    rsList.Add(new RoleAPIViewModel
                    {
                        RoleId = item.RoleId,
                        RoleName = item.RoleName,
                        IsDelete = item.IsDelete,
                        CreateDate = item.CreateDate.Value.ToString("MM/dd/yyyy"),
                        UpdateDate = item.UpdateDate.Value.ToString("MM/dd/yyyy"),

                    });

                }
            }

            return rsList;
        }
    }
}

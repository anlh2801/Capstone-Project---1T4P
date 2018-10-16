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
    public partial interface IRoleService
    {
        List<RoleAPIViewModel> GetAllRole();
    }

    public partial class RoleService
    {
        public List<RoleAPIViewModel> GetAllRole()
        {
            List<RoleAPIViewModel> rsList = new List<RoleAPIViewModel>();
            var RoleRepo = DependencyUtils.Resolve<IRoleRepository>();
            var roles = RoleRepo.GetActive().ToList();
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

using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{

    public interface IRoleDomain
    {
        ResponseObject<List<RoleAPIViewModel>> GetAllRole();
    };
    public class RoleDomain : BaseDomain, IRoleDomain
    {
        public ResponseObject<List<RoleAPIViewModel>> GetAllRole()
        {
            var roleService = this.Service<IRoleService>();

            var roles = roleService.GetAllRole();

            return roles;
        }
    }
}

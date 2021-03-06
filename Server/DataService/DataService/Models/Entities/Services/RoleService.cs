﻿using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.ResponseModel;
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
        ResponseObject<List<RoleAPIViewModel>> GetAllRole();
    }

    public partial class RoleService
    {
        public ResponseObject<List<RoleAPIViewModel>> GetAllRole()
        {
            try
            {
                List<RoleAPIViewModel> rsList = new List<RoleAPIViewModel>();
                var RoleRepo = DependencyUtils.Resolve<IRoleRepository>();
                var roles = RoleRepo.GetActive().ToList();
                if (roles.Count <= 0)
                {
                    return new ResponseObject<List<RoleAPIViewModel>> { IsError = true, WarningMessage = "Thất bại" };
                }
                foreach (var item in roles)
                {
                    if (!item.IsDelete)
                    {
                        rsList.Add(new RoleAPIViewModel
                        {

                            RoleId = item.RoleId,
                            RoleName = item.RoleName,
                            IsDelete = item.IsDelete,
                            CreateDate = item.CreateDate.ToString("HH:mm dd/MM/yyyy"),
                            UpdateDate = item.UpdateDate.Value.ToString("HH:mm dd/MM/yyyy"),

                        });

                    }
                }

                return new ResponseObject<List<RoleAPIViewModel>> { IsError = false, ObjReturn = rsList, SuccessMessage = "Lấy Thành công" };
            }
            catch (Exception e)
            {

                return new ResponseObject<List<RoleAPIViewModel>> { IsError = true, WarningMessage = "Thất bại", ObjReturn = null, ErrorMessage = e.ToString() };
            }
        }
    }
}

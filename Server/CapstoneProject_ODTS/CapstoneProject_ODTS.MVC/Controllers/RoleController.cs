using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    [MVC.Filters.AutorizeAdmin]
    public class RoleController: Controller
    {
        private RoleDomain _roleDomain;
        public RoleController()
        {
            _roleDomain = new RoleDomain();
        }
        public ActionResult GetAllRole()
        {
            var roles = _roleDomain.GetAllRole();
            
            return Json(new { result = roles }, JsonRequestBehavior.AllowGet);
        }
    }
}
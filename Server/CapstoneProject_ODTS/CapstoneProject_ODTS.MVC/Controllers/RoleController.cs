using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
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
            if (roles.Count() < 0)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = roles }, JsonRequestBehavior.AllowGet);
        }
    }
}
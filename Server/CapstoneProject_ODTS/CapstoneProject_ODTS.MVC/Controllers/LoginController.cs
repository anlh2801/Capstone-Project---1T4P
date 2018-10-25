using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class LoginController : Controller
    {
        private AccountDomain _accountDomain;

        public LoginController()
        {
            _accountDomain = new AccountDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        //public ActionResult CheckLogin(string username,string password,int roleId)
        //{
        //    var isSucess = _accountDomain.CheckLogin(username, password, roleId);
            
        //    return Json(new { isSucess = isSucess, urlReturn = "/Home/Index" }, JsonRequestBehavior.AllowGet);
            
        //}
    }
}
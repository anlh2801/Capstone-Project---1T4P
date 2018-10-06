using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class AccountController : Controller
    {
        private AccountDomain _accountDomain;

        public AccountController()
        {
            _accountDomain = new AccountDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllAccount()
        {
            var accounts = _accountDomain.GetAllAccount();
            if (accounts.Count() < 0)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = accounts }, JsonRequestBehavior.AllowGet);
        }
    }
}
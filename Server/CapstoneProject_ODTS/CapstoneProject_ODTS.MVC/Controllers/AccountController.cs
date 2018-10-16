using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult ViewProfile(int account_id)
        {
            var accountdetail = _accountDomain.ViewProfile(account_id);
            if (accountdetail == null)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = accountdetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateAccount(AccountAPIViewModel model)
        {
             
            var result = _accountDomain.CreateAccount(model);
            if (result == false)
            {
                return Json(false); ;
            }

            return Json(true);

        }
        public ActionResult RemoveAccount(int account_id)
        {
            var accountDetail = _accountDomain.RemoveAccount(account_id);
            return Json(new { result = accountDetail }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateProfile(AccountAPIViewModel model)
        {
            var result = _accountDomain.UpdateProfile(model);
            if (result == false)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
    }
}
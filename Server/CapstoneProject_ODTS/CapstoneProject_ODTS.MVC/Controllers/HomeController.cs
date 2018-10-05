using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    public class HomeController : Controller
    {
        private CompanyDomain _companyDomain;

        public HomeController()
        {
            _companyDomain = new CompanyDomain();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetAllCompany()
        {
            var result = _companyDomain.GetAllCompany();
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}
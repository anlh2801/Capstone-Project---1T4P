using DataService.Domain;
using DataService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    public class ServiceITSupportController : Controller
    {
        private ServiceITSupportDomain _serviceITSupportDomain;
        public ServiceITSupportController()
        {
            _serviceITSupportDomain = new ServiceITSupportDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllServiceITSupport()
        {
            var serviceITSupports = _serviceITSupportDomain.GetAllServiceITSupport();

            return Json(new { result = serviceITSupports }, JsonRequestBehavior.AllowGet);
        }
    }
}
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    [MVC.Filters.AutorizeAdmin]
    public class RequestStatisticController : Controller
    {
        private RequestDomain _requestDomain;

        public RequestStatisticController()
        {
            _requestDomain = new RequestDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllRequestForMonth(int month, int year)
        {
            var result = _requestDomain.GetAllRequestForMonth(month, year);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }
}
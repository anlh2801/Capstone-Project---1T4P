using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    public class RequestStatisticController : Controller
    {
        private RequestDomain _requestDomain;

        public RequestStatisticController()
        {
            //_companyDomain = new CompanyDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

    }
}
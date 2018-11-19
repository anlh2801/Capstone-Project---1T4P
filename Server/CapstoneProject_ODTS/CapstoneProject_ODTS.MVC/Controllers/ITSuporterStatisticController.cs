using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    [MVC.Filters.AutorizeAdmin]
    public class ITSuporterStatisticController : Controller
    {
        private ITSupporterDomain _itsupporterDomain;

        public ITSuporterStatisticController()
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
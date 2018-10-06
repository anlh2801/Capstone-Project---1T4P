using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataService.Domain;

namespace CapstoneProject_ODTS.Controllers
{
    //public class AgencyController
    //{
    //}
    public class AgencyController : Controller
    {
        private AgencyDomain _companyDomain;

        public AgencyController()
        {
            _companyDomain = new AgencyDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllAgency()
        {
            var result = _companyDomain.GetAllAgency();
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AgencyDevice(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }


        public ActionResult GetAllDevice(int agency_id)
        {
            var result = _companyDomain.ViewAllDevice(agency_id);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}
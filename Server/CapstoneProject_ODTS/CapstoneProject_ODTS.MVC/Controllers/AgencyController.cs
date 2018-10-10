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
        private AgencyDomain _agencyDomain;

        public AgencyController()
        {
            _agencyDomain = new AgencyDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllAgency()
        {
            var result = _agencyDomain.GetAllAgency();
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
            var result = _agencyDomain.ViewAllDeviceByAgencyId(agency_id);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAgencyDetail(int agency_id)
        {
            var agencyDetail = _agencyDomain.ViewProfile(agency_id);
            if (agencyDetail == null)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = agencyDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
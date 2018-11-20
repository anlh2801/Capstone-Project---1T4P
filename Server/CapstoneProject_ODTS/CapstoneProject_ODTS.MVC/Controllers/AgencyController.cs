using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataService.APIViewModels;
using DataService.Domain;

namespace CapstoneProject_ODTS.Controllers
{
    //public class AgencyController
    //{
    //}
    [MVC.Filters.AutorizeAdmin]
    public class AgencyController : Controller
    {
        private AgencyDomain _agencyDomain;
        private DeviceDomain _deviceDomain;

        public AgencyController()
        {
            _agencyDomain = new AgencyDomain();
            _deviceDomain = new DeviceDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllAgency()
        {
            var result = _agencyDomain.GetAllAgency();            

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AgencyDevice(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }
        public ActionResult CompanyAgency(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }

        public ActionResult GetAllDevice(int agency_id)
        {
            var result = _agencyDomain.ViewAllDeviceByAgencyId(agency_id);
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAgencyDetail(int agency_id)
        {
            var agencyDetail = _agencyDomain.ViewProfile(agency_id);
            
            return Json(new { result = agencyDetail }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveAgency(int agency_id)
        {
            var agencyDetail = _agencyDomain.RemoveAgency(agency_id);
            //return RedirectToAction("Index");
            return Json(new { result = agencyDetail }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateAgency(AgencyAPIViewModel model)
        {
            var result = _agencyDomain.CreateAgency(model);
           
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateAgency(AgencyUpdateAPIViewModel model)
        {
            var result = _agencyDomain.UpdateProfile(model);
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult CreateDevice(DeviceAPIViewModel model)
        {
            var result = _deviceDomain.CreateDevice(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
    }
}
using DataService.APIViewModels;
using DataService.Domain;
using DataService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    [MVC.Filters.AutorizeAdmin]
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
        public ActionResult ViewDetail(int serviceitsupport_id)
        {
            var serviceitsupportDetail = _serviceITSupportDomain.ViewDetail(serviceitsupport_id);

            return Json(new { result = serviceitsupportDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateServiceITSupport(ServiceITSupportAPIViewModel model)
        {
            var result = _serviceITSupportDomain.CreateServiceITSupport(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateServiceITSupport(ServiceITSupportAPIViewModel model)
        {
            var result = _serviceITSupportDomain.UpdateServiceITSupport(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveServiceITSupport(int serviceitsupport_id)
        {
            var serviceitsupportDetail = _serviceITSupportDomain.RemoveServiceITSupport(serviceitsupport_id);
            return Json(new { result = serviceitsupportDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllServiceITSupportByAgencyId(int agencyId)
        {
            var serviceitsupportDetail = _serviceITSupportDomain.GetAllServiceITSupportByAgencyId(agencyId);
            return Json(new { result = serviceitsupportDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
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
    public class DeviceController : Controller
    {
        private DeviceDomain _deviceDomain;

        public DeviceController()
        {
            _deviceDomain = new DeviceDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult AgencyDevice(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }
        public ActionResult GetAllDevice()
        {
            var devices = _deviceDomain.GetAllDevice();

            return Json(new { result = devices }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(int device_id)
        {
            var devicedetail = _deviceDomain.ViewDetail(device_id);

            return Json(new { result = devicedetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateDevice(DeviceAPIViewModel model)
        {
            var result = _deviceDomain.CreateDevice(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ViewAllDeviceByAgencyId(int agency_id)
        {
            var devices = _deviceDomain.ViewAllDeviceByAgencyId(agency_id);

            return Json(new { result = devices }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateDevice(AgencyDeviceAPIViewModel model)
        {
            var result = _deviceDomain.UpdateDevice(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveDevice(int device_id)
        {
            var deviceDetail = _deviceDomain.RemoveDevice(device_id);
            return Json(new { result = deviceDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
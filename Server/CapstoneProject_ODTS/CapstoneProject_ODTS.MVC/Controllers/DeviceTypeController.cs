using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class DeviceTypeController : Controller
    {
        private DeviceTypeDomain _devicetypeDomain;

        public DeviceTypeController()
        {
            _devicetypeDomain = new DeviceTypeDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllDeviceType()
        {
            var devicetypes = _devicetypeDomain.GetAllDeviceType();            

            return Json(new { result = devicetypes }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(int devicetype_id)
        {
            var devicetypedetail = _devicetypeDomain.ViewDetail(devicetype_id);
            if (devicetypedetail == null)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = devicetypedetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateDeviceType(DeviceTypeAPIViewModel model)
        {

            var result = _devicetypeDomain.CreateDeviceType(model);
            if (result == false)
            {
                return Json(false); ;
            }

            return Json(true);

        }
        public ActionResult UpdateDeviceType(DeviceTypeAPIViewModel model)
        {
            var result = _devicetypeDomain.UpdateDeviceType(model);
            if (result == false)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveDeviceType(int devicetype_id)
        {
            var devicetypeDetail = _devicetypeDomain.RemoveDeviceType(devicetype_id);
            return Json(new { result = devicetypeDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
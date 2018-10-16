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
    }
}
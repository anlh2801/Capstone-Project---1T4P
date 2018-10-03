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
        private DeviceTypeDomain _companyDomain;

        public DeviceTypeController()
        {
            _companyDomain = new DeviceTypeDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllDeviceType()
        {
            var devicetypes = _companyDomain.GetAllDeviceType();
            if (devicetypes.Count() < 0)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = devicetypes }, JsonRequestBehavior.AllowGet);
        }
    }
}
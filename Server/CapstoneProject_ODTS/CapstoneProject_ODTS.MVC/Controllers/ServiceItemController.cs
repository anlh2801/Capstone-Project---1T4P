using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    public class ServiceItemController : Controller
    {
        private ServiceItemDomain _serviceItemDomain;

        public ServiceItemController()
        {
            _serviceItemDomain = new ServiceItemDomain();
        }
        public ActionResult Index(int id)
        {
            ViewData["ID"] = id.ToString();

            return View();
        }
        //public ActionResult ServiceItem(int id)
        //{
        //    ViewData["ID"] = id.ToString();
        //    return View();
        //}
        public ActionResult GetAllServiceItem(int serviceITSupportId)
        {
            var serviceItem = _serviceItemDomain.GetAllServiceItemByServiceITSupportId(serviceITSupportId);

            return Json(new { result = serviceItem }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(int ServiceItemId)
        {
            var serviceItemDetail = _serviceItemDomain.ViewDetail(ServiceItemId);

            return Json(new { result = serviceItemDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateServiceItem(ServiceItemUpdateAPIViewModel model)
        {
            var result = _serviceItemDomain.UpdateServiceItem(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveServiceItem(int serviceItem_Id)
        {
            var deviceDetail = _serviceItemDomain.RemoveServiceItem(serviceItem_Id);
            return Json(new { result = deviceDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
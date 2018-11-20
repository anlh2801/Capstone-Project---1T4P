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
    public class GuidelineController : Controller
    {
        private GuidelineDomain _guidelineDomain;

        public GuidelineController()
        {
            _guidelineDomain = new GuidelineDomain();
        }
        public ActionResult ServiceGuideline(int id)
        {
            ViewData["ID"] = id.ToString();

            return View();
        }
        public ActionResult GetAllGuideline(int ServiceItemId)
        {
            var guideline = _guidelineDomain.GetAllGuidelineByServiceItemId(ServiceItemId);

            return Json(new { result = guideline }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(int GuidelineId)
        {
            var serviceItemDetail = _guidelineDomain.ViewDetail(GuidelineId);

            return Json(new { result = serviceItemDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateGuideline(GuidelineUpdateAPIViewModel model)
        {
            var result = _guidelineDomain.UpdateGuideline(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveGuideline(int GuidelineId)
        {
            var guidelineDetail = _guidelineDomain.RemoveGuideline(GuidelineId);
            return Json(new { result = guidelineDetail }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateGuideline(GuidelineAPIViewModel model)
        {
            var result = _guidelineDomain.CreateGuideline(model);

            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
    }
}
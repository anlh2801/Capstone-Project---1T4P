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
    public class ITSupporterController : Controller
    {
        private ITSupporterDomain _ITSupporterDomain;

        public ITSupporterController()
        {
            _ITSupporterDomain = new ITSupporterDomain();
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetAllITSupporter()
        {
            var result = _ITSupporterDomain.GetAllITSupporter();
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewProfileITSupporter(int itSupporter_id)
        {
            var result = _ITSupporterDomain.ViewProfileITSupporter(itSupporter_id);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewSkillITSupporter(int itSupporter_id)
        {
            var result = _ITSupporterDomain.ViewSkillITSupporter(itSupporter_id);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateITSuport(ITSupporterAPIViewModel model)
        {
            var result = _ITSupporterDomain.CreateITSuport(model);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddSkill(SkillAPIViewModel model)
        {
            var result = _ITSupporterDomain.AddSkill(model);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveSkill(int itsupporterId, int serviceITSupportId)
        {
            var result = _ITSupporterDomain.RemoveSkill(itsupporterId, serviceITSupportId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveITSuporter(int itsupporterId)
        {
            var result = _ITSupporterDomain.RemoveITSuporter(itsupporterId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateITSup(ITSupporterAPIViewModel model)
        {
            var result = _ITSupporterDomain.UpdateITSup(model);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
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
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}
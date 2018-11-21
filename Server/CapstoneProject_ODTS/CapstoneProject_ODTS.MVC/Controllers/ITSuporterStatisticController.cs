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
    public class ITSuporterStatisticController : Controller
    {
        private ITSupporterDomain _itsupporterDomain;

        public ITSuporterStatisticController()
        {
            _itsupporterDomain = new ITSupporterDomain();
        }
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ITSuporterStatisticAll(int year, int month)
        {
            var result = _itsupporterDomain.ITSuppoterStatistic(year, month);
            if (!result.IsError)
            {
                var totalReject = result.ObjReturn.ToList().Sum(p => p.TotalRejectTime);
                var totalSupport = result.ObjReturn.ToList().Sum(p => p.SupportTimeInMonth);

                return Json(new { result, totalReject = totalReject, totalSupport = totalSupport }, JsonRequestBehavior.AllowGet);
            }

           return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ServiceITSuppoterStatistic(int year, int month)
        {
            var result = _itsupporterDomain.ServiceITSuppoterStatistic(year, month);
            if (!result.IsError)
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }
}
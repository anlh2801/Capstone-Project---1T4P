using DataService.APIViewModels;
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
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ITSuppoterStatistic(int itsupporterId)
        {
            // var result = _ITSupporterDomain.ITSuppoterStatistic(itsupporterId);
            var result = new ITSupporterStatisticAPIViewModel
            {
                ITSupporterName = "long",
                AverageTimeSupport = 10,
                TotalTimeEveryService = new List<ITSupporterStatisticServiceTimeAPIViewModel>()
                {
                    new ITSupporterStatisticServiceTimeAPIViewModel ()
                    {
                        ServiceName = "wifi",
                        SupportTime = 10.ToString()
                        
                    },
                     new ITSupporterStatisticServiceTimeAPIViewModel ()
                    {
                        ServiceName = "camera",
                        SupportTime = 10.ToString()

                    },
                     new ITSupporterStatisticServiceTimeAPIViewModel ()
                    {
                        ServiceName = "pos",
                        SupportTime = 15.ToString()

                    }
                },

            


            };
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }
}
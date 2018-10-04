using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class ContractController : Controller
    {
        private ContractDomain _contractDomain;

        public ContractController()
        {
            _contractDomain = new ContractDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllContract()
        {
            var contracts = _contractDomain.GetAllContract();
            if (contracts.Count() < 0)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = contracts }, JsonRequestBehavior.AllowGet);
        }
    }
}
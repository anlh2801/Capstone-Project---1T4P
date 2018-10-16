using DataService.APIViewModels;
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
        public ActionResult ViewDetail(int contract_id)
        {
            var contractdetail = _contractDomain.ViewDetail(contract_id);
            if (contractdetail == null)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = contractdetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateContract(ContractAPIViewModel model)
        {

            var result = _contractDomain.CreateContract(model);
            if (result == false)
            {
                return Json(false); ;
            }

            return Json(true);

        }
        public ActionResult UpdateContract(ContractAPIViewModel model)
        {
            var result = _contractDomain.UpdateContract(model);
            if (result == false)
            {
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveContract(int contract_id)
        {
            var contractDetail = _contractDomain.RemoveContract(contract_id);
            return Json(new { result = contractDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
using DataService.APIViewModels;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    [MVC.Filters.AutorizeAdmin]
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
        
        public ActionResult CompanyContract(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }

        public ActionResult IndexContract(int contractId)
        {
            ViewData["ID"] = contractId.ToString();
            return View();
        }

        public ActionResult GetAllContract()
        {
            var contracts = _contractDomain.GetAllContract();
            
            return Json(new { result = contracts }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(int contract_id)
        {
            var contractdetail = _contractDomain.ViewDetail(contract_id);            

            return Json(new { result = contractdetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateContract(ContractAPIViewModel model)
        {
            var result = _contractDomain.CreateContract(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateContract(ContractAPIViewModel model)
        {
            var result = _contractDomain.UpdateContract(model);            
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveContract(int contract_id)
        {
            var contractDetail = _contractDomain.RemoveContract(contract_id);
            return Json(new { result = contractDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewAllContractServiceByContractId(int contract_id)
        {
            var contractDetail = _contractDomain.ViewAllContractServiceByContractId(contract_id);
            return Json(new { result = contractDetail }, JsonRequestBehavior.AllowGet);
        }
    }
}
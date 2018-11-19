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
    public class CompanyController : Controller
    {
        private CompanyDomain _companyDomain;

        public CompanyController()
        {
            _companyDomain = new CompanyDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Agency(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }
        public ActionResult Contract(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }
        public ActionResult GetAllCompany()
        {
            var companys = _companyDomain.GetAllCompany();

            return Json(new { result = companys }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(int company_id)
        {
            var companydetail = _companyDomain.ViewDetail(company_id);

            return Json(new { result = companydetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateCompany(CompanyAPIViewModel model)
        {
            var result = _companyDomain.CreateCompany(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateCompany(CompanyAPIViewModel model)
        {
            var result = _companyDomain.UpdateCompany(model);
            return Json(new { result }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult RemoveCompany(int company_id)
        {
            var companydetail = _companyDomain.RemoveCompany(company_id);
            return Json(new { result = companydetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CompanyAgency(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }
        public ActionResult GetAllAgency(int company_id)
        {
            var result = _companyDomain.ViewAllAgencyByCompanyId(company_id);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllContract(int company_id)
        {
            var result = _companyDomain.ViewAllContractByCompanyId(company_id);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCompanyDetail(int company_id)
        {
            var result = _companyDomain.ViewCompanyByCompanyId(company_id);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}
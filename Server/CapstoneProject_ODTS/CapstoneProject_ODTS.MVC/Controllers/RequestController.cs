using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class RequestController : Controller
    {
        private RequestDomain _requestDomain;

        public RequestController()
        {
            _requestDomain = new RequestDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllRequest()
        {
            var result = _requestDomain.GetAllRequest();
            if (result.Count() < 0)
            {
                //không co record
            }
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RequestDetail(int id)
        {
            ViewBag.Title = "Home Page";
            ViewData["ID"] = id.ToString();
            return View();
        }

        public ActionResult GetRequestDetail(int request_id)
        {
            var result = _requestDomain.GetTicketByRequestId(request_id);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RequestStatus(int id)
        {
            ViewBag.Title = "Home Page";
            ViewData["STATUS"] = id.ToString();
            return View();
        }

        public ActionResult GetRequestWithStatus(int status)
        {
            var result = _requestDomain.GetRequestWithStatus(status);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }
}

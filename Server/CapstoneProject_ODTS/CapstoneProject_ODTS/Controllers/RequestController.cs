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
        public ActionResult GetAllTicket()
        {
            var result = _requestDomain.GetAllRequest();
            if (result.Count() < 0)
            {
                //không co record
            }
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TicketDetail(Int32 id)
        {
            ViewBag.Title = "Home Page";
            ViewData["ID"] = id.ToString();
            return View();
        }

        public ActionResult GetTicketDetail(int requestId)
        {
            var result = _requestDomain.GetTicketByRequestId(requestId);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TicketStatus(Int32 id)
        {
            ViewBag.Title = "Home Page";
            ViewData["STATUS"] = id.ToString();
            return View();
        }

        public ActionResult GetTicketWithStatus(int status)
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

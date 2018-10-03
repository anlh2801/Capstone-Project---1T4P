using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class TicketController : Controller
    {
        private TicketDomain _TicketDomain;

        public TicketController()
        {
            _TicketDomain = new TicketDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllTicket()
        {
            var result = _TicketDomain.GetAllTicket();
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

        public ActionResult GetTicketDetail(Int32 id)
        {
            var result = _TicketDomain.GetTicketDetail(id);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}

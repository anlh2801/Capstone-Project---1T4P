using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class ProblemController : Controller
    {
        private ProblemDomain _problemDomain;

        public ProblemController()
        {
            _problemDomain = new ProblemDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllTicket()
        {
            var result = _problemDomain.GetAllProblem();
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

        public ActionResult GetTicketDetail(int problemId)
        {
            var result = _problemDomain.GetTicketByProblemId(problemId);
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
            var result = _problemDomain.GetProblemWithStatus(status);
            if (result.Count() < 0)
            {
                //không co record
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }
}

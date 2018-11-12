using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.MVC.Controllers
{
    public class ServiceItemController : Controller
    {
        // GET: ServiceItem
        public ActionResult Index(int id)
        {
            ViewData["ID"] = id.ToString();
            return View();
        }
    }
}
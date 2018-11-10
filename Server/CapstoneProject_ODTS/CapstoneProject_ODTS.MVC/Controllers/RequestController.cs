using DataService.CustomTools;
using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    public class RequestController : Controller
    {
        private RequestDomain _requestDomain;

        private AgencyDomain _agencyDomain;

        public RequestController()
        {
            _requestDomain = new RequestDomain();
            _agencyDomain = new AgencyDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetAllRequest()
        {
            var result = _requestDomain.GetAllRequest();
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequestStatistic()
        {
            var result = _requestDomain.GetRequestStatistic();

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
            var requestDetail = _requestDomain.GetTicketByRequestId(request_id);
            if (requestDetail == null)
            {
                //không co record
                return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = requestDetail}, JsonRequestBehavior.AllowGet);
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
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindITSupporterByRequestId(int requestId)
        {
            var result = _agencyDomain.FindITSupporterByRequestId(requestId);

            if (!result.IsError && result.ObjReturn > 0)
            {
                FirebaseService firebaseService = new FirebaseService();
                firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(result.ObjReturn, requestId);

                //int counter = 60;

                //while (counter > 0)
                //{
                //    counter--;
                //    Thread.Sleep(1000);
                //}
                //_requestDomain.AcceptRequestFromITSupporter(result.ObjReturn, requestId, false);

                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

    }
}

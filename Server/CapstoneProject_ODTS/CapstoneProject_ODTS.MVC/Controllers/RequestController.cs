using DataService.APIViewModels;
using DataService.CustomTools;
using DataService.Domain;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CapstoneProject_ODTS.Controllers
{
    [MVC.Filters.AutorizeAdmin]
    public class RequestController : Controller
    {
        private RequestDomain _requestDomain;

        private AgencyDomain _agencyDomain;

        private ServiceITSupportDomain _serviceITSupportDomain;

        private ServiceItemDomain _serviceItemDomain;

        private DeviceDomain _deviceDomain;

        private TicketDomain _ticketDomain;

        public RequestController()
        {
            _requestDomain = new RequestDomain();
            _agencyDomain = new AgencyDomain();
            _serviceITSupportDomain = new ServiceITSupportDomain();
            _serviceItemDomain = new ServiceItemDomain();
            _deviceDomain = new DeviceDomain();
            _ticketDomain = new TicketDomain();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult EditRequest(int requestId)
        {
            ViewData["ID"] = requestId.ToString();
            return View();
        }

        public ActionResult GetAllRequest(int companyId, int serviceItemId, int status, string start = null, string end = null)
        {
            var result = _requestDomain.GetAllRequest(companyId, serviceItemId, status, start, end);
            
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequestById(int requestId)
        {
            var result = _requestDomain.GetRequestById(requestId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateRequest(int requestId, int prioryty, int status, string description)
        {
            try
            {
                var result = _requestDomain.UpdateRequest(requestId, prioryty, status, description);

                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                if(status == (int) RequestStatusEnum.Pending)
                {
                    var result = _agencyDomain.FindITSupporterByRequestId(requestId);
                    if (!result.IsError && result.ObjReturn > 0)
                    {
                        FirebaseService firebaseService = new FirebaseService();
                        firebaseService.SendNotificationFromFirebaseCloudForITSupporterReceive(result.ObjReturn, requestId);
                    }
                }
                
            }
           
        }

        public ActionResult GetAllRequestForMonth(int month, int year)
        {
            var result = _requestDomain.GetAllRequestForMonth(month, year);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRequestStatisticForMonth(int year, int month)
        {
            var result = _requestDomain.GetRequestStatisticForMonth(month, year);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRequestStatistic()
        {
            var result = _requestDomain.GetRequestStatistic();

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRequestBytRequestId(int requestId)
        {
            var result = _requestDomain.GetRequestBytRequestId(requestId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SetPriority(int requestId, int priority)
        {
            var result = _requestDomain.SetPriority(requestId, priority);

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
        public ActionResult ApproveCancelRequest(int request_id, int status)
        {
            var result = _requestDomain.ApproveCancelRequest(request_id, status);

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

        public ActionResult CreateRequest(RequestAllTicketWithStatusAgencyAPIViewModel model)
        {
            var result = _agencyDomain.CreateRequest(model);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
            //return null;
        }
        // Danh mục
        public ActionResult GetServiceITSupportByAgencyId(int agencyId)
        {
            var result = _serviceITSupportDomain.GetAllServiceITSupportByAgencyId(agencyId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        // Hiện tượng
        public ActionResult GetAllServiceItemByServiceId(int serviceId)
        {
            var result = _serviceItemDomain.GetAllServiceItemByServiceId(serviceId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        // Thiết bị
        public ActionResult GetAllDeviceByAgencyIdAndServiceId(int agencyId, int serviceId)
        {
            var result = _deviceDomain.ViewAllDeviceByAgencyIdAndServiceId(agencyId, serviceId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }        

        public ActionResult ApproveRequestDone(int requestId)
        {
            var result = _requestDomain.UpdateStatusRequest(requestId, (int)RequestStatusEnum.Done);
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteTicket(int ticketId)
        {
            var result = _ticketDomain.DeleteTicket(ticketId);

            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDevicesForRequest(int requestId, List<int> deviceIds)
        {
            var result = _requestDomain.AddDevicesForRequest(requestId, deviceIds);
            return Json(new { result }, JsonRequestBehavior.AllowGet);
        }
    }
}

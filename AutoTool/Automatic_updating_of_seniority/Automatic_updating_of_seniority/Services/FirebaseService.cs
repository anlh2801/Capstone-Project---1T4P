using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class FirebaseService
    {
        public const string fcmKey = "AIzaSyCKceBvEIUixxsE77aNJot5oRYsSCZs7Zg";
        public const string webAddr = "https://fcm.googleapis.com/fcm/send";

        public String SendNotificationFromFirebaseCloudForITSupporterReceive(int itSupporterId, int requestId)
        {
            var result = "-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + fcmKey);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var data = RenderDataForITSupporterReceive(itSupporterId, requestId);
                var noti = new Notification()
                {
                    title = $"Chi nhánh {data.AgencyName} cần sửa {data.RequestName}",
                    text = $"Số lượng: {data.NumberOfTicket}",
                    sound = "default"
                };

                string strNJson = ConverMessageJsonForITSupporterReceiveFirebaseViewModel(data, noti);
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        public String SendNotificationFromFirebaseCloudForITSupporterOffline(int itSupporterId)
        {
            var result = "-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=" + fcmKey);
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var data = RenderDataForITSupporterOffline(itSupporterId);
                var noti = new Notification()
                {
                    title = $"Thông báo offline",
                    text = $"Bạn đã hủy 3 lần! Hệ thống tự động offline cho bạn",
                    sound = "default"
                };

                string strNJson = ConverMessageJsonForITSupporterOfflineFirebaseViewModel(data, noti);
                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }


            return result;
        }

        public string ConverMessageJsonForITSupporterReceiveFirebaseViewModel(ITSupporterReceiveFirebaseViewModel data, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", $"/topics/{data.ITSupporterId}");
            androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public string ConverMessageJsonForITSupporterOfflineFirebaseViewModel(ITSupporterOfflineFirebaseViewModel data, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", $"/topics/{data.ITSupporterId}");
            androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public ITSupporterReceiveFirebaseViewModel RenderDataForITSupporterReceive(int itSupporterId, int requestId)
        {
            var requestService = new RequestService();
            var itSupporterService = new ITSupporterService();
            var agencyService = new AgencyService();
            var ticketService = new TicketService();
            var accountService = new AccountService();
            var deviceService = new DeviceService();
            var deviceTypeService = new DeviceTypeService();
            
            var request = requestService.GetAll().SingleOrDefault(p => p.RequestId == requestId);
            var agency = agencyService.GetAll().SingleOrDefault(p => p.AgencyId == request.AgencyId);
            var ticket = ticketService.GetAll().Where(p => p.RequestId == request.RequestId);
            var itSupporter = itSupporterService.GetAll().SingleOrDefault(p => p.ITSupporterId == itSupporterId);
            var account = accountService.GetAll().SingleOrDefault(a => a.AccountId == itSupporter.AccountId);
            var itSupporterReceiveFirebaseViewModel = new ITSupporterReceiveFirebaseViewModel()
            {
                AgencyName = agency.AgencyName,
                AgencyAddress = agency.Address,
                RequestId = request.RequestId,
                RequestName = request.RequestName,
                NumberOfTicket = ticket.Count(),
                ITSupporterId = itSupporter.ITSupporterId,
                ITSupporterName = itSupporter.ITSupporterName,
                AccountId = itSupporter.AccountId,
                Username = account.Username
            };
            StringBuilder ticketInfo = new StringBuilder();
            foreach (var item in ticket)
            {
                var device = deviceService.GetAll().SingleOrDefault(d => d.DeviceId == item.DeviceId);
                ticketInfo.AppendLine($"Thiết bị: {deviceTypeService.GetAll().SingleOrDefault(dt => dt.DeviceTypeId == device.DeviceTypeId).DeviceTypeName} - {deviceService.GetAll().SingleOrDefault(d => d.DeviceId == item.DeviceId).DeviceName}");
            }
            itSupporterReceiveFirebaseViewModel.TicketsInfo = ticketInfo.ToString();
            itSupporterReceiveFirebaseViewModel.DateSend = DateTime.UtcNow.AddHours(7).ToString("HH:mm:ss");
            return itSupporterReceiveFirebaseViewModel;
        }

        public ITSupporterOfflineFirebaseViewModel RenderDataForITSupporterOffline(int itSupporterId)
        {
            var accountService = new AccountService();
            var itSupporterService = new ITSupporterService();
            var itSupporter = itSupporterService.GetAll().SingleOrDefault(p => p.ITSupporterId == itSupporterId);
            var account = accountService.GetAll().SingleOrDefault(a => a.AccountId == itSupporter.AccountId);

            var itSupporterOfflineFirebaseViewModel = new ITSupporterOfflineFirebaseViewModel()
            {
                ITSupporterName = itSupporter.ITSupporterName,
                ITSupporterId = itSupporter.ITSupporterId,
                isOnline = itSupporter.IsOnline ?? false,
                AccountId = itSupporter.AccountId,
                Username = account.Username
            };


            return itSupporterOfflineFirebaseViewModel;
        }
    }

    public class Notification
    {
        public string title { get; set; }
        public string text { get; set; }
        public string sound { get; set; }

        //public Notification(string title, string text, string sound = null)
        //{
        //    Title = title;
        //    Text = text;
        //    Sound = sound ?? "default";
        //}
    }

    public class ITSupporterReceiveFirebaseViewModel
    {
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string AgencyName { get; set; }
        public string AgencyAddress { get; set; }
        public int NumberOfTicket { get; set; }
        public string TicketsInfo { get; set; }
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string DateSend { get; set; }
    }

    public class ITSupporterOfflineFirebaseViewModel
    {
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public bool isOnline { get; set; }
    }
}

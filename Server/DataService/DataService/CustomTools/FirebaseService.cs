using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Models.Entities.Services;
using DataService.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataService.CustomTools
{
    public class FirebaseService
    {
        public String SendNotificationFromFirebaseCloudForITSupporterReceive(int itSupporterId, int requestId)
        {
            var result = "-1";
            var fcmKey = "AIzaSyCKceBvEIUixxsE77aNJot5oRYsSCZs7Zg";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
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

        public string ConverMessageJsonForITSupporterReceiveFirebaseViewModel(ITSupporterReceiveFirebaseViewModel data, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", $"/topics/{data.ITSupporterId}");
            androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public ITSupporterReceiveFirebaseViewModel RenderDataForITSupporterReceive(int itSupporterId, int requestId)
        {
            var itSupporterRepo = DependencyUtils.Resolve<IITSupporterRepository>();
            var requestRepo = DependencyUtils.Resolve<IRequestRepository>();
            var itSupporterService = new ITSupporterService();
            var request = requestRepo.GetActive().SingleOrDefault(p => p.RequestId == requestId);
            var itSupporter = itSupporterRepo.GetActive().SingleOrDefault(p => p.ITSupporterId == itSupporterId);
            var itSupporterReceiveFirebaseViewModel = new ITSupporterReceiveFirebaseViewModel()
            {
                AgencyName = request.Agency.AgencyName,
                AgencyAddress = request.Agency.Address,
                RequestId = request.RequestId,
                RequestName = request.RequestName,
                NumberOfTicket = request.Tickets.Count(),
                ITSupporterId = itSupporter.ITSupporterId,
                ITSupporterName = itSupporter.ITSupporterName,
                AccountId = itSupporter.AccountId,
                Username = itSupporter.Account.Username
            };
            StringBuilder ticketInfo = new StringBuilder();
            foreach (var item in request.Tickets)
            {
                ticketInfo.AppendLine($"Thiết bị: {item.Device.DeviceType.DeviceTypeName} - {item.Device.DeviceName}");
            }
            itSupporterReceiveFirebaseViewModel.TicketsInfo = ticketInfo.ToString();

            return itSupporterReceiveFirebaseViewModel;
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
    }
}

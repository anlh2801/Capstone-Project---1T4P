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
        public String SendNotificationFromFirebaseCloudForITSupporterReceive(ITSupporterAPIViewModel itSupporterAPIViewModel)
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
                var data = RenderDataForITSupporterReceive(itSupporterAPIViewModel);
                var noti = new Notification()
                {
                    title = "Title Dep1",
                    text = "Text Dep",
                    sound = "default"
                };

                string strNJson = ConverMessageJson(data, noti);
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

        public string ConverMessageJson(object data, Notification noti)
        {
            Dictionary<string, object> androidMessageDic = new Dictionary<string, object>();
            androidMessageDic.Add("to", "/topics/1");
            androidMessageDic.Add("data", data);
            androidMessageDic.Add("notification", noti);

            return JsonConvert.SerializeObject(androidMessageDic);

        }

        public ITSupporterReceive RenderDataForITSupporterReceive(ITSupporterAPIViewModel iTSupporterAPIViewModel)
        {
            var requestService = new RequestService();
            var requestModel = requestService.ViewRequestDetail(iTSupporterAPIViewModel.RequestWattingForAccept).ObjReturn;
            var ITSupporterReceive = new ITSupporterReceive();
            ITSupporterReceive.ITSupporterViewModel = iTSupporterAPIViewModel;
            ITSupporterReceive.RequestAPIViewModel = requestModel;

            return ITSupporterReceive;
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

    public class ITSupporterReceive
    {
        public ITSupporterAPIViewModel ITSupporterViewModel { get; set; }
        public RequestAllTicketWithStatusAgencyAPIViewModel RequestAPIViewModel { get; set; }
    }
}

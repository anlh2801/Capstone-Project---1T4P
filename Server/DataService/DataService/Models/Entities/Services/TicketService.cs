using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface ITicketService
    {
        List<TicketAPIViewModel> GetAllTicket();

        List<TicketAPIViewModel> GetTicketDetail(Int32 id);

        List<TicketAPIViewModel> GetTicketWithStatus(Int32 status);

        List<TicketAPIViewModel> GetAllTicketByAgencyIDAndStatus(Int32 acency_id, Int32 status);

        bool CreateFeedbackForTicket(int ticketId, string feedbackContent);
    }

    public partial class TicketService
    {
        public List<TicketAPIViewModel> GetAllTicket()
        {
            List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
            var TicketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var companies = TicketRepo.GetActive().ToList();
            foreach (var item in companies)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new TicketAPIViewModel()
                {
                    TicketId = item.TicketId,
                    TicketName = item.TicketName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }


        public List<TicketAPIViewModel> GetTicketWithStatus(Int32 status)
        {
            List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
            var TicketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var companies = TicketRepo.GetActive().ToList();
            var listStatus = companies.FindAll(x => x.CurrentStatus == status);
            foreach (var item in listStatus)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new TicketAPIViewModel()
                {
                    TicketId = item.TicketId,
                    TicketName = item.TicketName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }



        public List<TicketAPIViewModel> GetTicketDetail(Int32 id)
        {
            List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
            var TicketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var TicketDetailRepo = DependencyUtils.Resolve<ITicketDetailRepository>();
            var ServiceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
            var ITRepo = DependencyUtils.Resolve<IITSupporterRepository>();

            var ticket = TicketRepo.GetActive().ToList();
            var list = ticket.Find(x => x.TicketId == id);

            var service = ServiceItemRepo.GetActive().ToList();
            var it = ITRepo.GetActive().ToList();

            var detail = TicketDetailRepo.GetActive().ToList();
            var detailList = detail.FindAll(x => x.TicketId == list.TicketId);
            var listIssue = new List<String>();
            var listIT = new List<String>();
            for (int i = 0; i < detailList.Count; i++)
            {
                var serviceId = detailList[i].ServiceItemId;
                var IssueName = service.Find((x => x.ServiceItemId == serviceId)).IssueName;
                var ITId = detailList[i].CurrentITSupporter_Id;
                var ITName = it.Find((x => x.ITSupporterId == ITId)).ITSupporterName;
                listIssue.Add(IssueName);
                listIT.Add(ITName);
            }
            

            var timeAgo = TimeAgo(list.CreateDate.Value);
            var a = new TicketAPIViewModel()
            {
                TicketId = list.TicketId,
                TicketName = list.TicketName,
                CreateDate = timeAgo,
                AgencyName = list.Agency.AgencyName,
                //ITSupporterName = list.ITSupporter.ITSupporterName,
                //IssueName = IssueName.IssueName.ToString(),
                IssueName = listIssue,
                ITName = listIT,

            };
            rsList.Add(a);


            return rsList;
        }

        public static string TimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }

        public List<TicketAPIViewModel> GetAllTicketByAgencyIDAndStatus(Int32 acency_id, Int32 status)
        {
            List<TicketAPIViewModel> rsList = new List<TicketAPIViewModel>();
            var TicketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var companies = TicketRepo.GetActive().ToList();
            var listStatus = companies.FindAll(x => x.CurrentStatus == status && x.AgencyId == acency_id);
            foreach (var item in listStatus)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new TicketAPIViewModel()
                {
                    TicketId = item.TicketId,
                    TicketName = item.TicketName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }

        public bool CreateFeedbackForTicket(int ticketId, string feedbackContent)
        {
            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
                        
            var ticket = ticketRepo.Get(ticketId);

            if (ticket != null)
            {
                ticket.Feedback = feedbackContent;
                ticketRepo.Edit(ticket);
                ticketRepo.Save();

                return true;
            }
            return false;
        }
    }
}

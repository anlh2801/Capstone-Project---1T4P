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
    public partial interface IProblemService
    {
        List<ProblemAPIViewModel> GetAllProblem();

        List<ProblemAPIViewModel> GetTicketByProbleId(int problemId);

        List<ProblemAPIViewModel> GetProblemWithStatus(int status);

        List<ProblemAPIViewModel> GetAllProblemByAgencyIDAndStatus(int acency_id, int status);

        bool CreateFeedbackForProblem(int problemId, string feedbackContent);

        bool CancelProblem(ProblemCancelAPIViewModel model);

    }

    public partial class ProblemService
    {
        public List<ProblemAPIViewModel> GetAllProblem()
        {
            List<ProblemAPIViewModel> rsList = new List<ProblemAPIViewModel>();
            var ProblemRepo = DependencyUtils.Resolve<IProblemRepository>();
            var problems = ProblemRepo.GetActive().ToList();
            foreach (var item in problems)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new ProblemAPIViewModel()
                {
                    ProblemId = item.ProblemId,
                    ProblemName = item.ProblemtName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }


        public List<ProblemAPIViewModel> GetProblemWithStatus(int status)
        {
            List<ProblemAPIViewModel> rsList = new List<ProblemAPIViewModel>();
            var problemRepo = DependencyUtils.Resolve<IProblemRepository>();
            var problems = problemRepo.GetActive().ToList();
            var listStatus = problems.FindAll(x => x.ProblemStatus == status);
            foreach (var item in listStatus)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new ProblemAPIViewModel()
                {
                    ProblemId = item.ProblemId,
                    ProblemName = item.ProblemtName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }



        public List<ProblemAPIViewModel> GetTicketByProbleId(int problemId)
        {
            List<ProblemAPIViewModel> rsList = new List<ProblemAPIViewModel>();
            var problemRepo = DependencyUtils.Resolve<IProblemRepository>();
            var ticketRepo = DependencyUtils.Resolve<ITicketRepository>();
            var ServiceItemRepo = DependencyUtils.Resolve<IServiceItemRepository>();
            var ITRepo = DependencyUtils.Resolve<IITSupporterRepository>();

            var problem = problemRepo.GetActive().FirstOrDefault(x => x.ProblemId == problemId);            

            var service = ServiceItemRepo.GetActive().ToList();
            var it = ITRepo.GetActive().ToList();

            var tickets = ticketRepo.GetActive(x => x.ProblemId == problem.ProblemId).ToList();
            
            var listIssue = new List<String>();
            var listIT = new List<String>();
            for (int i = 0; i < tickets.Count; i++)
            {
                var serviceId = tickets[i].ServiceItemId;
                var IssueName = service.Find((x => x.ServiceItemId == serviceId)).IssueName;
                var ITId = tickets[i].CurrentITSupporter_Id;
                var ITName = it.Find((x => x.ITSupporterId == ITId)).ITSupporterName;
                listIssue.Add(IssueName);
                listIT.Add(ITName);
            }
            

            var timeAgo = TimeAgo(problem.CreateDate.Value);
            var a = new ProblemAPIViewModel()
            {
                ProblemId = problem.ProblemId,
                ProblemName = problem.ProblemtName,
                CreateDate = timeAgo,
                AgencyName = problem.Agency.AgencyName,
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

        public List<ProblemAPIViewModel> GetAllProblemByAgencyIDAndStatus(int acency_id, int status)
        {
            List<ProblemAPIViewModel> rsList = new List<ProblemAPIViewModel>();
            var problemRepo = DependencyUtils.Resolve<IProblemRepository>();
            var problems = problemRepo.GetActive().ToList();
            var listStatus = problems.FindAll(x => x.ProblemStatus == status && x.AgencyId == acency_id);
            foreach (var item in listStatus)
            {
                var timeAgo = TimeAgo(item.CreateDate.Value);
                var a = new ProblemAPIViewModel()
                {
                    ProblemId = item.ProblemId,
                    ProblemName = item.ProblemtName,
                    CreateDate = timeAgo,
                    //AgencyName = item.Agency.AgencyName,
                };
                rsList.Add(a);
            }

            return rsList;
        }

        public bool CreateFeedbackForProblem(int problemId, string feedbackContent)
        {
            var problemRepo = DependencyUtils.Resolve<IProblemRepository>();
                        
            var problem = problemRepo.Get(problemId);

            if (problem != null)
            {
                problem.Feedback = feedbackContent;
                problemRepo.Edit(problem);
                problemRepo.Save();

                return true;
            }
            return false;
        }

        public bool CancelProblem(ProblemCancelAPIViewModel model)
        {
            var problemRepo = DependencyUtils.Resolve<IProblemRepository>();
            var cancelTicket = problemRepo.GetActive().SingleOrDefault(a => a.ProblemId == model.ProblemId);
            if (cancelTicket.ProblemId == model.ProblemId)
            {

                cancelTicket.ProblemId = model.ProblemId;
                cancelTicket.ProblemStatus = model.CurrentStatus;

                problemRepo.Edit(cancelTicket);
                problemRepo.Save();
                return true;
            }

            return false;
        }
    }
}

using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public  interface ITicketDomain
    {
        List<ProblemAPIViewModel> GetAllProblem();

        List<ProblemAPIViewModel> GetTicketByProbleId(int problemId);

        List<ProblemAPIViewModel> GetProblemWithStatus(int status);

        List<ProblemAPIViewModel> GetAllProblemByAgencyIDAndStatus(int acency_id, int status);

        bool CreateFeedbackForProblem(FeedbackAPIViewModel feedback);

        bool CancelProblem(ProblemCancelAPIViewModel model);
    }

    public  class ProblemDomain : BaseDomain, ITicketDomain
    {
        public List<ProblemAPIViewModel> GetAllProblem()
        {
            var TicketList = new List<ProblemAPIViewModel>();            
            
            var TicketService = this.Service<IProblemService>();


            var companies = TicketService.GetAllProblem();
            
            return companies;
        }

        public List<ProblemAPIViewModel> GetProblemWithStatus(int status)
        {
            var TicketList = new List<ProblemAPIViewModel>();

            var TicketService = this.Service<IProblemService>();


            var companies = TicketService.GetProblemWithStatus(status);

            return companies;
        }

        public List<ProblemAPIViewModel> GetTicketByProbleId(int problemId)
        {
            var TicketListtt = new List<ProblemAPIViewModel>();

            var TicketService = this.Service<IProblemService>();


            var companies = TicketService.GetTicketByProbleId(problemId);

            return companies;
        }

        public List<ProblemAPIViewModel> GetAllProblemByAgencyIDAndStatus(int acency_id, int status)
        {
            var TicketService = this.Service<IProblemService>();
            
            var companies = TicketService.GetAllProblemByAgencyIDAndStatus(acency_id, status);

            return companies;

        }

        public bool CreateFeedbackForProblem(FeedbackAPIViewModel feedback)
        {          
            var TicketService = this.Service<IProblemService>();

            var rs = TicketService.CreateFeedbackForProblem(feedback.TicketId, feedback.FeedbackContent);

            return rs;

        }

        public bool CancelProblem(ProblemCancelAPIViewModel model)
        {
            var ticketService = this.Service<IProblemService>();

            var result = ticketService.CancelProblem(model);

            return result;
        }

    }
}

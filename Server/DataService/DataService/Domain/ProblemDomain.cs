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

        List<ProblemAPIViewModel> GetTicketByProblemId(int problemId);

        List<ProblemAPIViewModel> GetProblemWithStatus(int status);

        List<ProblemAPIViewModel> GetAllProblemByAgencyIDAndStatus(int acency_id, int status);

        bool CreateFeedbackForProblem(FeedbackAPIViewModel feedback);

        bool CancelProblem(ProblemCancelAPIViewModel model);
    }

    public  class ProblemDomain : BaseDomain, ITicketDomain
    {
        public List<ProblemAPIViewModel> GetAllProblem()
        {
            var problemService = this.Service<IProblemService>();

            var result = problemService.GetAllProblem();
            
            return result;
        }

        public List<ProblemAPIViewModel> GetProblemWithStatus(int status)
        {
            var problemService = this.Service<IProblemService>();
            
            var result = problemService.GetProblemWithStatus(status);

            return result;
        }

        public List<ProblemAPIViewModel> GetTicketByProblemId(int problemId)
        {
            var problemService = this.Service<IProblemService>();

            var result = problemService.GetTicketByProblemId(problemId);

            return result;
        }

        public List<ProblemAPIViewModel> GetAllProblemByAgencyIDAndStatus(int acency_id, int status)
        {
            var problemService = this.Service<IProblemService>();
            
            var result = problemService.GetAllProblemByAgencyIDAndStatus(acency_id, status);

            return result;

        }

        public bool CreateFeedbackForProblem(FeedbackAPIViewModel feedback)
        {          
            var problemService = this.Service<IProblemService>();

            var rs = problemService.CreateFeedbackForProblem(feedback.TicketId, feedback.FeedbackContent);

            return rs;

        }

        public bool CancelProblem(ProblemCancelAPIViewModel model)
        {
            var problemService = this.Service<IProblemService>();

            var result = problemService.CancelProblem(model);

            return result;
        }

    }
}

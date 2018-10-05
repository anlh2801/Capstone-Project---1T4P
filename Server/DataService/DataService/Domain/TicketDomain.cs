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
       
        List<TicketAPIViewModel> GetAllTicket();

        List<TicketAPIViewModel> GetTicketDetail(Int32 id);

        List<TicketAPIViewModel> GetTicketWithStatus(Int32 status);

        List<TicketAPIViewModel> GetAllTicketByAgencyIDAndStatus(Int32 acency_id, Int32 status);

        bool CreateFeedbackForTicket(FeedbackAPIViewModel feedback);

        bool CancelTicket(TicketCancelAPIViewModel model);
    }

    public  class TicketDomain : BaseDomain, ITicketDomain
    {
        public List<TicketAPIViewModel> GetAllTicket()
        {
            var TicketList = new List<TicketAPIViewModel>();            
            
            var TicketService = this.Service<ITicketService>();


            var companies = TicketService.GetAllTicket();
            
            return companies;
        }

        public List<TicketAPIViewModel> GetTicketWithStatus(Int32 status)
        {
            var TicketList = new List<TicketAPIViewModel>();

            var TicketService = this.Service<ITicketService>();


            var companies = TicketService.GetTicketWithStatus(status);

            return companies;
        }

        public List<TicketAPIViewModel> GetTicketDetail(Int32 id)
        {
            var TicketListtt = new List<TicketAPIViewModel>();

            var TicketService = this.Service<ITicketService>();


            var companies = TicketService.GetTicketDetail(id);

            return companies;
        }

        public List<TicketAPIViewModel> GetAllTicketByAgencyIDAndStatus(Int32 acency_id, Int32 status)
        {
            var TicketService = this.Service<ITicketService>();
            
            var companies = TicketService.GetAllTicketByAgencyIDAndStatus(acency_id, status);

            return companies;

        }

        public bool CreateFeedbackForTicket(FeedbackAPIViewModel feedback)
        {          
            var TicketService = this.Service<ITicketService>();

            var rs = TicketService.CreateFeedbackForTicket(feedback.TicketId, feedback.FeedbackContent);

            return rs;

        }

        public bool CancelTicket(TicketCancelAPIViewModel model)
        {
            var ticketService = this.Service<ITicketService>();

            var result = ticketService.CancelTicket(model);

            return result;
        }

    }
}

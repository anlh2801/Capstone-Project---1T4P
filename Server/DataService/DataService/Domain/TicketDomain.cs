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

        public List<TicketAPIViewModel> GetTicketDetail(Int32 id)
        {
            var TicketListtt = new List<TicketAPIViewModel>();

            var TicketService = this.Service<ITicketService>();


            var companies = TicketService.GetTicketDetail(id);

            return companies;
        }


    }
}

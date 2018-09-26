using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject_ODTS.Repository;
using CapstoneProject_ODTS.Repository.Repository;

namespace CapstoneProject_ODTS.Service.Services
{
    public class TicketService
    {
        TicketRepository _ticketRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
        }

        public List<Ticket> getAll()
        {
            return _ticketRepository.List.ToList();
        }

        public Ticket findByID(int id)
        {
            if (id < 0)
            {
                return null;
            }
            Ticket ticket = _ticketRepository.FindById(id);
            return ticket;
        }

        public void add(Ticket s)
        {
            _ticketRepository.Add(s);
        }

        public void update(Ticket s)
        {
            _ticketRepository.Update(s);
        }

        public void delete(Ticket s)
        {
            _ticketRepository.Delete(s);
        }

        public List<Ticket> GetTickets()
        {
            return _TicketRepository.GetAll();
        }
    }
}

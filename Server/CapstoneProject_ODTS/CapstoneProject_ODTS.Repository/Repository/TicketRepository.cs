using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_ODTS.Repository.Repository
{
    public interface ITicketRepository
    {

    }
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {

    }
}
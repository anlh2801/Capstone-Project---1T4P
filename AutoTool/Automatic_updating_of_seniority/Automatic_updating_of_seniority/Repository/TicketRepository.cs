using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Repository
{
    public interface ITicketRepository
    {

    }
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {

    }
}

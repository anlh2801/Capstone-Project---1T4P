using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class TicketService
    {
        TicketRepository _ticketRepository;

        public TicketService()
        {
            _ticketRepository = new TicketRepository();
        }

        public List<Ticket> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Ticket>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Ticket s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

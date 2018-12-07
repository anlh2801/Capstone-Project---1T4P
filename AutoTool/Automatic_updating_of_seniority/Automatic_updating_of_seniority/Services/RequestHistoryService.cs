using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class RequestHistoryService
    {
        RequestHistoryRepository _requestHistoryRepository;

        public RequestHistoryService()
        {
            _requestHistoryRepository = new RequestHistoryRepository();
        }

        public List<RequestHistory> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<RequestHistory>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(RequestHistory s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void Add(RequestHistory s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();

            }
        }
    }
}

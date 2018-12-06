using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class AgencyService
    {
        AgencyRepository _skillRepository;

        public AgencyService()
        {
            _skillRepository = new AgencyRepository();
        }

        public List<Agency> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Agency>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Agency s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

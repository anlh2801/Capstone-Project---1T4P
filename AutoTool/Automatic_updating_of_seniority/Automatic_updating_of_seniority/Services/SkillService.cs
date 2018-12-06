using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class SkillService
    {
        SkillRepository _skillRepository;

        public SkillService()
        {
            _skillRepository = new SkillRepository();
        }

        public List<Skill> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Skill>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Skill s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

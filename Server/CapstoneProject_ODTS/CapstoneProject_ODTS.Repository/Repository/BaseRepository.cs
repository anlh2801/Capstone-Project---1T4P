using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_ODTS.Repository.Repository
{
    public class BaseRepository<T>:  IRepository<T> where T : class
    {
        public IEnumerable<T> List => throw new NotImplementedException();

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new ODTS_DBEntities())
            {
                var entity = db.Set<T>().Find(id);
                if (entity != null)
                {
                    db.Set<T>().Remove(entity);
                }

                db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<T>().Find(id);

            }
        }

        public List<T> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<T>().ToList();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

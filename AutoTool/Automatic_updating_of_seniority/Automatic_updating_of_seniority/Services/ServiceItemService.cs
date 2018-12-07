using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class ServiceItemService
    {
        ServiceItemRepository _serviceItemRepository;

        public ServiceItemService()
        {
            _serviceItemRepository = new ServiceItemRepository();
        }

        public List<ServiceItem> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<ServiceItem>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(ServiceItem s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

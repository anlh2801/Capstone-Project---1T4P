using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class DeviceService
    {
        DeviceRepository _deviceRepository;

        public DeviceService()
        {
            _deviceRepository = new DeviceRepository();
        }

        public List<Device> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Device>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Device s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

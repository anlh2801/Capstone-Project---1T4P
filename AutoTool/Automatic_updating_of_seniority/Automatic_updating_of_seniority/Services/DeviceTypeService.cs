using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class DeviceTypeService
    {
        DeviceTypeRepository _deviceTypeRepository;

        public DeviceTypeService()
        {
            _deviceTypeRepository = new DeviceTypeRepository();
        }

        public List<DeviceType> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<DeviceType>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(DeviceType s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

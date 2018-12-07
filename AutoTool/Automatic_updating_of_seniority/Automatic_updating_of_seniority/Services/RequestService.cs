﻿using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    class RequestService
    {
        RequestRepository _requestRepository;

        public RequestService()
        {
            _requestRepository = new RequestRepository();
        }

        public List<Request> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Request>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Request s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

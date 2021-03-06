﻿using Automatic_updating_of_seniority.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_updating_of_seniority.Services
{
    public class CompanyService
    {
        CompanyRepository _companyRepository;

        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }

        public List<Company> GetAll()
        {
            using (var db = new ODTS_DBEntities())
            {
                return db.Set<Company>().Where(p => p.IsDelete == false).ToList();
            }
        }

        public void Update(Company s)
        {
            using (var db = new ODTS_DBEntities())
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
        }
    }
}

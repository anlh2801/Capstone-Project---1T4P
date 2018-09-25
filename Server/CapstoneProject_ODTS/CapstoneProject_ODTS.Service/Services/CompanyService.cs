using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject_ODTS.Repository;
using CapstoneProject_ODTS.Repository.Repository;

namespace CapstoneProject_ODTS.Service.Services
{
    public class CompanyService
    {
        CompanyRepository _companyRepository;

        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }

        public List<Company> getAll()
        {
            return _companyRepository.List.ToList();
        }

        public Company findByID(int id)
        {
            if (id < 0)
            {
                return null;
            }
            Company company = _companyRepository.FindById(id);
            return company;
        }

        public void add(Company s)
        {
            _companyRepository.Add(s);
        }

        public void update(Company s)
        {
            _companyRepository.Update(s);
        }

        public void delete(Company s)
        {
            _companyRepository.Delete(s);
        }

        public List<Company> GetCompanies()
        {
            return _companyRepository.GetAll();
        }
    }
}

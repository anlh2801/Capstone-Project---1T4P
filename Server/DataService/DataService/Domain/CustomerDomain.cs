using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface ICustomerDomain
    {
        CustomerAPIViewModel GetCustomerById(int id);
    }
    public class CustomerDomain : BaseDomain, ICustomerDomain
    {
        public CustomerAPIViewModel GetCustomerById(int id)
        {
            var customerService = this.Service<ICustomerService>();
           return customerService.GetCustomerById(id);
        }
    }
}

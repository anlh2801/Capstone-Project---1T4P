using DataService.APIViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface ICustomerService
    {
        CustomerAPIViewModel GetCustomerById(int id);
    }
    public partial class CustomerService
    {
        public CustomerAPIViewModel GetCustomerById(int id)
        {
            var customer = Repository.FirstOrDefaultActive(c => c.CustomerID == id);
            return new CustomerAPIViewModel(customer);

        }
    }
}

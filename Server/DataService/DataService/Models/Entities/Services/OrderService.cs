using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IOrderService
    {
        void SaveOrder(Order order);
    }

    public partial class OrderService : IOrderService
    {
        public void SaveOrder(Order order)
        {
            this.Create(order);
        }
    }
}

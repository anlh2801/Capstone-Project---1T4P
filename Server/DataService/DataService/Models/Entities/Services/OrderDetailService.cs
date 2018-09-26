using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IOrderDetailService
    {
        void SaveOrderDetail(OrderDetail orderDetail);
    }

    public partial class OrderDetailService : IOrderDetailService
    {
        public void SaveOrderDetail(OrderDetail orderDetail)
        {
            this.Create(orderDetail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models
{    
    //For agency view
    public enum RequestStatusEnum
    {
        [Display(Name ="Chờ Xử lý")]
        Pending = 1,
        [Display(Name = "Đang xử lý")]
        Processing = 2,
        [Display(Name = "Hoàn thành")]
        Done = 3,
        [Display(Name = "Hủy bỏ")]
        Cancel = 4
    }

    //For ITSupporter View
    public enum TicketStatusEnum
    {
        [Display(Name = "Mới")]
        New = 1,
        [Display(Name = "Xác nhận")]
        Approve = 2,
        [Display(Name = "Đang xử lý")]
        In_Process = 3,
        [Display(Name = "Hoàn thành")]
        Done = 4,
        [Display(Name = "Hủy bỏ")]
        Cancel = 5
    }

}


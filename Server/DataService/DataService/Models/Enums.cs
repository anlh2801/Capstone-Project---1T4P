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
        [Display(Name = "Tạo mới")]
        New = 1,
        [Display(Name = "Chờ xử lý")]
        Pending = 2,
        [Display(Name = "Đang xử lý")]
        Processing = 3,
        [Display(Name = "Hoàn thành")]
        Done = 4,
        [Display(Name = "Chờ hủy")]
        WaitingCancel = 5,
        [Display(Name = "Hủy bỏ")]
        Cancel = 6
    }

    //For ITSupporter View
    public enum RequestDoingStatus
    {
        [Display(Name = "Đã nhận")]
        Received = 1,
        [Display(Name = "Đang di chuyển")]
        Moving = 2,
        [Display(Name = "Đang sửa chữa")]
        Fixing = 3,
        [Display(Name = "Đợi linh kiện")]
        Holding = 4,
        [Display(Name = "Hoàn thành")]
        Done = 5
    }

    public enum TicketStatusEnum
    {
        [Display(Name = "Đang chờ xử lý")]
        Await = 1,
        [Display(Name = "Đang xử lý")]
        In_Process = 2,
        [Display(Name = "Hoàn thành")]
        Done = 3,
        [Display(Name = "Hủy bỏ")]
        Cancel = 4
    }

    public enum RequestTaskEnum
    {       
        [Display(Name = "Đang xử lý")]
        In_Process = 1,
        [Display(Name = "Hoàn thành")]
        Done = 2,
    }

    public enum Gender
    {
        [Display(Name = "Nam")]
        Male = 1,
        [Display(Name = "Nữ")]
        Female = 2,
        [Display(Name = "Khác")]
        Others = 3
    }

}


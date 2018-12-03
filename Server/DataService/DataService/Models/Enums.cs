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
        [Display(Name = "Chờ nhân viên xử lý")]
        Pending = 1,
        [Display(Name = "Đang xử lý")]
        Processing = 2,
        [Display(Name = "Hoàn thành")]
        Done = 3,
        [Display(Name = "Hủy bỏ")]
        Cancel = 4,
        [Display(Name = "Tạo mới")]
        New = 5,
        [Display(Name = "Chờ hủy")]
        WaitingCancel = 6,
        [Display(Name = "Chờ xác nhận hoàn thành")]
        WaitingDone = 7
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

    public enum RequestPriorityEnum
    {
        [Display(Name = "Cao")]
        Urgent = 1,
        [Display(Name = "Trung bình")]
        Normal = 2,
        [Display(Name = "Thấp")]
        Non_Urgent = 3,
    }

}


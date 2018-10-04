using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models
{    
    public enum NotificationsTypeEnum
    {
        [Display(Name ="Thông báo")]
        Notify = 1,
        [Display(Name = "Tin tức")]
        News = 2,
        [Display(Name = "Khuyến mãi")]
        Promotion = 3,
    }
}


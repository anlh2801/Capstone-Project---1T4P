//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Automatic_updating_of_seniority
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int RequestId { get; set; }
        public int DeviceId { get; set; }
        public string Desciption { get; set; }
        public bool IsDelete { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual Request Request { get; set; }
    }
}

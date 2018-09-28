//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketHistory
    {
        public int TicketHistoryId { get; set; }
        public Nullable<int> TicketId { get; set; }
        public Nullable<int> PreItSupporterId { get; set; }
        public Nullable<int> PreStatus { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual ITSupporter ITSupporter { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}

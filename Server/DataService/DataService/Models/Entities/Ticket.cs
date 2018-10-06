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
    
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            this.TicketHistories = new HashSet<TicketHistory>();
            this.TicketTasks = new HashSet<TicketTask>();
        }
    
        public int TicketId { get; set; }
        public int ServiceItemId { get; set; }
        public int ProblemId { get; set; }
        public int DeviceId { get; set; }
        public string Desciption { get; set; }
        public Nullable<int> Current_TicketStatus { get; set; }
        public int CurrentITSupporter_Id { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<double> Estimation { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> Endtime { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual ITSupporter ITSupporter { get; set; }
        public virtual Problem Problem { get; set; }
        public virtual ServiceItem ServiceItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketTask> TicketTasks { get; set; }
    }
}

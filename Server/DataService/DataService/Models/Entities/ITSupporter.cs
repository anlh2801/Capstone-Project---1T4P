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
    
    public partial class ITSupporter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITSupporter()
        {
            this.Requests = new HashSet<Request>();
            this.Skills = new HashSet<Skill>();
            this.TicketHistories = new HashSet<TicketHistory>();
        }
    
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int AccountId { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Address { get; set; }
        public Nullable<double> RatingAVG { get; set; }
        public Nullable<bool> IsBusy { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
    }
}

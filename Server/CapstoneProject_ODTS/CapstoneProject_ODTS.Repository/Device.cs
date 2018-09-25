//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapstoneProject_ODTS.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            this.TicketDetails = new HashSet<TicketDetail>();
        }
    
        public int DeviceId { get; set; }
        public int AgencyId { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceCode { get; set; }
        public Nullable<System.DateTime> GuarantyStartDate { get; set; }
        public Nullable<System.DateTime> GuarantyEndDate { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string DeviceAccount { get; set; }
        public string DevicePassword { get; set; }
        public Nullable<System.DateTime> SettingDate { get; set; }
        public string Other { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual Agency Agency { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketDetail> TicketDetails { get; set; }
    }
}

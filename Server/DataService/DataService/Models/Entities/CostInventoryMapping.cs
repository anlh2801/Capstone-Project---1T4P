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
    
    public partial class CostInventoryMapping
    {
        public int CostID { get; set; }
        public int ReceiptID { get; set; }
        public Nullable<int> StoreId { get; set; }
        public Nullable<int> ProviderID { get; set; }
    
        public virtual Cost Cost { get; set; }
        public virtual InventoryReceipt InventoryReceipt { get; set; }
    }
}

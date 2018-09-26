//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventoryReceiptViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.InventoryReceipt>
    {
    	
    			public virtual int ReceiptID { get; set; }
    			public virtual System.DateTime ChangeDate { get; set; }
    			public virtual int ReceiptType { get; set; }
    			public virtual int Status { get; set; }
    			public virtual string Notes { get; set; }
    			public virtual string Name { get; set; }
    			public virtual string Creator { get; set; }
    			public virtual Nullable<int> StoreId { get; set; }
    			public virtual Nullable<int> InStoreId { get; set; }
    			public virtual Nullable<int> OutStoreId { get; set; }
    			public virtual Nullable<int> ProviderId { get; set; }
    			public virtual Nullable<System.DateTime> CreateDate { get; set; }
    			public virtual string InvoiceNumber { get; set; }
    			public virtual Nullable<double> Amount { get; set; }
    	
    	public InventoryReceiptViewModel() : base() { }
    	public InventoryReceiptViewModel(DataService.Models.Entities.InventoryReceipt entity) : base(entity) { }
    
    }
}

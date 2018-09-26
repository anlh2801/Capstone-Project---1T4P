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
    
    public partial class AccountViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Account>
    {
    	
    			public virtual int AccountID { get; set; }
    			public virtual string AccountCode { get; set; }
    			public virtual string AccountName { get; set; }
    			public virtual short Level_ { get; set; }
    			public virtual Nullable<System.DateTime> StartDate { get; set; }
    			public virtual Nullable<System.DateTime> FinishDate { get; set; }
    			public virtual Nullable<decimal> Balance { get; set; }
    			public virtual string ProductCode { get; set; }
    			public virtual Nullable<int> MembershipCardId { get; set; }
    			public virtual Nullable<int> Type { get; set; }
    			public virtual Nullable<int> BrandId { get; set; }
    			public virtual Nullable<bool> Active { get; set; }
    			public virtual Nullable<int> CustomerId { get; set; }
    	
    	public AccountViewModel() : base() { }
    	public AccountViewModel(DataService.Models.Entities.Account entity) : base(entity) { }
    
    }
}

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
    
    public partial class ITSupporterViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ITSupporter>
    {
    	
    			public virtual int ITSupporterId { get; set; }
    			public virtual string ITSupporterName { get; set; }
    			public virtual int AccountId { get; set; }
    			public virtual string Telephone { get; set; }
    			public virtual string Email { get; set; }
    			public virtual Nullable<int> Gender { get; set; }
    			public virtual string Address { get; set; }
    			public virtual Nullable<double> RatingAVG { get; set; }
    			public virtual Nullable<bool> IsBusy { get; set; }
    			public virtual Nullable<bool> IsOnline { get; set; }
    			public virtual Nullable<bool> IsDelete { get; set; }
    			public virtual System.DateTime CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    	
    	public ITSupporterViewModel() : base() { }
    	public ITSupporterViewModel(DataService.Models.Entities.ITSupporter entity) : base(entity) { }
    
    }
}

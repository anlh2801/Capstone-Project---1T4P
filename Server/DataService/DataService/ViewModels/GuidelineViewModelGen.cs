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
    
    public partial class GuidelineViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Guideline>
    {
    	
    			public virtual int GuidelineId { get; set; }
    			public virtual Nullable<int> ServiceItemId { get; set; }
    			public virtual string GuidelineName { get; set; }
    			public virtual Nullable<System.DateTime> StartDate { get; set; }
    			public virtual Nullable<System.DateTime> EndDate { get; set; }
    			public virtual Nullable<bool> IsDelete { get; set; }
    			public virtual Nullable<System.DateTime> CreatedAt { get; set; }
    			public virtual Nullable<System.DateTime> UpdatedAt { get; set; }
    	
    	public GuidelineViewModel() : base() { }
    	public GuidelineViewModel(DataService.Models.Entities.Guideline entity) : base(entity) { }
    
    }
}
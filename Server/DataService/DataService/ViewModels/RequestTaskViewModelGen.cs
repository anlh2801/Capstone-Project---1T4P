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
    
    public partial class RequestTaskViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.RequestTask>
    {
    	
    			public virtual int RequestTaskId { get; set; }
    			public virtual int RequestId { get; set; }
    			public virtual string TaskDetails { get; set; }
    			public virtual Nullable<int> TaskStatus { get; set; }
    			public virtual Nullable<int> CreateByITSupporter { get; set; }
    			public virtual Nullable<System.DateTime> StartTime { get; set; }
    			public virtual Nullable<System.DateTime> EndTime { get; set; }
    			public virtual Nullable<int> Priority { get; set; }
    			public virtual Nullable<int> PreTaskCondition { get; set; }
    			public virtual bool IsDelete { get; set; }
    			public virtual System.DateTime CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    	
    	public RequestTaskViewModel() : base() { }
    	public RequestTaskViewModel(DataService.Models.Entities.RequestTask entity) : base(entity) { }
    
    }
}
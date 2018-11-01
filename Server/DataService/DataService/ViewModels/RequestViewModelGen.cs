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
    
    public partial class RequestViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Request>
    {
    	
    			public virtual int RequestId { get; set; }
    			public virtual int AgencyId { get; set; }
    			public virtual int ServiceItemId { get; set; }
    			public virtual string RequestDesciption { get; set; }
    			public virtual int RequestCategoryId { get; set; }
    			public virtual int RequestStatus { get; set; }
    			public virtual string RequestName { get; set; }
    			public virtual Nullable<double> Estimation { get; set; }
    			public virtual Nullable<System.DateTime> StartTime { get; set; }
    			public virtual Nullable<System.DateTime> EndTime { get; set; }
    			public virtual Nullable<int> CurrentITSupporter_Id { get; set; }
    			public virtual Nullable<int> Rating { get; set; }
    			public virtual string Feedback { get; set; }
    			public virtual bool IsDelete { get; set; }
    			public virtual System.DateTime CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    	
    	public RequestViewModel() : base() { }
    	public RequestViewModel(DataService.Models.Entities.Request entity) : base(entity) { }
    
    }
}

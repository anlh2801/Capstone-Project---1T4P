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
    
    public partial class TicketHistoryViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.TicketHistory>
    {
    	
    			public virtual int TicketHistoryId { get; set; }
    			public virtual int TicketId { get; set; }
    			public virtual Nullable<int> PreItSupporterId { get; set; }
    			public virtual Nullable<int> PreStatus { get; set; }
    			public virtual Nullable<System.DateTime> StartDate { get; set; }
    			public virtual Nullable<System.DateTime> EndDate { get; set; }
    			public virtual Nullable<bool> IsDelete { get; set; }
    			public virtual Nullable<System.DateTime> CreatedAt { get; set; }
    			public virtual Nullable<System.DateTime> UpdatedAt { get; set; }
    	
    	public TicketHistoryViewModel() : base() { }
    	public TicketHistoryViewModel(DataService.Models.Entities.TicketHistory entity) : base(entity) { }
    
    }
}

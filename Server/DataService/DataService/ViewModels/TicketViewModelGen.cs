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
    
    public partial class TicketViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
    	
    			public virtual int TicketId { get; set; }
    			public virtual int RequestId { get; set; }
    			public virtual int DeviceId { get; set; }
    			public virtual string Desciption { get; set; }
    			public virtual bool IsDelete { get; set; }
    			public virtual System.DateTime CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    			public virtual string CreateBy { get; set; }
    	
    	public TicketViewModel() : base() { }
    	public TicketViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }
    
    }
}

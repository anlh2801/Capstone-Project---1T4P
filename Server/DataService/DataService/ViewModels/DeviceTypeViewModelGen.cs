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
    
    public partial class DeviceTypeViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.DeviceType>
    {
    	
    			public virtual int DeviceTypeId { get; set; }
    			public virtual string DeviceTypeName { get; set; }
    			public virtual string Description { get; set; }
    			public virtual bool IsDelete { get; set; }
    			public virtual Nullable<System.DateTime> CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    	
    	public DeviceTypeViewModel() : base() { }
    	public DeviceTypeViewModel(DataService.Models.Entities.DeviceType entity) : base(entity) { }
    
    }
}
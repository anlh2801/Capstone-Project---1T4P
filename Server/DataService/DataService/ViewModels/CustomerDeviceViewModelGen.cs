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
    
    public partial class CustomerDeviceViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.CustomerDevice>
    {
    	
    			public virtual int Id { get; set; }
    			public virtual int CustomerId { get; set; }
    			public virtual string FCMToken { get; set; }
    			public virtual Nullable<int> DeviceType { get; set; }
    	
    	public CustomerDeviceViewModel() : base() { }
    	public CustomerDeviceViewModel(DataService.Models.Entities.CustomerDevice entity) : base(entity) { }
    
    }
}

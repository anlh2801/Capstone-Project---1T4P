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
    
    public partial class RoomCategoryViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.RoomCategory>
    {
    	
    			public virtual int CategoryID { get; set; }
    			public virtual string CategoryName { get; set; }
    			public virtual string IconUrl { get; set; }
    			public virtual string ShortNane { get; set; }
    			public virtual int Priority { get; set; }
    			public virtual Nullable<int> StoreID { get; set; }
    			public virtual Nullable<bool> IsDelete { get; set; }
    	
    	public RoomCategoryViewModel() : base() { }
    	public RoomCategoryViewModel(DataService.Models.Entities.RoomCategory entity) : base(entity) { }
    
    }
}

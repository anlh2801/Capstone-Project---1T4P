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
    
    public partial class ProductComboDetailViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ProductComboDetail>
    {
    	
    			public virtual int ComboID { get; set; }
    			public virtual int ProductID { get; set; }
    			public virtual int Quantity { get; set; }
    			public virtual int Position { get; set; }
    			public virtual bool Active { get; set; }
    	
    	public ProductComboDetailViewModel() : base() { }
    	public ProductComboDetailViewModel(DataService.Models.Entities.ProductComboDetail entity) : base(entity) { }
    
    }
}

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
    
    public partial class AgencyViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Agency>
    {
    	
    			public virtual int AgencyId { get; set; }
    			public virtual int CompanyId { get; set; }
    			public virtual int AccountId { get; set; }
    			public virtual string AgencyName { get; set; }
    			public virtual string Address { get; set; }
    			public virtual string Telephone { get; set; }
    			public virtual bool IsDelete { get; set; }
    			public virtual System.DateTime CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    	
    	public AgencyViewModel() : base() { }
    	public AgencyViewModel(DataService.Models.Entities.Agency entity) : base(entity) { }
    
    }
}

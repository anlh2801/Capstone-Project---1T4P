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
    
    public partial class ContractServiceITSupportViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ContractServiceITSupport>
    {
    	
    			public virtual int ContractServiceITSupportId { get; set; }
    			public virtual int ContractId { get; set; }
    			public virtual Nullable<int> ServiceITSupportId { get; set; }
    			public virtual Nullable<System.DateTime> StartDate { get; set; }
    			public virtual Nullable<System.DateTime> EndDate { get; set; }
    			public virtual Nullable<bool> IsDelete { get; set; }
    			public virtual Nullable<System.DateTime> CreateDate { get; set; }
    			public virtual Nullable<System.DateTime> UpdateDate { get; set; }
    	
    	public ContractServiceITSupportViewModel() : base() { }
    	public ContractServiceITSupportViewModel(DataService.Models.Entities.ContractServiceITSupport entity) : base(entity) { }
    
    }
}

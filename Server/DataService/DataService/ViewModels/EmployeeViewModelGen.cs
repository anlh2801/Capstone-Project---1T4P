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
    
    public partial class EmployeeViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Employee>
    {
    	
    			public virtual int Id { get; set; }
    			public virtual string Name { get; set; }
    			public virtual Nullable<int> Role { get; set; }
    			public virtual string EmpEnrollNumber { get; set; }
    			public virtual int MainStoreId { get; set; }
    			public virtual string Address { get; set; }
    			public virtual string Phone { get; set; }
    			public virtual bool Active { get; set; }
    			public virtual int BrandId { get; set; }
    			public virtual Nullable<decimal> Salary { get; set; }
    			public virtual int Status { get; set; }
    			public virtual Nullable<System.DateTime> DateStartWork { get; set; }
    			public virtual Nullable<int> EmployeeGroupId { get; set; }
    			public virtual string EmployeeCode { get; set; }
    			public virtual string EmployeeRegency { get; set; }
    			public virtual Nullable<System.DateTime> DateOfBirth { get; set; }
    			public virtual Nullable<int> EmployeeSex { get; set; }
    			public virtual string PersonalCardId { get; set; }
    			public virtual Nullable<System.DateTime> DatePersonalCard { get; set; }
    			public virtual string PlaceOfPersonalCard { get; set; }
    			public virtual string PhoneNumber { get; set; }
    			public virtual string Email { get; set; }
    			public virtual string MainAddress { get; set; }
    			public virtual string EmployeeHometown { get; set; }
    			public virtual string EmployeePlaceBorn { get; set; }
    	
    	public EmployeeViewModel() : base() { }
    	public EmployeeViewModel(DataService.Models.Entities.Employee entity) : base(entity) { }
    
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService.Models.Entities.Services
{
    using System;
    using System.Collections.Generic;
    using DataService.ViewModels;
    
    public partial interface ICustomerService : DataService.BaseConnect.IBaseService<Customer, CustomerViewModel>
    {
    }
    
    public partial class CustomerService : DataService.BaseConnect.BaseService<Customer, CustomerViewModel>, ICustomerService
    {
         public CustomerService()
         {
         }
        public CustomerService(DataService.BaseConnect.IUnitOfWork unitOfWork, Repositories.ICustomerRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}

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
    
    public partial interface ICompanyService : DataService.BaseConnect.IBaseService<Company, CompanyViewModel>
    {
    }
    
    public partial class CompanyService : DataService.BaseConnect.BaseService<Company, CompanyViewModel>, ICompanyService
    {
         public CompanyService()
         {
         }
        public CompanyService(DataService.BaseConnect.IUnitOfWork unitOfWork, Repositories.ICompanyRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}

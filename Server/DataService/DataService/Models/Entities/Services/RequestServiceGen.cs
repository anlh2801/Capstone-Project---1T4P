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
    
    public partial interface IRequestService : DataService.BaseConnect.IBaseService<Request, RequestViewModel>
    {
    }
    
    public partial class RequestService : DataService.BaseConnect.BaseService<Request, RequestViewModel>, IRequestService
    {
         public RequestService()
         {
         }
        public RequestService(DataService.BaseConnect.IUnitOfWork unitOfWork, Repositories.IRequestRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}
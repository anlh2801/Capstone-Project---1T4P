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
    
    public partial interface IPosService : DataService.BaseConnect.IBaseService<Pos, PosViewModel>
    {
    }
    
    public partial class PosService : DataService.BaseConnect.BaseService<Pos, PosViewModel>, IPosService
    {
         public PosService()
         {
         }
        public PosService(DataService.BaseConnect.IUnitOfWork unitOfWork, Repositories.IPosRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}

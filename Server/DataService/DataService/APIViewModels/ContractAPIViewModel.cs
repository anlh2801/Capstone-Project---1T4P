﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ContractAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Contract>
    {
        public ContractAPIViewModel() : base() { }
        public ContractAPIViewModel(DataService.Models.Entities.Contract entity) : base(entity) { }

        public int ContractId { get; set; }
        public int CompanyId { get; set; }
        public string ContractName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedAt { get; set; }
        public string UpdateAt { get; set; }
    }
}
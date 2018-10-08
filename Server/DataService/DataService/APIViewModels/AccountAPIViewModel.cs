using DataService.Models.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AccountAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Account>
    {
        public AccountAPIViewModel() : base() { }
        public AccountAPIViewModel(DataService.Models.Entities.Account entity) : base(entity) { }

        public int NumericalOrder { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsDelete { get; set; }
        public string CreateAt { get; set; }
        public string UpdateAt { get; set; }
    }
}

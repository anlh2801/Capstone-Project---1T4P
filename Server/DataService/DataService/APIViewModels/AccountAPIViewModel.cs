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

        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Passwrod { get; set; }
    }
}

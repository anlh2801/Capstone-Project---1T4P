using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class RoleAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Role>
    {
        public RoleAPIViewModel() : base() { }
        public RoleAPIViewModel(DataService.Models.Entities.Role entity) : base(entity) { }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsDelete { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}

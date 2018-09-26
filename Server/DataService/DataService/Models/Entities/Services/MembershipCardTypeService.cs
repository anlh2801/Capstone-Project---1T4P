using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IMembershipCardTypeService
    {
        MembershipCardTypeViewModel GetMembershipCardTypeById(int Id);
    }
    public partial class MembershipCardTypeService
    {
        public MembershipCardTypeViewModel GetMembershipCardTypeById(int Id)
        {
            var mbsCardType = Repository.FirstOrDefaultActive(m => m.Id == Id);
            return new MembershipCardTypeViewModel(mbsCardType);
        }
    }
}

using DataService.Models.Entities.Services;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IMembershipCardTypeDomain
    {
        MembershipCardTypeViewModel GetMembershipCardTypeById(int Id);
        
    }
    public class MembershipCardTypeDomain : BaseDomain,IMembershipCardTypeDomain
    {
        public MembershipCardTypeViewModel GetMembershipCardTypeById(int Id)
        {
            var cardTypeService = this.Service<IMembershipCardTypeService>();
            return cardTypeService.GetMembershipCardTypeById(Id);
        }
    }
}

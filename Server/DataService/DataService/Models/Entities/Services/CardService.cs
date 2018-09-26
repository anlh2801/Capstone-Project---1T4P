using AutoMapper.QueryableExtensions;
using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface ICardService
    {
        CardAPIViewModel GetCardByCardCode(string CardCode);
    }

    public partial class CardService
    {
        public CardAPIViewModel GetCardByCardCode(string CardCode)
        {
            var cardRepo = DependencyUtils.Resolve<ICardRepository>();
            var card = cardRepo.FirstOrDefaultActive(c => c.CardCode == CardCode);
            if( card != null)
            {
                var cardVM = new CardAPIViewModel(card)
                {
                    MembershipCardVM = new MembershipCardAPIViewModel(card.MembershipCard),
                    MembershipCardTypeVM = new MembershipCardTypeAPIViewModel(card.MembershipCard.MembershipCardType),
                    ListAccountVM = card.MembershipCard.Accounts.AsQueryable().ProjectTo<AccountAPIViewModel>(this.AutoMapperConfig).ToList(),
                    CustomerVM = new CustomerAPIViewModel(card.MembershipCard.Customer)
                };
                return cardVM;
            }
            
            return new CardAPIViewModel();
        }


    }
}

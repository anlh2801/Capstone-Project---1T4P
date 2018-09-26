using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface ICardDomain
    {
        CardAPIViewModel GetCardByCardCode(string CardCode);
    }
    public class CardDomain : BaseDomain, ICardDomain
    {
        public CardAPIViewModel GetCardByCardCode(string CardCode)
        {
            var cardService = this.Service<ICardService>();

           return cardService.GetCardByCardCode(CardCode);
        }
    }
}

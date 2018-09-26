using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class CardAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Card>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("id_card_type")]
        public int IdCardType { get; set; }
        [JsonProperty("card_code")]
        public string CardCode { get; set; }
        [JsonProperty("create_tiem")]
        public System.DateTime CreatedTime { get; set; }
        [JsonProperty("expiry_date")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        [JsonProperty("brand_id")]
        public int BrandId { get; set; }
        [JsonProperty("membership_id")]
        public int MembershipId { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("create_by")]
        public string CreateBy { get; set; }
        [JsonProperty("is_mobile")]
        public Nullable<bool> IsMobile { get; set; }
        [JsonProperty("brand")]
        public  BrandAPIViewModel BrandVM { get; set; }
        [JsonProperty("membership_card")]
        public MembershipCardAPIViewModel MembershipCardVM { get; set; }
        [JsonProperty("membership_card_type")]
        public MembershipCardTypeAPIViewModel MembershipCardTypeVM { get; set; }
        [JsonProperty("account")]
        public List<AccountAPIViewModel> ListAccountVM { get; set; }
        [JsonProperty("customer")]
        public CustomerAPIViewModel CustomerVM { get; set; }
        public CardAPIViewModel() : base() { }
        public CardAPIViewModel(DataService.Models.Entities.Card entity) : base(entity) { }
    }
}

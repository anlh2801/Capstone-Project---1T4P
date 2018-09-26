using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AccountAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Account>
    {
        [JsonProperty("account_id")]
        public int AccountID { get; set; }
        [JsonProperty("account_code")]
        public string AccountCode { get; set; }
        [JsonProperty("account_name")]
        public string AccountName { get; set; }
        [JsonProperty("level")]
        public short Level_ { get; set; }
        [JsonProperty("start_date")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [JsonProperty("finish_date")]
        public Nullable<System.DateTime> FinishDate { get; set; }
        [JsonProperty("balance")]
        public Nullable<decimal> Balance { get; set; }
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }
        [JsonProperty("membership_card_id")]
        public Nullable<int> MembershipCardId { get; set; }
        [JsonProperty("type")]
        public Nullable<int> Type { get; set; }
        [JsonProperty("brand_id")]
        public Nullable<int> BrandId { get; set; }
        [JsonProperty("active")]
        public Nullable<bool> Active { get; set; }
        [JsonProperty("customer_id")]
        public Nullable<int> CustomerId { get; set; }
        [JsonProperty("membership_card")]
        public  MembershipCardAPIViewModel MembershipCardVM { get; set; }
        [JsonProperty("customer")]
        public  CustomerAPIViewModel CustomerVM { get; set; }

        public AccountAPIViewModel() : base() { }
        public AccountAPIViewModel(DataService.Models.Entities.Account entity) : base(entity) { }
    }
}

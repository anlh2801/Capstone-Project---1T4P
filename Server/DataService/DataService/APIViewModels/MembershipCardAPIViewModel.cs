using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class MembershipCardAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.MembershipCard>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("customer_id")]
        public Nullable<int> CustomerId { get; set; }
        [JsonProperty("csv")]
        public string CSV { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("status")]
        public Nullable<int> Status { get; set; }
        [JsonProperty("c_level")]
        public Nullable<int> C_Level { get; set; }
        [JsonProperty("membership_type_id")]
        public Nullable<int> MembershipTypeId { get; set; }
        [JsonProperty("is_sample")]
        public Nullable<bool> IsSample { get; set; }
        [JsonProperty("store_id")]
        public Nullable<int> StoreId { get; set; }
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }
        [JsonProperty("initial_value")]
        public Nullable<double> InitialValue { get; set; }
        [JsonProperty("membership_card_code")]
        public string MembershipCardCode { get; set; }
        [JsonProperty("customer")]
        public CustomerAPIViewModel CustomerVM { get; set; }
        [JsonProperty("membership_card_type")]
        public  MembershipCardTypeAPIViewModel MembershipCardTypeVM { get; set; }
        [JsonProperty("account")]
        public AccountAPIViewModel AccountVM { get; set; }

        public MembershipCardAPIViewModel() : base() { }
        public MembershipCardAPIViewModel(DataService.Models.Entities.MembershipCard entity) : base(entity) { }
    }
}

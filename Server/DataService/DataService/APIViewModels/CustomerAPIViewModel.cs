using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class CustomerAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Customer>
    {
        [JsonProperty("customer_id")]
        public int CustomerID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("fax")]
        public string Fax { get; set; }
        [JsonProperty("contact_person")]
        public string ContactPerson { get; set; }
        [JsonProperty("contact_person_number")]
        public string ContactPersonNumber { get; set; }
        [JsonProperty("website")]
        public string Website { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("account_id")]
        public Nullable<int> AccountID { get; set; }
        [JsonProperty("id_card")]
        public string IDCard { get; set; }
        [JsonProperty("gender")]
        public Nullable<bool> Gender { get; set; }
        [JsonProperty("birth_day")]
        public Nullable<System.DateTime> BirthDay { get; set; }
        [JsonProperty("store_register_id")]
        public Nullable<int> StoreRegisterId { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }
        [JsonProperty("customer_type_id")]
        public Nullable<int> CustomerTypeId { get; set; }
        [JsonProperty("brand_id")]
        public Nullable<int> BrandId { get; set; }
        [JsonProperty("delivery_info_default")]
        public Nullable<int> deliveryInfoDefault { get; set; }
        [JsonProperty("pic_url")]
        public string picURL { get; set; }
        [JsonProperty("account_phone")]
        public string AccountPhone { get; set; }
        [JsonProperty("facebook_id")]
        public string FacebookId { get; set; }

        public CustomerAPIViewModel() : base() { }
        public CustomerAPIViewModel(DataService.Models.Entities.Customer entity) : base(entity) { }
    }
}

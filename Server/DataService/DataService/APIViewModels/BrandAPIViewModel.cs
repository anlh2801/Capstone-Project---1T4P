using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class BrandAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Brand>
    {
        [JsonProperty("id")]
        public  int Id { get; set; }
        [JsonProperty("brand_name")]
        public  string BrandName { get; set; }
        [JsonProperty("create_date")]
        public  System.DateTime CreateDate { get; set; }
        [JsonProperty("active")]
        public  bool Active { get; set; }
        [JsonProperty("description")]
        public  string Description { get; set; }
        [JsonProperty("company_name")]
        public  string CompanyName { get; set; }
        [JsonProperty("contact_person")]
        public  string ContactPerson { get; set; }
        [JsonProperty("phone_number")]
        public  string PhoneNumber { get; set; }
        [JsonProperty("fax")]
        public  string Fax { get; set; }
        [JsonProperty("website")]
        public  string Website { get; set; }
        [JsonProperty("vat_code")]
        public  string VATCode { get; set; }
        [JsonProperty("vat_template")]
        public  Nullable<int> VATTemplate { get; set; }
        [JsonProperty("address")]
        public  string Address { get; set; }
        [JsonProperty("pgp_password")]
        public  string PGPPassword { get; set; }
        [JsonProperty("pgp_privavte_key")]
        public  string PGPPrivavteKey { get; set; }
        [JsonProperty("pgp_publickey")]
        public  string PGPPublicKey { get; set; }
        [JsonProperty("des_key")]
        public  string DesKey { get; set; }
        [JsonProperty("des_vector")]
        public  string DesVector { get; set; }
        [JsonProperty("access_token")]
        public  string AccessToken { get; set; }
        [JsonProperty("tax_code")]
        public  string TaxCode { get; set; }
        [JsonProperty("api_sms_key")]
        public  string ApiSMSKey { get; set; }
        [JsonProperty("security_api_sms_key")]
        public  string SecurityApiSMSKey { get; set; }
        [JsonProperty("sms_type")]
        public  Nullable<int> SMSType { get; set; }
        [JsonProperty("brand_name_sms")]
        public  string BrandNameSMS { get; set; }
        [JsonProperty("json_config_url")]
        public  string JsonConfigUrl { get; set; }
        [JsonProperty("brand_feature_filter")]
        public  string BrandFeatureFilter { get; set; }
        [JsonProperty("wisky_id")]
        public  Nullable<int> WiskyId { get; set; }
        [JsonProperty("default_dash_board")]
        public  string DefaultDashBoard { get; set; }
        [JsonProperty("rsa_private_key")]
        public  string RSAPrivateKey { get; set; }
        [JsonProperty("rsa_public_key")]
        public  string RSAPublicKey { get; set; }

        public BrandAPIViewModel() : base() { }
        public BrandAPIViewModel(DataService.Models.Entities.Brand entity) : base(entity) { }
    }
}

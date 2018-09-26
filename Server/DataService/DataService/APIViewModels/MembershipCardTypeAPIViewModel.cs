using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class MembershipCardTypeAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.MembershipCardType>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("type_name")]
        public string TypeName { get; set; }
        [JsonProperty("append_code")]
        public string AppendCode { get; set; }
        [JsonProperty("brand_id")]
        public int BrandId { get; set; }
        [JsonProperty("active")]
        public Nullable<bool> Active { get; set; }
        [JsonProperty("is_mobile")]
        public Nullable<bool> IsMobile { get; set; }
        [JsonProperty("type_level")]
        public Nullable<int> TypeLevel { get; set; }
        [JsonProperty("type_point")]
        public Nullable<int> TypePoint { get; set; }

        public MembershipCardTypeAPIViewModel() : base() { }
        public MembershipCardTypeAPIViewModel(DataService.Models.Entities.MembershipCardType entity) : base(entity) { }
    }
}

using DataService.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModel
{
    public class ProductCategoryAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ProductCategory>
    {

        [JsonProperty("cate_id")]
        public  int CateID { get; set; }
        [JsonProperty("cate_name")]
        public  string CateName { get; set; }
        [JsonProperty("cate_name_eng")]
        public  string CateNameEng { get; set; }
        [JsonProperty("type")]
        public  int Type { get; set; }
        [JsonProperty("is_displayed")]
        public  bool IsDisplayed { get; set; }
        [JsonProperty("is_display_website")]
        public  bool IsDisplayedWebsite { get; set; }
        [JsonProperty("is_extra")]
        public  bool IsExtra { get; set; }
        [JsonProperty("display_order")]
        public  int DisplayOrder { get; set; }
        [JsonProperty("adjustment_note")]
        public  string AdjustmentNote { get; set; }
        [JsonProperty("store_id")]
        public  Nullable<int> StoreId { get; set; }
        [JsonProperty("seo_name")]
        public  string SeoName { get; set; }
        [JsonProperty("seo_keyword")]
        public  string SeoKeyword { get; set; }
        [JsonProperty("seo_description")]
        public  string SeoDescription { get; set; }
        [JsonProperty("image_font_awsome_css")]
        public  string ImageFontAwsomeCss { get; set; }
        [JsonProperty("parent_cate_id")]
        public  Nullable<int> ParentCateId { get; set; }
        [JsonProperty("position")]
        public  Nullable<int> Position { get; set; }
        [JsonProperty("active")]
        public  bool Active { get; set; }
        [JsonProperty("brand_id")]
        public  Nullable<int> BrandId { get; set; }
        [JsonProperty("pic_url")]
        public  string PicUrl { get; set; }
        [JsonProperty("banner_url")]
        public  string BannerUrl { get; set; }
        [JsonProperty("description")]
        public  string Description { get; set; }
        [JsonProperty("description_eng")]
        public  string DescriptionEng { get; set; }
        [JsonProperty("banner_description")]
        public  string BannerDescription { get; set; }
        [JsonProperty("banner_description_eng")]
        public  string BannerDescriptionEng { get; set; }
        [JsonProperty("att1")]
        public  string Att1 { get; set; }
        [JsonProperty("att2")]
        public  string Att2 { get; set; }
        [JsonProperty("att3")]
        public  string Att3 { get; set; }
        [JsonProperty("att4")]
        public  string Att4 { get; set; }
        [JsonProperty("att5")]
        public  string Att5 { get; set; }
        [JsonProperty("att6")]
        public  string Att6 { get; set; }
        [JsonProperty("att7")]
        public  string Att7 { get; set; }
        [JsonProperty("att8")]
        public  string Att8 { get; set; }
        [JsonProperty("att9")]
        public  string Att9 { get; set; }
        [JsonProperty("att10")]
        public  string Att10 { get; set; }
        [JsonProperty("vat")]
        public  Nullable<double> VAT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryExtraMapping> CategoryExtraMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryExtraMapping> CategoryExtraMappings1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> ProductCategory1 { get; set; }
        public virtual ProductCategory ProductCategory2 { get; set; }
        public ProductCategoryAPIViewModel() : base() { }
    public ProductCategoryAPIViewModel(DataService.Models.Entities.ProductCategory entity) : base(entity) { }
    }

}

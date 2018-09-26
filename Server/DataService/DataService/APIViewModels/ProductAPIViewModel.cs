﻿
using DataService.APIViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ProductAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Product>
    {
        [JsonProperty("product_id")]
        public int ProductID { get; set; }
        [JsonProperty("product_name")]
        public string ProductName { get; set; }
        [JsonProperty("product_name_eng")]
        public string ProductNameEng { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("pic_url")]
        public string PicURL { get; set; }
        [JsonProperty("cat_id")]
        public int CatID { get; set; }
        [JsonProperty("is_available")]
        public bool IsAvailable { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("discount_percent")]
        public double DiscountPercent { get; set; }
        [JsonProperty("discount_price")]
        public double DiscountPrice { get; set; }
        [JsonProperty("product_type")]
        public int ProductType { get; set; }
        [JsonProperty("display_order")]
        public int DisplayOrder { get; set; }
        [JsonProperty("has_extra")]
        public bool HasExtra { get; set; }
        [JsonProperty("is_fixed_price")]
        public bool IsFixedPrice { get; set; }
        [JsonProperty("pos_x")]
        public Nullable<int> PosX { get; set; }
        [JsonProperty("pos_y")]
        public Nullable<int> PosY { get; set; }
        [JsonProperty("color_group")]
        public Nullable<int> ColorGroup { get; set; }
        [JsonProperty("group")]
        public Nullable<int> Group { get; set; }
        [JsonProperty("group_id")]
        public Nullable<int> GroupId { get; set; }
        [JsonProperty("is_menu_display")]
        public Nullable<bool> IsMenuDisplay { get; set; }
        [JsonProperty("general_product_id")]
        public Nullable<int> GeneralProductId { get; set; }
        [JsonProperty("att1")]
        public string Att1 { get; set; }
        [JsonProperty("att2")]
        public string Att2 { get; set; }
        [JsonProperty("att3")]
        public string Att3 { get; set; }
        [JsonProperty("att4")]
        public string Att4 { get; set; }
        [JsonProperty("att5")]
        public string Att5 { get; set; }
        [JsonProperty("att6")]
        public string Att6 { get; set; }
        [JsonProperty("att7")]
        public string Att7 { get; set; }
        [JsonProperty("att8")]
        public string Att8 { get; set; }
        [JsonProperty("att9")]
        public string Att9 { get; set; }
        [JsonProperty("att10")]
        public string Att10 { get; set; }
        [JsonProperty("max_extra")]
        public Nullable<int> MaxExtra { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("description_eng")]
        public string DescriptionEng { get; set; }
        [JsonProperty("introduction")]
        public string Introduction { get; set; }
        [JsonProperty("introduction_eng")]
        public string IntroductionEng { get; set; }
        [JsonProperty("print_group")]
        public Nullable<int> PrintGroup { get; set; }
        [JsonProperty("seo_name")]
        public string SeoName { get; set; }
        [JsonProperty("is_home_page")]
        public Nullable<int> IsHomePage { get; set; }
        [JsonProperty("web_content")]
        public string WebContent { get; set; }
        [JsonProperty("seo_key_words")]
        public string SeoKeyWords { get; set; }
        [JsonProperty("seo_description")]
        public string SeoDescription { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("is_sefault_child_product")]
        public int IsDefaultChildProduct { get; set; }
        [JsonProperty("position")]
        public Nullable<int> Position { get; set; }
        [JsonProperty("sale_type")]
        public Nullable<int> SaleType { get; set; }
        [JsonProperty("is_most_ordered")]
        public bool IsMostOrdered { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("create_time")]
        public Nullable<System.DateTime> CreateTime { get; set; }
        [JsonProperty("rating_total")]
        public Nullable<int> RatingTotal { get; set; }
        [JsonProperty("num_of_user_voted")]
        public Nullable<int> NumOfUserVoted { get; set; }
        [JsonProperty("sale_method_enum")]
        public Nullable<int> SaleMethodEnum { get; set; }

        #region Additional Property
        [JsonProperty("product_category")]
        public ProductCategoryAPIViewModel ProductCategory { get; set; }
        #endregion
        public ProductAPIViewModel() : base() { }
        public ProductAPIViewModel(DataService.Models.Entities.Product entity) : base(entity) { }

    }
}

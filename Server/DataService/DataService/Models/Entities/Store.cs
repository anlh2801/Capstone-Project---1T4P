//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            this.Articles = new HashSet<Article>();
            this.AspNetUsers = new HashSet<AspNetUser>();
            this.Attendances = new HashSet<Attendance>();
            this.AttendanceDates = new HashSet<AttendanceDate>();
            this.BlogPosts = new HashSet<BlogPost>();
            this.BlogPostCollections = new HashSet<BlogPostCollection>();
            this.Costs = new HashSet<Cost>();
            this.Coupons = new HashSet<Coupon>();
            this.CustomerStoreReportMappings = new HashSet<CustomerStoreReportMapping>();
            this.DateProducts = new HashSet<DateProduct>();
            this.DateProductItems = new HashSet<DateProductItem>();
            this.DateReports = new HashSet<DateReport>();
            this.EmployeeInStores = new HashSet<EmployeeInStore>();
            this.ImageCollections = new HashSet<ImageCollection>();
            this.InventoryDateReports = new HashSet<InventoryDateReport>();
            this.InventoryReceipts = new HashSet<InventoryReceipt>();
            this.InventoryReceipts1 = new HashSet<InventoryReceipt>();
            this.InventoryReceipts2 = new HashSet<InventoryReceipt>();
            this.Languages = new HashSet<Language>();
            this.LanguageKeys = new HashSet<LanguageKey>();
            this.Orders = new HashSet<Order>();
            this.PaymentReports = new HashSet<PaymentReport>();
            this.ProductCollections = new HashSet<ProductCollection>();
            this.ProductDetailMappings = new HashSet<ProductDetailMapping>();
            this.PromotionStoreMappings = new HashSet<PromotionStoreMapping>();
            this.ReportTrackings = new HashSet<ReportTracking>();
            this.RoomCategories = new HashSet<RoomCategory>();
            this.StoreDomains = new HashSet<StoreDomain>();
            this.StoreGroupMappings = new HashSet<StoreGroupMapping>();
            this.StoreThemes = new HashSet<StoreTheme>();
            this.StoreUsers = new HashSet<StoreUser>();
            this.StoreWebRoutes = new HashSet<StoreWebRoute>();
            this.StoreWebSettings = new HashSet<StoreWebSetting>();
            this.StoreWebViewCounters = new HashSet<StoreWebViewCounter>();
            this.ViewCounters = new HashSet<ViewCounter>();
            this.WebMenuCategories = new HashSet<WebMenuCategory>();
            this.WebPages = new HashSet<WebPage>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public Nullable<bool> isAvailable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public int Type { get; set; }
        public Nullable<int> RoomRentMode { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public string ShortName { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<System.DateTime> OpenTime { get; set; }
        public Nullable<System.DateTime> CloseTime { get; set; }
        public string DefaultAdminPassword { get; set; }
        public Nullable<bool> HasProducts { get; set; }
        public Nullable<bool> HasNews { get; set; }
        public Nullable<bool> HasImageCollections { get; set; }
        public Nullable<bool> HasMultipleLanguage { get; set; }
        public Nullable<bool> HasWebPages { get; set; }
        public Nullable<bool> HasCustomerFeedbacks { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> HasOrder { get; set; }
        public Nullable<bool> HasBlogEditCollections { get; set; }
        public string LogoUrl { get; set; }
        public string FbAccessToken { get; set; }
        public string StoreFeatureFilter { get; set; }
        public Nullable<bool> RunReport { get; set; }
        public Nullable<int> AttendanceStoreFilter { get; set; }
        public string StoreCode { get; set; }
        public Nullable<int> PosId { get; set; }
        public string StoreConfig { get; set; }
        public string DefaultDashBoard { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public Nullable<bool> Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceDate> AttendanceDates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogPostCollection> BlogPostCollections { get; set; }
        public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cost> Costs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coupon> Coupons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerStoreReportMapping> CustomerStoreReportMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DateProduct> DateProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DateProductItem> DateProductItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DateReport> DateReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmployeeInStore> EmployeeInStores { get; set; }
        public virtual Group Group { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageCollection> ImageCollections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryDateReport> InventoryDateReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryReceipt> InventoryReceipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryReceipt> InventoryReceipts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryReceipt> InventoryReceipts2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LanguageKey> LanguageKeys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentReport> PaymentReports { get; set; }
        public virtual Pos Pos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCollection> ProductCollections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetailMapping> ProductDetailMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionStoreMapping> PromotionStoreMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportTracking> ReportTrackings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomCategory> RoomCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreDomain> StoreDomains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreGroupMapping> StoreGroupMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreTheme> StoreThemes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreUser> StoreUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreWebRoute> StoreWebRoutes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreWebSetting> StoreWebSettings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StoreWebViewCounter> StoreWebViewCounters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViewCounter> ViewCounters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WebMenuCategory> WebMenuCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WebPage> WebPages { get; set; }
    }
}

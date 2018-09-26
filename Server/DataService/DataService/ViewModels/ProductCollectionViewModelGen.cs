//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductCollectionViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.ProductCollection>
    {
    	
    			public virtual int Id { get; set; }
    			public virtual int StoreId { get; set; }
    			public virtual string Name { get; set; }
    			public virtual string NameEng { get; set; }
    			public virtual bool Active { get; set; }
    			public virtual string Description { get; set; }
    			public virtual string DescriptionEng { get; set; }
    			public virtual string SEO { get; set; }
    			public virtual string SEODescription { get; set; }
    			public virtual string SEOKeyword { get; set; }
    			public virtual string Link { get; set; }
    			public virtual string BannerUrl { get; set; }
    			public virtual Nullable<int> BrandId { get; set; }
    	
    	public ProductCollectionViewModel() : base() { }
    	public ProductCollectionViewModel(DataService.Models.Entities.ProductCollection entity) : base(entity) { }
    
    }
}

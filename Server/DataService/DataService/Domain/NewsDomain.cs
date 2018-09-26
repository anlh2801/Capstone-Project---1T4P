using AutoMapper;
using DataService.Models.Entities;
using DataService.Models.Entities.Services;
using DataService.Utilities;
using DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    
    public interface INewsDomain
    {
        IQueryable<BlogCategoryViewModel> GetAllBlogCategories(int brandID);
        IQueryable<StoreWebSettingViewModel> GetWebSettingActive(int storeID);
    }
    public class NewsDomain : BaseDomain, INewsDomain
    {
        public IQueryable<BlogCategoryViewModel> GetAllBlogCategories(int brandID)
        {
            BlogCategoryService blogCategoriesService = new BlogCategoryService();
            var BlogCategories = blogCategoriesService.GetActive(q => q.IsDisplay== true && q.BrandId == brandID);
            return BlogCategories;
        }

        public IQueryable<StoreWebSettingViewModel> GetWebSettingActive(int storeID)
        {
            return new StoreWebSettingService().GetActive(q => q.StoreId == storeID);
        }
    }
}

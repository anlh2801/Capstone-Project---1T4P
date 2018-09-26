using DataService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.Models.Entities;
using DataService.Models.Entities.Services;

namespace TestDataService
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var _db = new DatabaseEntities())
            //{
            //    var result = _db.BlogCategories.ToList();
            //}
            BlogCategoryService blogCategoryService = new BlogCategoryService();
            var blogCategories = blogCategoryService.GetActive();
            Console.ReadLine();
        }
    }
}

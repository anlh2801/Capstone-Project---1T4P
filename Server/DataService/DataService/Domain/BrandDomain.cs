using DataService.APIViewModels;
using DataService.Models.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Domain
{
    public interface IBrandDomain
    {
        BrandAPIViewModel GetBrandById(int brandid);
    }
    public class BrandDomain : BaseDomain, IBrandDomain
    {
        public BrandAPIViewModel GetBrandById(int brandid)
        {
            var brandService = this.Service<IBrandService>();
            return brandService.GetBrandById(brandid);
        }
    }
}

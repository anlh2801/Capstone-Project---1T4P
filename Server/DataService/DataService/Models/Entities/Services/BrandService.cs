using DataService.APIViewModels;
using DataService.Models.Entities.Repositories;
using DataService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Models.Entities.Services
{
    public partial interface IBrandService
    {
        BrandAPIViewModel GetBrandById(int brandid);
    }
    public partial class BrandService
    {
        public BrandAPIViewModel GetBrandById(int brandid)
        {
            var brandRepo = DependencyUtils.Resolve<IBrandRepository>();
            var brand = brandRepo.FirstOrDefaultActive(b => b.Id == brandid);
            return new BrandAPIViewModel(brand);
        }

    }
}

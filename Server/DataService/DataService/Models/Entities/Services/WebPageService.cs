using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.BaseConnect;

namespace DataService.Models.Entities.Services
{

    public partial interface IWebPageService
    {
        //IQueryable<WebPage> GetActiveWebPage();
    }

    public partial class WebPageService : IWebPageService
    {
        //public IQueryable<WebPage> GetActiveWebPage()
        //{
        //    return this.Get(p => p.IsActive == true);
        //}
    }
}

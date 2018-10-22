using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class RequestDetailAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Request>
    {
        public RequestDetailAPIViewModel() : base() { }
        public RequestDetailAPIViewModel(DataService.Models.Entities.Request entity) : base(entity) { }

        public int RequestId { get; set; }
        public int AgencyId { get; set; }
        public int ServiceItemId { get; set; }
        public int RequestCategoryId { get; set; }
        public int RequestStatus { get; set; }
        public string RequestName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Feedback { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }


    }
}

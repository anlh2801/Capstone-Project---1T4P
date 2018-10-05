using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService.ViewModels;

namespace DataService.APIViewModels
{
    public class ProblemAPIViewModel: DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public ProblemAPIViewModel() : base() { }
        public ProblemAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public string CreateDate { get; set; }
        public string AgencyName { get; set; }
        public string ITSupporterName { get; set; }
        public List<String> IssueName { get; set; }
        public List<String> ITName { get; set; }


    }
}

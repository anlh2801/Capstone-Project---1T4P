using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ProblemCancelAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public ProblemCancelAPIViewModel() : base() { }
        public ProblemCancelAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int ProblemId { get; set; }
        public int CurrentStatus { get; set; }
    }
}

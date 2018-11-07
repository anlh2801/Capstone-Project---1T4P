using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AgencyStatisticalAPIViewModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public List<StatusAPIViewModel> Statuses { get; set; }
    }
}

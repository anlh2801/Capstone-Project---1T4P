using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ServiceItemUpdateAPIViewModel
    {
        public int ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }
        public string Description { get; set; }
    }
}

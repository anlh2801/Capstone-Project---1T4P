using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ServiceItemAPIViewModel 
    {        
        public int NumericalOrder { get; set; }
        public int ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }
        public double ServiceItemPrice { get; set; }
        public string Description { get; set; }        
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int ServiceId { get; set; }
    }
}

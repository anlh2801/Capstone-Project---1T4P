using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class RatingAPIViewModel
    {
        public int RequestId { get; set; }
        public int ServiceItemId { get; set; }
        public int CurrentITSupporter_Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.CustomTools
{
    public class RenderITSupporterListWithWeight
    {
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public double ITSupporterListWeight { get; set; }
        public int TimesReject { get; set; }
    }
}

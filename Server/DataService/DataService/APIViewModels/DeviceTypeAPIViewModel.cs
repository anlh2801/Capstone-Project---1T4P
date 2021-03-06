﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class DeviceTypeAPIViewModel 
    {
        public int NumericalOrder { get; set; }
        public int DeviceTypeId { get; set; }
        public int ServiceId { get; set; }
        public string DeviceTypeName { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string ServiceName { get; set; }
    }
}

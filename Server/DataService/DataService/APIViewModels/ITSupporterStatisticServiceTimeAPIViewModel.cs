﻿using DataService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterStatisticServiceTimeAPIViewModel
    {
        public string ServiceName { get; set; }
        public double SupportTimeByDay { get; set; }
        public double SupportTimeByHour { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class CreateRequestHistoryAPIViewModel
    {
        public int RequestId { get; set; }
        public String PreSupporter_Name { get; set; }
        public int PreStatus { get; set; }
        public string CreateDate { get; set; }
    }
}

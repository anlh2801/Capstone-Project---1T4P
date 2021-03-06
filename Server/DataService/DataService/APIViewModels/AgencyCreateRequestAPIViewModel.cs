﻿using DataService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class AgencyCreateRequestAPIViewModel
    {
        public int RequestId { get; set; }
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public int RequestCategoryId { get; set; }
        public int ServiceItemId { get; set; }
        public string RequestName { get; set; }
        public string RequestDesciption { get; set; }
        public string PhoneNumber { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string RequestStatus { get; set; }
        public string RequestEstimationTime { get; set; }
        public int NumberOfTicketDone { get; set; }
        public int NumberTicketInProcessing { get; set; }
        public int NumberOfTicket { get; set; }
        public string ITSupporterName { get; set; }
        public List<AgencyCreateTicketAPIViewModel> Tickets { get; set; }        
    }
}

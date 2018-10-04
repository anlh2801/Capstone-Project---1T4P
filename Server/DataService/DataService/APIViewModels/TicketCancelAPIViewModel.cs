﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class TicketCancelAPIViewModel : DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Ticket>
    {
        public TicketCancelAPIViewModel() : base() { }
        public TicketCancelAPIViewModel(DataService.Models.Entities.Ticket entity) : base(entity) { }

        public int TicketId { get; set; }
        public int CurrentStatus { get; set; }
    }
}

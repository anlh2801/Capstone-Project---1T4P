using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class ITSupporterAPIViewModel
    {
        public int ITSupporterId { get; set; }
        public string ITSupporterName { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public double RatingAVG { get; set; }
        public string IsBusy { get; set; }
        public bool IsBusyValue { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public int RequestWattingForAccept { get; set; }
    }
}

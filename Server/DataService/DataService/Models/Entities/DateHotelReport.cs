//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataService.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class DateHotelReport
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string CreateBy { get; set; }
        public int Status { get; set; }
        public int StoreID { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double FinalAmount { get; set; }
        public double TotalOrderDetail { get; set; }
        public double TotalOrderFeeItem { get; set; }
    }
}

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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.OrderFeeItems = new HashSet<OrderFeeItem>();
            this.OrderPromotionMappings = new HashSet<OrderPromotionMapping>();
            this.Payments = new HashSet<Payment>();
            this.VATOrderMappings = new HashSet<VATOrderMapping>();
        }
    
        public int RentID { get; set; }
        public string InvoiceID { get; set; }
        public Nullable<System.DateTime> CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountOrderDetail { get; set; }
        public double FinalAmount { get; set; }
        public int OrderStatus { get; set; }
        public Nullable<int> RentStatus { get; set; }
        public int OrderType { get; set; }
        public int RentType { get; set; }
        public string Notes { get; set; }
        public string FeeDescription { get; set; }
        public string CheckInPerson { get; set; }
        public string CheckOutPerson { get; set; }
        public string ApprovePerson { get; set; }
        public Nullable<int> PriceGroupID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<System.DateTime> ArrivalDate { get; set; }
        public Nullable<System.DateTime> DepartureDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> SubRentGroupID { get; set; }
        public Nullable<int> RoomId { get; set; }
        public bool IsFixedPrice { get; set; }
        public Nullable<System.DateTime> LastRecordDate { get; set; }
        public string ServedPerson { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> SourceID { get; set; }
        public int SourceType { get; set; }
        public string DeliveryAddress { get; set; }
        public Nullable<int> DeliveryStatus { get; set; }
        public Nullable<int> OrderDetailsTotalQuantity { get; set; }
        public Nullable<int> CheckinHour { get; set; }
        public Nullable<int> TotalInvoicePrint { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> VATAmount { get; set; }
        public Nullable<int> NumberOfGuest { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
        public string Att5 { get; set; }
        public int GroupPaymentStatus { get; set; }
        public string DeliveryReceiver { get; set; }
        public string DeliveryPhone { get; set; }
        public Nullable<System.DateTime> LastModifiedPayment { get; set; }
        public Nullable<System.DateTime> LastModifiedOrderDetail { get; set; }
        public Nullable<int> PaymentStatus { get; set; }
        public Nullable<int> DeliveryType { get; set; }
        public Nullable<int> DeliveryPayment { get; set; }
        public Nullable<int> InvoiceStatus { get; set; }
        public Nullable<int> WardCode { get; set; }
        public Nullable<int> DistrictCode { get; set; }
        public Nullable<int> ProvinceCode { get; set; }
        public Nullable<int> PromotionPartnerId { get; set; }
        public Nullable<double> MemberPoint { get; set; }
        public string Receiver { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual District District { get; set; }
        public virtual PriceGroup PriceGroup { get; set; }
        public virtual PromotionPartner PromotionPartner { get; set; }
        public virtual Province Province { get; set; }
        public virtual Room Room { get; set; }
        public virtual Store Store { get; set; }
        public virtual SubRentGroup SubRentGroup { get; set; }
        public virtual Ward Ward { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderFeeItem> OrderFeeItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPromotionMapping> OrderPromotionMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual PromotionPartner PromotionPartner1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VATOrderMapping> VATOrderMappings { get; set; }
    }
}

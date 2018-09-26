using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.APIViewModels
{
    public class StoreAPIViewModel: DataService.ViewModels.BaseEntityViewModel<DataService.Models.Entities.Store>
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Lat { get; set; }
        public virtual string Lon { get; set; }
        public virtual Nullable<bool> isAvailable { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual Nullable<System.DateTime> CreateDate { get; set; }
        public virtual int Type { get; set; }
        public virtual Nullable<int> RoomRentMode { get; set; }
        public virtual Nullable<System.DateTime> ReportDate { get; set; }
        public virtual string ShortName { get; set; }
        public virtual Nullable<int> GroupId { get; set; }
        public virtual Nullable<System.DateTime> OpenTime { get; set; }
        public virtual Nullable<System.DateTime> CloseTime { get; set; }
        public virtual string DefaultAdminPassword { get; set; }
        public virtual Nullable<bool> HasProducts { get; set; }
        public virtual Nullable<bool> HasNews { get; set; }
        public virtual Nullable<bool> HasImageCollections { get; set; }
        public virtual Nullable<bool> HasMultipleLanguage { get; set; }
        public virtual Nullable<bool> HasWebPages { get; set; }
        public virtual Nullable<bool> HasCustomerFeedbacks { get; set; }
        public virtual Nullable<int> BrandId { get; set; }
        public virtual Nullable<bool> HasOrder { get; set; }
        public virtual Nullable<bool> HasBlogEditCollections { get; set; }
        public virtual string LogoUrl { get; set; }
        public virtual string FbAccessToken { get; set; }
        public virtual string StoreFeatureFilter { get; set; }
        public virtual Nullable<bool> RunReport { get; set; }
        public virtual Nullable<int> AttendanceStoreFilter { get; set; }
        public virtual string StoreCode { get; set; }
        public virtual Nullable<int> PosId { get; set; }
        public virtual string StoreConfig { get; set; }
        public virtual string DefaultDashBoard { get; set; }
        public virtual string District { get; set; }
        public virtual string Province { get; set; }
        public virtual Nullable<bool> Active { get; set; }

        public StoreAPIViewModel() : base() { }
        public StoreAPIViewModel(DataService.Models.Entities.Store entity) : base(entity) { }
    }
}

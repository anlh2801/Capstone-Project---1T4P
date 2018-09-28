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
    
    public partial class Skill
    {
        public int SkillId { get; set; }
        public int ITSupportId { get; set; }
        public Nullable<int> ServiceItemId { get; set; }
        public Nullable<int> MonthExperience { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual ITSupporter ITSupporter { get; set; }
        public virtual ServiceItem ServiceItem { get; set; }
    }
}
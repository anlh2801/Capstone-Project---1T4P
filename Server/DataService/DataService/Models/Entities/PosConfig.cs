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
    
    public partial class PosConfig
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int PosFileId { get; set; }
    
        public virtual PosFile PosFile { get; set; }
    }
}

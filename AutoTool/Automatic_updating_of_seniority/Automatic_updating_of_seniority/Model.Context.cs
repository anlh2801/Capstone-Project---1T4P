﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Automatic_updating_of_seniority
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ODTS_DBEntities : DbContext
    {
        public ODTS_DBEntities()
            : base("name=ODTS_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractServiceITSupport> ContractServiceITSupport { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<Guideline> Guideline { get; set; }
        public virtual DbSet<ITSupporter> ITSupporter { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestCategory> RequestCategory { get; set; }
        public virtual DbSet<RequestHistory> RequestHistory { get; set; }
        public virtual DbSet<RequestTask> RequestTask { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ServiceItem> ServiceItem { get; set; }
        public virtual DbSet<ServiceITSupport> ServiceITSupport { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
    }
}

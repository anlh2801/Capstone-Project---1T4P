﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DataEntities : DbContext
    {
        public DataEntities()
            : base("name=DataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractServiceITSupport> ContractServiceITSupports { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Guideline> Guidelines { get; set; }
        public virtual DbSet<ITSupporter> ITSupporters { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ServiceItem> ServiceItems { get; set; }
        public virtual DbSet<ServiceITSupport> ServiceITSupports { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketDetail> TicketDetails { get; set; }
        public virtual DbSet<TicketHistory> TicketHistories { get; set; }
        public virtual DbSet<TicketTask> TicketTasks { get; set; }
    }
}

namespace CapstoneProjectServer.DataAccess.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
using CapstoneProjectServer.DataAccess.EF.Models;

public partial class CasptoneProjectContext : DbContext
    {
        public CasptoneProjectContext()
            : base("name=CasptoneProjectContext")
        {
        }

        public virtual DbSet<tblContact> tblContacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblContact>()
                .Property(e => e.contactId)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<tblContact>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}

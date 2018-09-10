namespace CapstoneProjectServer.DataAccess.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblContact")]
    public partial class tblContact
    {
        [Key]
        [StringLength(50)]
        public string contactId { get; set; }

        [StringLength(50)]
        public string address { get; set; }

        [StringLength(50)]
        public string telephone { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? publicDate { get; set; }
    }
}

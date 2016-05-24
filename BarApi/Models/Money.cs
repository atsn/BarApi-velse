namespace BarApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Money")]
    public partial class Money
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Place { get; set; }

        [Column("Money")]
        public int Money1 { get; set; }
    }
}

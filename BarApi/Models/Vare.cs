namespace BarApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vare")]
    public partial class Vare
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Varenavn { get; set; }

        [Column("AntaliEnRamme/Flaske")]
        public int AntaliEnRamme_Flaske { get; set; }

        public int Pris { get; set; }
    }
}

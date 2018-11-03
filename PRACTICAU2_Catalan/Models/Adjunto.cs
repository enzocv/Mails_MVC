namespace PRACTICAU2_Catalan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adjunto")]
    public partial class Adjunto
    {
        [Key]
        public int idadjunto { get; set; }

        public int idcorreo { get; set; }

        [StringLength(250)]
        public string archivo { get; set; }

        public virtual Correo Correo { get; set; }
    }
}

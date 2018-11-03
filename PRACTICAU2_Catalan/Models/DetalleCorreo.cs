namespace PRACTICAU2_Catalan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleCorreo")]
    public partial class DetalleCorreo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iddetalle { get; set; }

        public int idcorreo { get; set; }

        public int idpersona { get; set; }

        public virtual Correo Correo { get; set; }

        public virtual Persona Persona { get; set; }
    }
}

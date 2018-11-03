namespace PRACTICAU2_Catalan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Net.Mail;

    [Table("Correo")]
    public partial class Correo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Correo()
        {
            Adjunto = new HashSet<Adjunto>();
            DetalleCorreo = new HashSet<DetalleCorreo>();
        }

        [Key]
        public int idcorreo { get; set; }

        public int idpersona { get; set; }

        [Required]
        [StringLength(20)]
        public string asunto { get; set; }

        [StringLength(50)]
        public string mensaje { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Column(TypeName = "date")]
        public DateTime hora { get; set; }

        [Required]
        [StringLength(15)]
        public string importancia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjunto> Adjunto { get; set; }

        public virtual Persona Persona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCorreo> DetalleCorreo { get; set; }

        //public void Guardar()
        //{
        //    try
        //    {
        //        using (var db = new Model_Correo())
        //        {
        //            db.Entry(this).State = EntityState.Added;
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}

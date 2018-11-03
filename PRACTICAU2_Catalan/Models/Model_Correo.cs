namespace PRACTICAU2_Catalan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Correo : DbContext
    {
        public Model_Correo()
            : base("name=Model_Correo")
        {
        }

        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Correo> Correo { get; set; }
        public virtual DbSet<DetalleCorreo> DetalleCorreo { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adjunto>()
                .Property(e => e.archivo)
                .IsUnicode(false);

            modelBuilder.Entity<Correo>()
                .Property(e => e.asunto)
                .IsUnicode(false);

            modelBuilder.Entity<Correo>()
                .Property(e => e.mensaje)
                .IsUnicode(false);

            modelBuilder.Entity<Correo>()
                .Property(e => e.importancia)
                .IsUnicode(false);

            modelBuilder.Entity<Correo>()
                .HasMany(e => e.Adjunto)
                .WithRequired(e => e.Correo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Correo>()
                .HasMany(e => e.DetalleCorreo)
                .WithRequired(e => e.Correo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Correo)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.DetalleCorreo)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nivel)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

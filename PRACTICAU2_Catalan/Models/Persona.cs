namespace PRACTICAU2_Catalan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Correo = new HashSet<Correo>();
            DetalleCorreo = new HashSet<DetalleCorreo>();
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int idpersona { get; set; }

        [Required]
        [StringLength(6)]
        public string codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [Required]
        [StringLength(250)]
        public string url { get; set; }

        [Required]
        [StringLength(10)]
        public string celular { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Correo> Correo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCorreo> DetalleCorreo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public List<Persona> Listar()
        {//devuelve una coleccion
            var objTipo = new List<Persona>();
            try
            {
                //establecer el origen de la fuente de datos
                using (var db = new Model_Correo())
                {
                    //sentencia LINQ
                    objTipo = db.Persona.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public Persona Obtener(int id)
        {
            var objTipo = new Persona();
            try
            {
                using (var db = new Model_Correo())
                {
                    objTipo = db.Persona
                        .Where(x => x.idpersona == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public List<Persona> Buscar(string criterio)
        {
            var objTipo = new List<Persona>();
            string estadoUsuario = "";
            if (criterio.Equals("Activo"))
            {
                estadoUsuario = "A";
            }
            else if (criterio.Equals("Inactivo"))
            {
                estadoUsuario = "I";
            }
            try
            {
                using (var db = new Model_Correo())
                {
                    objTipo = db.Persona
                        .Where(x => x.nombre.Contains(criterio) ||
                                    x.apellido.Contains(criterio) ||
                                    x.email.Contains(criterio) ||
                                    x.estado.Equals(estadoUsuario))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objTipo;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Correo())
                {
                    if (this.idpersona > 0)
                    {
                        //si existe un valor en la DB la modifica
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        if (this.sexo == "" || this.sexo == null)
                        {

                        }
                        else
                        {
                            //agrega un nuevo valor
                            db.Entry(this).State = EntityState.Added;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new Model_Correo())
                {
                    //si existe un valor en la DB la modifica
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //METHOD VALIDATE LOGIN
        public ResponseModel1 ValidarLogin(string Usuario, string Passwaord)
        {
            var rm = new ResponseModel1();

            try
            {
                using (var db = new Model_Correo())
                {
                    //Passwaord = HashHelper.MD5(Passwaord);
                    var usuario = db.Persona.Where(x => x.email == Usuario)
                                            .Where(x => x.codigo == Passwaord)
                                            .SingleOrDefault();
                    if (usuario != null)
                    {
                        if (usuario.estado.Equals("A"))
                        {
                            SessionHelper1.AddUserToSession(usuario.idpersona.ToString());
                            rm.SetResponse(true);
                        }
                        else
                        {
                            rm.SetResponse(false, "Usuario deshabilitado consulte con el Administrador...");
                        }
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario o Password incorrectos...");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }

    }
}

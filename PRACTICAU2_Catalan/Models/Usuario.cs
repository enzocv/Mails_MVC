namespace PRACTICAU2_Catalan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int idusuario { get; set; }

        public int idpersona { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string clave { get; set; }

        [StringLength(30)]
        public string nivel { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Persona Persona { get; set; }


        public Usuario Obtener(int id)
        {
            var objTipo = new Usuario();
            try
            {
                using (var db = new Model_Correo())
                {
                    objTipo = db.Usuario.Include("Persona")
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

        //METHOD VALIDATE LOGIN
        public ResponseModel1 ValidarLogin(string Usuario, string Passwaord)
        {
            var rm = new ResponseModel1();

            try
            {
                using (var db = new Model_Correo())
                {
                    //Passwaord = HashHelper.MD5(Passwaord);
                    var usuario = db.Usuario.Where(x => x.nombre == Usuario)
                                            .Where(x => x.clave == Passwaord)
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

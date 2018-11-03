using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PRACTICAU2_Catalan.Models;
using PRACTICAU2_Catalan.Filters;

namespace PRACTICAU2_Catalan.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        private Persona persona = new Persona();

        [Autenticado]
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(persona.Listar());
            }
            else
            {
                return View(persona.Buscar(criterio));
            }
        }

        [Autenticado]
        public ActionResult Ver(int id)
        {
            return View(persona.Obtener(id));
        }

        [Autenticado]
        public ActionResult Buscar(string criterio)
        {
            return View(
                criterio == null || criterio == ""
                ? persona.Listar() : persona.Buscar(criterio)
                );
        }
        [Autenticado]
        public ActionResult AgregarEditar(int id = 0)
        {
            //ViewBag.tipo = tipousuario.Listar();
            return View(
                id == 0 ? new Persona() //agregar un nuevo objeto
                : persona.Obtener(id)
                );
        }
        [Autenticado]
        public ActionResult Guardar(Persona usu)
        {
            if (ModelState.IsValid)
            {
                usu.Guardar();
                return Redirect("~/Persona");
            }
            else
            {
                return View("~/Views/Persona/AgregarEditar.cshtml", usu);
            }
        }
        [Autenticado]
        public ActionResult Eliminar(int id)
        {
            persona.idpersona = id;
            persona.Eliminar();
            return Redirect("~/Persona");
        }

    }
}
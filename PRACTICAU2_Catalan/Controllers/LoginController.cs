using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PRACTICAU2_Catalan.Models;
using PRACTICAU2_Catalan.Filters;

namespace PRACTICAU2_Catalan.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Usuario usuario = new Usuario();

        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Validar(string Usuario, string Password)
        {
            var rm = usuario.ValidarLogin(Usuario, Password);
            if (rm.response)
            {
                rm.href = Url.Content("/Default");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper1.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}
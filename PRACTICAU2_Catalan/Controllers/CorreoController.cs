using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

using PRACTICAU2_Catalan.Models;
using PRACTICAU2_Catalan.Filters;

namespace PRACTICAU2_Catalan.Controllers
{
    public class CorreoController : Controller
    {
        // GET: Correo
        private Correo correo = new Correo();
        private Persona persona = new Persona();
        private Usuario currentUser = new Usuario().Obtener(SessionHelper1.GetUser());

        [Autenticado]
        public ActionResult Index(string criterio)
        {
            ViewBag.CountryList = persona.Listar();

            return View();
        }

        [Autenticado]
        public ActionResult Enviar(Correo mail)
        {
            string name = Request.Form["idpersonas"];
            if (enviarMail(name))
            {
                return Redirect("~/Persona");
            }
            else
            {
                return View();
            }
            //enviarMail(name);
        }

        [Autenticado]
        public bool enviarMail(string name)
        {
            bool result = false;
            
            string frmasunto  = Request.Form["frmasunto"];
            string frmmensaje = Request.Form["frmasunto2"];
            string fechaMail = Request.Form["fechaMail"];
            string horaMail = Request.Form["horaMail"];
            string frmimportancia = Request.Form["frmimportancia"];

            string[] strTemp = name.Split(',');

            string hostMail = "";
            if (currentUser.Persona.email.Contains("gmail"))
            {
                hostMail = "smtp.gmail.com";
            }
            else //if (frmenvia.Contains("outlook") || frmenvia.Contains("hotmail") || frmenvia.Contains(".pe"))
            {
                //hostMail = "smtp-mail.outlook.com";
                hostMail = "smtp.office365.com";
            }
            SmtpClient cliente = new SmtpClient(hostMail, 587);//465 | 587
            cliente.EnableSsl = true;
            cliente.Timeout = 100000;
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new NetworkCredential(currentUser.Persona.email, currentUser.clave);
            for (int i = 0; i < strTemp.Length; i++)
            {
                try
                {
                    Persona per = persona.Obtener(Convert.ToInt32(strTemp[i]));
                    string paraemail = per.email;
                    string body = "<p>Hola, "
                                     + per.nombre
                                     + "<br/>"
                                     + frmmensaje
                                     + "<br/>"
                                     + per.url
                                     + "</p>";

                    MailMessage mensaje = new MailMessage(currentUser.Persona.email, paraemail, frmasunto, body);
                    mensaje.IsBodyHtml = true;
                    mensaje.BodyEncoding = UTF8Encoding.UTF8;

                    if (frmimportancia.Equals("Alta"))
                    {
                        mensaje.Priority = MailPriority.High;
                    }
                    else if (frmimportancia.Equals("Media"))
                    {
                        mensaje.Priority = MailPriority.Normal;
                    }
                    else
                    {
                        mensaje.Priority = MailPriority.Low;
                    }

                    cliente.Send(mensaje);
                    result = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return result;
        }


    }
}
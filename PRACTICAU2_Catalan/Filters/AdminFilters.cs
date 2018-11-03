using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Web.Routing;
using PRACTICAU2_Catalan.Models;
using System.Web.Mvc;

namespace PRACTICAU2_Catalan.Filters
{
    // Si no estamos logeado, regresamos al login
    public class AutenticadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper1.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
        }
    }

    // Si estamos logeado ya no podemos acceder a la página de Login
    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper1.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index"
                }));
            }
        }
    }
}
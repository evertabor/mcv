using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mcv.Models;
using mcv.Controllers;

namespace mcv.Filters
{
    public class VerifySession : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (users)HttpContext.Current.Session["user"];
            if (oUser == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/");
                }
            }
            base.OnActionExecuting(filterContext);
        }


    }
}
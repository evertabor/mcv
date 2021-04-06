using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mcv.Models;


namespace mcv.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Enter(string user, string pass)
        {
            try
            {
                using (MYDBEntities1 dbUser = new MYDBEntities1())
                {
                    var usuario = from myuser in dbUser.users
                                    where myuser.correo == user 
                                    select myuser;
                     var contra = from mycontra in dbUser.users
                                  where mycontra.pasword == pass
                                 select mycontra;
                    var state = from mystate in dbUser.users
                                   where mystate.idState == 1 && mystate.correo == user
                                   select mystate;
                   if (usuario.Count() > 0)
                   {
                        if (state.Count() > 0)
                        {
                            if (contra.Count() > 0)
                            {
                                users oUser = usuario.First();
                                Session["user"] = oUser;
                                Session["username"] = oUser.correo;
                                return Content("1");
                            }
                            else
                            {
                                return Content("Contraseña incorcecta");
                            }
                        }
                        else
                        {
                            return Content("Usuario bloqueado, por favor comuniquese con el administrador de sistemas");
                        }
                   }
                   else
                   {
                     return Content("Usuario no valido");
                   }
                }

            }
            catch (Exception e)
            {
                return Content("Oh ocurrio un error :(" + e.Message);
            }
        }
    }
}
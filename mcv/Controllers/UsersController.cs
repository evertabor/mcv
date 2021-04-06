using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mcv.Models;
using mcv.Models.TableViewModel;
using mcv.Models.ViewModel;
namespace mcv.Controllers
{
    public class UsersController : Controller
    {

        // GET: Users
        public ActionResult Index()
        {
            List<UserTableModel> lst = null;
            using (MYDBEntities1 db = new MYDBEntities1())
            {
                lst = (from d in db.users
                       where d.idState == 1
                       orderby d.id
                       select new UserTableModel
                       {
                           correo = d.correo,
                           id = d.id
                       }).ToList();
            }
            return View(lst);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.mensaje = "";
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.mensaje = "";
                return View();
            }
            using (var db = new MYDBEntities1())
            {
                users oUser = new users
                {
                    idState = 1,
                    correo = model.Correo,
                    pasword = model.Password
                };

                db.users.Add(oUser);
                db.SaveChanges();
                ViewBag.mensaje = "Usuario guardado con exito";
            }
           
            return View();
        }
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();
            using (var db = new MYDBEntities1())
            {
                var oUser = db.users.Find(id);
                model.Correo = oUser.correo;
                model.Id = oUser.id;
            }
            ViewBag.mensaje = "";
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new MYDBEntities1())
            {
                var oUser = db.users.Find(model.Id);

                oUser.correo = model.Correo;
                if(model.Password != null && model.Password.Trim() != "")
                {
                    oUser.pasword = model.Password;
                }
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.mensaje = "Usuario actualizado con exito";
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new MYDBEntities1())
            {
                var oUser = db.users.Find(Id);
                oUser.idState = 3;//eliminaremos
                
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.mensaje = "Usuario actualizado con exito";
            return Content("1");
        }

    }
}
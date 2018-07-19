using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using projekt_13_1_vj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projekt_13_1_vj.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        ApplicationDbContext contex = new ApplicationDbContext();

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection forma)
        {
            var rol = Request.Form["rola"];
            IdentityRole rola = new IdentityRole(rol);
            

            contex.Roles.Add(rola);
            contex.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult List()
        {
            List<IdentityRole> role = contex.Roles.ToList();

            return View(role);
        }

        public ActionResult Edit(string id)
        {
            IdentityRole rola = contex.Roles.Where(r => r.Id == id).SingleOrDefault();

            return View(rola);
        }


        [HttpPost]
        public ActionResult Edit(IdentityRole Role)
        {
            IdentityRole rola = contex.Roles.Where(r => r.Id == Role.Id).SingleOrDefault();
            rola.Name = Role.Name;

            contex.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(string id)
        {
            

            IdentityRole rola = contex.Roles.Where(r => r.Id == id).SingleOrDefault();

            contex.Roles.Remove(rola);
            contex.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult ManageUserRoles()
        {
            List<IdentityRole> rola = contex.Roles.ToList();
            return View(rola);
        }

        [HttpPost]
        public ActionResult RoleAddToUser(FormCollection form)
        {
            string naziv = form["Username"];
            string rolaName = form["RoleName"];

            var user = contex.Users.Where(u => u.UserName == naziv).SingleOrDefault();
            var rola = contex.Roles.Where(r => r.Id == rolaName).SingleOrDefault();

            

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            um.AddToRole(user.Id, rola.Name);

            

            contex.SaveChanges();

            return RedirectToAction("ManageUserRoles");
        }

        [HttpPost]
        public ActionResult GetRoles(FormCollection form)
        {
            string naziv = form["Username"];
            var user = contex.Users.Where(u => u.UserName == naziv).SingleOrDefault();

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            ViewBag.Role = um.GetRoles(user.Id); 

            return View("ManageUserRoles", contex.Roles.ToList());
        }

        [HttpPost]
        public ActionResult DeleteRoleForUser(FormCollection form)
        {
            string naziv = form["Username"];
            string rolaName = form["RoleName"];

            var rola = contex.Roles.Where(r => r.Id == rolaName).SingleOrDefault();
            var user = contex.Users.Where(u => u.UserName == naziv).SingleOrDefault();


            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            um.RemoveFromRole(user.Id, rola.Name);

            contex.SaveChanges();

            return RedirectToAction("ManageUserRoles");
        }
    }
}
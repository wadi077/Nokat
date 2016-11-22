using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemNokta.Models;

namespace SystemNokta.Controllers
{
    public class UserController : Controller
    {
        NoktaContext db = new NoktaContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount model, HttpPostedFileBase ProfilePic)
        {
            if (ModelState.IsValid)
            {
                String picName = null;
                if (ProfilePic.ContentLength > 0)
                {
                    if (ProfilePic.ContentType.Contains("image"))
                    {
                        picName = Guid.NewGuid().ToString() + "" + Path.GetExtension(ProfilePic.FileName);
                        String path = Server.MapPath("~/Images/" + picName);
                        ProfilePic.SaveAs(path);
                    }
                }
                db.Users.Add(model);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Success = "The user was successfully created";
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount model)
        {
            

            UserAccount user = db.Users.Where(m => m.Password == model.Password && model.UserName == model.UserName).FirstOrDefault();

            if(user == null)
            {
                ViewBag.Error = "User Name or Password did not correct";
                return View();
            }
            else
            {
                Session["userId"] = user.Id;
                Session["userName"] = user.UserName;
                return RedirectToAction("Index", "Nokta");
            }
        }
    }
}
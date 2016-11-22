using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemNokta.Models;

namespace SystemNokta.Controllers
{
    public class NoktaController : Controller
    {
        NoktaContext db = new NoktaContext();
        // GET: Nokta
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                //var N = from s in db.Users
                //        join r in db.Nokat on s.Id equals r.UserId
                //        select new { UserName = s.UserName, Id = r.Id, NoktaContent = r.NoktaContent, Like = r.Like, DisLike = r.DisLike };
                //return View(N);
                return View(db.Nokat.ToList());
            }

            return RedirectToAction("Login", "Nokta");
        }

        public ActionResult Like(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Nokta message = db.Nokat.Find(id);
            if (message == null)
                return HttpNotFound();

            int count = message.Like;
            count = count + 1;
            message.Like = count;
            db.Entry(message).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DisLike(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Nokta message = db.Nokat.Find(id);
            if (message == null)
                return HttpNotFound();

            int count = message.DisLike;
            count = count + 1;
            message.DisLike = count;
            db.Entry(message).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Comment(int Id)
        {
            Session["noktaId"] = Id;
            return RedirectToAction("Index", "Comment");
        }
        public ActionResult Create()
        {
            if(Session["userId"] != null)
            {
                return View();
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult Create(Nokta model)
        {
            if(Session["userId"] != null)
            {
                if (ModelState.IsValid)
                {
                    int userId = Int16.Parse(Session["userId"].ToString());
                    UserAccount user = db.Users.Find(userId);
                    model.UserAccount = user;

                    db.Nokat.Add(model);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemNokta.Models;

namespace SystemNokta.Controllers
{
    public class CommentController : Controller
    {
        NoktaContext db = new NoktaContext();
        // GET: Comment
        public ActionResult Index()
        {
            int noktaId = Int32.Parse(Session["noktaId"].ToString());
            var Comments = db.Comments.Where(m => m.Nokat.Id == noktaId);
            return View(Comments);
        }

        public ActionResult Back()
        {
            return RedirectToAction("Index","Nokta");
        }

        public ActionResult Add()
        {
            if (Session["userId"] != null)
            {
                return View();
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public ActionResult Add(Comment model)
        {
            if (Session["userId"] != null)
            {
                if (ModelState.IsValid)
                {
                    int noktaId = Int16.Parse(Session["noktaId"].ToString());
                    Nokta user = db.Nokat.Find(noktaId);
                    model.Nokat = user;

                    db.Comments.Add(model);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
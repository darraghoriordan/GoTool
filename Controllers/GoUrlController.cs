using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoTool.Models;

namespace GoTool.Controllers
{
    public class GoUrlController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private  const string adminUser = "doriordan";
        // GET: /GoUrl/
        public ActionResult Index()
        {
            if (Request.RequestContext.HttpContext.User.Identity.Name == adminUser)
                ViewData["admin"] = "true";

            return View(db.GoLinkViewModels.ToList());
        }

        // GET: /GoUrl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoLinkViewModel golinkviewmodel = db.GoLinkViewModels.Find(id);
            if (golinkviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(golinkviewmodel);
        }
        // GET: /url
        public ActionResult Forward(string linkUrl)
        {
            if (string.IsNullOrEmpty(linkUrl))
            {
                RedirectToAction("Index");
            }
            GoLinkViewModel golinkviewmodel = db.GoLinkViewModels.FirstOrDefault(v => v.LinkName == linkUrl);
            if (golinkviewmodel == null)
            {
                return HttpNotFound();
            }
            return Redirect(golinkviewmodel.GoUrl);
        }
        // GET: /GoUrl/Create
        [Authorize(Users = adminUser)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /GoUrl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = adminUser)]
        public ActionResult Create([Bind(Include = "Id,LinkName,GoUrl,Owner,Description")] GoLinkViewModel golinkviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.GoLinkViewModels.Add(golinkviewmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(golinkviewmodel);
        }

        // GET: /GoUrl/Edit/5
        [Authorize(Users = adminUser)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoLinkViewModel golinkviewmodel = db.GoLinkViewModels.Find(id);
            if (golinkviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(golinkviewmodel);
        }

        // POST: /GoUrl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = adminUser)]
        public ActionResult Edit([Bind(Include = "Id,LinkName,GoUrl,Owner,Description")] GoLinkViewModel golinkviewmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golinkviewmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golinkviewmodel);
        }

        // GET: /GoUrl/Delete/5
        [Authorize(Users = adminUser)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoLinkViewModel golinkviewmodel = db.GoLinkViewModels.Find(id);
            if (golinkviewmodel == null)
            {
                return HttpNotFound();
            }
            return View(golinkviewmodel);
        }

        // POST: /GoUrl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = adminUser)]
        public ActionResult DeleteConfirmed(int id)
        {
            GoLinkViewModel golinkviewmodel = db.GoLinkViewModels.Find(id);
            db.GoLinkViewModels.Remove(golinkviewmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

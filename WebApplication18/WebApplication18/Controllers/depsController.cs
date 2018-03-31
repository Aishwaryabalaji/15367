using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication18.Models;

namespace WebApplication18.Controllers
{
    public class depsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: deps
        public ActionResult Index()
        {
            return View(db.deps.ToList());
        }

        // GET: deps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dep dep = db.deps.Find(id);
            if (dep == null)
            {
                return HttpNotFound();
            }
            return View(dep);
        }

        // GET: deps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: deps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "deptid,deptname")] dep dep)
        {
            if (ModelState.IsValid)
            {
                db.deps.Add(dep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dep);
        }

        // GET: deps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dep dep = db.deps.Find(id);
            if (dep == null)
            {
                return HttpNotFound();
            }
            return View(dep);
        }

        // POST: deps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "deptid,deptname")] dep dep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dep);
        }

        // GET: deps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dep dep = db.deps.Find(id);
            if (dep == null)
            {
                return HttpNotFound();
            }
            return View(dep);
        }

        // POST: deps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            dep dep = db.deps.Find(id);
            db.deps.Remove(dep);
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

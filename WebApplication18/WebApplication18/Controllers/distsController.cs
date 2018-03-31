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
    public class distsController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: dists
        public ActionResult Index()
        {
            return View(db.dists.ToList());
        }

        // GET: dists/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dist dist = db.dists.Find(id);
            if (dist == null)
            {
                return HttpNotFound();
            }
            return View(dist);
        }

        // GET: dists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public string Create([Bind(Include = "districtid,district")] dist dist)
        {
            if (ModelState.IsValid)
            {
                db.dists.Add(dist);
                db.SaveChanges();
                return "in";
                //return RedirectToAction("Index");
            }

            return "out";
            //return View(dist);
        }

        // GET: dists/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dist dist = db.dists.Find(id);
            if (dist == null)
            {
                return HttpNotFound();
            }
            return View(dist);
        }

        // POST: dists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "districtid,district")] dist dist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dist);
        }

        // GET: dists/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dist dist = db.dists.Find(id);
            if (dist == null)
            {
                return HttpNotFound();
            }
            return View(dist);
        }

        // POST: dists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            dist dist = db.dists.Find(id);
            db.dists.Remove(dist);
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

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
    public class desController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: des
        public ActionResult Index()
        {
            return View(db.des.ToList());
        }

        // GET: des/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            de de = db.des.Find(id);
            if (de == null)
            {
                return HttpNotFound();
            }
            return View(de);
        }

        // GET: des/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: des/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "desigid,desig")] de de)
        {
            if (ModelState.IsValid)
            {
                db.des.Add(de);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(de);
        }

        // GET: des/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            de de = db.des.Find(id);
            if (de == null)
            {
                return HttpNotFound();
            }
            return View(de);
        }

        // POST: des/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "desigid,desig")] de de)
        {
            if (ModelState.IsValid)
            {
                db.Entry(de).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(de);
        }

        // GET: des/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            de de = db.des.Find(id);
            if (de == null)
            {
                return HttpNotFound();
            }
            return View(de);
        }

        // POST: des/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            de de = db.des.Find(id);
            db.des.Remove(de);
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

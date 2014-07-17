using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SegConRep;
using EntityState = System.Data.Entity.EntityState;

namespace SegConRep.Controllers
{
    public class RamoController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /Ramo/
        public ActionResult Index()
        {
            return View(db.ramo.ToList());
        }

        // GET: /Ramo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ramo ramo = db.ramo.Find(id);
            if (ramo == null)
            {
                return HttpNotFound();
            }
            return View(ramo);
        }

        // GET: /Ramo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ramo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ramo_producto_1,ramo_producto_2,ramo_nombre")] ramo ramo)
        {
            if (ModelState.IsValid)
            {
                db.ramo.Add(ramo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ramo);
        }

        // GET: /Ramo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ramo ramo = db.ramo.Find(id);
            if (ramo == null)
            {
                return HttpNotFound();
            }
            return View(ramo);
        }

        // POST: /Ramo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ramo_producto_1,ramo_producto_2,ramo_nombre")] ramo ramo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ramo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ramo);
        }

        // GET: /Ramo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ramo ramo = db.ramo.Find(id);
            if (ramo == null)
            {
                return HttpNotFound();
            }
            return View(ramo);
        }

        // POST: /Ramo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ramo ramo = db.ramo.Find(id);
            db.ramo.Remove(ramo);
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

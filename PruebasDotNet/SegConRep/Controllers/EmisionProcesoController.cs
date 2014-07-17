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
    public class EmisionProcesoController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /EmisionProceso/
        public ActionResult Index()
        {
            return View(db.emisionproceso.ToList());
        }

        // GET: /EmisionProceso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionproceso emisionproceso = db.emisionproceso.Find(id);
            if (emisionproceso == null)
            {
                return HttpNotFound();
            }
            return View(emisionproceso);
        }

        // GET: /EmisionProceso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EmisionProceso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="emisionproceso_id,emisionproceso_nombre,emisionproceso_descripcion")] emisionproceso emisionproceso)
        {
            if (ModelState.IsValid)
            {
                db.emisionproceso.Add(emisionproceso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emisionproceso);
        }

        // GET: /EmisionProceso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionproceso emisionproceso = db.emisionproceso.Find(id);
            if (emisionproceso == null)
            {
                return HttpNotFound();
            }
            return View(emisionproceso);
        }

        // POST: /EmisionProceso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="emisionproceso_id,emisionproceso_nombre,emisionproceso_descripcion")] emisionproceso emisionproceso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emisionproceso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emisionproceso);
        }

        // GET: /EmisionProceso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionproceso emisionproceso = db.emisionproceso.Find(id);
            if (emisionproceso == null)
            {
                return HttpNotFound();
            }
            return View(emisionproceso);
        }

        // POST: /EmisionProceso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emisionproceso emisionproceso = db.emisionproceso.Find(id);
            db.emisionproceso.Remove(emisionproceso);
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

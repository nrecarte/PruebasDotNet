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
    public class EmisionLimiteController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /EmisionLimite/
        public ActionResult Index()
        {
            var emisionlimite = db.emisionlimite.Include(e => e.emisionproceso).Include(e => e.ramo);
            return View(emisionlimite.ToList());
        }

        // GET: /EmisionLimite/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionlimite emisionlimite = db.emisionlimite.Find(id);
            if (emisionlimite == null)
            {
                return HttpNotFound();
            }
            return View(emisionlimite);
        }

        // GET: /EmisionLimite/Create
        public ActionResult Create()
        {
            ViewBag.emisionlimite_proceso_id = new SelectList(db.emisionproceso, "emisionproceso_id", "emisionproceso_nombre");
            ViewBag.emisionlimite_producto_1 = new SelectList(db.ramo, "ramo_producto_1", "ramo_nombre");
            return View();
        }

        // POST: /EmisionLimite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="emisionlimite_dias,emisionlimite_descripcion,emisionlimite_producto_1,emisionlimite_producto_2,emisionlimite_proceso_id")] emisionlimite emisionlimite)
        {
            if (ModelState.IsValid)
            {
                db.emisionlimite.Add(emisionlimite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emisionlimite_proceso_id = new SelectList(db.emisionproceso, "emisionproceso_id", "emisionproceso_nombre", emisionlimite.emisionlimite_proceso_id);
            ViewBag.emisionlimite_producto_1 = new SelectList(db.ramo, "ramo_producto_1", "ramo_nombre", emisionlimite.emisionlimite_producto_1);
            return View(emisionlimite);
        }

        // GET: /EmisionLimite/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionlimite emisionlimite = db.emisionlimite.Find(id);
            if (emisionlimite == null)
            {
                return HttpNotFound();
            }
            ViewBag.emisionlimite_proceso_id = new SelectList(db.emisionproceso, "emisionproceso_id", "emisionproceso_nombre", emisionlimite.emisionlimite_proceso_id);
            ViewBag.emisionlimite_producto_1 = new SelectList(db.ramo, "ramo_producto_1", "ramo_nombre", emisionlimite.emisionlimite_producto_1);
            return View(emisionlimite);
        }

        // POST: /EmisionLimite/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="emisionlimite_dias,emisionlimite_descripcion,emisionlimite_producto_1,emisionlimite_producto_2,emisionlimite_proceso_id")] emisionlimite emisionlimite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emisionlimite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emisionlimite_proceso_id = new SelectList(db.emisionproceso, "emisionproceso_id", "emisionproceso_nombre", emisionlimite.emisionlimite_proceso_id);
            ViewBag.emisionlimite_producto_1 = new SelectList(db.ramo, "ramo_producto_1", "ramo_nombre", emisionlimite.emisionlimite_producto_1);
            return View(emisionlimite);
        }

        // GET: /EmisionLimite/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionlimite emisionlimite = db.emisionlimite.Find(id);
            if (emisionlimite == null)
            {
                return HttpNotFound();
            }
            return View(emisionlimite);
        }

        // POST: /EmisionLimite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emisionlimite emisionlimite = db.emisionlimite.Find(id);
            db.emisionlimite.Remove(emisionlimite);
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

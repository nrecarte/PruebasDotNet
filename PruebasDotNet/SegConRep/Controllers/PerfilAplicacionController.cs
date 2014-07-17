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
    public class PerfilAplicacionController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /PerfilAplicacion/
        public ActionResult Index()
        {
            var perfilaplicacion = db.perfilaplicacion.Include(p => p.aplicacion).Include(p => p.perfil);
            return View(perfilaplicacion.ToList());
        }

        // GET: /PerfilAplicacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilaplicacion perfilaplicacion = db.perfilaplicacion.Find(id);
            if (perfilaplicacion == null)
            {
                return HttpNotFound();
            }
            return View(perfilaplicacion);
        }

        // GET: /PerfilAplicacion/Create
        public ActionResult Create()
        {
            ViewBag.perfilaplicacion_aplicacion_id = new SelectList(db.aplicacion, "aplicacion_id", "aplicacion_nombre");
            ViewBag.perfilaplicacion_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre");
            return View();
        }

        // POST: /PerfilAplicacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="perfilaplicacion_id,perfilaplicacion_perfil_id,perfilaplicacion_aplicacion_id")] perfilaplicacion perfilaplicacion)
        {
            if (ModelState.IsValid)
            {
                db.perfilaplicacion.Add(perfilaplicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.perfilaplicacion_aplicacion_id = new SelectList(db.aplicacion, "aplicacion_id", "aplicacion_nombre", perfilaplicacion.perfilaplicacion_aplicacion_id);
            ViewBag.perfilaplicacion_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", perfilaplicacion.perfilaplicacion_perfil_id);
            return View(perfilaplicacion);
        }

        // GET: /PerfilAplicacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilaplicacion perfilaplicacion = db.perfilaplicacion.Find(id);
            if (perfilaplicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.perfilaplicacion_aplicacion_id = new SelectList(db.aplicacion, "aplicacion_id", "aplicacion_nombre", perfilaplicacion.perfilaplicacion_aplicacion_id);
            ViewBag.perfilaplicacion_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", perfilaplicacion.perfilaplicacion_perfil_id);
            return View(perfilaplicacion);
        }

        // POST: /PerfilAplicacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="perfilaplicacion_id,perfilaplicacion_perfil_id,perfilaplicacion_aplicacion_id")] perfilaplicacion perfilaplicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilaplicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.perfilaplicacion_aplicacion_id = new SelectList(db.aplicacion, "aplicacion_id", "aplicacion_nombre", perfilaplicacion.perfilaplicacion_aplicacion_id);
            ViewBag.perfilaplicacion_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", perfilaplicacion.perfilaplicacion_perfil_id);
            return View(perfilaplicacion);
        }

        // GET: /PerfilAplicacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilaplicacion perfilaplicacion = db.perfilaplicacion.Find(id);
            if (perfilaplicacion == null)
            {
                return HttpNotFound();
            }
            return View(perfilaplicacion);
        }

        // POST: /PerfilAplicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            perfilaplicacion perfilaplicacion = db.perfilaplicacion.Find(id);
            db.perfilaplicacion.Remove(perfilaplicacion);
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

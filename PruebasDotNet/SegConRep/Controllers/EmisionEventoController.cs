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
    public class EmisionEventoController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /EmisionEvento/
        public ActionResult Index()
        {
            var emisionevento = db.emisionevento.Include(e => e.eventoestado).Include(e => e.emisionlimite).Include(e => e.poliza);
            return View(emisionevento.ToList());
        }

        // GET: /EmisionEvento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionevento emisionevento = db.emisionevento.Find(id);
            if (emisionevento == null)
            {
                return HttpNotFound();
            }
            return View(emisionevento);
        }

        // GET: /EmisionEvento/Create
        public ActionResult Create()
        {
            ViewBag.emisionevento_estado_id = new SelectList(db.eventoestado, "eventoestado_id", "eventoestado_estado");
            ViewBag.emisionevento_producto_1 = new SelectList(db.emisionlimite, "emisionlimite_producto_1", "emisionlimite_descripcion");
            ViewBag.emisionevento_poliza_numero = new SelectList(db.poliza, "poliza_numero", "poliza_numero");
            return View();
        }

        // POST: /EmisionEvento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="emisionevento_id,emisionevento_poliza_numero,emisionevento_proceso_id,emisionevento_estado_id,emisionevento_producto_1,emisionevento_producto_2,emisionevento_descripcion,emisionevento_fecha_inicio,emisionevento_numero,emisionevento_usuario_id,emisionevento_fecha_fin")] emisionevento emisionevento)
        {
            if (ModelState.IsValid)
            {
                db.emisionevento.Add(emisionevento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emisionevento_estado_id = new SelectList(db.eventoestado, "eventoestado_id", "eventoestado_estado", emisionevento.emisionevento_estado_id);
            ViewBag.emisionevento_producto_1 = new SelectList(db.emisionlimite, "emisionlimite_producto_1", "emisionlimite_descripcion", emisionevento.emisionevento_producto_1);
            ViewBag.emisionevento_poliza_numero = new SelectList(db.poliza, "poliza_numero", "poliza_numero", emisionevento.emisionevento_poliza_numero);
            return View(emisionevento);
        }

        // GET: /EmisionEvento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionevento emisionevento = db.emisionevento.Find(id);
            if (emisionevento == null)
            {
                return HttpNotFound();
            }
            ViewBag.emisionevento_estado_id = new SelectList(db.eventoestado, "eventoestado_id", "eventoestado_estado", emisionevento.emisionevento_estado_id);
            ViewBag.emisionevento_producto_1 = new SelectList(db.emisionlimite, "emisionlimite_producto_1", "emisionlimite_descripcion", emisionevento.emisionevento_producto_1);
            ViewBag.emisionevento_poliza_numero = new SelectList(db.poliza, "poliza_numero", "poliza_numero", emisionevento.emisionevento_poliza_numero);
            return View(emisionevento);
        }

        // POST: /EmisionEvento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="emisionevento_id,emisionevento_poliza_numero,emisionevento_proceso_id,emisionevento_estado_id,emisionevento_producto_1,emisionevento_producto_2,emisionevento_descripcion,emisionevento_fecha_inicio,emisionevento_numero,emisionevento_usuario_id,emisionevento_fecha_fin")] emisionevento emisionevento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emisionevento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emisionevento_estado_id = new SelectList(db.eventoestado, "eventoestado_id", "eventoestado_estado", emisionevento.emisionevento_estado_id);
            ViewBag.emisionevento_producto_1 = new SelectList(db.emisionlimite, "emisionlimite_producto_1", "emisionlimite_descripcion", emisionevento.emisionevento_producto_1);
            ViewBag.emisionevento_poliza_numero = new SelectList(db.poliza, "poliza_numero", "poliza_numero", emisionevento.emisionevento_poliza_numero);
            return View(emisionevento);
        }

        // GET: /EmisionEvento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emisionevento emisionevento = db.emisionevento.Find(id);
            if (emisionevento == null)
            {
                return HttpNotFound();
            }
            return View(emisionevento);
        }

        // POST: /EmisionEvento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emisionevento emisionevento = db.emisionevento.Find(id);
            db.emisionevento.Remove(emisionevento);
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

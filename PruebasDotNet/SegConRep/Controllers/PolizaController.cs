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
    public class PolizaController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /Poliza/
        public ActionResult Index()
        {
            var poliza = db.poliza.Include(p => p.polizaestado);
            return View(poliza.ToList());
        }

        // GET: /Poliza/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poliza poliza = db.poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // GET: /Poliza/Create
        public ActionResult Create()
        {
            ViewBag.poliza_estado_id = new SelectList(db.polizaestado, "polizaestado_id", "polizaestado_estado");
            return View();
        }

        // POST: /Poliza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="poliza_numero,poliza_producto_1,poliza_producto_2,poliza_zona,poliza_oficina,poliza_estado_id")] poliza poliza)
        {
            if (ModelState.IsValid)
            {
                db.poliza.Add(poliza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.poliza_estado_id = new SelectList(db.polizaestado, "polizaestado_id", "polizaestado_estado", poliza.poliza_estado_id);
            return View(poliza);
        }

        // GET: /Poliza/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poliza poliza = db.poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            ViewBag.poliza_estado_id = new SelectList(db.polizaestado, "polizaestado_id", "polizaestado_estado", poliza.poliza_estado_id);
            return View(poliza);
        }

        // POST: /Poliza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="poliza_numero,poliza_producto_1,poliza_producto_2,poliza_zona,poliza_oficina,poliza_estado_id")] poliza poliza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poliza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.poliza_estado_id = new SelectList(db.polizaestado, "polizaestado_id", "polizaestado_estado", poliza.poliza_estado_id);
            return View(poliza);
        }

        // GET: /Poliza/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poliza poliza = db.poliza.Find(id);
            if (poliza == null)
            {
                return HttpNotFound();
            }
            return View(poliza);
        }

        // POST: /Poliza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            poliza poliza = db.poliza.Find(id);
            db.poliza.Remove(poliza);
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

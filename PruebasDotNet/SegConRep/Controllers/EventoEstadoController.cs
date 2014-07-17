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
    public class EventoEstadoController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /EventoEstado/
        public ActionResult Index()
        {
            return View(db.eventoestado.ToList());
        }

        // GET: /EventoEstado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventoestado eventoestado = db.eventoestado.Find(id);
            if (eventoestado == null)
            {
                return HttpNotFound();
            }
            return View(eventoestado);
        }

        // GET: /EventoEstado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EventoEstado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="eventoestado_id,eventoestado_estado,eventoestado_descripcion")] eventoestado eventoestado)
        {
            if (ModelState.IsValid)
            {
                db.eventoestado.Add(eventoestado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventoestado);
        }

        // GET: /EventoEstado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventoestado eventoestado = db.eventoestado.Find(id);
            if (eventoestado == null)
            {
                return HttpNotFound();
            }
            return View(eventoestado);
        }

        // POST: /EventoEstado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="eventoestado_id,eventoestado_estado,eventoestado_descripcion")] eventoestado eventoestado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventoestado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventoestado);
        }

        // GET: /EventoEstado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventoestado eventoestado = db.eventoestado.Find(id);
            if (eventoestado == null)
            {
                return HttpNotFound();
            }
            return View(eventoestado);
        }

        // POST: /EventoEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventoestado eventoestado = db.eventoestado.Find(id);
            db.eventoestado.Remove(eventoestado);
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

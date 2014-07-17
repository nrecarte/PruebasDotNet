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
    public class PolizaEstadoController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /PolizaEstado/
        public ActionResult Index()
        {
            return View(db.polizaestado.ToList());
        }

        // GET: /PolizaEstado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            polizaestado polizaestado = db.polizaestado.Find(id);
            if (polizaestado == null)
            {
                return HttpNotFound();
            }
            return View(polizaestado);
        }

        // GET: /PolizaEstado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PolizaEstado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="polizaestado_id,polizaestado_estado,polizaestado_descripcion")] polizaestado polizaestado)
        {
            if (ModelState.IsValid)
            {
                db.polizaestado.Add(polizaestado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polizaestado);
        }

        // GET: /PolizaEstado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            polizaestado polizaestado = db.polizaestado.Find(id);
            if (polizaestado == null)
            {
                return HttpNotFound();
            }
            return View(polizaestado);
        }

        // POST: /PolizaEstado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="polizaestado_id,polizaestado_estado,polizaestado_descripcion")] polizaestado polizaestado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(polizaestado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(polizaestado);
        }

        // GET: /PolizaEstado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            polizaestado polizaestado = db.polizaestado.Find(id);
            if (polizaestado == null)
            {
                return HttpNotFound();
            }
            return View(polizaestado);
        }

        // POST: /PolizaEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            polizaestado polizaestado = db.polizaestado.Find(id);
            db.polizaestado.Remove(polizaestado);
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

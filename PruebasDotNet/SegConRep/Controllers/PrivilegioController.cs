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

namespace Prueba.Controllers
{
    public class PrivilegioController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /Privilegio/
        public ActionResult Index()
        {
            return View(db.privilegio.ToList());
        }

        // GET: /Privilegio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            privilegio privilegio = db.privilegio.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // GET: /Privilegio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Privilegio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="privilegio_id,privilegio_nombre,privilegio_descripcion")] privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.privilegio.Add(privilegio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privilegio);
        }

        // GET: /Privilegio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            privilegio privilegio = db.privilegio.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: /Privilegio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="privilegio_id,privilegio_nombre,privilegio_descripcion")] privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privilegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(privilegio);
        }

        // GET: /Privilegio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            privilegio privilegio = db.privilegio.Find(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: /Privilegio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            privilegio privilegio = db.privilegio.Find(id);
            db.privilegio.Remove(privilegio);
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

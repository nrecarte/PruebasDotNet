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
    public class PerfilPrivilegioController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /PerfilPrivilegio/
        public ActionResult Index()
        {
            var perfilprivilegio = db.perfilprivilegio.Include(p => p.privilegio).Include(p => p.perfil);
            return View(perfilprivilegio.ToList());
        }

        // GET: /PerfilPrivilegio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilprivilegio perfilprivilegio = db.perfilprivilegio.Find(id);
            if (perfilprivilegio == null)
            {
                return HttpNotFound();
            }
            return View(perfilprivilegio);
        }

        // GET: /PerfilPrivilegio/Create
        public ActionResult Create()
        {
            ViewBag.perfilprivilegio_privilegio_id = new SelectList(db.privilegio, "privilegio_id", "privilegio_nombre");
            ViewBag.perfilprivilegio_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre");
            return View();
        }

        // POST: /PerfilPrivilegio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="perfilprivilegio_id,perfilprivilegio_perfil_id,perfilprivilegio_privilegio_id")] perfilprivilegio perfilprivilegio)
        {
            if (ModelState.IsValid)
            {
                db.perfilprivilegio.Add(perfilprivilegio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.perfilprivilegio_privilegio_id = new SelectList(db.privilegio, "privilegio_id", "privilegio_nombre", perfilprivilegio.perfilprivilegio_privilegio_id);
            ViewBag.perfilprivilegio_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", perfilprivilegio.perfilprivilegio_perfil_id);
            return View(perfilprivilegio);
        }

        // GET: /PerfilPrivilegio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilprivilegio perfilprivilegio = db.perfilprivilegio.Find(id);
            if (perfilprivilegio == null)
            {
                return HttpNotFound();
            }
            ViewBag.perfilprivilegio_privilegio_id = new SelectList(db.privilegio, "privilegio_id", "privilegio_nombre", perfilprivilegio.perfilprivilegio_privilegio_id);
            ViewBag.perfilprivilegio_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", perfilprivilegio.perfilprivilegio_perfil_id);
            return View(perfilprivilegio);
        }

        // POST: /PerfilPrivilegio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="perfilprivilegio_id,perfilprivilegio_perfil_id,perfilprivilegio_privilegio_id")] perfilprivilegio perfilprivilegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilprivilegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.perfilprivilegio_privilegio_id = new SelectList(db.privilegio, "privilegio_id", "privilegio_nombre", perfilprivilegio.perfilprivilegio_privilegio_id);
            ViewBag.perfilprivilegio_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", perfilprivilegio.perfilprivilegio_perfil_id);
            return View(perfilprivilegio);
        }

        // GET: /PerfilPrivilegio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            perfilprivilegio perfilprivilegio = db.perfilprivilegio.Find(id);
            if (perfilprivilegio == null)
            {
                return HttpNotFound();
            }
            return View(perfilprivilegio);
        }

        // POST: /PerfilPrivilegio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            perfilprivilegio perfilprivilegio = db.perfilprivilegio.Find(id);
            db.perfilprivilegio.Remove(perfilprivilegio);
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

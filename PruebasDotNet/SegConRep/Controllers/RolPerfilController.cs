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
    public class RolPerfilController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /RolPerfil/
        public ActionResult Index()
        {
            var rolperfil = db.rolperfil.Include(r => r.rol).Include(r => r.perfil);
            return View(rolperfil.ToList());
        }

        // GET: /RolPerfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rolperfil rolperfil = db.rolperfil.Find(id);
            if (rolperfil == null)
            {
                return HttpNotFound();
            }
            return View(rolperfil);
        }

        // GET: /RolPerfil/Create
        public ActionResult Create()
        {
            ViewBag.rolperfil_rol_id = new SelectList(db.rol, "rol_id", "rol_nombre");
            ViewBag.rolperfil_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre");
            return View();
        }

        // POST: /RolPerfil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="rolperfil_id,rolperfil_perfil_id,rolperfil_rol_id")] rolperfil rolperfil)
        {
            if (ModelState.IsValid)
            {
                db.rolperfil.Add(rolperfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rolperfil_rol_id = new SelectList(db.rol, "rol_id", "rol_nombre", rolperfil.rolperfil_rol_id);
            ViewBag.rolperfil_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", rolperfil.rolperfil_perfil_id);
            return View(rolperfil);
        }

        // GET: /RolPerfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rolperfil rolperfil = db.rolperfil.Find(id);
            if (rolperfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.rolperfil_rol_id = new SelectList(db.rol, "rol_id", "rol_nombre", rolperfil.rolperfil_rol_id);
            ViewBag.rolperfil_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", rolperfil.rolperfil_perfil_id);
            return View(rolperfil);
        }

        // POST: /RolPerfil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="rolperfil_id,rolperfil_perfil_id,rolperfil_rol_id")] rolperfil rolperfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolperfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rolperfil_rol_id = new SelectList(db.rol, "rol_id", "rol_nombre", rolperfil.rolperfil_rol_id);
            ViewBag.rolperfil_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", rolperfil.rolperfil_perfil_id);
            return View(rolperfil);
        }

        // GET: /RolPerfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rolperfil rolperfil = db.rolperfil.Find(id);
            if (rolperfil == null)
            {
                return HttpNotFound();
            }
            return View(rolperfil);
        }

        // POST: /RolPerfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rolperfil rolperfil = db.rolperfil.Find(id);
            db.rolperfil.Remove(rolperfil);
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

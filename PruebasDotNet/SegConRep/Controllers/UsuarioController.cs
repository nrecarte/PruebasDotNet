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
    public class UsuarioController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /Usuario/
        public ActionResult Index()
        {
            var usuario = db.usuario.Include(u => u.estadousuario).Include(u => u.grupo).Include(u => u.perfil).Include(u => u.departamento);
            return View(usuario.ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            ViewBag.usuario_estadousuario_id = new SelectList(db.estadousuario, "estadousuario_id", "estadousuario_estado");
            ViewBag.usuario_grupo_id = new SelectList(db.grupo, "grupo_id", "grupo_nombre");
            ViewBag.usuario_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre");
            ViewBag.usuario_departamento_id = new SelectList(db.departamento, "departamento_id", "departamento_nombre");
            return View();
        }

        // POST: /Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="usuario_id,usuario_usuario,usuario_email,usuario_grupo_id,usuario_perfil_id,usuario_estadousuario_id,usuario_clave,usuario_nombre,usuario_departamento_id")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuario_estadousuario_id = new SelectList(db.estadousuario, "estadousuario_id", "estadousuario_estado", usuario.usuario_estadousuario_id);
            ViewBag.usuario_grupo_id = new SelectList(db.grupo, "grupo_id", "grupo_nombre", usuario.usuario_grupo_id);
            ViewBag.usuario_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", usuario.usuario_perfil_id);
            ViewBag.usuario_departamento_id = new SelectList(db.departamento, "departamento_id", "departamento_nombre", usuario.usuario_departamento_id);
            return View(usuario);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuario_estadousuario_id = new SelectList(db.estadousuario, "estadousuario_id", "estadousuario_estado", usuario.usuario_estadousuario_id);
            ViewBag.usuario_grupo_id = new SelectList(db.grupo, "grupo_id", "grupo_nombre", usuario.usuario_grupo_id);
            ViewBag.usuario_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", usuario.usuario_perfil_id);
            ViewBag.usuario_departamento_id = new SelectList(db.departamento, "departamento_id", "departamento_nombre", usuario.usuario_departamento_id);
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="usuario_id,usuario_usuario,usuario_email,usuario_grupo_id,usuario_perfil_id,usuario_estadousuario_id,usuario_clave,usuario_nombre,usuario_departamento_id")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuario_estadousuario_id = new SelectList(db.estadousuario, "estadousuario_id", "estadousuario_estado", usuario.usuario_estadousuario_id);
            ViewBag.usuario_grupo_id = new SelectList(db.grupo, "grupo_id", "grupo_nombre", usuario.usuario_grupo_id);
            ViewBag.usuario_perfil_id = new SelectList(db.perfil, "perfil_id", "perfil_nombre", usuario.usuario_perfil_id);
            ViewBag.usuario_departamento_id = new SelectList(db.departamento, "departamento_id", "departamento_nombre", usuario.usuario_departamento_id);
            return View(usuario);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuario usuario = db.usuario.Find(id);
            db.usuario.Remove(usuario);
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

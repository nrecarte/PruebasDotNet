using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SegConRep.Controllers
{
    public class EstadoUsuarioController : Controller
    {
        private segconrepEntities db = new segconrepEntities();

        // GET: /EstadoUsuario/
        public ActionResult Index()
        {
            return View(db.estadousuario.ToList());
        }

        // GET: /EstadoUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadousuario estadousuario = db.estadousuario.Find(id);
            if (estadousuario == null)
            {
                return HttpNotFound();
            }
            return View(estadousuario);
        }

        // GET: /EstadoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /EstadoUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="estadousuario_id,estadousuario_estado,estadousuario_descripcion")] estadousuario estadousuario)
        {
            if (ModelState.IsValid)
            {
                db.estadousuario.Add(estadousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadousuario);
        }

        // GET: /EstadoUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadousuario estadousuario = db.estadousuario.Find(id);
            if (estadousuario == null)
            {
                return HttpNotFound();
            }
            return View(estadousuario);
        }

        // POST: /EstadoUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="estadousuario_id,estadousuario_estado,estadousuario_descripcion")] estadousuario estadousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadousuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadousuario);
        }

        // GET: /EstadoUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadousuario estadousuario = db.estadousuario.Find(id);
            if (estadousuario == null)
            {
                return HttpNotFound();
            }
            return View(estadousuario);
        }

        // POST: /EstadoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estadousuario estadousuario = db.estadousuario.Find(id);
            db.estadousuario.Remove(estadousuario);
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

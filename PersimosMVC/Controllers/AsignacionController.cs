using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersimosMVC.Filters;
using PersimosMVC.Models;

namespace PersimosMVC.Controllers
{
    public class AsignacionController : Controller
    {
        private MiSistemaEntities db = new MiSistemaEntities();

        [AuthorizeUser(idOperacion:4)]
        // GET: Asignacion
        public ActionResult Index()
        {
            var rol_operacion = db.rol_operacion.Include(r => r.operaciones).Include(r => r.rol);
            return View(rol_operacion.ToList());
        }

        // GET: Asignacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }
        [AuthorizeUser(idOperacion:5)]
        // GET: Asignacion/Create
        public ActionResult Create()
        {
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre");
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre");
            return View();
        }

        // POST: Asignacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idRol,idOperacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.rol_operacion.Add(rol_operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: Asignacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // POST: Asignacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idRol,idOperacion")] rol_operacion rol_operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idOperacion = new SelectList(db.operaciones, "id", "nombre", rol_operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.rol, "id", "nombre", rol_operacion.idRol);
            return View(rol_operacion);
        }

        // GET: Asignacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            if (rol_operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_operacion);
        }

        // POST: Asignacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rol_operacion rol_operacion = db.rol_operacion.Find(id);
            db.rol_operacion.Remove(rol_operacion);
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

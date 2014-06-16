using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRole1.Models;

namespace WebRole1.Controllers
{
    public class EjerciciosController : Controller
    {
        private bj_gimnasioEntities db = new bj_gimnasioEntities();

        // GET: /Ejercicios/
        public ActionResult Index()
        {
            return View(db.EJERCICIO.ToList());
        }

        // GET: /Ejercicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EJERCICIO ejercicio = db.EJERCICIO.Find(id);
            if (ejercicio == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio);
        }

        // GET: /Ejercicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ejercicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="INT_ID_EJERCICIO,STR_NOMBRE_EJERCICIO,INT_DURACION,INT_REPETICIONES,INT_PESO,INT_DESCANSO,INT_SERIES")] EJERCICIO ejercicio)
        {
            if (ModelState.IsValid)
            {
                db.EJERCICIO.Add(ejercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejercicio);
        }

        // GET: /Ejercicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EJERCICIO ejercicio = db.EJERCICIO.Find(id);
            if (ejercicio == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio);
        }

        // POST: /Ejercicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="INT_ID_EJERCICIO,STR_NOMBRE_EJERCICIO,INT_DURACION,INT_REPETICIONES,INT_PESO,INT_DESCANSO,INT_SERIES")] EJERCICIO ejercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ejercicio);
        }

        // GET: /Ejercicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EJERCICIO ejercicio = db.EJERCICIO.Find(id);
            if (ejercicio == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio);
        }

        // POST: /Ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EJERCICIO ejercicio = db.EJERCICIO.Find(id);
            db.EJERCICIO.Remove(ejercicio);
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

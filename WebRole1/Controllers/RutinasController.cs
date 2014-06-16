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
    public class RutinasController : Controller
    {
        private bj_gimnasioEntities db = new bj_gimnasioEntities();

        // GET: /Rutinas/
        public ActionResult Index()
        {
            var rutina = db.RUTINA.Include(r => r.CLIENTE);
            return View(rutina.ToList());
        }

        // GET: /Rutinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTINA rutina = db.RUTINA.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            return View(rutina);
        }

        // GET: /Rutinas/Create
        public ActionResult Create()
        {
            ViewBag.INT_NUMERO_CLIENTE = new SelectList(db.CLIENTE, "INT_NUMERO_CLIENTE", "STR_CEDULA");
            return View();
        }

        // POST: /Rutinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="INT_ID_RUTINA,INT_NUMERO_CLIENTE,STR_NOMBRE_RUTINA,INT_DURACION_TOTAL")] RUTINA rutina)
        {
            if (ModelState.IsValid)
            {
                db.RUTINA.Add(rutina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INT_NUMERO_CLIENTE = new SelectList(db.CLIENTE, "INT_NUMERO_CLIENTE", "STR_CEDULA", rutina.INT_NUMERO_CLIENTE);
            return View(rutina);
        }

        // GET: /Rutinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTINA rutina = db.RUTINA.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            ViewBag.INT_NUMERO_CLIENTE = new SelectList(db.CLIENTE, "INT_NUMERO_CLIENTE", "STR_CEDULA", rutina.INT_NUMERO_CLIENTE);
            return View(rutina);
        }

        // POST: /Rutinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="INT_ID_RUTINA,INT_NUMERO_CLIENTE,STR_NOMBRE_RUTINA,INT_DURACION_TOTAL")] RUTINA rutina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INT_NUMERO_CLIENTE = new SelectList(db.CLIENTE, "INT_NUMERO_CLIENTE", "STR_CEDULA", rutina.INT_NUMERO_CLIENTE);
            return View(rutina);
        }

        // GET: /Rutinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTINA rutina = db.RUTINA.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            return View(rutina);
        }

        // POST: /Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RUTINA rutina = db.RUTINA.Find(id);
            db.RUTINA.Remove(rutina);
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

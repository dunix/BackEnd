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
    public class PersonasController : Controller
    {
        private bj_gimnasioEntities db = new bj_gimnasioEntities();

        // GET: /Personas/
        public ActionResult Index()
        {
            return View(db.PERSONA.ToList());
        }

        // GET: /Personas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA persona = db.PERSONA.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: /Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="STR_CEDULA,STR_APELLIDO1,STR_APELLIDO2,DT_FECHA_NACIMIENTO,STR_PROFESION,IMG_FOTO,FT_TAMANO_FOTO,STR_TELEFONO1,STR_TELEFONO2,STR_DIRECCION,STR_EMAIL,STR_NOMBRE,rol")] PERSONA persona)
        {
            if (ModelState.IsValid)
            {
                db.PERSONA.Add(persona);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: /Personas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA persona = db.PERSONA.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: /Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="STR_CEDULA,STR_APELLIDO1,STR_APELLIDO2,DT_FECHA_NACIMIENTO,STR_PROFESION,IMG_FOTO,FT_TAMANO_FOTO,STR_TELEFONO1,STR_TELEFONO2,STR_DIRECCION,STR_EMAIL,STR_NOMBRE,rol")] PERSONA persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: /Personas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA persona = db.PERSONA.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: /Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PERSONA persona = db.PERSONA.Find(id);
            db.PERSONA.Remove(persona);
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

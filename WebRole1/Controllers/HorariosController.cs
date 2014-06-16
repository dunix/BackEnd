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
    public class HorariosController : Controller
    {
        private bj_gimnasioEntities db = new bj_gimnasioEntities();

        // GET: /Horarios/
        public ActionResult Index()
        {
            var horario_gimnasio = db.HORARIO_GIMNASIO.Include(h => h.ADMINISTRADOR);
            return View(horario_gimnasio.ToList());
        }

        // GET: /Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO_GIMNASIO horario_gimnasio = db.HORARIO_GIMNASIO.Find(id);
            if (horario_gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(horario_gimnasio);
        }

        // GET: /Horarios/Create
        public ActionResult Create()
        {
            ViewBag.INT_ID_ADMINISTRADOR = new SelectList(db.ADMINISTRADOR, "INT_ID_ADMINISTRADOR", "STR_CEDULA");
            return View();
        }

        // POST: /Horarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_HORARIO,INT_ID_ADMINISTRADOR,DIA,ACTIVIDAD,FT_HORA,HORA")] HORARIO_GIMNASIO horario_gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.HORARIO_GIMNASIO.Add(horario_gimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INT_ID_ADMINISTRADOR = new SelectList(db.ADMINISTRADOR, "INT_ID_ADMINISTRADOR", "STR_CEDULA", horario_gimnasio.INT_ID_ADMINISTRADOR);
            return View(horario_gimnasio);
        }

        // GET: /Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO_GIMNASIO horario_gimnasio = db.HORARIO_GIMNASIO.Find(id);
            if (horario_gimnasio == null)
            {
                return HttpNotFound();
            }
            ViewBag.INT_ID_ADMINISTRADOR = new SelectList(db.ADMINISTRADOR, "INT_ID_ADMINISTRADOR", "STR_CEDULA", horario_gimnasio.INT_ID_ADMINISTRADOR);
            return View(horario_gimnasio);
        }

        // POST: /Horarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_HORARIO,INT_ID_ADMINISTRADOR,DIA,ACTIVIDAD,FT_HORA,HORA")] HORARIO_GIMNASIO horario_gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario_gimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INT_ID_ADMINISTRADOR = new SelectList(db.ADMINISTRADOR, "INT_ID_ADMINISTRADOR", "STR_CEDULA", horario_gimnasio.INT_ID_ADMINISTRADOR);
            return View(horario_gimnasio);
        }

        // GET: /Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO_GIMNASIO horario_gimnasio = db.HORARIO_GIMNASIO.Find(id);
            if (horario_gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(horario_gimnasio);
        }

        // POST: /Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HORARIO_GIMNASIO horario_gimnasio = db.HORARIO_GIMNASIO.Find(id);
            db.HORARIO_GIMNASIO.Remove(horario_gimnasio);
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

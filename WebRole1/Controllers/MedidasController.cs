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
    public class MedidasController : Controller
    {
        private bj_gimnasioEntities db = new bj_gimnasioEntities();

        // GET: /Medidas/
        public ActionResult Index(){
           
            return View(db.MEDIDA.ToList());
        }

        // GET: /Medidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDIDA medida = db.MEDIDA.Find(id);
            if (medida == null)
            {
                return HttpNotFound();
            }
            return View(medida);
        }

        // GET: /Medidas/Create
        public ActionResult Create()
        {
            
            //var first = new MEDIDA();
            //var second = new EJERCICIO();
            //return View(Tuple.Create(first, second));
            ;
            var concha = new Tuple<MEDIDA, IEnumerable<CLIENTE>>(new MEDIDA(), db.CLIENTE.ToList());
            return View(concha);
        }

        // POST: /Medidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind (Prefix="Item1", Include  = "INT_ID_MEDIDA,DT_FECHA_MEDIDA,DB_ALTURA,DB_IMC,DB_BICDER,DB_BICIZQ,DB_CINTURA,INT_EDAD,DB_ESPALDA,DB_MUSLO_DER,DB_MUSLO_IZQ,DB_PECHO,DB_PESO,DB_PORCENTAJE_GRASA,DB_CADERA") ] MEDIDA medida )
        {
           
            if (ModelState.IsValid)
            {
                db.MEDIDA.Add(medida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medida);
        }

        // GET: /Medidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDIDA medida = db.MEDIDA.Find(id);
            if (medida == null)
            {
                return HttpNotFound();
            }
            return View(medida);
        }

        // POST: /Medidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="INT_ID_MEDIDA,DT_FECHA_MEDIDA,DB_ALTURA,DB_IMC,DB_BICDER,DB_BICIZQ,DB_CINTURA,INT_EDAD,DB_ESPALDA,DB_MUSLO_DER,DB_MUSLO_IZQ,DB_PECHO,DB_PESO,DB_PORCENTAJE_GRASA,DB_CADERA")] MEDIDA medida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medida);
        }

        // GET: /Medidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDIDA medida = db.MEDIDA.Find(id);
            if (medida == null)
            {
                return HttpNotFound();
            }
            return View(medida);
        }

        // POST: /Medidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEDIDA medida = db.MEDIDA.Find(id);
            db.MEDIDA.Remove(medida);
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

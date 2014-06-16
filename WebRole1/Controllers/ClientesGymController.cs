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
    public class ClientesGymController : Controller
    {
        private bj_gimnasioEntities db = new bj_gimnasioEntities();

        // GET: /ClientesGym/
        public ActionResult Index()
        {
            var cliente = db.CLIENTE.Include(c => c.PERSONA);
            return View(cliente.ToList());
        }

        // GET: /ClientesGym/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cliente = db.CLIENTE.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: /ClientesGym/Create
        public ActionResult Create()
        {
            ViewBag.STR_CEDULA = new SelectList(db.PERSONA, "STR_CEDULA", "STR_APELLIDO1");
            return View();
        }

        // POST: /ClientesGym/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="INT_NUMERO_CLIENTE,STR_CEDULA,DT_FECHA_INGRESO")] CLIENTE cliente)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STR_CEDULA = new SelectList(db.PERSONA, "STR_CEDULA", "STR_APELLIDO1", cliente.STR_CEDULA);
            return View(cliente);
        }

        // GET: /ClientesGym/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cliente = db.CLIENTE.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.STR_CEDULA = new SelectList(db.PERSONA, "STR_CEDULA", "STR_APELLIDO1", cliente.STR_CEDULA);
            return View(cliente);
        }

        // POST: /ClientesGym/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="INT_NUMERO_CLIENTE,STR_CEDULA,DT_FECHA_INGRESO")] CLIENTE cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STR_CEDULA = new SelectList(db.PERSONA, "STR_CEDULA", "STR_APELLIDO1", cliente.STR_CEDULA);
            return View(cliente);
        }

        // GET: /ClientesGym/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cliente = db.CLIENTE.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /ClientesGym/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTE cliente = db.CLIENTE.Find(id);
            db.CLIENTE.Remove(cliente);
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

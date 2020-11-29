using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ImDone;

namespace ImDone.Controllers
{
    public class CinesController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Cines
        public ActionResult Index()
        {
            var cine = db.Cine.Include(c => c.Tarifa);
            return View(cine.ToList());
        }

        // GET: Cines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cine.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // GET: Cines/Create
        public ActionResult Create()
        {
            ViewBag.id_tarifa = new SelectList(db.Tarifa, "id_tarifa", "tipo_tarifa");
            return View();
        }

        // POST: Cines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cine,nombre_cine,provincia_cine,municipio_cine,calle_cine,numero_cine,localidad_cine,telefono_cine,id_tarifa")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                db.Cine.Add(cine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_tarifa = new SelectList(db.Tarifa, "id_tarifa", "tipo_tarifa", cine.id_tarifa);
            return View(cine);
        }

        // GET: Cines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cine.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_tarifa = new SelectList(db.Tarifa, "id_tarifa", "tipo_tarifa", cine.id_tarifa);
            return View(cine);
        }

        // POST: Cines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cine,nombre_cine,provincia_cine,municipio_cine,calle_cine,numero_cine,localidad_cine,telefono_cine,id_tarifa")] Cine cine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_tarifa = new SelectList(db.Tarifa, "id_tarifa", "tipo_tarifa", cine.id_tarifa);
            return View(cine);
        }

        // GET: Cines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cine cine = db.Cine.Find(id);
            if (cine == null)
            {
                return HttpNotFound();
            }
            return View(cine);
        }

        // POST: Cines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cine cine = db.Cine.Find(id);
            db.Cine.Remove(cine);
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

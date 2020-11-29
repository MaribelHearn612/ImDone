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
    public class sapnu_puasController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: sapnu_puas
        public ActionResult Index()
        {
            return View(db.sapnu_puas.ToList());
        }

        // GET: sapnu_puas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sapnu_puas sapnu_puas = db.sapnu_puas.Find(id);
            if (sapnu_puas == null)
            {
                return HttpNotFound();
            }
            return View(sapnu_puas);
        }

        // GET: sapnu_puas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sapnu_puas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre_cine,localidad_cine,telefono_cine,nombre_sala,nombre_genero,titulo_pelicula,nombre_protagonista,Periodo,tipo_tarifa,precio,nombre_clasificacion")] sapnu_puas sapnu_puas)
        {
            if (ModelState.IsValid)
            {
                db.sapnu_puas.Add(sapnu_puas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sapnu_puas);
        }

        // GET: sapnu_puas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sapnu_puas sapnu_puas = db.sapnu_puas.Find(id);
            if (sapnu_puas == null)
            {
                return HttpNotFound();
            }
            return View(sapnu_puas);
        }

        // POST: sapnu_puas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre_cine,localidad_cine,telefono_cine,nombre_sala,nombre_genero,titulo_pelicula,nombre_protagonista,Periodo,tipo_tarifa,precio,nombre_clasificacion")] sapnu_puas sapnu_puas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sapnu_puas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sapnu_puas);
        }

        // GET: sapnu_puas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sapnu_puas sapnu_puas = db.sapnu_puas.Find(id);
            if (sapnu_puas == null)
            {
                return HttpNotFound();
            }
            return View(sapnu_puas);
        }

        // POST: sapnu_puas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sapnu_puas sapnu_puas = db.sapnu_puas.Find(id);
            db.sapnu_puas.Remove(sapnu_puas);
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

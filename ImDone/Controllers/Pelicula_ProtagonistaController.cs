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
    public class Pelicula_ProtagonistaController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Pelicula_Protagonista
        public ActionResult Index()
        {
            var pelicula_Protagonista = db.Pelicula_Protagonista.Include(p => p.Pelicula).Include(p => p.Protagonista);
            return View(pelicula_Protagonista.ToList());
        }

        // GET: Pelicula_Protagonista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula_Protagonista pelicula_Protagonista = db.Pelicula_Protagonista.Find(id);
            if (pelicula_Protagonista == null)
            {
                return HttpNotFound();
            }
            return View(pelicula_Protagonista);
        }

        // GET: Pelicula_Protagonista/Create
        public ActionResult Create()
        {
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula");
            ViewBag.id_protagonista = new SelectList(db.Protagonista, "id_protagonista", "nombre_protagonista");
            return View();
        }

        // POST: Pelicula_Protagonista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_PP,id_pelicula,id_protagonista,Dummy")] Pelicula_Protagonista pelicula_Protagonista)
        {
            if (ModelState.IsValid)
            {
                db.Pelicula_Protagonista.Add(pelicula_Protagonista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", pelicula_Protagonista.id_pelicula);
            ViewBag.id_protagonista = new SelectList(db.Protagonista, "id_protagonista", "nombre_protagonista", pelicula_Protagonista.id_protagonista);
            return View(pelicula_Protagonista);
        }

        // GET: Pelicula_Protagonista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula_Protagonista pelicula_Protagonista = db.Pelicula_Protagonista.Find(id);
            if (pelicula_Protagonista == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", pelicula_Protagonista.id_pelicula);
            ViewBag.id_protagonista = new SelectList(db.Protagonista, "id_protagonista", "nombre_protagonista", pelicula_Protagonista.id_protagonista);
            return View(pelicula_Protagonista);
        }

        // POST: Pelicula_Protagonista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_PP,id_pelicula,id_protagonista,Dummy")] Pelicula_Protagonista pelicula_Protagonista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula_Protagonista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", pelicula_Protagonista.id_pelicula);
            ViewBag.id_protagonista = new SelectList(db.Protagonista, "id_protagonista", "nombre_protagonista", pelicula_Protagonista.id_protagonista);
            return View(pelicula_Protagonista);
        }

        // GET: Pelicula_Protagonista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula_Protagonista pelicula_Protagonista = db.Pelicula_Protagonista.Find(id);
            if (pelicula_Protagonista == null)
            {
                return HttpNotFound();
            }
            return View(pelicula_Protagonista);
        }

        // POST: Pelicula_Protagonista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula_Protagonista pelicula_Protagonista = db.Pelicula_Protagonista.Find(id);
            db.Pelicula_Protagonista.Remove(pelicula_Protagonista);
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

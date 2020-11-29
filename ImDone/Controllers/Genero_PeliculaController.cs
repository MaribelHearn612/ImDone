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
    public class Genero_PeliculaController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Genero_Pelicula
        public ActionResult Index()
        {
            var genero_Pelicula = db.Genero_Pelicula.Include(g => g.Genero).Include(g => g.Pelicula);
            return View(genero_Pelicula.ToList());
        }

        // GET: Genero_Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero_Pelicula genero_Pelicula = db.Genero_Pelicula.Find(id);
            if (genero_Pelicula == null)
            {
                return HttpNotFound();
            }
            return View(genero_Pelicula);
        }

        // GET: Genero_Pelicula/Create
        public ActionResult Create()
        {
            ViewBag.id_genero = new SelectList(db.Genero, "id_genero", "nombre_genero");
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula");
            return View();
        }

        // POST: Genero_Pelicula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dummy,id_GP,id_pelicula,id_genero")] Genero_Pelicula genero_Pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Genero_Pelicula.Add(genero_Pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_genero = new SelectList(db.Genero, "id_genero", "nombre_genero", genero_Pelicula.id_genero);
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", genero_Pelicula.id_pelicula);
            return View(genero_Pelicula);
        }

        // GET: Genero_Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero_Pelicula genero_Pelicula = db.Genero_Pelicula.Find(id);
            if (genero_Pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_genero = new SelectList(db.Genero, "id_genero", "nombre_genero", genero_Pelicula.id_genero);
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", genero_Pelicula.id_pelicula);
            return View(genero_Pelicula);
        }

        // POST: Genero_Pelicula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dummy,id_GP,id_pelicula,id_genero")] Genero_Pelicula genero_Pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero_Pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_genero = new SelectList(db.Genero, "id_genero", "nombre_genero", genero_Pelicula.id_genero);
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", genero_Pelicula.id_pelicula);
            return View(genero_Pelicula);
        }

        // GET: Genero_Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero_Pelicula genero_Pelicula = db.Genero_Pelicula.Find(id);
            if (genero_Pelicula == null)
            {
                return HttpNotFound();
            }
            return View(genero_Pelicula);
        }

        // POST: Genero_Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero_Pelicula genero_Pelicula = db.Genero_Pelicula.Find(id);
            db.Genero_Pelicula.Remove(genero_Pelicula);
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

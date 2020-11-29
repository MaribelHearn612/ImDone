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
    public class TandasController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Tandas
        public ActionResult Index()
        {
            return View(db.Tanda.ToList());
        }

        // GET: Tandas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanda tanda = db.Tanda.Find(id);
            if (tanda == null)
            {
                return HttpNotFound();
            }
            return View(tanda);
        }

        // GET: Tandas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tandas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tanda,periodo_tanda")] Tanda tanda)
        {
            if (ModelState.IsValid)
            {
                db.Tanda.Add(tanda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tanda);
        }

        // GET: Tandas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanda tanda = db.Tanda.Find(id);
            if (tanda == null)
            {
                return HttpNotFound();
            }
            return View(tanda);
        }

        // POST: Tandas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tanda,periodo_tanda")] Tanda tanda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tanda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tanda);
        }

        // GET: Tandas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tanda tanda = db.Tanda.Find(id);
            if (tanda == null)
            {
                return HttpNotFound();
            }
            return View(tanda);
        }

        // POST: Tandas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tanda tanda = db.Tanda.Find(id);
            db.Tanda.Remove(tanda);
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

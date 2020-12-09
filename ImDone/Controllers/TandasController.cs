using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Index(string Criterio = null)
        {
            return View(db.Tanda.Where(p => Criterio == null || p.periodo_tanda.StartsWith(Criterio) ||
           p.periodo_tanda.StartsWith(Criterio)).ToList());
        }
        public ActionResult exportaExcel()
        {
            string filename = "ExcelR.csv";
            string filepath = @"C:\Users\Monika 2.0\Desktop" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("Servicio,Descripcion,Estado"); //Encabezado 
            foreach (var i in db.Tanda.ToList())
            {
                sw.WriteLine(i.id_tanda.ToString() + "," + i.periodo_tanda.ToString());
            }
            sw.Close();


            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = false,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }

        // GET: Tandas/Details/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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

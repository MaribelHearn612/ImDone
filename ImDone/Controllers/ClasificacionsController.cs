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
    public class ClasificacionsController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Clasificacions
        [Authorize(Roles = "Administrador")]
        public ActionResult Index(string Criterio = null)
        {
            return View(db.Clasificacion.Where(p => Criterio == null || p.nombre_clasificacion.StartsWith(Criterio) ||
           p.nombre_clasificacion.StartsWith(Criterio)).ToList());
        }
        public ActionResult exportaExcel()
        {
            string filename = "ExcelR.csv";
            string filepath = @"C:\Users\Monika 2.0\Desktop" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("Servicio,Descripcion,Estado"); //Encabezado 
            foreach (var i in db.Cine.ToList())
            {
                sw.WriteLine(i.nombre_cine.ToString());
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

        // GET: Clasificacions/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificacion clasificacion = db.Clasificacion.Find(id);
            if (clasificacion == null)
            {
                return HttpNotFound();
            }
            return View(clasificacion);
        }

        // GET: Clasificacions/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clasificacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_clasificacion,nombre_clasificacion")] Clasificacion clasificacion)
        {
            if (ModelState.IsValid)
            {
                db.Clasificacion.Add(clasificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clasificacion);
        }

        // GET: Clasificacions/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificacion clasificacion = db.Clasificacion.Find(id);
            if (clasificacion == null)
            {
                return HttpNotFound();
            }
            return View(clasificacion);
        }

        // POST: Clasificacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_clasificacion,nombre_clasificacion")] Clasificacion clasificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clasificacion);
        }

        // GET: Clasificacions/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clasificacion clasificacion = db.Clasificacion.Find(id);
            if (clasificacion == null)
            {
                return HttpNotFound();
            }
            return View(clasificacion);
        }

        // POST: Clasificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clasificacion clasificacion = db.Clasificacion.Find(id);
            db.Clasificacion.Remove(clasificacion);
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

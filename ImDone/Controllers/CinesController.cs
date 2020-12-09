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
    public class CinesController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Cines
        [Authorize(Roles ="Administrador")]
        public ActionResult Index(string Criterio = null)
        {
            return View(db.Cine.Where(p => Criterio == null || p.nombre_cine.StartsWith(Criterio) ||
           p.localidad_cine.StartsWith(Criterio)).ToList());
        }
        public ActionResult exportaExcel()
        {
            string filename = "ExcelR.csv";
            string filepath = @"C:\Users\Monika 2.0\Desktop" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("Servicio,Descripcion,Estado"); //Encabezado 
            foreach (var i in db.Cine.ToList())
            {
                sw.WriteLine(i.localidad_cine.ToString() + "," + i.nombre_cine.ToString() + "," + i.telefono_cine);
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

        // GET: Cines/Details/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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

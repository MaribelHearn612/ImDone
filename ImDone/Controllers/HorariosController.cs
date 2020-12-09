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
    public class HorariosController : Controller
    {
        private Cines5Entities db = new Cines5Entities();

        // GET: Horarios
        [Authorize(Roles = "Administrador")]
        public ActionResult Index(string Criterio = null)
        {
            return View(db.Horario.Where(p => Criterio == null || p.Tanda.ToString().StartsWith(Criterio) ||
           p.Tanda.ToString().StartsWith(Criterio)).ToList());
        }
        public ActionResult exportaExcel()
        {
            string filename = "ExcelR.csv";
            string filepath = @"C:\Users\Monika 2.0\Desktop" + filename;
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine("Servicio,Descripcion,Estado"); //Encabezado 
            foreach (var i in db.Horario.ToList())
            {
                sw.WriteLine(i.id_tanda.ToString() + "," + i.Tanda.ToString());
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

        // GET: Horarios/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: Horarios/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.id_cine = new SelectList(db.Cine, "id_cine", "nombre_cine");
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula");
            ViewBag.id_sala = new SelectList(db.Sala, "id_sala", "nombre_sala");
            ViewBag.id_tanda = new SelectList(db.Tanda, "id_tanda", "periodo_tanda");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cine,id_pelicula,id_tanda,id_sala")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Horario.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cine = new SelectList(db.Cine, "id_cine", "nombre_cine", horario.id_cine);
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", horario.id_pelicula);
            ViewBag.id_sala = new SelectList(db.Sala, "id_sala", "nombre_sala", horario.id_sala);
            ViewBag.id_tanda = new SelectList(db.Tanda, "id_tanda", "periodo_tanda", horario.id_tanda);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cine = new SelectList(db.Cine, "id_cine", "nombre_cine", horario.id_cine);
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", horario.id_pelicula);
            ViewBag.id_sala = new SelectList(db.Sala, "id_sala", "nombre_sala", horario.id_sala);
            ViewBag.id_tanda = new SelectList(db.Tanda, "id_tanda", "periodo_tanda", horario.id_tanda);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cine,id_pelicula,id_tanda,id_sala")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cine = new SelectList(db.Cine, "id_cine", "nombre_cine", horario.id_cine);
            ViewBag.id_pelicula = new SelectList(db.Pelicula, "id_pelicula", "titulo_pelicula", horario.id_pelicula);
            ViewBag.id_sala = new SelectList(db.Sala, "id_sala", "nombre_sala", horario.id_sala);
            ViewBag.id_tanda = new SelectList(db.Tanda, "id_tanda", "periodo_tanda", horario.id_tanda);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horario.Find(id);
            db.Horario.Remove(horario);
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

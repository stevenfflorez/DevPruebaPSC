using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevPruebaPSC.Models;

namespace DevPruebaPSC.Controllers
{
    public class MarcasController : Controller
    {
        private pruebaDevEntities1 db = new pruebaDevEntities1();

        // GET: Marcas -> lista de marcas
        public ActionResult Brand()
        {
            try
            {
                return View(db.Marcas.ToList());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar las marcas: " + ex.Message;
                return View(new List<Marca>());
            }
        }

        // GET: Marcas -> redirige a Brand
        public ActionResult Index()
        {
            return RedirectToAction("Brand");
        }

        // Details (por compatibilidad)
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Marca marca = db.Marcas.Find(id);
            if (marca == null)
                return HttpNotFound();

            return View(marca);
        }

        // POST: Marcas/Create (llamado desde el modal agregar marca)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "marcaId,nombre")] Marca marca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Marcas.Add(marca);
                    db.SaveChanges();
                    TempData["Exito"] = "Marca agregada exitosamente.";
                    return RedirectToAction("Brand");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al agregar la marca: " + ex.Message;
            }

            return RedirectToAction("Brand");
        }

        // POST: Marcas/Edit (llamado desde el modal editar marca)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "marcaId,nombre")] Marca marca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(marca).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Exito"] = "Marca editada exitosamente.";
                    return RedirectToAction("Brand");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al editar la marca: " + ex.Message;
            }

            return RedirectToAction("Brand");
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

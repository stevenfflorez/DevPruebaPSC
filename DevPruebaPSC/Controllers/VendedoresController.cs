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
    public class VendedoresController : Controller
    {
        private pruebaDevEntities1 db = new pruebaDevEntities1();

        // GET: Vendedores -> lista principal
        public ActionResult Sellers()
        {
            return View(db.Vendedores.ToList());
        }

        // GET: Vendedores -> redirige a Sellers por compatibilidad
        public ActionResult Index()
        {
            return RedirectToAction("Sellers");
        }

        // GET: Vendedores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedore vendedore = db.Vendedores.Find(id);
            if (vendedore == null)
            {
                return HttpNotFound();
            }
            return View(vendedore);
        }

        // POST: Vendedores/Create (llamado desde el modal agregar vendedor)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nombre,apellido,telefono,email")] Vendedore vendedore)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Vendedores.Add(vendedore);
                    db.SaveChanges();
                    TempData["Exito"] = "Vendedor agregado exitosamente.";
                    return RedirectToAction("Sellers");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el vendedor: " + ex.Message);
            }
            return RedirectToAction("Sellers");
        }

        // POST: Vendedores/Edit (llamado desde el modal editar vendedor)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nombre,apellido,telefono,email")] Vendedore vendedore)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(vendedore).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Exito"] = "Vendedor actualizado exitosamente.";
                    return RedirectToAction("Sellers");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar el vendedor: " + ex.Message);
            }

            return RedirectToAction("Sellers");
        }

        // POST: Vendedores/Delete (llamado desde el modal eliminar vendedor)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Vendedore vendedore = db.Vendedores.Find(id);
                if (vendedore != null)
                {
                    db.Vendedores.Remove(vendedore);
                    db.SaveChanges();
                    TempData["Exito"] = "Vendedor eliminado exitosamente.";
                }
                else
                {
                    TempData["Error"] = "Vendedor no encontrado.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar el vendedor: " + ex.Message;
            }

            return RedirectToAction("Sellers");
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

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
    public class VentasController : Controller
    {
        private pruebaDevEntities1 db = new pruebaDevEntities1();

        // GET: Ventas/Sales -> lista de ventas con barra de búsqueda por cédula
        public ActionResult Sales(string searchCedula)
        {
            try
            {
                ViewBag.SearchCedula = searchCedula;

                IQueryable<Venta> consulta = db.Ventas
                    .Include(v => v.Vehiculo)
                    .Include(v => v.Vendedore);

                if (!String.IsNullOrEmpty(searchCedula))
                {
                    consulta = consulta.Where(s => s.cedula.Contains(searchCedula));
                }

                return View(consulta.ToList());
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al cargar las ventas: " + ex.Message;
                return View(new List<Venta>());
            }
        }

        // GET: Ventas/Details (solo por compatibilidad)
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Venta venta = db.Ventas.Find(id);
            if (venta == null)
                return HttpNotFound();

            return View(venta);
        }

        // POST: Ventas/Delete (llamada desde el modal de eliminar venta)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Venta venta = db.Ventas.Find(id);
                if (venta != null)
                {
                    db.Ventas.Remove(venta);
                    db.SaveChanges();
                    TempData["Exito"] = $"Venta #{id} eliminada correctamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error al eliminar la venta: " + ex.Message;
            }

            return RedirectToAction("Sales");
        }

        // Stored Procedure: Vehículos vendidos por vendedor (por cédula)
        // GET: Ventas/VehXVendedor
        public ActionResult VehiculosPorVendedor(string cedula)
        {
            try
            {
                if (string.IsNullOrEmpty(cedula))
                    return Json(new { error = "Debe ingresar una cédula." }, JsonRequestBehavior.AllowGet);

                // Llama al SP importado en el .edmx (ajusta el nombre si lo importaste diferente)
                var vehiculos = db.sp_VehXVendedor(cedula).ToList();

                if (!vehiculos.Any())
                    return Json(new { error = "No se encontraron vehículos vendidos para esa cédula." }, JsonRequestBehavior.AllowGet);

                var resultado = vehiculos.Select(v => new
                {
                    ventaId = v.ventaId,
                    fechaVenta = v.fechaVenta.ToString("dd/MM/yyyy"),
                    vehiculoId = v.vehiculoId,
                    marca = v.nombre,
                    modelo = v.modelo,
                    anio = v.anio,
                    precio = v.precio
                });

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Error al ejecutar el SP: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
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

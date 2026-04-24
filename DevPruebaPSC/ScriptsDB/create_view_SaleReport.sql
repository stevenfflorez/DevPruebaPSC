-- ==========================================================
-- PSC - Prueba 
-- Este script crea la vista ReporteVentas en la base de datos 
-- pruebaDev, que muestra un reporte detallado de las ventas 
-- realizadas, incluyendo información del vendedor, el vehículo 
-- vendido y su marca.
-- Autor: Wilson Florez
-- Fecha: 2024-04-22
-- ==========================================================

create view dbo.vw_ReporteVentas as
select v.ventaId, v.fechaVenta, ve.cedula, ve.nombre + ' ' + ve.apellido as Vendedor, 
	v.precioTotal, m.nombre as Marca, vh.modelo, vh.anio
from dbo.Ventas v
join dbo.Vendedores ve on v.cedula = ve.cedula
join dbo.Vehiculos vh on v.vehiculoId = vh.vehiculoId
join dbo.Marcas m on vh.marcaId = m.marcaId;
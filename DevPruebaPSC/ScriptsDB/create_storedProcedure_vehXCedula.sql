-- ==========================================================
-- PSC - Prueba 
-- Este script crea la vista ReporteVentas en la base de datos 
-- pruebaDev, que muestra un reporte detallado de las ventas 
-- realizadas, incluyendo información del vendedor, el vehículo 
-- vendido y su marca.
-- Autor: Wilson Florez
-- Fecha: 2024-04-22
-- ==========================================================

create procedure dbo.sp_VehXVendedor
	@cedula varchar(50)
as
begin
	select v.ventaId, v.fechaVenta, vh.vehiculoId, m.nombre, vh.modelo, vh.anio, vh.precio
	from dbo.Ventas v
	join dbo.Vehiculos vh on v.vehiculoId = vh.vehiculoId
	join dbo.Marcas m on vh.marcaId = m.marcaId
	where v.cedula = @cedula;
end
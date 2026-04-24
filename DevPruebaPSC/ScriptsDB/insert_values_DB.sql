-- ==========================================================
-- PSC - Prueba 
-- Este script inserta datos de ejemplo en las tablas Marcas, 
-- Vehiculos, Vendedores y Ventas de la base de datos pruebaDev.
-- Autor: Wilson Florez
-- Fecha: 2024-04-22
-- ==========================================================

use pruebaDev;

insert into dbo.Marcas (nombre) values 
	('Renault'), ('BYD'),
	('Chevrolet'), ('Volkswagen'),
	('Ford'), ('Mazda');

insert into dbo.Vehiculos (marcaId, modelo, anio, precio) values 
	(1, 'Logan', 2020, 48000000.00),
	(1, 'Sandero', 2021, 55000000.00),
	(2, 'Denza X', 2022, 120000000.00),
	(2, 'Han EV', 2021, 110000000.00),
	(3, 'Onix', 2020, 60000000.00),
	(3, 'Sail', 2019, 40000000.00),
	(4, 'Gol', 2019, 45000000.00),
	(4, 'Polo', 2020, 50000000.00),
	(5, 'Ranger', 2021, 90000000.00),
	(5, 'Mustang', 2020, 150000000.00),
	(6, 'CX-3', 2019, 75000000.00),
	(6, 'CX-5', 2020, 85000000.00);

insert into dbo.Vendedores (cedula, nombre, apellido, telefono, email) values 
	('1234567890', 'Juan', 'Perez', '3001234567', 'juan.perez@example.com'),
	('9876543210', 'Maria', 'Gomez', '3009876543', 'maria.gomez@example.com'),
	('1122334455', 'Carlos', 'Lopez', '3001122334', 'carlos.lopez@example.com'),
	('5566778899', 'Ana', 'Martinez', '3005566778', 'ana.martinez@example.com');

insert into dbo.Ventas (vehiculoId, cedula, fechaVenta, precioTotal) values 
	(1, '1234567890', '2023-01-15', 48000000.00),
	(2, '9876543210', '2023-02-20', 55000000.00),
	(3, '1122334455', '2023-03-10', 120000000.00),
	(4, '5566778899', '2023-04-05', 110000000.00),
	(5, '1234567890', '2023-05-12', 60000000.00),
	(6, '9876543210', '2023-06-18', 40000000.00);
-- ==========================================================
-- PSC - Prueba 
-- Este script crea las tablas Marcas, Vehiculos, Vendedores y Ventas 
-- en la base de datos pruebaDev, estableciendo las relaciones entre ellas.
-- Autor: Wilson Florez
-- Fecha: 2024-04-22
-- ==========================================================

use pruebaDev;

create table dbo.Marcas
(
	marcaId int identity(1,1) primary key,
	nombre varchar(50) not null
);

create table dbo.Vehiculos
(
	vehiculoId int identity(1,1) primary key,
	marcaId int not null,
	modelo varchar(50) not null,
	anio int not null,
	precio decimal(18, 2) not null,
	foreign key (marcaId) references dbo.Marcas(marcaId)
);

create table dbo.Vendedores
(
	cedula varchar(50) primary key,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	telefono varchar(20) not null,
	email varchar(100) not null
);

create table dbo.Ventas
(
	ventaId int identity(1,1) primary key,
	vehiculoId int not null,
	cedula varchar(50) not null,
	fechaVenta datetime not null default getdate(),
	precioTotal decimal(18, 2) not null,
	foreign key (vehiculoId) references dbo.Vehiculos(vehiculoId),
	foreign key (cedula) references dbo.Vendedores(cedula)
);


CREATE DATABASE NETJACKET2
GO

USE NETJACKET2
GO

CREATE TABLE Vehiculos (
  Placa varchar(10) primary key NOT NULL,
  Vehiculo varchar(30) NOT NULL,
  Marca varchar(30) NOT NULL,
  Modelo int NOT NULL,
  Capacidad varchar(10) NOT NULL,
  Tipo varchar(30) NOT NULL,
  Color varchar(30) NOT NULL,
  Servicio varchar(30) NOT NULL,
  Linea varchar(30) NOT NULL,
  Motor varchar(10) NOT NULL,
  Chasis varchar(30) NOT NULL,
  Serie varchar(20) NOT NULL,
  Empresa varchar(30) NOT NULL,
  Matricula varchar(7) NOT NULL,
  Kilometraje varchar(20) NOT NULL,
  Cilindraje varchar(20) NOT NULL,
  Combustible varchar(30) NOT NULL,
  Traccion varchar(6) NOT NULL,
  Soat varchar(30) NOT NULL,
  Tecnomecanica varchar(30) NOT NULL,
  Correadentada varchar(30) NOT NULL,
);
GO


CREATE TABLE Compras(
	Idcompra INT IDENTITY PRIMARY KEY,
	Fechacompra DATETIME NOT NULL DEFAULT GETDATE(),
	Preciocompra INT NOT NULL,
	MPcompra VARCHAR(30) NOT NULL,
	Limitacionescompra VARCHAR(500) NULL,
	Ciudadcompra VARCHAR(30) NOT NULL, 
	SPcompra INT NOT NULL,
	Placacompra varchar(10) NOT NULL,	
	foreign key (Placacompra) references Vehiculos (Placa)
);
GO

CREATE TABLE Ventas(
	Idventa INT IDENTITY PRIMARY KEY,
	Fechaventa DATETIME NOT NULL DEFAULT GETDATE(),
	Precioventa INT NOT NULL,
	MPventa VARCHAR(30) NOT NULL,
	Limitacionesventa VARCHAR(500) NULL,
	Ciudadventa VARCHAR(30) NOT NULL, 
	SPventa INT NOT NULL,
	Placaventa varchar(10) NOT NULL,	
	foreign key (Placaventa) references Vehiculos (Placa)
);
GO

BEGIN TRANSACTION

CREATE TABLE cheshire_jack.usuarios (
	codUsuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	nombreUsuario VARCHAR(50) NOT NULL,
	contrasenia CHAR(256) NOT NULL,
	habilitado BIT NOT NULL DEFAULT(1),
	ingresosRestantes TINYINT NOT NULL DEFAULT(3),
	tipo varchar(255) DEFAULT(NULL)
	)

CREATE TABLE cheshire_jack.roles (
	codRol INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(255) NOT NULL,
	habilitado bit NOT NULL DEFAULT(1)
	)

CREATE TABLE cheshire_jack.funcionalidades (
	codFuncionalidad INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	descripcion varchar(255) NOT NULL
	)

CREATE TABLE cheshire_jack.publicaciones (
	codPublicacion NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	grado CHAR(1) NOT NULL,
	codEspectaculo NUMERIC(18,0) NOT NULL,
	estado VARCHAR(255) NOT NULL,
	fecha DATETIME NOT NULL,
	fechaVencimiento DATETIME NOT NULL,
	CHECK(fecha < fechaVencimiento)
	)

CREATE TABLE cheshire_jack.espectaculos (
	codEspectaculo NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	codUsuario INT NOT NULL,
	descripcion varchar(255) NOT NULL,
	codRubro INT NOT NULL
	)

CREATE TABLE cheshire_jack.rubros (
	codRubro INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(255) NOT NULL
	)

CREATE TABLE cheshire_jack.ubicaciones (
	codUbicacion NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	codPublicacion NUMERIC (18,0) NOT NULL,
	fila CHAR(3) NOT NULL,
	asiento SMALLINT NOT NULL,
	sinNumerar BIT NOT NULL DEFAULT(0),
	precio NUMERIC(18,2) NOT NULL,
	codTipo INT NOT NULL
	)

CREATE TABLE cheshire_jack.tiposUbicaciones (
	codTipo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(255) NOT NULL
	)

CREATE TABLE cheshire_jack.clientes (
	codCliente INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	tipoDocumento VARCHAR(255) NOT NULL,
	nroDocumento NUMERIC(18,0) NOT NULL,
	CUIL CHAR(14) NOT NULL,
	apellido VARCHAR(255) NOT NULL,
	nombre VARCHAR(255) NOT NULL,
	fechaNacimiento DATE NOT NULL,
	mail VARCHAR(255) CHECK(mail LIKE '%@%'),
	telefono CHAR(13),
	localidad VARCHAR(255) NOT NULL,
	domicilioCalle VARCHAR(255) NOT NULL,
	nroCalle INT NOT NULL CHECK(nroCalle > 0),
	piso TINYINT,
	dept VARCHAR(50),
	codigoPostal VARCHAR(25),
	codUsuario INT
	)

CREATE TABLE cheshire_jack.empresas (
	codEmpresa INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	razonSocial VARCHAR(255) NOT NULL,
	CUIT CHAR(14) NOT NULL,
	fechaCreacion DATE,
	mail VARCHAR(255) CHECK(mail LIKE '%@%'),
	telefono char(13),
	ciudad VARCHAR(255) NOT NULL,
	domicilioCalle VARCHAR(255) NOT NULL,
	nroCalle INT NOT NULL CHECK(nroCalle > 0),
	piso TINYINT,
	dept VARCHAR(50),
	codigoPostal VARCHAR(25),
	codUsuario INT
	)

CREATE TABLE cheshire_jack.compras (
	codCompra NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	codCliente INT NOT NULL,
	fecha DATETIME NOT NULL,
	codPublicacion NUMERIC(18,0) NOT NULL,
	metodoPago VARCHAR(255) NOT NULL,
	codMetodo NUMERIC(18,0) DEFAULT(NULL)
	)

CREATE TABLE cheshire_jack.facturas (
	nroFactura NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	codCompra NUMERIC(18,0) NOT NULL,
	fecha DATETIME NOT NULL,
	total NUMERIC(18,2) NOT NULL,
	formaPago VARCHAR(255) NOT NULL
	)

CREATE TABLE cheshire_jack.items (
	codItem TINYINT NOT NULL,
	codCompra NUMERIC(18,0) NOT NULL,
	monto NUMERIC(18,2) NOT NULL check(monto > 0),
	cantidad SMALLINT NOT NULL check(cantidad > 0),
	PRIMARY KEY(codItem, codCompra)
	)

CREATE TABLE cheshire_jack.puntos (
	codPuntos INT NOT NULL identity(1,1),
	codCliente INT NOT NULL,
	cantidad NUMERIC(16,0) NOT NULL,
	fechaVencimiento DATE NOT NULL,
	PRIMARY KEY(codPuntos, codCliente) 
	)

CREATE TABLE cheshire_jack.usuariosXRoles (
	codUsuario INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.usuarios(codUsuario),
	codRol INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.roles(codRol),
	PRIMARY KEY(codUsuario, codRol)
	)

CREATE TABLE cheshire_jack.RolesxFuncionalidades (
	codRol INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.roles(codRol),
	codFuncionalidad INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.funcionalidades(codFuncionalidad),
	PRIMARY KEY(codRol, codFuncionalidad)
	)

ALTER TABLE cheshire_jack.clientes
ADD FOREIGN KEY (codUsuario) REFERENCES cheshire_jack.usuarios(codUsuario)

ALTER TABLE cheshire_jack.empresas
ADD FOREIGN KEY (codUsuario) REFERENCES cheshire_jack.usuarios(codUsuario)

ALTER TABLE cheshire_jack.publicaciones
ADD FOREIGN KEY (codEspectaculo) REFERENCES cheshire_jack.espectaculos(codEspectaculo)

ALTER TABLE cheshire_jack.espectaculos
ADD FOREIGN KEY (codRubro) REFERENCES cheshire_jack.rubros(codRubro)

ALTER TABLE cheshire_jack.ubicaciones
ADD FOREIGN KEY (codPublicacion) REFERENCES cheshire_jack.publicaciones(codpublicacion)

ALTER TABLE cheshire_jack.ubicaciones
ADD FOREIGN KEY (codTipo) REFERENCES cheshire_jack.tiposUbicaciones(codTipo)

ALTER TABLE cheshire_jack.puntos
ADD FOREIGN KEY (codCliente) REFERENCES cheshire_jack.clientes(codCliente)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (codCliente) REFERENCES cheshire_jack.clientes(codCliente)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (codPublicacion) REFERENCES cheshire_jack.publicaciones(codPublicacion)

ALTER TABLE cheshire_jack.facturas
ADD FOREIGN KEY (codCompra) REFERENCES cheshire_jack.compras(codCompra)

ALTER TABLE cheshire_jack.items
ADD FOREIGN KEY (codCompra) REFERENCES cheshire_jack.compras(codCompra)

ROLLBACK
USE GD2C2018
GO

CREATE SCHEMA cheshire_jack
GO

CREATE TABLE cheshire_jack.usuarios (
	cod_usuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	nombre_usuario VARCHAR(50) NOT NULL,
	contrasenia CHAR(256) NOT NULL,
	habilitado BIT NOT NULL DEFAULT(1),
	ingresos_restantes TINYINT NOT NULL DEFAULT(3),
	tipo varchar(255) DEFAULT(NULL),
	contrasenia_automatica BIT NOT NULL DEFAULT(1)
	)

CREATE TABLE cheshire_jack.roles (
	cod_rol INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(255) NOT NULL,
	habilitado BIT NOT NULL DEFAULT(1),
	registrable BIT NOT NULL
	)

CREATE TABLE cheshire_jack.funcionalidades (
	cod_funcionalidad INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	descripcion varchar(255) NOT NULL
	)

CREATE TABLE cheshire_jack.grados (
	cod_grado TINYINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre CHAR(5) NOT NULL,
	comision NUMERIC(2,2) NOT NULL,
	peso TINYINT NOT NULL
	)

CREATE TABLE cheshire_jack.estados (
	cod_estado TINYINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre CHAR(10) NOT NULL
	)

CREATE TABLE cheshire_jack.publicaciones (
	cod_publicacion NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	cod_grado TINYINT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.grados(cod_grado),
	cod_espectaculo NUMERIC(18,0) NOT NULL,
	cod_estado TINYINT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.estados(cod_estado),
	fecha_evento DATETIME NOT NULL,
	fecha_vencimiento DATETIME,
	fecha_publicacion DATETIME,
	CHECK(fecha_publicacion < fecha_evento)
	)


CREATE TABLE cheshire_jack.espectaculos (
	cod_espectaculo NUMERIC(18,0) PRIMARY KEY NOT NULL IDENTITY(1,1),
	cod_empresa INT NOT NULL,
	descripcion VARCHAR(255) NOT NULL,
	cod_rubro INT NOT NULL,
	direccion VARCHAR(50) NOT NULL,
	altura NUMERIC(18,0) NOT NULL,
	cod_espectaculo_viejo NUMERIC(18,0)
	)

CREATE TABLE cheshire_jack.rubros (
	cod_rubro INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(255) NOT NULL
	)

CREATE TABLE cheshire_jack.ubicaciones (
	cod_ubicacion NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	cod_publicacion NUMERIC (18,0) NOT NULL,
	fila CHAR(3) NOT NULL,
	asiento NUMERIC(18,0) NOT NULL,
	sin_numerar BIT NOT NULL DEFAULT(0),
	precio NUMERIC(18,0) NOT NULL CHECK(precio > 0),
	cod_tipo INT NOT NULL,
	disponible BIT NOT NULL DEFAULT(1)
	)

CREATE TABLE cheshire_jack.tipos_de_ubicacion (
	cod_tipo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(255) NOT NULL,
	cod_tipo_viejo NUMERIC(18,0)
	)

CREATE TABLE cheshire_jack.clientes (
	cod_cliente INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	tipo_documento VARCHAR(255) NOT NULL,
	nro_documento NUMERIC(18,0) NOT NULL,
	CUIL CHAR(14),
	apellido VARCHAR(255) NOT NULL,
	nombre VARCHAR(255) NOT NULL,
	fecha_nacimiento DATE NOT NULL,
	mail VARCHAR(255) CHECK(mail LIKE '_%@_%._%') NOT NULL,
	telefono CHAR(14),
	localidad VARCHAR(255),
	domicilio_calle VARCHAR(255) NOT NULL,
	nro_calle NUMERIC(18,0) NOT NULL CHECK(nro_calle > 0),
	piso TINYINT,
	dept VARCHAR(50),
	codigo_postal VARCHAR(25),
	fecha_creacion DATETIME,
	cod_usuario INT
	)

CREATE TABLE cheshire_jack.empresas (
	cod_empresa INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	razon_social VARCHAR(255) NOT NULL,
	CUIT CHAR(14) NOT NULL,
	fecha_creacion DATE,
	mail VARCHAR(255) CHECK(mail LIKE '_%@_%._%'),
	telefono char(14),
	ciudad VARCHAR(255),
	domicilio_calle VARCHAR(255) NOT NULL,
	nro_calle INT NOT NULL CHECK(nro_calle > 0),
	piso TINYINT,
	dept VARCHAR(50),
	codigo_postal VARCHAR(25),
	cod_usuario INT
	)
		
CREATE TABLE cheshire_jack.compras (
	cod_compra NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	cod_cliente INT NOT NULL,
	nro_factura NUMERIC(18,0),
	fecha DATETIME NOT NULL,
	cod_publicacion NUMERIC(18,0) NOT NULL,
	metodo_pago VARCHAR(255) NOT NULL,
	cod_metodo NUMERIC(18,0) DEFAULT(NULL)
	)

CREATE TABLE cheshire_jack.facturas (
	nro_factura NUMERIC(18,0) PRIMARY KEY NOT NULL,
	fecha DATETIME NOT NULL,
	total NUMERIC(18,2) NOT NULL,
	forma_pago VARCHAR(255) NOT NULL
	)

CREATE TABLE cheshire_jack.items (
	cod_item TINYINT NOT NULL,
	cod_compra NUMERIC(18,0) NOT NULL,
	cantidad NUMERIC(18,0) DEFAULT(1) CHECK(cantidad > 0),
	monto NUMERIC(18,2) NOT NULL CHECK(monto > 0),
	comision NUMERIC(18,2) NOT NULL CHECK(comision > 0),
	descripcion VARCHAR(255),
	PRIMARY KEY(cod_item, cod_compra)
	)

CREATE TABLE cheshire_jack.puntos (
	anio_vencimiento INT NOT NULL,
	cod_cliente INT NOT NULL,
	cantidad NUMERIC(18,0) NOT NULL,
	PRIMARY KEY(anio_vencimiento, cod_cliente) 
	)

CREATE TABLE cheshire_jack.premios (
	cod_premio INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	nombre VARCHAR(50) NOT NULL,
	descripcion VARCHAR(255),
	stock INT DEFAULT(0) NOT NULL,
	valor NUMERIC(18,0) NOT NULL
	)

CREATE TABLE cheshire_jack.canjes (
	cod_usuario INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.usuarios(cod_Usuario),
	cod_premio INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.premios(cod_premio),
	PRIMARY KEY(cod_usuario, cod_premio)
	)

CREATE TABLE cheshire_jack.tarjetas_de_credito (
	cod_tarjeta NUMERIC(18,0) NOT NULL IDENTITY(1,1),
	cod_cliente INT NOT NULL,
	hash_nro_tarjeta char(256) NOT NULL,
	ultimos_digitos char(4) NOT NULL,
	cod_seguridad char(4) NOT NULL
	)

CREATE TABLE cheshire_jack.usuariosXRoles (
	cod_usuario INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.usuarios(cod_Usuario),
	cod_rol INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.roles(cod_rol),
	PRIMARY KEY(cod_usuario, cod_rol)
	)

CREATE TABLE cheshire_jack.RolesxFuncionalidades (
	cod_rol INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.roles(cod_rol),
	cod_funcionalidad INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.funcionalidades(cod_funcionalidad),
	PRIMARY KEY(cod_rol, cod_funcionalidad)
	)

ALTER TABLE cheshire_jack.clientes
ADD FOREIGN KEY (cod_usuario) REFERENCES cheshire_jack.usuarios(cod_usuario)

ALTER TABLE cheshire_jack.empresas
ADD FOREIGN KEY (cod_usuario) REFERENCES cheshire_jack.usuarios(cod_usuario)

ALTER TABLE cheshire_jack.publicaciones
ADD FOREIGN KEY (cod_espectaculo) REFERENCES cheshire_jack.espectaculos(cod_espectaculo)

ALTER TABLE cheshire_jack.espectaculos
ADD FOREIGN KEY (cod_rubro) REFERENCES cheshire_jack.rubros(cod_rubro)

ALTER TABLE cheshire_jack.ubicaciones
ADD FOREIGN KEY (cod_publicacion) REFERENCES cheshire_jack.publicaciones(cod_publicacion)

ALTER TABLE cheshire_jack.ubicaciones
ADD FOREIGN KEY (cod_tipo) REFERENCES cheshire_jack.tipos_de_ubicacion(cod_tipo)

ALTER TABLE cheshire_jack.puntos
ADD FOREIGN KEY (cod_cliente) REFERENCES cheshire_jack.clientes(cod_cliente)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (cod_cliente) REFERENCES cheshire_jack.clientes(cod_cliente)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (cod_publicacion) REFERENCES cheshire_jack.publicaciones(cod_publicacion)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (nro_factura) REFERENCES cheshire_jack.facturas(nro_factura)

ALTER TABLE cheshire_jack.items
ADD FOREIGN KEY (cod_compra) REFERENCES cheshire_jack.compras(cod_compra)

ALTER TABLE cheshire_jack.tarjetas_de_credito
ADD FOREIGN KEY (cod_cliente) REFERENCES cheshire_jack.clientes(cod_cliente)

INSERT INTO cheshire_jack.grados
(nombre, comision, peso)
VALUES ('Baja', 0.05, 1)

INSERT INTO cheshire_jack.grados
(nombre, comision, peso)
VALUES ('Media', 0.1, 2)

INSERT INTO cheshire_jack.grados
(nombre, comision, peso)
VALUES ('Alta', 0.2, 3)

INSERT INTO cheshire_jack.grados
(nombre, comision, peso) 
VALUES ('S.D.', 0.0, 0)

INSERT INTO cheshire_jack.estados
(nombre) VALUES ('Borrador')

INSERT INTO cheshire_jack.estados
(nombre) VALUES ('Publicada')

INSERT INTO cheshire_jack.estados
(nombre) VALUES ('Finalizada')

INSERT INTO cheshire_jack.estados
(nombre) VALUES ('Pausada')

INSERT INTO cheshire_jack.empresas 
(razon_social, CUIT, fecha_creacion, mail, 
domicilio_calle, nro_calle, piso, dept, codigo_postal)
SELECT DISTINCT Espec_Empresa_Razon_Social, Espec_Empresa_Cuit, Espec_Empresa_Fecha_Creacion, Espec_Empresa_Mail, 
				Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, Espec_Empresa_Piso, Espec_Empresa_Depto, Espec_Empresa_Cod_Postal
FROM gd_esquema.Maestra

INSERT INTO cheshire_jack.clientes
(nombre, apellido, fecha_nacimiento, tipo_documento, nro_documento, 
mail, domicilio_calle, nro_calle, piso, dept, codigo_postal)
SELECT DISTINCT Cli_Nombre, Cli_Apeliido, Cli_Fecha_Nac, 'DNI', Cli_Dni, 
				Cli_Mail, Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, Cli_Cod_Postal
FROM gd_esquema.Maestra
WHERE Cli_Nombre IS NOT NULL

INSERT INTO cheshire_jack.rubros
(descripcion)
SELECT DISTINCT Espectaculo_Rubro_Descripcion 
FROM gd_esquema.Maestra

INSERT INTO cheshire_jack.espectaculos
(descripcion, cod_empresa, cod_rubro, cod_espectaculo_viejo, direccion, altura)
SELECT DISTINCT Espectaculo_Descripcion, 
				(SELECT cod_empresa FROM cheshire_jack.empresas E WHERE E.CUIT = M.Espec_Empresa_Cuit), 
				(SELECT cod_rubro FROM cheshire_jack.rubros R WHERE R.descripcion = M.Espectaculo_Rubro_Descripcion),
				Espectaculo_Cod,
				'S.D',
				0
FROM gd_esquema.Maestra M
WHERE Espectaculo_Cod IS NOT NULL

INSERT INTO cheshire_jack.publicaciones
(cod_grado, cod_espectaculo, cod_estado, fecha_evento, fecha_vencimiento)
SELECT DISTINCT (SELECT cod_grado FROM cheshire_jack.grados WHERE nombre = 'S.D.'), 
				(SELECT cod_espectaculo FROM cheshire_jack.espectaculos E WHERE M.Espectaculo_Cod = E.cod_espectaculo_viejo),
				(SELECT cod_estado FROM cheshire_jack.estados WHERE nombre = 'Publicada'), 
				Espectaculo_Fecha,
				Espectaculo_Fecha_Venc
FROM gd_esquema.Maestra M
WHERE Espectaculo_Cod IS NOT NULL

INSERT INTO cheshire_jack.tipos_de_ubicacion
(descripcion, cod_tipo_viejo)
SELECT DISTINCT Ubicacion_Tipo_Descripcion,
				Ubicacion_Tipo_Codigo
FROM gd_esquema.Maestra
WHERE Ubicacion_Tipo_Codigo IS NOT NULL

INSERT INTO cheshire_jack.ubicaciones
(asiento, fila, sin_numerar, precio, cod_tipo, cod_publicacion)
SELECT DISTINCT Ubicacion_Asiento, 
				Ubicacion_Fila, 
				Ubicacion_Sin_numerar, 
				Ubicacion_Precio,
				(SELECT cod_tipo FROM cheshire_jack.tipos_de_ubicacion TU WHERE TU.cod_tipo_viejo = M.Ubicacion_Tipo_Codigo),
				(SELECT cod_publicacion FROM cheshire_jack.publicaciones P JOIN cheshire_jack.espectaculos E ON P.cod_espectaculo = E.cod_espectaculo WHERE M.espectaculo_cod = E.cod_espectaculo_viejo)
FROM gd_esquema.Maestra M
WHERE Espectaculo_Cod IS NOT NULL

INSERT INTO cheshire_jack.roles
(descripcion, registrable)
VALUES
('Cliente', 1)

INSERT INTO cheshire_jack.roles
(descripcion, registrable)
VALUES
('Empresa de Espectaculos', 1)

INSERT INTO cheshire_jack.roles
(descripcion, registrable)
VALUES
('Administrador', 0)

GO
CREATE PROCEDURE cheshire_jack.mover_compras_de_maestra
AS
BEGIN
	DECLARE cursorCompra CURSOR FOR
	SELECT DISTINCT (SELECT cod_cliente FROM GD2C2018.cheshire_jack.clientes C WHERE M.Cli_Dni = C.nro_documento),
				(SELECT cod_publicacion FROM GD2C2018.cheshire_jack.publicaciones P JOIN GD2C2018.cheshire_jack.espectaculos E ON P.cod_espectaculo = E.cod_espectaculo WHERE M.espectaculo_cod = E.cod_espectaculo_viejo),
				Compra_Fecha,
				Factura_Nro,
				Factura_Fecha,
				Factura_Total,
				Forma_Pago_Desc
	FROM GD2C2018.gd_esquema.Maestra M
	WHERE M.Factura_Nro IS NOT NULL

	DECLARE @cod_cliente INT, @cod_publicacion NUMERIC(18,0), @fechaCompra DATETIME, 
		@nroFactura NUMERIC(18,0), @fechaFactura DATETIME, @totalFactura NUMERIC(18,2), 
		@formaPago VARCHAR(255), @ultimoCodFactura NUMERIC(18,0), @ultimoCodCompra NUMERIC(18,0)

	DECLARE cursorItem CURSOR FOR
	SELECT DISTINCT Item_Factura_Monto,
					Item_Factura_Cantidad,
					Item_Factura_Descripcion
	FROM GD2C2018.gd_esquema.Maestra
	WHERE @ultimoCodFactura = Factura_Nro

	DECLARE @itemMonto NUMERIC(18,0), @itemCantidad NUMERIC(18,0), @itemDescripcion VARCHAR(255), @curItem TINYINT

	OPEN cursorCompra

	FETCH NEXT FROM cursorCompra INTO @cod_cliente, @cod_publicacion, @fechaCompra, 
								@nroFactura, @fechaFactura, @totalFactura, @formaPago 
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO GD2C2018.cheshire_jack.facturas
		(fecha, forma_pago, nro_factura, total)
		VALUES 
		(@fechaFactura, @formaPago, @nroFactura, @totalFactura)

		INSERT INTO GD2C2018.cheshire_jack.compras
		(cod_cliente, cod_publicacion, fecha, metodo_pago, nro_factura)
		VALUES
		(@cod_cliente, @cod_publicacion, @fechaCompra, NULL, @ultimoCodFactura)

		SET @ultimoCodCompra = SCOPE_IDENTITY()
		SET @curItem = 1

		OPEN cursorItem

		FETCH NEXT FROM cursorItem INTO @itemMonto, @itemCantidad, @itemDescripcion
		WHILE @@FETCH_STATUS = 0
		BEGIN	
			INSERT INTO GD2C2018.cheshire_jack.items
			(cod_item, cod_compra, comision, monto, cantidad, descripcion)
			VALUES (@curItem, @ultimoCodCompra, 0, @itemMonto, @itemCantidad, @itemDescripcion)
			
			SET @curItem = @curItem + 1
		END

		CLOSE cursorItem
	
		FETCH NEXT FROM cursorCompra INTO @cod_cliente, @cod_publicacion, @fechaCompra, 
									@nroFactura, @fechaFactura, @totalFactura, @formaPago 
	END

	DEALLOCATE cursorItem
	CLOSE cursorCompra
	DEALLOCATE cursorCompra
END

GO
EXEC cheshire_jack.mover_compras_de_maestra

DROP PROCEDURE cheshire_jack.mover_compras_de_maestra

GO
CREATE PROCEDURE cheshire_jack.modificar_puntos 
(@cod_cliente INT, @cantidad NUMERIC(18,0), @fecha_actual DATE)
AS
BEGIN
	DECLARE @anio_vencimiento_max INT
	SELECT @anio_vencimiento_max = MAX(@cod_cliente) FROM GD2C2018.cheshire_jack.puntos WHERE @cod_cliente = cod_cliente
	
	IF EXISTS (SELECT * FROM GD2C2018.cheshire_jack.puntos WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) < anio_vencimiento)
	BEGIN 
		UPDATE GD2C2018.cheshire_jack.puntos
		SET cantidad = CASE WHEN cantidad + @cantidad > 0 THEN cantidad + @cantidad ELSE 0 END
		WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) = anio_vencimiento
	END
	ELSE
	BEGIN
		INSERT INTO GD2C2018.cheshire_jack.puntos
		(cod_cliente, anio_vencimiento, cantidad)
		VALUES
		(@cod_cliente, YEAR(@fecha_actual) + 1,
		CASE WHEN @cantidad > 0 THEN @cantidad ELSE 0 END)
	END
END

GO
CREATE PROCEDURE cheshire_jack.hacer_canje
(@cod_cliente INT, @cod_premio INT, @fecha_actual DATE)
AS
BEGIN
	IF (SELECT stock FROM GD2C2018.cheshire_jack.premios WHERE @cod_premio = cod_premio) > 0
	BEGIN
		RAISERROR('No se puede canjear algo sin stock',12, 1)
	END
	
	DECLARE @cantidad_puntos_actuales NUMERIC(18,0), @costo_premio NUMERIC(18,0)
	SELECT @cantidad_puntos_actuales = cantidad FROM GD2C2018.cheshire_jack.puntos WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) < anio_vencimiento
	SELECT @costo_premio = valor FROM GD2C2018.cheshire_jack.premios WHERE cod_premio = @cod_premio

	IF @cantidad_puntos_actuales IS NULL OR @cantidad_puntos_actuales < @costo_premio
	BEGIN
		RAISERROR('El premio cuesta más que los puntos disponibles', 12, 1)
	END

	BEGIN TRANSACTION
		INSERT INTO GD2C2018.cheshire_jack.canjes
		(cod_premio, cod_usuario)
		VALUES
		(@cod_premio, @cod_cliente)

		UPDATE GD2C2018.cheshire_jack.premios
		SET stock = stock - 1
		WHERE @cod_premio = cod_premio

		SET @costo_premio *= -1
		EXEC GD2C2018.cheshire_jack.modificar_puntos @cod_cliente, @costo_premio, @fecha_actual
	COMMIT TRANSACTION
END

GO

SELECT cod_rol, descripcion FROM cheshire_jack.roles WHERE habilitado = 1 AND registrable = 1
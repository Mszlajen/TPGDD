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
	contrasenia_automatica BIT NOT NULL DEFAULT(1),
	contrasenia_valida BIT NOT NULL DEFAULT (1)
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

CREATE TABLE cheshire_jack.grados_de_publicacion (
	cod_grado TINYINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre CHAR(5) NOT NULL,
	comision NUMERIC(2,2) NOT NULL,
	peso TINYINT NOT NULL
	)

CREATE TABLE cheshire_jack.estados (
	cod_estado TINYINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre NVARCHAR(255) NOT NULL
	)

CREATE TABLE cheshire_jack.publicaciones (
	cod_publicacion NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	cod_grado TINYINT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.grados_de_publicacion(cod_grado),
	cod_espectaculo NUMERIC(18,0) NOT NULL,
	cod_estado TINYINT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.estados(cod_estado),
	fecha_evento DATETIME NOT NULL,
	fecha_vencimiento DATETIME,
	fecha_publicacion DATETIME,
	CHECK(fecha_publicacion < fecha_evento)
	)

CREATE TABLE cheshire_jack.rubros (
	cod_rubro INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion varchar(255) NOT NULL
	)

CREATE TABLE cheshire_jack.espectaculos (
	cod_espectaculo NUMERIC(18,0) PRIMARY KEY NOT NULL IDENTITY(1,1),
	cod_empresa INT NOT NULL,
	descripcion NVARCHAR(255) NOT NULL,
	cod_rubro INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.rubros(cod_rubro),
	direccion VARCHAR(50) NOT NULL,
	altura NUMERIC(18,0) NOT NULL,
	cod_espectaculo_viejo NUMERIC(18,0)
	)

CREATE TABLE cheshire_jack.tipos_de_ubicacion (
	cod_tipo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	descripcion NVARCHAR(255) NOT NULL,
	cod_tipo_viejo NUMERIC(18,0)
	)

CREATE TABLE cheshire_jack.ubicaciones (
	nro_ubicacion NUMERIC(18,0) NOT NULL,
	cod_publicacion NUMERIC (18,0) NOT NULL,
	fila VARCHAR(3) NOT NULL,
	asiento NUMERIC(18,0) NOT NULL,
	sin_numerar BIT NOT NULL DEFAULT(0),
	precio NUMERIC(18,0) NOT NULL CHECK(precio > 0),
	cod_tipo INT NOT NULL,
	disponible BIT NOT NULL DEFAULT(1),
	PRIMARY KEY(cod_publicacion, nro_ubicacion)
	)
	
CREATE TABLE cheshire_jack.clientes (
	cod_cliente INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	tipo_documento VARCHAR(50) NOT NULL,
	nro_documento NUMERIC(18,0) NOT NULL,
	CUIL CHAR(14) NOT NULL,
	apellido NVARCHAR(255) NOT NULL,
	nombre NVARCHAR(255) NOT NULL,
	fecha_nacimiento DATETIME NOT NULL,
	mail NVARCHAR(255) CHECK(mail LIKE '_%@_%._%') NOT NULL,
	telefono CHAR(14),
	localidad NVARCHAR(255) NOT NULL DEFAULT('Sin Definir'),
	domicilio_calle NVARCHAR(255) NOT NULL,
	nro_calle NUMERIC(18,0) NOT NULL CHECK(nro_calle > 0),
	piso TINYINT,
	dept NVARCHAR(50),
	codigo_postal NVARCHAR(255),
	fecha_creacion DATETIME,
	cod_usuario INT,
	habilitado BIT NOT NULL DEFAULT(1)
	)

CREATE TABLE cheshire_jack.empresas (
	cod_empresa INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	razon_social NVARCHAR(255) NOT NULL,
	CUIT NVARCHAR(14) NOT NULL,
	fecha_creacion DATETIME,
	mail NVARCHAR(255) CHECK(mail LIKE '_%@_%._%'),
	telefono CHAR(14),
	ciudad NVARCHAR(255) NOT NULL DEFAULT('Sin Definir'),
	domicilio_calle NVARCHAR(50) NOT NULL,
	nro_calle NUMERIC(18,0) NOT NULL CHECK(nro_calle > 0),
	piso NUMERIC(18,0),
	dept NVARCHAR(50),
	codigo_postal NVARCHAR(50),
	cod_usuario INT,
	habilitado BIT NOT NULL DEFAULT(1)
	)
		
CREATE TABLE cheshire_jack.compras (
	cod_compra NUMERIC(18,0) PRIMARY KEY IDENTITY(1,1) NOT NULL,
	cod_cliente INT NOT NULL,
	nro_factura NUMERIC(18,0),
	fecha DATETIME NOT NULL,
	metodo_pago VARCHAR(255) NOT NULL,
	cod_metodo NUMERIC(18,0),
	cod_publicacion NUMERIC(18,0) NOT NULL,
	nro_ubicacion NUMERIC(18,0) NOT NULL,
	cantidad NUMERIC(18,0) DEFAULT(1)
	)

CREATE TABLE cheshire_jack.facturas (
	nro_factura NUMERIC(18,0) PRIMARY KEY NOT NULL,
	fecha DATETIME NOT NULL,
	total NUMERIC(18,2) NOT NULL,
	forma_pago VARCHAR(255)
	)

CREATE TABLE cheshire_jack.items (
	nro_factura NUMERIC(18,0) NOT NULL,
	nro_item INT NOT NULL,
	monto NUMERIC(18,2),
	descripcion NVARCHAR(60),
	cantidad NUMERIC(18,0),
	PRIMARY KEY(nro_factura, nro_item),
	)

CREATE TABLE cheshire_jack.puntos (
	anio_vencimiento INT NOT NULL,
	cod_cliente INT NOT NULL,
	cantidad NUMERIC(18,0) NOT NULL,
	PRIMARY KEY(cod_cliente, anio_vencimiento)
	)

CREATE TABLE cheshire_jack.premios (
	cod_premio INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	nombre VARCHAR(50) NOT NULL,
	descripcion VARCHAR(255),
	stock INT DEFAULT(0) NOT NULL,
	valor NUMERIC(18,0) NOT NULL
	)

CREATE TABLE cheshire_jack.canjes (
	cod_cliente INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.usuarios(cod_Usuario),
	cod_premio INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.premios(cod_premio),
	fecha DATETIME NOT NULL,
	nroRepeticion TINYINT NOT NULL
	PRIMARY KEY(cod_cliente, cod_premio, nroRepeticion)
	)

CREATE TABLE cheshire_jack.tarjetas_de_credito (
	cod_tarjeta NUMERIC(18,0) NOT NULL IDENTITY(1,1),
	cod_cliente INT NOT NULL,
	hash_nro_tarjeta char(256) NOT NULL,
	ultimos_digitos char(4) NOT NULL,
	cod_seguridad char(4) NOT NULL,
	mes_vencimiento TINYINT NOT NULL CHECK(mes_vencimiento BETWEEN 1 AND 12),
	anio_vencimiento INT NOT NULL CHECK(anio_vencimiento > 0)
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
ADD FOREIGN KEY (cod_empresa) REFERENCES cheshire_jack.empresas(cod_empresa)

ALTER TABLE cheshire_jack.ubicaciones
ADD FOREIGN KEY (cod_publicacion) REFERENCES cheshire_jack.publicaciones(cod_publicacion)

ALTER TABLE cheshire_jack.ubicaciones
ADD FOREIGN KEY (cod_tipo) REFERENCES cheshire_jack.tipos_de_ubicacion(cod_tipo)

ALTER TABLE cheshire_jack.puntos
ADD FOREIGN KEY (cod_cliente) REFERENCES cheshire_jack.clientes(cod_cliente)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (cod_cliente) REFERENCES cheshire_jack.clientes(cod_cliente)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (nro_factura) REFERENCES cheshire_jack.facturas(nro_factura)

ALTER TABLE cheshire_jack.compras
ADD FOREIGN KEY (cod_publicacion, nro_ubicacion) REFERENCES cheshire_jack.ubicaciones(cod_publicacion, nro_ubicacion)

ALTER TABLE cheshire_jack.items
ADD FOREIGN KEY (nro_factura) REFERENCES cheshire_jack.facturas(nro_factura)

ALTER TABLE cheshire_jack.tarjetas_de_credito
ADD FOREIGN KEY (cod_cliente) REFERENCES cheshire_jack.clientes(cod_cliente)

CREATE INDEX CUIT ON cheshire_jack.clientes(CUIL)
CREATE INDEX documento ON cheshire_jack.clientes(tipo_documento, nro_documento)
CREATE INDEX CUIL ON cheshire_jack.empresas(CUIT)
CREATE INDEX razon_social ON cheshire_jack.empresas(razon_social)
CREATE INDEX usuario ON cheshire_jack.usuarios(nombre_usuario)

INSERT INTO cheshire_jack.grados_de_publicacion
(nombre, comision, peso)
VALUES ('S.D.', 0, 0),
('Baja', 0.05, 5),
('Media', 0.1, 100),
('Alta', 0.2, 200)

INSERT INTO cheshire_jack.estados
(nombre) 
VALUES ('Borrador'),
('Publicada'),
('Finalizada'),
('Pausada')

INSERT INTO cheshire_jack.roles
(descripcion, registrable)
VALUES ('Empresa de Espectaculo', 1),
('Cliente', 1),
('Administrador', 0)

INSERT INTO cheshire_jack.funcionalidades
(descripcion)
VALUES ('ABM Cliente'),
('ABM Empresa de Espectaculo'),
('ABM Grado'),
('ABM Rol'),
('ABM Rubro'),
('Canje de Puntos'),
('Comprar'),
('Editar Publicacion'),
('Generar Publicacion'),
('Generar Rendicion de Comisiones'),
('Historial Cliente'),
('Listado Estadistico'), 
('Cambiar Contraseña'),
('Editar Usuario')

INSERT INTO cheshire_jack.RolesxFuncionalidades
(cod_funcionalidad, cod_rol)
VALUES (6, 2),
(7, 2),
(8, 1),
(9, 1),
(11, 2),
(13, 2),
(13, 1)

INSERT INTO cheshire_jack.RolesxFuncionalidades
(cod_funcionalidad, cod_rol)
SELECT cod_funcionalidad, 3 
FROM cheshire_jack.funcionalidades

INSERT INTO cheshire_jack.usuarios
(nombre_usuario, contrasenia, contrasenia_automatica)
VALUES ('admin', '23018411280191203129672521842191112164220158208131447722162427420917723222015220155231', 0) --Contraseña = w23e

INSERT INTO cheshire_jack.usuariosXRoles
(cod_usuario, cod_rol)
VALUES (1, 3)

GO
INSERT INTO cheshire_jack.empresas 
(razon_social, CUIT, fecha_creacion, mail, 
domicilio_calle, nro_calle, piso, dept, codigo_postal)
SELECT DISTINCT Espec_Empresa_Razon_Social, Espec_Empresa_Cuit, Espec_Empresa_Fecha_Creacion, 
				Espec_Empresa_Mail, Espec_Empresa_Dom_Calle, Espec_Empresa_Nro_Calle, 
				Espec_Empresa_Piso, Espec_Empresa_Depto, Espec_Empresa_Cod_Postal
FROM gd_esquema.Maestra

INSERT INTO cheshire_jack.clientes
(nombre, apellido, fecha_nacimiento, tipo_documento, nro_documento, 
mail, domicilio_calle, nro_calle, piso, dept, codigo_postal, CUIL)
SELECT DISTINCT Cli_Nombre, Cli_Apeliido, Cli_Fecha_Nac, 'DNI', Cli_Dni, 
				Cli_Mail, Cli_Dom_Calle, Cli_Nro_Calle, Cli_Piso, Cli_Depto, 
				Cli_Cod_Postal, 'S. D.'
FROM gd_esquema.Maestra
WHERE Cli_Nombre IS NOT NULL

DECLARE @cantidadClientes INT, @usuarioActual INT, @cantidadEmpresas INT

SET @cantidadClientes = (SELECT COUNT(*) FROM cheshire_jack.clientes)
SET	@usuarioActual = 0

WHILE @usuarioActual < @cantidadClientes
BEGIN
	INSERT INTO cheshire_jack.usuarios
	(nombre_usuario, contrasenia)
	VALUES
	('clienteMigrado' + CAST(1 + @usuarioActual AS VARCHAR), 
	'596862374011182110423175134179201677017974934059176207194179572531874953111238') --Contraseña = migrado

	SET @usuarioActual += 1
END

UPDATE cheshire_jack.clientes
SET cod_usuario = cod_cliente + 1
WHERE cod_usuario IS NULL

INSERT INTO cheshire_jack.usuariosXRoles
(cod_rol, cod_usuario)
SELECT 2, cod_usuario FROM cheshire_jack.clientes

SET @cantidadEmpresas = (SELECT COUNT(*) FROM cheshire_jack.empresas)
SET	@usuarioActual = 0

WHILE @usuarioActual < @cantidadEmpresas
BEGIN
	INSERT INTO cheshire_jack.usuarios
	(nombre_usuario, contrasenia)
	VALUES
	('empresaMigrada' + CAST(1 + @usuarioActual AS CHAR), 
	'596862374011182110423175134179201677017974934059176207194179572531874953111238') --Contraseña = migrado


	SET @usuarioActual += 1
END

UPDATE cheshire_jack.empresas
SET cod_usuario = cod_empresa + @cantidadClientes + 1
WHERE cod_usuario IS NULL

INSERT INTO cheshire_jack.usuariosXRoles
(cod_rol, cod_usuario)
SELECT 1, cod_usuario FROM cheshire_jack.empresas

ALTER TABLE cheshire_jack.clientes
ADD CONSTRAINT CheckToCodUsuarioClientes CHECK(cod_usuario IS NOT NULL)

ALTER TABLE cheshire_jack.empresas
ADD CONSTRAINT CheckToCodUsuarioEmpresas CHECK(cod_usuario IS NOT NULL)

GO
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
SELECT DISTINCT (SELECT cod_grado FROM cheshire_jack.grados_de_publicacion WHERE nombre = 'S.D.'), 
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

SELECT DISTINCT (SELECT cod_publicacion FROM cheshire_jack.espectaculos E JOIN cheshire_jack.publicaciones P ON E.cod_espectaculo = P.cod_espectaculo WHERE M.Espectaculo_Cod = E.cod_espectaculo_viejo) cod_publicacion,
		(SELECT cod_tipo FROM cheshire_jack.tipos_de_ubicacion TU WHERE TU.cod_tipo_viejo = M.Ubicacion_Tipo_Codigo) cod_tipo,
		Ubicacion_Fila,
		Ubicacion_Asiento,
		Ubicacion_Sin_numerar,
		Ubicacion_Precio,
		1 Ubicacion_disponible,
		Compra_Fecha, 
		Compra_Cantidad,
		Cli_Dni,
		Factura_Nro,
		Forma_Pago_Desc
INTO #ubicacionesIntermediaSinNroUbicacion
FROM gd_esquema.Maestra M
WHERE Espectaculo_Cod IS NOT NULL AND Compra_Fecha IS NULL

MERGE #ubicacionesIntermediaSinNroUbicacion AS target
USING (SELECT DISTINCT (SELECT cod_publicacion FROM cheshire_jack.espectaculos E JOIN cheshire_jack.publicaciones P ON E.cod_espectaculo = P.cod_espectaculo WHERE M.Espectaculo_Cod = E.cod_espectaculo_viejo) cod_publicacion,
		(SELECT cod_tipo FROM cheshire_jack.tipos_de_ubicacion TU WHERE TU.cod_tipo_viejo = M.Ubicacion_Tipo_Codigo) cod_tipo,
		Ubicacion_Fila,
		Ubicacion_Asiento,
		Ubicacion_Sin_numerar,
		Ubicacion_Precio,
		0 Ubicacion_disponible,
		Compra_Fecha, 
		Compra_Cantidad,
		Cli_Dni,
		Factura_Nro,
		Forma_Pago_Desc
FROM gd_esquema.Maestra M
WHERE Espectaculo_Cod IS NOT NULL AND compra_fecha IS NOT NULL AND factura_nro IS NULL) AS source
ON target.cod_publicacion = source.cod_publicacion AND target.Ubicacion_fila = source.Ubicacion_fila AND target.Ubicacion_asiento = source.Ubicacion_asiento
WHEN MATCHED
THEN UPDATE SET target.compra_fecha = source.compra_fecha, 
				target.compra_cantidad = source.compra_cantidad, 
				target.cli_dni = source.cli_dni,
				target.forma_pago_desc = source.forma_pago_desc,
				target.ubicacion_disponible = 0;

MERGE #ubicacionesIntermediaSinNroUbicacion AS target
USING (SELECT DISTINCT (SELECT cod_publicacion FROM cheshire_jack.espectaculos E JOIN cheshire_jack.publicaciones P ON E.cod_espectaculo = P.cod_espectaculo WHERE M.Espectaculo_Cod = E.cod_espectaculo_viejo) cod_publicacion,
		(SELECT cod_tipo FROM cheshire_jack.tipos_de_ubicacion TU WHERE TU.cod_tipo_viejo = M.Ubicacion_Tipo_Codigo) cod_tipo,
		Ubicacion_Fila,
		Ubicacion_Asiento,
		Ubicacion_Sin_numerar,
		Ubicacion_Precio,
		0 Ubicacion_disponible,
		Compra_Fecha, 
		Compra_Cantidad,
		Cli_Dni,
		Factura_Nro,
		Forma_Pago_Desc
FROM gd_esquema.Maestra M
WHERE Espectaculo_Cod IS NOT NULL AND Factura_Nro IS NOT NULL) AS source
ON target.cod_publicacion = source.cod_publicacion AND target.Ubicacion_fila = source.Ubicacion_fila AND target.Ubicacion_asiento = source.Ubicacion_asiento
WHEN MATCHED
THEN UPDATE SET target.compra_fecha = source.compra_fecha, 
				target.compra_cantidad = source.compra_cantidad, 
				target.cli_dni = source.cli_dni,
				target.factura_nro = source.factura_nro,
				target.forma_pago_desc = source.forma_pago_desc,
				target.ubicacion_disponible = 0;

SELECT DISTINCT cod_publicacion,
		ROW_NUMBER() OVER(PARTITION BY cod_publicacion ORDER BY cod_publicacion) nro_ubicacion,
		cod_tipo,
		Ubicacion_Fila,
		Ubicacion_Asiento,
		Ubicacion_Sin_numerar,
		Ubicacion_Precio,
		Ubicacion_disponible,
		Cli_Dni,
		Compra_Fecha,
		Compra_Cantidad,
		Factura_Nro,
		Forma_Pago_Desc
INTO #ubicacionesIntermedia
FROM #ubicacionesIntermediaSinNroUbicacion

INSERT INTO cheshire_jack.ubicaciones
(cod_publicacion, nro_ubicacion, cod_tipo, fila, asiento, sin_numerar, precio, disponible)
SELECT DISTINCT cod_publicacion,
				nro_ubicacion,
				cod_tipo,
				Ubicacion_Fila,
				Ubicacion_Asiento,
				Ubicacion_Sin_numerar,
				Ubicacion_Precio,
				ubicacion_disponible
FROM #ubicacionesIntermedia

INSERT INTO cheshire_jack.facturas
(nro_factura, forma_pago, fecha, total)
SELECT DISTINCT Factura_Nro, 
				Forma_Pago_Desc, 
				Factura_Fecha, 
				Factura_Total
FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL

INSERT INTO cheshire_jack.items
(nro_factura, nro_item, descripcion, monto, cantidad)
SELECT DISTINCT Factura_Nro, 
				ROW_NUMBER() OVER(PARTITION BY Factura_nro ORDER BY Factura_nro),
				Item_Factura_Descripcion,
				Item_Factura_Monto,
				Item_Factura_Cantidad
FROM gd_esquema.Maestra
WHERE Factura_Nro IS NOT NULL

INSERT INTO cheshire_jack.compras
(cod_cliente, fecha, metodo_pago, nro_factura, cod_publicacion, nro_ubicacion)
SELECT DISTINCT (SELECT cod_cliente FROM cheshire_jack.clientes C WHERE UI.Cli_Dni = C.nro_documento),
				Compra_Fecha,
				forma_pago_desc,
				Factura_Nro,
				cod_publicacion,
				nro_ubicacion
FROM #ubicacionesIntermedia UI
WHERE Compra_Fecha IS NOT NULL

DROP TABLE #ubicacionesIntermedia
DROP TABLE #ubicacionesIntermediaSinNroUbicacion
--Fin migracion

INSERT INTO cheshire_jack.premios
(nombre, stock, valor)
VALUES('Mono de peluche', 2, 200),
('Oso de peluche', 5, 400),
('Remera de jesus de Laferre', 1, 1000)
--Fin datos adicionales

GO
CREATE PROCEDURE cheshire_jack.modificar_puntos 
(@cod_cliente INT, @cantidad NUMERIC(18,0), @fecha_actual DATE)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM GD2C2018.cheshire_jack.puntos WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) + 1 = anio_vencimiento)
	BEGIN 
		UPDATE GD2C2018.cheshire_jack.puntos
		SET cantidad = CASE WHEN cantidad + @cantidad > 0 THEN cantidad + @cantidad ELSE 0 END
		WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) + 1 = anio_vencimiento
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
(@cod_cliente INT, @cod_premio INT, @fecha_actual DATETIME)
AS
BEGIN
	IF (SELECT stock FROM GD2C2018.cheshire_jack.premios WHERE @cod_premio = cod_premio) = 0
	BEGIN
		RAISERROR('No se puede canjear algo sin stock',16, 1)
	END
	
	DECLARE @cantidad_puntos_actuales NUMERIC(18,0), @costo_premio NUMERIC(18,0)
	SELECT @cantidad_puntos_actuales = cantidad FROM GD2C2018.cheshire_jack.puntos WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) + 1 = anio_vencimiento
	SELECT @costo_premio = valor FROM GD2C2018.cheshire_jack.premios WHERE cod_premio = @cod_premio

	IF @cantidad_puntos_actuales IS NULL OR @cantidad_puntos_actuales < @costo_premio
	BEGIN
		RAISERROR('El premio cuesta más que los puntos disponibles', 16, 1)
	END

	BEGIN TRANSACTION
		INSERT INTO GD2C2018.cheshire_jack.canjes
		(cod_premio, cod_cliente, fecha, nroRepeticion)
		VALUES
		(@cod_premio, @cod_cliente, @fecha_actual, 
			(SELECT COALESCE(MAX(nroRepeticion), 0) + 1
			FROM cheshire_jack.canjes 
			WHERE cod_premio = @cod_premio AND cod_cliente = @cod_cliente))

		UPDATE GD2C2018.cheshire_jack.premios
		SET stock = stock - 1
		WHERE @cod_premio = cod_premio

		SET @costo_premio *= -1
		EXEC GD2C2018.cheshire_jack.modificar_puntos @cod_cliente, @costo_premio, @fecha_actual
	COMMIT TRANSACTION
END

GO
CREATE PROCEDURE cheshire_jack.crearCliente
(@nombre NVARCHAR(255), @apellido NVARCHAR(255), @tipoDocumento NVARCHAR(255), @nroDocumento NUMERIC(18,0), 
@CUIL NVARCHAR(255), @mail NVARCHAR(255), @telefono NVARCHAR(255), @domicilio NVARCHAR(255), @nroCalle NUMERIC(18,0), 
@piso NUMERIC(18,0), @dept NVARCHAR(255), @localidad NVARCHAR(255), @codPostal NVARCHAR(255), @fechaCreacion DATETIME, 
@fechaNacimiento DATETIME, @nombreUsuario VARCHAR(50), @contrasenia CHAR(256), @automatico BIT, @nroTarjeta CHAR(256), 
@ultimosDigitos CHAR(4), @codSeguridad CHAR(4), @mesVencimiento TINYINT, @anioVencimiento INT)
AS BEGIN
	DECLARE @codUsuario INT, @codCliente INT = -1
	
	BEGIN TRANSACTION
		INSERT INTO cheshire_jack.usuarios
		(nombre_usuario, contrasenia)
		VALUES(@nombreUsuario, @contrasenia)

		EXEC @codUsuario = cheshire_jack.crearUsuario @nombreUsuario, @contrasenia, @automatico

		INSERT INTO cheshire_jack.usuariosXRoles
		(cod_usuario, cod_rol)
		VALUES(@codUsuario, 2)

		INSERT INTO cheshire_jack.clientes
		(nombre, apellido, telefono, CUIL, mail, tipo_documento, nro_documento, domicilio_calle, 
		nro_calle, piso, dept, localidad, codigo_postal, fecha_creacion, fecha_nacimiento, cod_usuario)
		VALUES (@nombre, @apellido, @telefono, @CUIL, @mail, @tipoDocumento, @nroDocumento, @domicilio, @nroCalle,
				@piso, @dept, @localidad, @codPostal, @fechaCreacion, @fechaNacimiento, @codUsuario)
		
		SET @codCliente = SCOPE_IDENTITY()

		IF(@nroTarjeta IS NOT NULL)
		BEGIN
			INSERT INTO cheshire_jack.tarjetas_de_credito
			(cod_cliente, hash_nro_tarjeta, ultimos_digitos, cod_seguridad, mes_vencimiento, anio_vencimiento)
			VALUES(@codCliente, @nroTarjeta, @ultimosDigitos, @codSeguridad, @mesVencimiento, @anioVencimiento)
		END
	COMMIT TRANSACTION

	RETURN @codCliente
END

GO
/*
Valores de retorno:
0 - Usuario no existente
1 - Contraseña invalida
2 - Usuario deshabilitado
3 - Usuario bloqueado por intentos fallidos
4 - Contraseña automatica gastada
5 - Datos correctos
6 - Contraseña de un uso
*/
CREATE PROCEDURE cheshire_jack.iniciarSesion
(@usuario VARCHAR(50), @contrasenia CHAR(256), @codUsuario INT OUT)
AS BEGIN
	IF(NOT EXISTS (SELECT 1 FROM cheshire_jack.usuarios WHERE @usuario = nombre_usuario))
		RETURN 0
	ELSE
	BEGIN
		DECLARE @automatica BIT, @intentos TINYINT, @habilitado BIT, @valida BIT
		
		SELECT @codUsuario = cod_usuario, @automatica = contrasenia_automatica, @intentos = ingresos_restantes, @habilitado = habilitado, @valida = contrasenia_valida
		FROM cheshire_jack.usuarios WHERE @usuario = nombre_usuario

		IF(@intentos = 0)
			RETURN 3
		ELSE IF(@habilitado = 0)
			RETURN 2
		ELSE IF(NOT EXISTS(SELECT 1 FROM cheshire_jack.usuarios WHERE cod_usuario = @codUsuario AND @contrasenia = contrasenia))
		BEGIN
			UPDATE cheshire_jack.usuarios
			SET ingresos_restantes -= 1
			WHERE cod_usuario = @codUsuario
			RETURN 1
		END
		ELSE IF(@valida = 0)
			RETURN 4
		ELSE
		BEGIN
			IF(@automatica = 1 AND @valida = 1)
				UPDATE cheshire_jack.usuarios SET contrasenia_valida = 0 WHERE cod_usuario = @codUsuario
			UPDATE cheshire_jack.usuarios SET ingresos_restantes = 3 WHERE cod_usuario = @codUsuario
			RETURN 5 + @automatica
		END
	END
END

GO 
CREATE PROCEDURE cheshire_jack.crearUsuario
(@nombreUsuario VARCHAR(50), @contrasenia CHAR(256), @automatico BIT)
AS BEGIN
	INSERT INTO cheshire_jack.usuarios
	(nombre_usuario, contrasenia, contrasenia_automatica)
	VALUES(@nombreUsuario, @contrasenia, @automatico)

	RETURN SCOPE_IDENTITY()
END

GO
CREATE PROCEDURE cheshire_jack.cambiarContrasenia
(@codUsuario INT, @nuevaContrasenia CHAR(256))
AS BEGIN
	UPDATE cheshire_jack.usuarios
	SET contrasenia = @nuevaContrasenia, contrasenia_automatica = 0, contrasenia_valida = 1
	WHERE cod_usuario = @codUsuario
END

GO
/*
	Returns:
	0 - Tiene más de un rol
	> 0 - Solo tiene un rol y corresponde al #
	NULL - Si no tiene rol asignado
*/
CREATE FUNCTION cheshire_jack.usuarioTieneMultiplesRoles
(@codUsuario INT)
RETURNS INT
AS BEGIN
	DECLARE @resultado INT
	IF((SELECT TOP 2 COUNT(cod_rol) FROM cheshire_jack.usuariosXRoles WHERE cod_usuario = @codUsuario) > 1)
		SET @resultado = 0
	ELSE
		SELECT @resultado = cod_rol FROM cheshire_jack.usuariosXRoles WHERE cod_usuario = @codUsuario

	RETURN @resultado
END

GO --Retorna el codigo del nuevo rol
CREATE PROCEDURE cheshire_jack.CrearRol (@descripcion VARCHAR(255), @habilitado BIT, @registrable BIT)
AS BEGIN
	INSERT INTO cheshire_jack.roles
	(descripcion, habilitado, registrable)
	VALUES (@descripcion, @habilitado, @registrable)

	RETURN SCOPE_IDENTITY()
END

GO --Funcion auxiliar para UpdateRolesXFuncionalidades
CREATE FUNCTION cheshire_jack.SplitList (@list NVARCHAR(MAX), @separator CHAR = ' ')
RETURNS @table TABLE (Value NVARCHAR(MAX))
AS BEGIN
  DECLARE @position INT, @previous INT
  SET @list = @list + @separator
  SET @previous = 1
  SET @position = CHARINDEX(@separator, @list)
  WHILE @position > 0 
  BEGIN
    IF @position - @previous > 0
      INSERT INTO @table VALUES (SUBSTRING(@list, @previous, @position - @previous))
    IF @position >= LEN(@list) BREAK
      SET @previous = @position + 1
      SET @position = CHARINDEX(@separator, @list, @previous)
  END
  RETURN
END

GO
CREATE PROCEDURE cheshire_jack.UpdateRolesXFuncionalidades
(@cod_rol INT, @funcionalidades VARCHAR(MAX))
AS BEGIN
	
	MERGE cheshire_jack.RolesXFuncionalidades AS tg
	USING cheshire_jack.SplitList(@funcionalidades, ' ') AS src
	ON cod_rol = @cod_rol AND cod_funcionalidad = CAST(src.Value AS INT)
	WHEN NOT MATCHED BY TARGET THEN
		INSERT (cod_rol, cod_funcionalidad) VALUES (@cod_rol, src.Value)
	WHEN NOT MATCHED BY SOURCE AND cod_rol = @cod_rol  THEN
		DELETE;
END

GO --Retorna el codigo del nuevo rol
CREATE PROCEDURE cheshire_jack.CrearGrado 
(@nombre CHAR(5), @comision NUMERIC(2,2), @peso TINYINT)
AS BEGIN
	INSERT INTO cheshire_jack.grados_de_publicacion
	(nombre, comision, peso)
	VALUES (@nombre, @comision, @peso)

	RETURN SCOPE_IDENTITY()
END

GO
CREATE VIEW cheshire_jack.vw_grados AS
SELECT cod_grado, nombre, CAST(comision * 100 AS TINYINT) AS comision, peso 
FROM cheshire_jack.grados_de_publicacion 
WHERE cod_grado != 1

GO 
-- trimestre un valor de 1 a 4 indicando el trimestre
CREATE FUNCTION cheshire_jack.fechaEnTrimestre
(@fecha DateTime, @anio INT, @trimestre TINYINT)
RETURNS BIT
AS BEGIN
	DECLARE @result BIT, 
			@fechaInicial DATETIME = CAST(@anio AS CHAR) + '/' + CAST(@trimestre * 3 - 2 AS CHAR) + '/1',
			@fechaFinal DATETIME = EOMONTH(CAST(@anio AS CHAR) + '/' + CAST(@trimestre * 3 AS CHAR) + '/1')
	IF(@fecha BETWEEN @fechaInicial AND @fechaFinal)
		SET @result = 1
	ELSE
		SET @result = 0

	RETURN @result
END

GO
CREATE VIEW cheshire_jack.vw_clientes AS
SELECT cod_cliente, cod_usuario, apellido AS Apellido, nombre AS Nombre, 
tipo_documento AS 'Tipo de Documento', nro_documento 'Nro de Documento', 
CUIL, CAST(fecha_nacimiento AS DATE) AS 'Fecha de Nacimiento', mail AS 'E-mail', 
telefono AS Telefono, localidad AS Localidad, domicilio_calle AS 'Domicilio Calle',
nro_calle AS Altura, piso AS Piso, dept AS Departamento, codigo_postal AS 'Codigo Postal',
fecha_creacion AS 'Fecha de Creacion', habilitado Habilitado
FROM cheshire_jack.clientes

GO
CREATE VIEW cheshire_jack.vw_empresas AS
SELECT cod_empresa, cod_usuario, razon_social 'Razon Social', CUIT, 
ciudad Ciudad, domicilio_calle Domicilio, 
nro_calle Altura, piso Piso, dept Departamento, codigo_postal 'Codigo Postal', 
mail 'E-mail', telefono Telefono, habilitado Habilitado
FROM cheshire_jack.empresas

GO
CREATE PROCEDURE cheshire_jack.crearEmpresa
(@nombre NVARCHAR(255), @ciudad NVARCHAR(255), @domicilio NVARCHAR(255), 
@altura NUMERIC(18,0), @piso NUMERIC(18,0), @dept NVARCHAR(50), @codigoPostal NVARCHAR(50), 
@mail NVARCHAR(255), @telefono CHAR(14), @CUIT NVARCHAR(14), @nombreUsuario VARCHAR(50), 
@contrasenia VARCHAR(256), @automatico BIT)
AS BEGIN
	DECLARE @codEmpresa INT = -1, @codUsuario INT = -1
	BEGIN TRANSACTION
		EXEC @codUsuario = cheshire_jack.crearUsuario @nombreUsuario, @contrasenia, @automatico
		
		INSERT INTO cheshire_jack.usuariosXRoles
		(cod_usuario, cod_rol)
		VALUES(@codUsuario, 1)

		INSERT INTO cheshire_jack.empresas
		(razon_social, ciudad, domicilio_calle, nro_calle, piso, dept, codigo_postal, mail, telefono, CUIT, cod_usuario)
		VALUES(@nombre, @ciudad, @domicilio, @altura, @piso, @dept, @codigoPostal, @mail, @telefono, @CUIT, @codUsuario)
			
		SET @codEmpresa = SCOPE_IDENTITY()
	COMMIT TRANSACTION

	RETURN @codEmpresa
END

GO 
/*
RETORNO:
	0 - No existe empresa con esos datos o no se encuentra habilitada
	1 - Ya existe alguien con ese CUIT
	2 - Ya existe alguien con esa Razon Social
*/
CREATE FUNCTION cheshire_jack.existeEmpresa
(@razonSocial NVARCHAR(255), @CUIT CHAR(14))
RETURNS TINYINT
AS BEGIN 
	DECLARE @result TINYINT = 0

	SELECT @result = 1 FROM cheshire_jack.empresas WHERE CUIT = @CUIT AND habilitado = 1
	SELECT @result = 2 FROM cheshire_jack.empresas WHERE razon_social = @razonSocial AND habilitado = 1

	RETURN @result
END

GO
/*
RETORNO:
	0 - No existe cliente con esos datos o no se encuentra habilitado
	1 - Ya existe alguien con ese CUIL
	2 - Ya existe alguien con ese documento
*/
CREATE FUNCTION cheshire_jack.existeCliente
(@tipoDocumento VARCHAR(50), @nroDocumento NUMERIC(18,0), @CUIL CHAR(14))
RETURNS TINYINT
AS BEGIN
	DECLARE @result TINYINT = 0

	SELECT @result = 1 FROM cheshire_jack.clientes WHERE CUIL = @CUIL AND habilitado = 1 
	SELECT @result = 2 FROM cheshire_jack.clientes WHERE tipo_documento = @tipoDocumento AND nro_documento = @nroDocumento AND habilitado = 1

	RETURN @result
END

GO
CREATE FUNCTION cheshire_jack.existeUsuario
(@nombre VARCHAR(50))
RETURNS BIT
AS BEGIN
	DECLARE @result BIT = 0

	SELECT @result = 1 FROM cheshire_jack.usuarios
	WHERE nombre_usuario = @nombre AND habilitado = 1

	RETURN @result
END

GO 
CREATE VIEW cheshire_jack.vw_premios AS
SELECT p.cod_premio, p.nombre Nombre, p.descripcion Descripcion, p.stock Disponibles, p.valor Costo
FROM cheshire_jack.premios p
WHERE p.stock > 0

GO
CREATE FUNCTION cheshire_jack.obtenerTotalDePaginasDeHistorial
(@codCliente INT, @tamPagina INT) 
RETURNS INT
AS BEGIN
	DECLARE @cant INT
	SELECT @cant = COUNT(*) FROM cheshire_jack.compras WHERE @codCliente = cod_cliente
	IF @cant % @tamPagina = 0
		SET @cant /= @tamPagina
	ELSE
		SET @cant = @cant / @tamPagina + 1
	RETURN @cant
END

GO
CREATE PROCEDURE cheshire_jack.obtenerPaginaDeHistorial
(@codCliente INT, @nroPagina INT, @tamPagina INT)
AS BEGIN
	SELECT TOP (@tamPagina * @nroPagina) descripcion Descripcion, fecha_evento [Fecha Evento], cantidad Cantidad, fecha [Fecha Compra], 
	metodo_pago [Metodo de Pago]
	INTO #paginas
	FROM cheshire_jack.compras c JOIN cheshire_jack.publicaciones p 
		ON c.cod_publicacion = p.cod_publicacion JOIN cheshire_jack.espectaculos e
		ON p.cod_espectaculo = e.cod_espectaculo
	WHERE cod_cliente = @codCliente

	SELECT TOP (@tamPagina) * FROM #paginas ORDER BY [Fecha Compra] DESC
END

GO 
CREATE PROCEDURE cheshire_jack.obtenerUltimaPaginaDeHistorial
(@codCliente INT, @tamPagina INT)
AS BEGIN
	DECLARE @resto INT
	SELECT @resto = COUNT(*) % @tamPagina FROM cheshire_jack.compras WHERE cod_cliente = @codCliente
	
	SELECT TOP (CASE WHEN @resto = 0 THEN @tamPagina ELSE @resto END) 
	descripcion Descripcion, fecha_evento [Fecha Evento], cantidad Cantidad, fecha [Fecha Compra], 
	metodo_pago [Metodo de Pago]
	FROM cheshire_jack.compras c JOIN cheshire_jack.publicaciones p 
		ON c.cod_publicacion = p.cod_publicacion JOIN cheshire_jack.espectaculos e
		ON p.cod_espectaculo = e.cod_espectaculo
	WHERE cod_cliente = @codCliente
	ORDER BY [Fecha Compra] DESC
END

GO
CREATE PROCEDURE cheshire_jack.comisionesPendientes
(@codEmpresa INT)
AS BEGIN
	SELECT cod_compra, fecha Fecha, u.precio Precio, gp.comision * u.precio Comision
	FROM cheshire_jack.compras c JOIN cheshire_jack.ubicaciones u ON c.cod_publicacion = u.cod_publicacion AND c.nro_ubicacion = u.nro_ubicacion
		JOIN cheshire_jack.publicaciones p ON c.cod_publicacion = p.cod_publicacion 
		JOIN cheshire_jack.grados_de_publicacion gp ON p.cod_grado = gp.cod_grado 
		JOIN cheshire_jack.espectaculos e ON p.cod_espectaculo = e.cod_espectaculo
	WHERE cod_empresa = @codEmpresa AND nro_factura IS NULL
	ORDER BY cod_compra
END

GO
CREATE PROCEDURE cheshire_jack.facturarComisiones
(@compraDesde NUMERIC(18,0), @compraHasta NUMERIC(18,0), @fecha DATETIME)
AS BEGIN 
	DECLARE @nroFactura NUMERIC(18,0)
	SELECT @nroFactura = MAX(nro_factura) + 1 FROM cheshire_jack.facturas
	BEGIN TRANSACTION
		INSERT INTO cheshire_jack.facturas
		(nro_factura, fecha, total)
		VALUES(@nroFactura, @fecha, 1)

		UPDATE cheshire_jack.compras
		SET nro_factura = @nroFactura
		WHERE cod_compra BETWEEN @compraDesde AND @compraHasta

		INSERT INTO cheshire_jack.items
		(nro_factura, nro_item, descripcion,monto,cantidad)
		SELECT @nroFactura, ROW_NUMBER() OVER(ORDER BY @nroFactura),
			'Comision por venta', u.precio * gp.comision, cantidad
		FROM cheshire_jack.compras c JOIN cheshire_jack.ubicaciones u 
			ON c.cod_publicacion = u.cod_publicacion AND c.nro_ubicacion = u.nro_ubicacion JOIN
			cheshire_jack.publicaciones p ON p.cod_publicacion = c.cod_publicacion JOIN
			cheshire_jack.grados_de_publicacion gp ON p.cod_grado = gp.cod_grado
		WHERE cod_compra BETWEEN @compraDesde AND @compraHasta

		UPDATE cheshire_jack.facturas
		SET total = (SELECT SUM(monto) FROM cheshire_jack.items WHERE nro_factura = @nroFactura)
		WHERE @nroFactura = nro_factura
	COMMIT TRANSACTION

	RETURN @nroFactura
END

GO
CREATE VIEW cheshire_jack.vw_rubros AS
SELECT cod_rubro, descripcion Nombre FROM cheshire_jack.rubros

GO 
CREATE FUNCTION cheshire_jack.SplitUbicacion
(@ubicacion NVARCHAR(MAX), @separador CHAR)
RETURNS @table TABLE (sinNumerar BIT, fila VARCHAR(3), asiento NUMERIC(18,0), precio NUMERIC(18,0), tipoAsiento INT)
AS BEGIN
	DECLARE @sinNumerar BIT, @fila VARCHAR(3), @asiento NUMERIC(18,0), @precio NUMERIC(18,0), @tipo INT

	DECLARE @separadorSiguiente BIGINT = CHARINDEX(@separador, @ubicacion), @separadorAnterior BIGINT = 1

	SET @sinNumerar = SUBSTRING(@ubicacion, 1, @separadorSiguiente - 1)
	
	SET @separadorAnterior = @separadorSiguiente
	SET @separadorSiguiente = CHARINDEX(@separador, @ubicacion, @separadorSiguiente + 1)

	SET @fila = SUBSTRING(@ubicacion, @separadorAnterior + 1, @separadorSiguiente - @separadorAnterior)

	SET @separadorAnterior = @separadorSiguiente
	SET @separadorSiguiente = CHARINDEX(@separador, @ubicacion, @separadorSiguiente + 1)

	SET @asiento = CAST(SUBSTRING(@ubicacion, @separadorAnterior + 1, @separadorSiguiente - @separadorAnterior) AS NUMERIC(18,0))

	SET @separadorAnterior = @separadorSiguiente
	SET @separadorSiguiente = CHARINDEX(@separador, @ubicacion, @separadorSiguiente + 1)

	SET @precio = CAST(SUBSTRING(@ubicacion, @separadorAnterior + 1, @separadorSiguiente - @separadorAnterior) AS NUMERIC(18,0))

	SET @separadorAnterior = @separadorSiguiente
	SET @separadorSiguiente = LEN(@ubicacion)

	SET @tipo = CAST(SUBSTRING(@ubicacion, @separadorAnterior + 1, @separadorSiguiente - @separadorAnterior) AS INT)

	INSERT INTO @table
	VALUES(@sinNumerar, @fila, @asiento, @precio, @tipo)

	RETURN
END

GO
CREATE PROCEDURE cheshire_jack.crearEvento
(@codEmpresa INT, @codRubro INT, @codGrado INT, @descripcion NVARCHAR(255), 
@direccion NVARCHAR(255), @altura NUMERIC(18,0), @fechas VARCHAR(MAX), 
@ubicaciones NVARCHAR(MAX), @estado INT, @fechaPublicacion DATETIME = NULL)
AS BEGIN
	DECLARE @codEspectaculo NUMERIC(18,0), @codPublicacion NUMERIC(18,0), 
	@cantPublicaciones INT, @contador INT = 1
	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO cheshire_jack.espectaculos
		(cod_empresa, cod_rubro, descripcion, direccion, altura)
		VALUES(@codEmpresa, @codRubro, @descripcion, @direccion, @altura)

		SET @codEspectaculo = SCOPE_IDENTITY()

		SELECT Value fecha INTO #fechas FROM SplitList(@fechas, '@')

		SELECT @cantPublicaciones = COUNT(*) FROM #fechas
		SET @codPublicacion = IDENT_CURRENT('cheshire_jack.publicaciones')

		INSERT INTO cheshire_jack.publicaciones
		(cod_espectaculo, cod_estado, cod_grado, fecha_publicacion, fecha_evento)
		SELECT @codEspectaculo, @estado, @codGrado, @fechaPublicacion, fecha
		FROM #fechas

		CREATE TABLE #ubicaciones (
			sinNumerar BIT, 
			fila VARCHAR(3), 
			asiento NUMERIC(18,0), 
			precio NUMERIC(18,0),
			tipo INT)

		DECLARE @pSig BIGINT = CHARINDEX('@', @ubicaciones, 1), @pAnt BIGINT = 0

		WHILE @pSig != 0
		BEGIN
			INSERT INTO #ubicaciones
			SELECT * 
			FROM cheshire_jack.SplitUbicacion(SUBSTRING(@ubicaciones, @pAnt + 1, @pSig - @pAnt - 1), ' ')

			SET @pAnt = @pSig
			SET @pSig = CHARINDEX('@', @ubicaciones, @pSig + 1)
		END

		WHILE @contador <= @cantPublicaciones
		BEGIN
			INSERT INTO cheshire_jack.ubicaciones
			(cod_publicacion, nro_ubicacion, asiento, fila, sin_numerar, precio, cod_tipo)
			SELECT @codPublicacion + @contador, ROW_NUMBER() OVER(ORDER BY (SELECT 1)), 
					asiento, fila, sinNumerar, precio, tipo
			FROM #ubicaciones

			SET @contador += 1
		END

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH

	RETURN CAST(@codEspectaculo AS BIGINT)
END

GO
CREATE PROCEDURE cheshire_jack.publicacionesDe
(@codEmpresa INT, @estado INT = NULL)
AS BEGIN
	SELECT p.cod_publicacion, e.descripcion Descripcion, p.fecha_evento Fecha, 
	gp.cod_grado, gp.nombre [Grado de Publicacion], r.cod_rubro, r.descripcion Rubro, 
	e.direccion Direccion, e.altura Altura, est.cod_estado, est.nombre Estado
	FROM cheshire_jack.publicaciones p JOIN 
	cheshire_jack.espectaculos e ON p.cod_espectaculo = e.cod_espectaculo JOIN
	cheshire_jack.grados_de_publicacion gp ON gp.cod_grado = p.cod_grado JOIN
	cheshire_jack.rubros r ON e.cod_rubro = r.cod_rubro JOIN
	cheshire_jack.estados est ON p.cod_estado = est.cod_estado
	WHERE e.cod_empresa = @codEmpresa AND (@estado IS NULL OR p.cod_estado = @estado)
END

GO
CREATE VIEW cheshire_jack.vw_estados AS
SELECT cod_estado, nombre FROM cheshire_jack.estados

GO
CREATE PROCEDURE cheshire_jack.modificarEstado
(@codPublicacion NUMERIC(18,0), @estado INT)
AS BEGIN
	UPDATE cheshire_jack.publicaciones
	SET cod_estado = @estado
	WHERE @codPublicacion = cod_publicacion
END

GO
CREATE PROCEDURE cheshire_jack.ubicacionesDe
(@codPublicacion NUMERIC(18,0))
AS BEGIN
	SELECT u.nro_ubicacion, u.sin_numerar [Sin Numerar], u.fila Fila, u.asiento Asiento, u.precio Precio, 
	u.cod_tipo, tp.descripcion [Tipo de Asiento] FROM cheshire_jack.ubicaciones u 
	JOIN cheshire_jack.tipos_de_ubicacion tp ON u.cod_tipo = tp.cod_tipo
	WHERE u.cod_publicacion = @codPublicacion
END

GO
CREATE PROCEDURE cheshire_jack.actualizarPublicacion
(@codPublicacion NUMERIC(18,0), @descripcion NVARCHAR(255), @direccion VARCHAR(50), 
@altura NUMERIC(18,0), @codRubro INT, @codGrado INT, @ubicaciones NVARCHAR(MAX), 
@fecha DATETIME, @fechaPublicacion DATETIME, @codEstado INT, @modificarEspectaculo BIT,
@modificarPublicaciones BIT)
AS BEGIN
	DECLARE @codEspectaculo NUMERIC(18,0), @codEspectaculoNuevo NUMERIC(18,0)
	BEGIN TRANSACTION
	BEGIN TRY
		(SELECT @codEspectaculo = cod_espectaculo FROM cheshire_jack.publicaciones WHERE cod_publicacion = @codPublicacion)

		UPDATE cheshire_jack.publicaciones
		SET fecha_evento = @fecha
		WHERE cod_publicacion = @codPublicacion

		IF(@modificarEspectaculo = 0)
		BEGIN
			UPDATE cheshire_jack.espectaculos
			SET descripcion = @descripcion, direccion = @direccion, altura = @altura
			WHERE cod_espectaculo = @codEspectaculo

			SET @codEspectaculoNuevo = @codEspectaculo
		END
		ELSE
		BEGIN
			INSERT INTO cheshire_jack.espectaculos
			(cod_empresa, cod_espectaculo_viejo, cod_rubro, descripcion, direccion, altura)
			SELECT cod_empresa, cod_espectaculo_viejo, @codRubro, @descripcion, @direccion, @altura
			FROM cheshire_jack.espectaculos
			WHERE cod_espectaculo = @codEspectaculo

			SET @codEspectaculoNuevo = SCOPE_IDENTITY()
		END

		CREATE TABLE #ubicaciones (
				sinNumerar BIT, 
				fila VARCHAR(3), 
				asiento NUMERIC(18,0), 
				precio NUMERIC(18,0),
				tipo INT)

		DECLARE @pSig BIGINT = CHARINDEX('@', @ubicaciones, 1), @pAnt BIGINT = 0

		WHILE @pSig != 0
		BEGIN
			INSERT INTO #ubicaciones
			SELECT * 
			FROM cheshire_jack.SplitUbicacion(SUBSTRING(@ubicaciones, @pAnt + 1, @pSig - @pAnt - 1), ' ')

			SET @pAnt = @pSig
			SET @pSig = CHARINDEX('@', @ubicaciones, @pSig + 1)
		END
		
		IF(@modificarPublicaciones = 0)
		BEGIN
			UPDATE cheshire_jack.publicaciones 
			SET cod_grado = @codGrado, cod_estado = @codEstado, fecha_publicacion = @fechaPublicacion, 
				cod_espectaculo = @codEspectaculoNuevo
			WHERE @codPublicacion = cod_publicacion
		
			DELETE FROM cheshire_jack.ubicaciones
			WHERE cod_publicacion = @codPublicacion

			INSERT INTO cheshire_jack.ubicaciones
			(cod_publicacion, nro_ubicacion, asiento, fila, sin_numerar, precio, cod_tipo)
			SELECT @codPublicacion, ROW_NUMBER() OVER(ORDER BY (SELECT 1)), 
					asiento, fila, sinNumerar, precio, tipo
			FROM #ubicaciones
		END
		ELSE 
		BEGIN
			UPDATE cheshire_jack.publicaciones 
			SET cod_grado = @codGrado, cod_estado = @codEstado, fecha_publicacion = @fechaPublicacion, 
				cod_espectaculo = @codEspectaculoNuevo
			WHERE @codEspectaculo = cod_espectaculo

			DELETE FROM cheshire_jack.ubicaciones
			WHERE cod_publicacion IN (SELECT cod_publicacion FROM cheshire_jack.publicaciones WHERE cod_espectaculo = @codEspectaculoNuevo)

			DECLARE @codPublicacionIterativo NUMERIC(18,0) = (SELECT MIN(cod_publicacion) FROM cheshire_jack.publicaciones WHERE cod_espectaculo = @codEspectaculoNuevo)

			WHILE(@codPublicacionIterativo IS NOT NULL)
			BEGIN
				INSERT INTO cheshire_jack.ubicaciones
				(cod_publicacion, nro_ubicacion, asiento, fila, sin_numerar, precio, cod_tipo)
				SELECT @codPublicacionIterativo, ROW_NUMBER() OVER(ORDER BY (SELECT 1)), 
						asiento, fila, sinNumerar, precio, tipo
				FROM #ubicaciones

				SELECT @codPublicacionIterativo = MIN(cod_publicacion) FROM cheshire_jack.publicaciones WHERE cod_espectaculo = @codEspectaculoNuevo AND cod_publicacion > @codPublicacionIterativo
			END
			
		END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
	RETURN @codEspectaculoNuevo
END

GO
CREATE FUNCTION cheshire_jack.getCodEmpresa
(@codUsuario INT, @deshabilitados BIT = 0)
RETURNS INT
AS BEGIN
	DECLARE @ret INT
	SELECT @ret = cod_empresa FROM cheshire_jack.empresas 
	WHERE cod_usuario = @codUsuario AND (@deshabilitados = 1 OR habilitado = 1)
	RETURN COALESCE(@ret, 0)
END

GO 
CREATE PROCEDURE cheshire_jack.listadoPuntosVencidos
(@anio INT, @trimestre TINYINT)
AS BEGIN
	SELECT TOP 5 nombre Nombre, apellido Apellido, tipo_documento [Tipo de Documento],
	nro_documento [Nro de Documento], telefono Telefono, mail [E-Mail]
	FROM cheshire_jack.puntos p JOIN cheshire_jack.clientes c 
	ON p.cod_cliente = c.cod_cliente WHERE p.anio_vencimiento = @anio + 1
	ORDER BY p.cantidad DESC
END

GO
CREATE PROCEDURE cheshire_jack.listadoLocalidadesNoVendidas
(@anio INT, @trimestre TINYINT)
AS BEGIN
	SELECT TOP 5 emp.cod_empresa, COUNT(*) Total
	INTO #peoresVendedores 
	FROM cheshire_jack.empresas emp JOIN cheshire_jack.espectaculos esp ON emp.cod_empresa = esp.cod_empresa
	JOIN cheshire_jack.publicaciones pub ON pub.cod_espectaculo = esp.cod_espectaculo
	JOIN cheshire_jack.ubicaciones ubi ON pub.cod_publicacion = ubi.cod_publicacion
	WHERE cheshire_jack.fechaEnTrimestre(pub.fecha_evento, @anio, @trimestre) = 1 AND
	NOT EXISTS (SELECT 1 FROM cheshire_jack.compras WHERE pub.cod_publicacion = cod_publicacion AND ubi.nro_ubicacion = nro_ubicacion)
	GROUP BY emp.cod_empresa

	SELECT pv.Total, emp.razon_social, emp.CUIT, esp.descripcion, gra.nombre Grado, 
	pub.fecha_evento, ubi.asiento, ubi.fila 
	FROM #peoresVendedores PV
	JOIN cheshire_jack.empresas emp ON PV.cod_empresa = emp.cod_empresa 
	JOIN cheshire_jack.espectaculos esp ON PV.cod_empresa = esp.cod_empresa
	JOIN cheshire_jack.publicaciones pub ON pub.cod_espectaculo = esp.cod_espectaculo
	JOIN cheshire_jack.grados_de_publicacion gra ON pub.cod_grado = gra.cod_grado
	JOIN cheshire_jack.ubicaciones ubi ON pub.cod_publicacion = ubi.cod_publicacion
	WHERE cheshire_jack.fechaEnTrimestre(pub.fecha_evento, @anio, @trimestre) = 1 AND
	NOT EXISTS (SELECT 1 FROM cheshire_jack.compras WHERE pub.cod_publicacion = cod_publicacion AND ubi.nro_ubicacion = nro_ubicacion)
	ORDER BY Total DESC, fecha_evento DESC, peso DESC
END

GO 
CREATE PROCEDURE cheshire_jack.listadoMayoresCompradores
(@anio INT, @trimestre TINYINT)
AS BEGIN
	SELECT TOP 5 cod_cliente, COUNT(cod_compra) cantCompras
	INTO #mayoresCompradores
	FROM cheshire_jack.compras
	WHERE cheshire_jack.fechaEnTrimestre(fecha, @anio, @trimestre) = 1
	GROUP BY cod_cliente

	SELECT apellido, nombre, tipo_documento [Tipo de Documento], 
	nro_documento [Nro de Documento], razon_social Empresa, COUNT(DISTINCT com.cod_publicacion) [Cant de Publicaciones],
	cantCompras [Total de Compras]
	FROM cheshire_jack.clientes cli JOIN #mayoresCompradores MC ON MC.cod_cliente = cli.cod_cliente
		JOIN cheshire_jack.compras com ON MC.cod_cliente = com.cod_cliente
		JOIN cheshire_jack.publicaciones pub ON com.cod_publicacion = pub.cod_publicacion
		JOIN cheshire_jack.espectaculos esp ON esp.cod_espectaculo = pub.cod_espectaculo
		JOIN cheshire_jack.empresas emp ON emp.cod_empresa = esp.cod_empresa 
	WHERE cheshire_jack.fechaEnTrimestre(com.fecha, @anio, @trimestre) = 1
	GROUP BY apellido, nombre, tipo_documento, nro_documento, razon_social, cantCompras
	ORDER BY cantCompras DESC
END


GO
CREATE VIEW cheshire_jack.vw_publicaciones AS
SELECT p.cod_publicacion, p.fecha_evento [Fecha Evento], p.fecha_publicacion,
e.descripcion Descripcion, e.direccion Direccion, e.altura Altura, gp.cod_grado, 
gp.nombre Grado, gp.peso, r.cod_rubro, r.descripcion Rubro
FROM cheshire_jack.publicaciones p JOIN cheshire_jack.espectaculos e 
ON p.cod_espectaculo = e.cod_espectaculo JOIN cheshire_jack.empresas emp 
ON emp.cod_empresa = e.cod_empresa JOIN cheshire_jack.grados_de_publicacion gp
ON p.cod_grado = gp.cod_grado JOIN cheshire_jack.rubros r
ON e.cod_rubro = r.cod_rubro 
WHERE emp.habilitado = 1 AND p.cod_estado = 2

GO
CREATE FUNCTION cheshire_jack.obtenerTotalDePaginasCompras
(@fechaHoy DATETIME, @tamPagina INT, @cod_rubro INT, @desde DATETIME, 
@hasta DATETIME, @descripcion NVARCHAR(255)) 
RETURNS INT
AS BEGIN
	DECLARE @cant INT
	SELECT @cant = COUNT(*) 
	FROM cheshire_jack.vw_publicaciones 
	WHERE [Fecha Evento] > @fechaHoy AND 
	(@cod_rubro IS NULL OR cod_rubro = @cod_rubro) AND
	(@desde IS NULL OR [Fecha Evento] >= @desde) AND
	(@hasta IS NULL OR @hasta >= [Fecha Evento]) AND
	(@descripcion IS NULL OR Descripcion LIKE ('%' + @descripcion + '%'))

	IF @cant % @tamPagina = 0
		SET @cant /= @tamPagina
	ELSE
		SET @cant = @cant / @tamPagina + 1
	RETURN @cant
END

GO
CREATE PROCEDURE cheshire_jack.obtenerPaginaDeCompras
(@fechaHoy DATETIME, @nroPagina INT, @tamPagina INT, @cod_rubro INT, @desde DATETIME, 
@hasta DATETIME, @descripcion NVARCHAR(255))
AS BEGIN
	SELECT TOP (@tamPagina * @nroPagina) *
	INTO #paginas
	FROM cheshire_jack.vw_publicaciones 
	WHERE [Fecha Evento] > @fechaHoy AND 
	(@cod_rubro IS NULL OR cod_rubro = @cod_rubro) AND
	(@desde IS NULL OR [Fecha Evento] >= @desde) AND
	(@hasta IS NULL OR @hasta >= [Fecha Evento]) AND
	(@descripcion IS NULL OR Descripcion LIKE ('%' + @descripcion + '%'))
	ORDER BY peso DESC, cod_publicacion ASC

	SELECT TOP (@tamPagina) * FROM #paginas ORDER BY peso ASC, cod_publicacion DESC
END

GO 
CREATE PROCEDURE cheshire_jack.obtenerUltimaPaginaDeCompras
(@fechaHoy DATETIME, @tamPagina INT, @cod_rubro INT, @desde DATETIME, 
@hasta DATETIME, @descripcion NVARCHAR(255))
AS BEGIN
	DECLARE @resto INT
	SELECT @resto = COUNT(*) % @tamPagina 
	FROM cheshire_jack.vw_publicaciones 
	WHERE [Fecha Evento] > @fechaHoy AND 
	(@cod_rubro IS NULL OR cod_rubro = @cod_rubro) AND
	(@desde IS NULL OR [Fecha Evento] >= @desde) AND
	(@hasta IS NULL OR @hasta >= [Fecha Evento]) AND
	(@descripcion IS NULL OR Descripcion LIKE ('%' + @descripcion + '%'))
	
	SELECT TOP (CASE WHEN @resto = 0 THEN @tamPagina ELSE @resto END) *
	FROM cheshire_jack.vw_publicaciones 
	WHERE [Fecha Evento] > @fechaHoy AND 
	(@cod_rubro IS NULL OR cod_rubro = @cod_rubro) AND
	(@desde IS NULL OR [Fecha Evento] >= @desde) AND
	(@hasta IS NULL OR @hasta >= [Fecha Evento]) AND
	(@descripcion IS NULL OR Descripcion LIKE ('%' + @descripcion + '%'))
	ORDER BY peso ASC, cod_publicacion DESC
END

GO
ALTER PROCEDURE cheshire_jack.buscarUbicaciones
(@codPublicacion NUMERIC(18,0), @tipoUbicacion INT = NULL)
AS BEGIN
	SELECT u.nro_ubicacion, TdP.descripcion [Tipo de Ubicacion], u.fila Fila, u.asiento Asiento, 
	~u.sin_numerar Numerada, u.precio Precio
	FROM cheshire_jack.ubicaciones u 
	JOIN cheshire_jack.tipos_de_ubicacion TdP ON u.cod_tipo = TdP.cod_tipo
	WHERE cod_publicacion = @codPublicacion AND 
		NOT EXISTS (SELECT 1 FROM cheshire_jack.compras c 
						WHERE c.cod_publicacion = u.cod_publicacion 
						AND c.nro_ubicacion = u.nro_ubicacion)
		AND (@tipoUbicacion IS NULL OR u.cod_tipo = @tipoUbicacion)
END

GO 
CREATE VIEW cheshire_jack.vw_tipos_de_ubicacion AS
SELECT cod_tipo, descripcion nombre FROM cheshire_jack.tipos_de_ubicacion
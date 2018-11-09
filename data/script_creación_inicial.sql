USE GD2C2018
GO

CREATE SCHEMA cheshire_jack
GO

CREATE TABLE cheshire_jack.usuarios (
	cod_usuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
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
	CUIL CHAR(14),
	apellido NVARCHAR(255) NOT NULL,
	nombre NVARCHAR(255) NOT NULL,
	fecha_nacimiento DATETIME NOT NULL,
	mail NVARCHAR(255) CHECK(mail LIKE '_%@_%._%') NOT NULL,
	telefono CHAR(14),
	localidad NVARCHAR(255),
	domicilio_calle NVARCHAR(255) NOT NULL,
	nro_calle NUMERIC(18,0) NOT NULL CHECK(nro_calle > 0),
	piso TINYINT,
	dept NVARCHAR(50),
	codigo_postal NVARCHAR(255),
	fecha_creacion DATETIME,
	cod_usuario INT
	)

CREATE TABLE cheshire_jack.empresas (
	cod_empresa INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	razon_social NVARCHAR(255) NOT NULL,
	CUIT NVARCHAR(14) NOT NULL,
	fecha_creacion DATETIME,
	mail NVARCHAR(255) CHECK(mail LIKE '_%@_%._%'),
	telefono CHAR(14),
	ciudad NVARCHAR(255),
	domicilio_calle NVARCHAR(50) NOT NULL,
	nro_calle NUMERIC(18,0) NOT NULL CHECK(nro_calle > 0),
	piso NUMERIC(18,0),
	dept NVARCHAR(50),
	codigo_postal NVARCHAR(50),
	cod_usuario INT
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
	forma_pago VARCHAR(255) NOT NULL
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
	cod_cliente INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.usuarios(cod_Usuario),
	cod_premio INT NOT NULL FOREIGN KEY REFERENCES cheshire_jack.premios(cod_premio),
	PRIMARY KEY(cod_cliente, cod_premio)
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

INSERT INTO cheshire_jack.grados_de_publicacion
(nombre, comision, peso)
VALUES ('Baja', 0.05, 1),
('Media', 0.1, 2),
('Alta', 0.2, 3),
('S.D.', 0.0, 0)

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
('Generar Rendicion de Compra'),
('Historial Cliente'),
('Listado Estadistico')

INSERT INTO cheshire_jack.RolesxFuncionalidades
(cod_funcionalidad, cod_rol)
VALUES (6, 2),
(7, 2),
(8, 1),
(9, 1),
(11, 2)

INSERT INTO cheshire_jack.RolesxFuncionalidades
(cod_funcionalidad, cod_rol)
SELECT cod_funcionalidad, 3 
FROM cheshire_jack.funcionalidades

INSERT INTO cheshire_jack.usuarios
(nombre_usuario, contrasenia, contrasenia_automatica)
VALUES ('admin', '23018411280191203129672521842191112164220158208131447722162427420917723222015220155231', 0)

INSERT INTO cheshire_jack.usuariosXRoles
(cod_usuario, cod_rol)
SELECT 1, cod_rol 
FROM cheshire_jack.roles

GO
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

DECLARE @cantidadClientes INT, @usuarioActual INT, @cantidadEmpresas INT

SET @cantidadClientes = (SELECT COUNT(*) FROM cheshire_jack.clientes)
SET	@usuarioActual = 0

WHILE @usuarioActual < @cantidadClientes
BEGIN
	INSERT INTO cheshire_jack.usuarios
	(nombre_usuario, contrasenia)
	VALUES
	('clienteImportado' + CAST(1 + @usuarioActual AS VARCHAR), 
	'596862374011182110423175134179201677017974934059176207194179572531874953111238')

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
	('empresaImportada' + CAST(1 + @usuarioActual AS CHAR), 
	'596862374011182110423175134179201677017974934059176207194179572531874953111238')

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
--Fin importaci�n

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
		RAISERROR('No se puede canjear algo sin stock',16, 1)
	END
	
	DECLARE @cantidad_puntos_actuales NUMERIC(18,0), @costo_premio NUMERIC(18,0)
	SELECT @cantidad_puntos_actuales = cantidad FROM GD2C2018.cheshire_jack.puntos WHERE @cod_cliente = cod_cliente AND YEAR(@fecha_actual) < anio_vencimiento
	SELECT @costo_premio = valor FROM GD2C2018.cheshire_jack.premios WHERE cod_premio = @cod_premio

	IF @cantidad_puntos_actuales IS NULL OR @cantidad_puntos_actuales < @costo_premio
	BEGIN
		RAISERROR('El premio cuesta m�s que los puntos disponibles', 16, 1)
	END

	BEGIN TRANSACTION
		INSERT INTO GD2C2018.cheshire_jack.canjes
		(cod_premio, cod_cliente)
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
CREATE PROCEDURE cheshire_jack.crearCliente
(@nombre NVARCHAR(255), @apellido NVARCHAR(255), @tipoDocumento NVARCHAR(255), @nroDocumento NUMERIC(18,0), 
@CUIL NVARCHAR(255), @telefono NVARCHAR(255), @domicilio NVARCHAR(255), @nroCalle NUMERIC(18,0), @piso NUMERIC(18,0),
@dept NVARCHAR(255), @localidad NVARCHAR(255), @codPostal NVARCHAR(255), @fechaCreacion DATETIME, @fechaNacimiento DATETIME, 
@codUsuario INT, @codCliente INT OUT)
AS BEGIN
	INSERT INTO cheshire_jack.clientes
	(nombre, apellido, telefono, CUIL, tipo_documento, nro_documento, domicilio_calle, 
	nro_calle, piso, dept, localidad, codigo_postal, fecha_creacion, fecha_nacimiento, cod_usuario)
	VALUES (@nombre, @apellido, @telefono, @CUIL, @tipoDocumento, @nroDocumento, @domicilio, @nroCalle,
			@piso, @dept, @localidad, @codPostal, @fechaCreacion, @fechaNacimiento, @codUsuario)

	SET @codCliente = SCOPE_IDENTITY()
END

GO
/*
Valores de retorno:
0 - Usuario no existente
1 - Contrase�a invalida
2 - Usuario deshabilitado
3 - Usuario bloqueado por intentos fallidos
4 - Contrase�a automatica gastada
5 - Datos correctos
6 - Contrase�a de un uso
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
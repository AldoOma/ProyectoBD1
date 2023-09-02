--PROYECTO MARKET
/*
BR. ALDO MOLINA
BR. YOSUER MARTINEZ

SCRIPT:
*/

USE MASTER
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME = 'BD_MARKET')
	DROP DATABASE BD_MARKET
GO

CREATE DATABASE BD_MARKET
GO

USE BD_MARKET

GO

--REGLA QUE SE USARÁ PARA VALIDA PRECIO Y SALARIO
CREATE RULE RG_MayorQueCero 
AS @Numero > 0
GO

---REGLA PARA QUE EL CAMPO CEDULA SIGA UN PATRON
CREATE RULE RG_PatronCedula 
AS @Cedula LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][A-Z]';
GO

/*SELECT NAME FROM SYSOBJECTS WHERE XTYPE = 'R';*/

---REGLA PARA VALIDAR QUE LAS FECHAS SEAN ANTES O HOY 
CREATE RULE RG_FechaValida
AS @Fecha <= CONVERT(DATE,GETDATE());
GO


CREATE TABLE Cargos
(
Id INT IDENTITY(1,1) NOT NULL, 
Nombre VARCHAR(30) NOT NULL,
Descripcion VARCHAR(100),
Salario FLOAT NOT NULL,
Estado BIT NOT NULL CONSTRAINT DF_Cargos_Estado DEFAULT 1,
CONSTRAINT PK_CLongitudCadenaargos_Id PRIMARY KEY(Id),
CONSTRAINT UQ_Cargos_Nombre UNIQUE(Nombre)
)
GO

EXEC SP_BINDRULE RG_MayorQueCero, 'Cargos.Salario'

GO

CREATE TABLE Empleados
(
Id INT IDENTITY(1,1) NOT NULL, 
Cedula VARCHAR(16) NOT NULL,
PrimerNombre VARCHAR(30) NOT NULL,
SegundoNombre VARCHAR(30),
PrimerApellido VARCHAR(30) NOT NULL,
SegundoApellido VARCHAR(30),
IdCargo INT NOT NULL, 
FechaIngreso DATE NOT NULL,
Estado BIT NOT NULL CONSTRAINT DF_Empleados_Estado DEFAULT 1,
FechaSalida DATE,
CONSTRAINT PK_Empleados_Id PRIMARY KEY(Id), 
CONSTRAINT UQ_Empleados_Cedula UNIQUE(Cedula), 
CONSTRAINT FK_Empleados_IdCargo FOREIGN KEY(IdCargo) REFERENCES Cargos(Id)
)
GO

EXEC SP_BINDRULE RG_FechaValida, 'Empleados.FechaIngreso'

EXEC SP_BINDRULE RG_FechaValida, 'Empleados.FechaSalida'

EXEC SP_BINDRULE RG_PatronCedula, 'Empleados.Cedula'

GO


--Tabla Roles
-- vendedor y administrador
CREATE TABLE Roles
(
Id INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(30) NOT NULL,
CONSTRAINT PK_Roles_Id PRIMARY KEY(Id),
CONSTRAINT UQ_Roles_Nombre UNIQUE(Nombre)
)
GO

---TABLA USUARIOS
/*
Encryption type  = deterministic
Usa el metodo que genera siempre el mismo texto cifrado para cualquier 
texto no cifrado. 
Puede permitir que los usuario averiguen el valor del texto cifrado examinando
patrones, es predecible pero va a permitir comparar las cadenas.

si lo ponemos como aleatorio (RANDOMIZED) seria más seguro pero 
esto impediria las busquedas de igualdad, agrupacion, 
indexacion, la union en columnas cifradas y calculos.


Indicamos el algoritmo con el que deseamos encriptar

Con las columnas encriptadas no podremos usar un insert normal en el query
porque el insert debe producirse a traves de ADO.NET en una aplicación cliente.
*/
/*
CREATE TABLE Usuarios
(
Id INT NOT NULL, 
Nombre VARCHAR(30) NOT NULL,
Contrasenia VARCHAR(50) COLLATE Latin1_General_BIN2 ENCRYPTED WITH (ENCRYPTION_TYPE = DETERMINISTIC
, ALGORITHM = 'AEAD_AES_256_CBC_HMAC_SHA_256', 
COLUMN_ENCRYPTION_KEY = CEK1) NOT NULL,
IdRol INT NOT NULL,
FechaCreacion DATE NOT NULL,
HoraCreacion TIME NOT NULL,
CONSTRAINT PK_Usuarios_Id PRIMARY KEY(Id),
CONSTRAINT FK_Usuarios_IdEmpleado FOREIGN KEY(Id) REFERENCES 
Empleados(Id),
CONSTRAINT FK_Roles_IdRol FOREIGN KEY(IdRol) REFERENCES Roles(Id)
)
GO
*/

CREATE TABLE Usuarios
(
Id INT NOT NULL, 
Nombre VARCHAR(30) NOT NULL,
Contrasenia VARCHAR(50) NOT NULL,
IdRol INT NOT NULL,
FechaCreacion DATE NOT NULL,
HoraCreacion TIME NOT NULL,
UltimaActualizacion DATETIME,
Estado BIT NOT NULL CONSTRAINT DF_Usuarios_Estado DEFAULT 1,
CONSTRAINT PK_Usuarios_Id PRIMARY KEY(Id),
CONSTRAINT FK_Usuarios_IdEmpleado FOREIGN KEY(Id) REFERENCES 
Empleados(Id),
CONSTRAINT FK_Roles_IdRol FOREIGN KEY(IdRol) REFERENCES Roles(Id),
CONSTRAINT UQ_Usuarios_Nombre UNIQUE(Nombre)
)

GO

EXEC SP_BINDRULE RG_FechaValida, 'Usuarios.FechaCreacion';

GO

--TABLA MODULO
--Gestion de usuarios, Gestion de Productos, Gestion de Clientes, Gestion de Existencias, Reportes
CREATE TABLE Modulos
(
Id INT IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(30) NOT NULL, 
Estado BIT NOT NULL CONSTRAINT DF_Modulos_Estado DEFAULT 1,
CONSTRAINT PK_Modulos_Id PRIMARY KEY(Id),
CONSTRAINT UQ_Modulos_Nombre UNIQUE(Nombre)
)

GO

--TABLA Opcion
/*
Gestion de existencias: ventas y compras
Gestion de productos: categoria, productos y proveedores
Gestion de usuarios: usuarios y empleados
Gestion de clientes: clientes
*/
CREATE TABLE Opciones
(
Id INT IDENTITY(1,1) NOT NULL, 
Nombre VARCHAR(30) NOT NULL, 
IdModulo INT NOT NULL,
Estado BIT NOT NULL CONSTRAINT DF_Opciones_Estado DEFAULT 1,
CONSTRAINT PK_Opcion_Id PRIMARY KEY(Id),
CONSTRAINT UQ_Opcion_Nombre UNIQUE(Nombre),
CONSTRAINT FK_Opcion_IdModulo FOREIGN KEY(IdModulo) REFERENCES Modulos(Id)
)
GO

--Tabla Permisos 
CREATE TABLE PermisosRoles
(
Id INT IDENTITY(1,1) NOT NULL,
IdRol INT NOT NULL,
IdOpcion INT NOT NULL,
Permitido BIT NOT NULL CONSTRAINT DF_PermisosRoles_Permitido DEFAULT 1,
CONSTRAINT PK_PermisosRoles_Id PRIMARY KEY(Id),
CONSTRAINT FK_PermisosRoles_IdRol FOREIGN KEY(IdRol) REFERENCES Roles(Id),
CONSTRAINT FK_PermisosRoles_IdOpcion FOREIGN KEY(IdOpcion) REFERENCES Opciones(Id));

GO 

CREATE TABLE Categorias
(
Id INT IDENTITY(1,1) NOT NULL, 
Nombre VARCHAR(30) NOT NULL,
Descripcion VARCHAR(100) NOT NULL,
Estado BIT NOT NULL CONSTRAINT DF_Categorias_Estado DEFAULT 1,
CONSTRAINT PK_Categorias_Id PRIMARY KEY(Id),
CONSTRAINT UQ_Categorias_Nombre UNIQUE(Nombre)
)
GO

---PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CARGOS---

--FUNCION QUE VERIFICA SI EL NOMBRE DEL CARGO YA EXISTE
CREATE FUNCTION FN_CargoExiste
(@Nombre VARCHAR(30))
RETURNS BIT
AS
BEGIN
	DECLARE @resultado BIT;
	IF EXISTS(SELECT 1 FROM Cargos WHERE Nombre = @Nombre )--si el cargo ya existe entonces que devuelva uno
		SET @resultado = 1;
	ELSE 
		SET @resultado = 0; --si la categoria no existe devolverá 0

	RETURN @resultado;
END

GO

--PROCEDIMIENTO ALMACENADO PARA MOSTRAR TODOS LOS CARGOS
CREATE PROCEDURE SP_MostrarCargos
AS
BEGIN
	SELECT Id, Nombre, Descripcion, Salario FROM Cargos WHERE Estado = 1;
END

GO

--PROCEDIMIENTO ALMACENADO PARA AGREGAR UN CARGO
CREATE PROCEDURE SP_AgregarCargo
@Nombre VARCHAR(30),
@Descripcion VARCHAR(100) = NULL,
@Salario FLOAT
AS
BEGIN
	DECLARE @SinErrores BIT
	
	SET @SinErrores = 1

	DECLARE @CargoExiste BIT


	IF @NOMBRE IS NULL OR @NOMBRE = ''
	BEGIN
		SET @SinErrores = 0
		PRINT 'Nombre del cargo no puede estar vacio'
	END
	IF @Salario IS NULL OR @Salario<=0
	BEGIN
		SET @SinErrores = 0
		PRINT 'Se necesitan valores superiores a 0 para el salario'
	END
	IF @SinErrores = 0 --SI NOMBRE O SALARIO ESTÁN VACIOS O SALARIO ES MENOR O IGUAL A 0 ENTONCES QUE SE SALGA
	BEGIN
		RETURN ;
	END
	ELSE --COMO NOMBRE NO ES VACIO NI NULO Y SALARIO MAYOR QUE 0 ENTONCES 
		SET @CargoExiste = dbo.FN_CargoExiste(@Nombre)--COMPROBAMOS SI EL NOMBRE DEL CARGO AUN NO EXISTE
		IF @CargoExiste = 0 --COMO NO EXISTE ENTONCES INSERTAMOS
			INSERT INTO Cargos(Nombre, Descripcion, Salario) VALUES(@Nombre, @Descripcion, @Salario)
		ELSE --SI EXISTE IMPRIMIMOS
			PRINT 'Cargo ya existe'
END

GO

--PROCEDIMIENTO ALMACENADO PARA EDITAR UN CARGO
CREATE PROCEDURE SP_EditarCargo
@Id INT,
@Nombre VARCHAR(30),
@Descripcion VARCHAR(100),
@Salario FLOAT
AS
BEGIN
	
	DECLARE @CargoExiste BIT

	DECLARE @NombreC VARCHAR(30)
	DECLARE @DescripcionC VARCHAR(100)
	DECLARE @SalarioC FLOAT

		IF EXISTS(SELECT 1 FROM Cargos WHERE Id = @Id)--SI EL ID EXISTE ENTONCES PODREMOS EDITAR
		BEGIN
			--VALIDEMOS QUE NOMBRE Y SALARIO NO ESTEN VACIOS O SALARIO MENOR O IGUAL A 0
			
				--AHORA VALIDEMOS QUE EL NOMBRE NO SEA EL MISMO QUE YA TENIA, SI NO ES EL MISMO ACUALIZAMOS NOMBRE
				SET @NombreC = (SELECT Nombre FROM Cargos WHERE Id = @Id)
				IF(@Nombre != @NombreC)
				BEGIN
				--VALIDEMOS QUE EL NOMBRE DE CARGO NO EXISTA 
					SET @CargoExiste = dbo.FN_CargoExiste(@Nombre)
					IF @CargoExiste = 1
					BEGIN
						PRINT CONCAT(@Nombre, ' es un cargo que ya esta registrado')
						RETURN;
					END
					ELSE
					IF @Nombre IS NOT NULL AND @Nombre != ''
					BEGIN
						UPDATE Cargos SET Nombre = @Nombre WHERE Id = @Id
					END
					ELSE 
						PRINT 'No se puede establecer un valor vacio o nulo como nombre del cargo'
				END

				--AHORA VALIDEMOS QUE LA DESCRIPCION NO SEA LA MISMA QUE YA TENIA, SI NO ES EL MISMO ACUALIZAMOS DESCRIPCION
				SET @DescripcionC = (SELECT Descripcion FROM Cargos WHERE Id = @Id)

				IF @DescripcionC IS NULL 
				BEGIN
				SET @DescripcionC = ''
				END
			

				IF(@Descripcion != @DescripcionC)
				BEGIN
					UPDATE Cargos SET Descripcion = @Descripcion WHERE Id = @Id
				END

				--AHORA VALIDEMOS QUE EL SALARIO NO SEA EL MISMO QUE YA TENIA, SI NO ES EL MISMO ACUALIZAMOS SALARIO
				SET @SalarioC = (SELECT Salario FROM Cargos WHERE Id = @Id)
				IF(@Salario != @SalarioC)
					IF @Salario > 0
					BEGIN
						UPDATE Cargos SET Salario = @Salario WHERE Id = @Id
					END
					ELSE
						PRINT 'Salario debe ser mayor a 0'
				END
			END
GO

--PROCEDIMIENTO ALMACENADO PARA ELIMINAR UN CARGO
CREATE PROCEDURE SP_EliminarCargo
@Id INT
AS
BEGIN
--AL ELIMINAR EL CARGO LOS EMPLEADOS QUE TENGAN ESE CARGO DEBERÁN SER ELIMINADOS
	IF @Id IS NOT NULL OR @Id != 0
	BEGIN
		UPDATE Cargos SET Estado = 0 WHERE Id = @Id
		UPDATE Empleados SET Estado = 0 WHERE IdCargo = @Id
	END
END

GO

--PROCEDIMIENTO ALMACENADO QUE SE USARA PARA LLENAR LOS CAMPOS CUANDO SE TRATE DE EDITAR
CREATE PROCEDURE SP_ObtenerCargoPorId
@Id INT
AS
BEGIN
	SELECT Id, Nombre, Descripcion, Salario FROM Cargos WHERE Id = @Id;
	
END
GO

--PROCEDIMIENTOS ALMACENADOS PARA LA TABLA EMPLEADOS

--PROCEDIMIENTO ALMACENADO PARA MOSTRAR A LOS EMPLEADOS
CREATE PROCEDURE SP_MostrarEmpleados
AS
BEGIN
	
	DECLARE @Empleados TABLE
	(
	Id INT, 
	Cedula VARCHAR(16),
	NombreCompleto VARCHAR(100),
	IdCargo INT, 
	NombreCargo VARCHAR(30),
	FechaIngreso DATE,
	Estado BIT
	)
		DECLARE @NombreCargo VARCHAR(30)

		
		INSERT INTO @Empleados(Id, Cedula, NombreCompleto, IdCargo,NombreCargo,FechaIngreso, Estado)
		SELECT Id, Cedula,CONCAT(PrimerNombre,' ',ISNULL(SegundoNombre,''),' ', PrimerApellido,' ', ISNULL(SegundoApellido,'')), IdCargo,NULL, FechaIngreso,Estado FROM Empleados


		DECLARE @Contador INT
		SET @Contador = (SELECT COUNT(*) FROM Empleados)
		
		WHILE @Contador >= 1
		BEGIN
		UPDATE @Empleados SET NombreCargo = (SELECT Nombre FROM Cargos WHERE Id = IdCargo)
		SET @Contador = @Contador - 1
		END

		SELECT Id, Cedula, NombreCompleto,NombreCargo,FechaIngreso  FROM @Empleados WHERE Estado = 1;
END

GO

CREATE PROCEDURE SP_ObtenerNombresCargos
AS
BEGIN
	SELECT Id,Nombre FROM Cargos WHERE Estado = 1;
END
GO

--CREAMOS UNA FUNCION PARA VERIFICAR SI LA CEDULA YA LE PERTENECE A OTRO EMPLEADO
CREATE FUNCTION FN_CedulaExiste
(
@Cedula VARCHAR(16)
)
RETURNS BIT 
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Empleados WHERE Cedula = @Cedula)--SI LA CEDULA YA EXISTE QUE DEVUELVA 1
	BEGIN
		RETURN 1; 
	END;

	RETURN 0;
END

GO

--PROCEDIMIENTO PARA INSERTAR UN EMPLEADO
CREATE PROCEDURE SP_AgregarEmpleado
@Cedula VARCHAR(16),
@PrimerNombre VARCHAR(30),
@SegundoNombre VARCHAR(30),
@PrimerApellido VARCHAR(30),
@SegundoApellido VARCHAR(30),
@IdCargo INT, 
@FechaIngreso DATE
AS
BEGIN
	DECLARE @CedulaE VARCHAR(16)
	DECLARE @CargoExiste BIT
	DECLARE @FormatoCedulaValido BIT
	
	IF @Cedula LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][A-Z]'
	BEGIN
		SET @FormatoCedulaValido = 1
	END
	ELSE 
	BEGIN
		SET @FormatoCedulaValido = 0
		PRINT 'Numero de cedula no valido'
		RETURN;
	END


	
		
		--VALIDAMOS QUE LA CEDULA NO SEA UNA QUE YA EXISTE
		SET @CedulaE = dbo.FN_CedulaExiste(@Cedula);
		IF @CedulaE = 1--LA CEDULA YA LE PERTENECE A OTRO EMPLEADO
		BEGIN
			PRINT CONCAT('La cedula ', @Cedula, ' le pertenece a otro empleado')
		END
		ELSE
			--VALIDAMOS QUE EL ID QUE RECIBIMOS DEL CARGO EXISTE
			SET @CargoExiste = (SELECT 1 FROM Cargos WHERE Id = @IdCargo AND Estado = 1)
			--SI EL CARGO EXISTE ENTONCES Y ESTA ACTIVO ENTONCES QUE INSERTE AL EMPLEADO
			IF @CargoExiste = 1
			BEGIN
				INSERT INTO Empleados(Cedula, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, IdCargo, FechaIngreso) VALUES(@Cedula, @PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@IdCargo,@FechaIngreso)
			END
END
GO

--PROCEDIMIENTO PARA EDITAR UN EMPLEADO
CREATE PROCEDURE SP_EditarEmpleado
@Id INT,
@Cedula VARCHAR(16),
@PrimerNombre VARCHAR(30),
@SegundoNombre VARCHAR(30),
@PrimerApellido VARCHAR(30),
@SegundoApellido VARCHAR(30),
@IdCargo INT, 
@FechaIngreso DATE
AS
BEGIN
	DECLARE @CedulaE VARCHAR(16)
	DECLARE @PrimerNombreE VARCHAR(30)
	DECLARE @SegundoNombreE VARCHAR(30)
	DECLARE @PrimerApellidoE VARCHAR(30)
	DECLARE @SegundoApellidoE VARCHAR(30)
	DECLARE @IdCargoE INT
	DECLARE @FechaIngresoE DATE

	DECLARE @CargoExiste BIT
	DECLARE @CedulaExiste BIT

	DECLARE @FechaActual DATE = CONVERT(DATE,GETDATE())

	IF EXISTS(SELECT 1 FROM Empleados WHERE Id = @Id)--SI EL EMPLEADO EXISTE
	BEGIN
	--PRIMERO VALIDAMOS QUE LOS CAMPOS NO SEAN NULOS Y QUE EL ID NO SEA 0 O MENOR QUE 0
	IF ((@Cedula IS NOT NULL AND LEN(@Cedula)=16) AND (@PrimerNombre IS NOT NULL AND @PrimerNombre != '')
	AND (@PrimerApellido IS NOT NULL AND @PrimerApellido != '') AND @IdCargo IS NOT NULL AND @FechaIngreso IS NOT NULL AND @FechaIngreso<=@FechaActual)
	BEGIN

		--VALIDAMOS QUE LA CEDULA QUE ESTOY RECIBIENDO NO SEA LA MISMA QUE YA TENIA ANTES
		SET @CedulaE = (SELECT Cedula FROM Empleados WHERE Id = @Id)
		IF(@Cedula != @CedulaE)--SI SON DIFERENTES ES PORQUE DESEA ACTUALIZARLA
		BEGIN
			--ENTONCES DEBEMOS VALIDAR QUE LA CEDULA NUEVA NO SEA IGUAL A OTRA DE LA TABLA
			SET @CedulaExiste = dbo.FN_CedulaExiste(@Cedula)
			IF @CedulaExiste = 1
			BEGIN
				PRINT '' + CONCAT('La cedula ', @Cedula, ' ya le pertenece a otro usuario')
			END
			ELSE --SI NO EXISTE LA CEDULA ENTONCES QUE LA ACTUALICE
				UPDATE Empleados SET Cedula = @Cedula WHERE Id = @Id
		END


		--VALIDAMOS QUE EL PRIMER NOMBRE QUE ESTOY RECIBIENDO NO ES EL MISMO QUE YA TENIA ANTES
		SET @PrimerNombreE = (SELECT PrimerNombre FROM Empleados WHERE Id = @Id)
		IF @PrimerNombre != @PrimerNombreE --SI SON DIFERENTES ENTONCES QUE LO ACTUALICE
		BEGIN
			UPDATE Empleados SET PrimerNombre = @PrimerNombre WHERE Id = @Id
		END

		--VALIDAMOS QUE EL SEGUNDO NOMBRE QUE ESTOY RECIBIENDO NO ES EL MISMO QUE YA TENIA ANTES
		SET @SegundoNombreE = (SELECT SegundoNombre FROM Empleados WHERE Id = @Id)
		IF @SegundoNombre != @SegundoNombreE --SI SON DIFERENTES ENTONCES QUE LO ACTUALICE
		BEGIN
			UPDATE Empleados SET SegundoNombre = @SegundoNombre WHERE Id = @Id
		END

		--VALIDAMOS QUE EL PRIMER APELLIDO QUE ESTOY RECIBIENDO NO ES EL MISMO QUE YA TENIA ANTES
		SET @PrimerApellidoE = (SELECT PrimerApellido FROM Empleados WHERE Id = @Id)
		IF @PrimerApellido != @PrimerApellidoE  --SI SON DIFERENTES ENTONCES QUE LO ACTUALICE
		BEGIN
			UPDATE Empleados SET PrimerApellido = @PrimerApellido WHERE Id = @Id
		END

		--VALIDAMOS QUE EL SEGUNDO APELLIDO QUE ESTOY RECIBIENDO NO ES EL MISMO QUE YA TENIA ANTES
		SET @SegundoApellidoE = (SELECT SegundoApellido FROM Empleados WHERE Id = @Id)
		IF @SegundoApellido != @SegundoApellidoE --SI SON DIFERENTES ENTONCES QUE LO ACTUALICE
		BEGIN
			UPDATE Empleados SET SegundoApellido = @SegundoApellido WHERE Id = @Id
		END

		--VALIDAMOS QUE EL ID DE CARGO NO SEA EL MISMO DE ANTES
		SET @IdCargoE = (SELECT IdCargo FROM Empleados WHERE Id = @Id)
		IF @IdCargo != @IdCargoE --SI SON DIFERENTES ENTONCES QUE LO ACTUALICE
		BEGIN
			UPDATE Empleados SET IdCargo = @IdCargo WHERE Id = @Id
		END
		--VALIDAMOS QUE LA FECHA DE INGRESO NO SEA LA QUE YA TIENE

		SET @FechaIngresoE = (SELECT FechaIngreso FROM Empleados WHERE Id = @Id)
		IF @FechaIngreso != @FechaIngresoE --SI LA FECHA NO ES LA MISMA QUE YA TENIA ANTES ENTONCES
		BEGIN
			IF @FechaIngreso > @FechaActual --SI LA FECHA ES MAYOR A LA DE HOY
			BEGIN
				PRINT CONVERT(VARCHAR(30),@FechaIngreso) + ' sobrepasa a la fecha de hoy'
			END
			ELSE --COMO ES MENOR O IGUAL A LA FECHA DE HOY ENTONCES QUE ACTUALICE LA FECHA
				UPDATE Empleados SET FechaIngreso = @FechaIngreso WHERE Id = @Id
		 END
	END
	END
END

GO

CREATE PROCEDURE SP_ObtenerEmpleadoPorId
@Id INT
AS
BEGIN
	DECLARE @Empleados TABLE
	(
	Id INT, 
	Cedula VARCHAR(16),
	NombreCompleto VARCHAR(100),
	ApellidoCompleto VARCHAR(100), 
	IdCargo INT,
	NombreCargo VARCHAR(30),
	FechaIngreso DATE,
	Estado BIT
	)

		
		INSERT INTO @Empleados(Id, Cedula, NombreCompleto, ApellidoCompleto, IdCargo,NombreCargo,FechaIngreso, Estado)
		SELECT Id, Cedula,CONCAT(PrimerNombre,' ',ISNULL(SegundoNombre,'')),CONCAT(PrimerApellido, ' ', ISNULL(SegundoApellido, '')), IdCargo,NULL, FechaIngreso,Estado FROM Empleados


		DECLARE @Contador INT
		SET @Contador = (SELECT COUNT(*) FROM Empleados)
		
		WHILE @Contador >= 1
		BEGIN
		UPDATE @Empleados SET NombreCargo = (SELECT Nombre FROM Cargos WHERE Id = IdCargo)
		SET @Contador = @Contador - 1
		END

		SELECT Cedula, NombreCompleto, ApellidoCompleto, NombreCargo, FechaIngreso,IdCargo FROM @Empleados WHERE Id = @Id;
END
GO

--PROCEDIMIENTO PARA DAR DE BAJA A UN EMPLEADO
CREATE PROCEDURE SP_EliminarEmpleado
@Id INT,
@FechaSalida DATE
AS
BEGIN
--SI SE ELIMINA EL EMPLEADO SE DEBE DE OBTENER LA FECHA EN LA QUE SE DA DE SALIDA DE LA EMPRESA
	UPDATE Empleados SET Estado = 0, FechaSalida = @FechaSalida WHERE Id = @Id
--SE DEBE DAR DE BAJA A SU USUARIO TAMBIÉN PARA QUE NO TENGA INGRESO A NUESTRO SISTEMA
	UPDATE Usuarios SET Estado = 0 WHERE Id = @Id;
--DE ESTA FORMA EL USUARIO SE VA DE LA TIENDA Y TAMBIÉN DEL SISTEMA
END

GO

--PROCEDIMIENTOS DE LA TABLA USUARIO

--PROCEDIMIENTO PARA MOSTRAR LOS USUARIOS

CREATE PROCEDURE SP_MostrarUsuarios
AS 
BEGIN
DECLARE @NombreCompleto VARCHAR(100)

	DECLARE @PrimerNombre VARCHAR(30)

	DECLARE @SegundoNombre VARCHAR(30)

	DECLARE @PrimerApellido VARCHAR(30)

	DECLARE @SegundoApellido VARCHAR(30)

	DECLARE @Cargo VARCHAR(30)


	SET @PrimerNombre = (SELECT PrimerNombre FROM Empleados)

	SET @NombreCompleto = @PrimerNombre

	SET @SegundoNombre = (SELECT SegundoNombre FROM Empleados)

	IF @SegundoNombre IS NOT NULL 
	BEGIN
		SET @NombreCompleto = CONCAT(@NombreCompleto,' ',@SegundoNombre)
	END
	
	SET @PrimerApellido = (SELECT PrimerApellido FROM Empleados)

	SET @NombreCompleto = CONCAT(@NombreCompleto, ' ', @PrimerApellido)


	SET @SegundoApellido = (SELECT SegundoApellido FROM Empleados)

	IF @SegundoApellido IS NOT NULL
	BEGIN
		SET @NombreCompleto = CONCAT(@NombreCompleto,' ',@SegundoApellido)
	END

	SELECT u.Id, u.Nombre, @NombreCompleto 'Empleado', CONCAT(CONVERT(VARCHAR(30), FechaCreacion),' ', CONVERT(VARCHAR(30),HoraCreacion)) 'Fecha/Hora de creacion', UltimaActualizacion FROM Usuarios u JOIN Empleados e ON u.Id = e.Id WHERE u.Estado = 1;
END

GO

CREATE PROCEDURE SP_AgregarUsuario
@IdEmpleado INT,
@Nombre VARCHAR(30),
@Contrasenia VARCHAR(50),
@IdRol INT
AS
BEGIN
	DECLARE @FechaCreacion DATE = CONVERT(DATE,GETDATE());
	DECLARE @HoraCreacion TIME = CONVERT(TIME, GETDATE());
	--Verificamos que el usuario que esta agregando es un empleado
	IF EXISTS(SELECT 1 FROM Empleados WHERE Empleados.Id = @IdEmpleado)
	BEGIN
	 --COMO ES UN EMPLEADO ENTONCES PROCEDEMOS A VERIFICAR QUE 
	 --NOMBRE, CONTRASENIA Y IDROL NO SEAN NULOS
		IF((@Nombre IS NULL OR @Nombre = '') OR (@Contrasenia IS NULL OR @Contrasenia = '') OR
		(@IdRol = 0 OR @IdRol IS NULL))
		BEGIN
			PRINT 'Compruebe que ha llenado los campos correctamente'
		END
		ELSE 
		--COMO SI TIENEN VALORES ENTONCES SE PROCEDE A INSERTAR
		INSERT INTO Usuarios(Id, Nombre, Contrasenia, IdRol, FechaCreacion, HoraCreacion)
		VALUES (@IdEmpleado, @Nombre, @Contrasenia, @IdRol, @FechaCreacion, @HoraCreacion)
	END	 
END

GO


--PROCEDIMIENTO PARA OBTENER LAS OPCIONES A LAS QUE PUEDE ACCEDER EL ROL
CREATE PROCEDURE SP_MostrarOpcionesRol
@IdRol INT
AS
BEGIN
	SELECT IdOpcion FROM PermisosRoles WHERE Permitido = 1 
	AND IdRol = 1;
END

GO
--PROCEDIMIENTO PARA OBTENER LOS MODULOS A LOS QUE PUEDE ACCEDER EL ROL 
CREATE PROCEDURE SP_MostrarModuloOpciones
@IdRol INT
AS
BEGIN
	SELECT DISTINCT(IdModulo) FROM  PermisosRoles pr JOIN Opciones o ON pr.IdOpcion = o.Id JOIN Modulos m ON m.Id = o.IdModulo WHERE IdRol = 1 AND 
	Permitido = 1;
END
GO

--PROCEDIMIENTO PARA EDITAR A UN USUARIO 
CREATE PROCEDURE SP_EditarUsuario 
@Id INT,
@Nombre VARCHAR(30),
@Contrasenia VARCHAR(50),
@IdRol INT
AS
BEGIN
	
	DECLARE @NombreU VARCHAR(30)
	DECLARE @ContraseniaU VARCHAR(50)
	DECLARE @IdRolU INT
	DECLARE @RolExiste BIT 

	--PRIMERO VERIFICAR QUE EL USUARIO EXISTE
	IF EXISTS(SELECT 1 FROM Usuarios WHERE Id = @Id)
	BEGIN
		SET @RolExiste = (SELECT 1 FROM Roles WHERE Id = @IdRol )
		--VERIFICAMOS QUE NO NOS HAYAN PASADO VALORES NULOS Y QUE EL ID DEL ROL EXISTA
		IF((@Nombre IS NOT NULL AND @Nombre !='') AND (@Contrasenia IS NOT NULL AND @Contrasenia !='') AND @RolExiste = 1)
		BEGIN
			--COMO EXISTEN VERIFICAMOS QUE NOMBRE, CONTRASEÑA Y ROL SEAN DIFERENTES AL QUE TENIAN ANTES SI NO ACTUALIZAMOS
			
			SET @NombreU = (SELECT Nombre FROM Usuarios WHERE Id = @Id)
			
			IF @Nombre != @NombreU --SI EL VALOR QUE PASO ES DIFERENTE AL QUE YA TENIA ENTONCES
			BEGIN
			
			IF(SELECT 1 FROM Usuarios WHERE Nombre = @Nombre) = 1--QUE COMPRUEBE SI EXISTE OTRO USUARIO CON ESE NOMBRE
			BEGIN
				PRINT CONCAT(@Nombre, ' ya existe como nombre de usuario')
			END
			ELSE --COMO EL NOMBRE NUEVO NO EXISTE ENTONCES QUE ACTUALICE EL NOMBRE
				UPDATE Usuarios SET Nombre = @Nombre WHERE Id = @Id
			END

			SET @ContraseniaU = (SELECT Contrasenia FROM Usuarios WHERE Id = @Id)
			IF @Contrasenia != @ContraseniaU--SI EL VALOR QUE PASO ES DIFERENTE AL QUE YA TENIA ENTONCES
			BEGIN
				UPDATE Usuarios SET Contrasenia = @Contrasenia WHERE Id = @Id
			END

			SET @IdRolU = (SELECT IdRol FROM Usuarios WHERE Id = @Id)
			IF @IdRol != @IdRolU--SI EL VALOR QUE PASO ES DIFERENTE AL QUE YA TENIA ENTONCES
			BEGIN
				UPDATE Usuarios SET IdRol = @IdRol WHERE Id = @Id
			END
			--
		END
	END
END

GO

--PROCEDIMIENTO PARA DAR DE BAJA A UN USUARIO 
CREATE PROCEDURE SP_EliminarUsuario
@Id INT
AS
BEGIN 
	UPDATE Usuarios SET Estado = 0 WHERE Id = @Id
END
GO

--PROCEDIMIENTO ALMACENADO PARA IDENTIFICAR EL ROL DEL USUARIO
CREATE PROCEDURE SP_ObtenerIdRol
@NombreUsuario VARCHAR(30),
@ContraseniaUsuario VARCHAR(50)
AS
BEGIN
	SELECT IdRol FROM Usuarios WHERE Nombre = @NombreUsuario AND Contrasenia = @ContraseniaUsuario AND Estado = 1;
END
GO
--PROCEDIMIENTOS ALMACENADOS PARA LA TABLA CATGORIAS
--MUESTRA SOLO LAS CATEGORIAS ACTIVAS
CREATE PROCEDURE SP_MostrarCategorias
AS
BEGIN
	SELECT Id, Nombre, Descripcion FROM Categorias WHERE Estado = 1;
END
GO

--AGREGAR CATEGORIAS 

--FUNCION PARA SABER SI EL NOMBRE DE LA CATEGORIA YA EXISTE 
GO
CREATE FUNCTION FN_CategoriaExiste
(
@Nombre VARCHAR(30)
)
RETURNS BIT
AS 
BEGIN 
	DECLARE @resultado BIT;
	IF EXISTS(SELECT 1 FROM Categorias WHERE Nombre = @Nombre )--si la categoria ya existe entonces que devuelva uno
		SET @resultado = 1;
	ELSE 
		SET @resultado = 0; --si la categoria no existe devolverá 0

	RETURN @resultado;
END
GO

--PROCEDIMIENTO ALMACENADO PARA AGREGAR UNA CATEGORIA
CREATE PROCEDURE SP_AgregarCategoria
@Nombre VARCHAR(30),
@Descripcion VARCHAR(100)
AS
BEGIN 
	
	DECLARE @CategoriaExiste BIT;

	IF(@Nombre IS NULL OR @Nombre = '') 
	BEGIN
		PRINT 'El campo nombre para categoría no puede estar vacio o sin valor'
		RETURN; --SE SALDRÁ DEL PROCEDIMIENTO SI ES NULO O VACIO
	END

	
	SET @CategoriaExiste = dbo.FN_CategoriaExiste(@Nombre);
	IF( @CategoriaExiste = 1)
	BEGIN
		PRINT @Nombre + ' ya existe como nombre de categoría';
		RETURN; -- SE SALDRÁ DEL PROCEDIMIENTO ALMACENADO SI YA EXISTE EL NOMBRE DE LA CATEGORÍA
	END
	ELSE -- SI EL NOMBRE DE LA CATEGORÍA NO EXISTE ES PORQUE DEVOLVIO 0 LA FUNCIÓN Y PROCEDEMOS A INSERTAR
		INSERT INTO Categorias(Nombre, Descripcion) VALUES (@Nombre, @Descripcion);
END
GO

--PROCEDIMIENTO ALMACENADO PARA OBTENER INFORMACION DE UNA CATEGORIA SEGÚN SU ID
CREATE PROCEDURE SP_ObtenerCategoriaPorId
@Id INT
AS
BEGIN
	SELECT Id, Nombre, Descripcion FROM Categorias WHERE Id = @Id;
END
GO

--PROCEDIMIENTO ALMACENADO PARA EDITAR LA CATEGORIA
CREATE PROCEDURE SP_EditarCategoria

@Id INT,
@Nombre VARCHAR(30),
@Descripcion VARCHAR(100)

AS
BEGIN
	
	DECLARE @CategoriaExiste BIT;
	DECLARE @NombreC VARCHAR(30);
	DECLARE @DescripcionC VARCHAR(100);
	


	--VALORAR SI EL ID EXISTE, SI DEVUELVE EL 1 ES PORQUE EXISTE ESE ID

	IF EXISTS(SELECT 1 FROM Categorias WHERE Id = @Id)
	BEGIN 

		--COMO EL ID EXISTE AHORA VALIDEMOS QUE EL NUEVO NOMBRE NO SEA UN NOMBRE QUE YA EXISTE, VACIO O NULO
		IF(@Nombre IS NULL OR @Nombre = '') 
		BEGIN
			PRINT 'El campo nombre para categoría no puede estar vacio o sin valor'
			RETURN; --SE SALDRÁ DEL PROCEDIMIENTO SI ES NULO O VACIO
		END

		SET @NombreC = (SELECT Nombre FROM Categorias WHERE Id = @Id);--TENDRA EL VALOR DEL CAMPO NOMBRE ANTES DE ACTUALIZARSE
		
		SET @CategoriaExiste = dbo.FN_CategoriaExiste(@Nombre);

		IF(@Nombre != @NombreC)--SI EL NOMBRE QUE ESTA INGRESANDO ES DIFERENTE AL QUE YA TENIA ENTONCES
		BEGIN
			--COMPROBAMOS QUE EL NUEVO INGRESO NO ES UN NOMBRE DE CATEGORIA YA EXISTENTE
			IF(@CategoriaExiste = 1)
			BEGIN
				PRINT @Nombre + ' es una categoría que ya existe';
			END
			ELSE --SI NO EXISTE ENTONCES QUE ACTUALICE EL NOMBRE
				UPDATE Categorias SET Nombre = @Nombre WHERE Id = @Id;
		END

		SET @DescripcionC = (SELECT Descripcion FROM Categorias WHERE Id = @Id);--TENDRA EL VALOR DEL CAMPO DESCRIPCION ANTES DE ACTUALIZARSE
		
		IF(@Descripcion != @DescripcionC)--SI LOS VALORES NO SON LOS MISMOS QUE YA TENIA ENTONCES QUE ACTUALICE
			BEGIN
				UPDATE Categorias SET Descripcion = @Descripcion WHERE Id = @Id;
			END
	END

END
GO


EXEC SP_EditarCategoria 1, 'Avena','Empacado';
GO

--PROCEDIMIENTO PARA ELIMINAR O DAR DE BAJA UNA CATEGORIA
CREATE PROCEDURE SP_EliminarCategoria
@Id INT 
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Categorias WHERE Id = @Id)
		BEGIN
			UPDATE Categorias SET Estado = 0 WHERE Id = @Id;
		END

END
GO

/*
--PRUEBAS CARGOS

EXEC SP_AgregarCargo 'Administrador', 'Supervisa operaciones, inventario y personal', 6800;
EXEC SP_AgregarCargo 'Vendedor', NULL, 4000;
--Vende productos, atiende clientes y gestiona transacciones 
EXEC SP_MostrarCargos;

GO

EXEC SP_EditarCargo 1, 'Vendedor', NULL, 899400;

EXEC SP_EditarCargo 2, 'Ginuis','Clientes', 893;

EXEC SP_MostrarCargos;

EXEC SP_EliminarCargo 2

--PRUEBAS

EXEC SP_MostrarEmpleados;

GO
DECLARE @dateParam DATE;
SET @dateParam = CONVERT(DATE, '2023-08-31');

EXEC SP_AgregarEmpleado '401-290108-1016K',NULL, NULL, 'DI',NULL, 2, @dateParam;;

GO
DECLARE @dateParam DATE;
SET @dateParam = CONVERT(DATE, '2024-08-31');
EXEC SP_EditarEmpleado 3, '401-287108-1006K', 'karlos', 'quant', 'Acebido', NULL,1,@dateParam;
GO

DECLARE @dateParam DATE;
SET @dateParam = CONVERT(DATE, '2023-08-31');
EXEC SP_EliminarEmpleado 1, @dateParam
GO

SELECT * FROM Empleados 
*/
--PROCEDIMIENTO PARA AGREGAR MODULOS
GO
CREATE PROCEDURE [dbo].[SP_AgregarModulos]
@Nombre VARCHAR(30) 
AS 
BEGIN
	IF @Nombre IS NOT NULL AND @Nombre != ''
	BEGIN
		INSERT INTO Modulos(Nombre) VALUES(@Nombre)
	END
END

GO
SP_AgregarModulos 'Gestionar empleados'
GO
SP_AgregarModulos 'Gestionar usuarios'
GO
SP_AgregarModulos 'Gestionar clientes'
GO
SP_AgregarModulos 'Gestionar productos'
GO
SP_AgregarModulos 'Gestionar existencias'
GO

CREATE PROCEDURE [dbo].[SP_AgregarOpcionModulo]
@Nombre VARCHAR(30),
@IdModulo INT
AS
BEGIN
	IF EXISTS(SELECT 1 FROM Modulos WHERE Id = @IdModulo)
	BEGIN
		IF @NOMBRE IS NOT NULL AND @NOMBRE != ''
		BEGIN
			INSERT INTO Opciones(Nombre,IdModulo) VALUES(@Nombre, @IdModulo)
		END
	END
END
GO
GO
SP_AgregarOpcionModulo 'Cargo',1
GO
SP_AgregarOpcionModulo 'Empleados',1
GO
SP_AgregarOpcionModulo 'Usuarios',2
GO
SP_AgregarOpcionModulo 'Clientes',3
GO
SP_AgregarOpcionModulo 'Categorias',4
GO
SP_AgregarOpcionModulo 'Proveedores',4
GO
SP_AgregarOpcionModulo 'Productos', 4
GO
SP_AgregarOpcionModulo 'Compras',5
GO
SP_AgregarOpcionModulo 'Ventas',6

GO
GO
CREATE PROCEDURE [dbo].[SP_AgregarRol]
@Nombre VARCHAR(30)
AS
BEGIN
	IF @Nombre IS NOT NULL AND @Nombre !=''
	BEGIN
		INSERT INTO Roles(Nombre) VALUES(@Nombre)
	END
END
GO

SP_AgregarRol 'Administrador'
GO
SP_AgregarRol 'Vendedor'
GO


CREATE PROCEDURE [dbo].[SP_AgregarPermisoRol]
@IdRol INT,
@IdOpcion INT
AS
BEGIN
	DECLARE @RolExiste BIT = (SELECT 1 FROM Roles WHERE Id = @IdRol);
	DECLARE @OpcionExiste BIT = (SELECT 1 FROM Opciones WHERE Id = @IdOpcion);

	IF @RolExiste = 1 AND @OpcionExiste = 1 
	BEGIN
		INSERT INTO PermisosRoles(IdRol,IdOpcion) VALUES(@IdRol,@IdOpcion);
	END
END
GO

SP_AgregarPermisoRol 1, 1
GO
SP_AgregarPermisoRol 1, 2
GO
SP_AgregarPermisoRol 1, 3
GO
SP_AgregarPermisoRol 1, 4
GO
SP_AgregarPermisoRol 1, 5
GO
SP_AgregarPermisoRol 1, 6
GO
SP_AgregarPermisoRol 1, 7
GO
SP_AgregarPermisoRol 1, 8
GO
SP_AgregarPermisoRol 1, 9
GO

--Vendedor permisos

SP_AgregarPermisoRol 2, 4
GO
SP_AgregarPermisoRol 2, 5
GO
SP_AgregarPermisoRol 2, 6
GO
SP_AgregarPermisoRol 2, 7
GO
SP_AgregarPermisoRol 2, 8
GO
SP_AgregarPermisoRol 2, 9
GO

GO
GO




--MOSTRAMOS LOS INSERT QUE HICIMOS
CREATE PROCEDURE [dbo].[SP_MostrarModulos]
AS
BEGIN
	SELECT * FROM Modulos;
END
GO
SP_MostrarModulos;
GO

CREATE PROCEDURE [dbo].[SP_MostrarRol]
AS
BEGIN
	SELECT * FROM Roles;
END
GO

SP_MostrarRol

GO

SP_MostrarUsuarios;

GO



create table Departamentos(
IdDepartamento int identity(1,1),
NombreDepartamento nvarchar(30),
Estado bit not null constraint DF_Departamentos_Estado Default 1,
Constraint PK_Departamentos_IdDepartamento Primary Key (IdDepartamento),
Constraint UK_Departamentos_NombreDepartamento Unique (NombreDepartamento)
)
Go
Create table Municipios (
IdMunicipio int not null identity(1,1),
NombreMunicipio nvarchar(30),
IdDepartamento int,
Constraint PK_Municipios_IdMunicipio Primary Key (IdMunicipio),
Constraint FK_Municipios_IdDepartamento Foreign Key (IdDepartamento) references Departamentos(IdDepartamento)
)
GO
Create rule RG_PatronTlf2 as @telefono like '[2|5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
GO


--SP_UNBINDRULE 'Proveedores.Telefono'
GO
Create table Proveedores(
IdProveedor Int identity(1,1) not null,
RazonSocial nvarchar(60) not null ,
RUC nvarchar(30) not null,
NombreComercial nvarchar(50),
Representante nvarchar(50),
Direccion nvarchar(60) not null,
IdMunicipio int not null,
Telefono char(8)not null,
Estado bit not null constraint DF_Proveedor_Estado Default 1,
Constraint PK_Proveedores_IdProveedor Primary key(IdProveedor),
Constraint FK_Proveedores_IdMunicipio Foreign Key(IdMunicipio) references Municipios(IdMunicipio),
constraint UQ_Proveedores_RazonSocial Unique(RazonSocial)
)
GO
sp_bindrule RG_PatronTlf2, 'Proveedores.Telefono'
Go
Create table Clientes(
IdCliente int not null identity (1,1),
Cedula char(16) check(Cedula like '[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][A-Z]'),
PrimerNombre nvarchar(30) not null,
SegundoNombre nvarchar(30),
PrimerApellido nvarchar(30) not null,
SegundoApellido nvarchar(30),
Telefono char(8) not null,
Direccion nvarchar(50),
IdMunicipio int,
Constraint PK_Clientes_IdCliente Primary key(IdCliente),
Constraint UQ_Clientes_CedulaTelefono unique(Cedula,Telefono),
Constraint FK_Clientes_IdMunicipio foreign key(IdMunicipio) references Municipios(IdMunicipio)
)
GO


Create table UnidadesMedida(
IdMedida int not null identity(1,1),
Nombre nvarchar(30) not null,
Abreviatura nvarchar(5) not null,
Estado bit not null constraint DF_UnidadesMedida_Estado Default 1,
Constraint PK_UnidadesMedida_IdMedida primary key(IdMedida),
Constraint UQ_UnidadesMedida_NombreAbreviatura unique(Nombre, Abreviatura)
)
GO

Create table Producto(
IdProducto Int Identity(1,1) not null,
Nombre nvarchar(50) not null,
Descripcion nvarchar(50),
PrecioVenta Float not null,
IdCategoria int not null,
IdMedida int not null,
Existencia int not null,


Estado bit not null constraint DF_Producto_Estado Default 1,
Constraint PK_Producto_IdProducto primary key(IdProducto),
Constraint FK_ProductoCategoria_IdCategoria foreign Key(IdCategoria) references Categorias(Id),
Constraint FK_ProductoUnidadesMedidas_IdMedida foreign key(IdMedida) references UnidadesMedida(IdMedida)
)
GO

Create table Compras(
IdCompra int identity (1,1) not null,
IdProveedor int not null,
FechaCompra date not null,
Estado bit not null constraint DF_Compras_Estado Default 1,
Constraint PK_Compras_IdCompras Primary key(IdCompra),
Constraint FK_Compras_IdProveedor Foreign key (IdProveedor) references Proveedores(IdProveedor)
)
Go
Create table DetalleCompras(
IdDetalleCompra int not null identity (1,1),
IdCompra int not null,
IdProducto int not null,
Cantidad float not null,
PrecioCompra float,
Subtotal float not null,
Constraint PK_DetalleCompras_IdDetalleCompra Primary key(IdDetalleCompra),
Constraint FK_DetalleCompras_IdCompra Foreign key(IdCompra) references Compras(IdCompra),
Constraint K_DetalleCompras_IdProducto Foreign key(IdProducto) references Producto(IdProducto)
)
Create table FacturasCompra(
IdFacturaCompra int not null identity(1,1),
NumeroFactura nvarchar(16) not null,
IdCompra int not null ,
FechaFactura date not null,
Total float not null,
Constraint PK_FacturasCompra_IdFacturaCompra primary key(IdFacturaCompra),
Constraint FK_FacturasCompra_IdCompra Foreign key(IdCompra) references Compras(IdCompra),
Constraint UQ_FacturaCompra_NumeroFactura Unique(NumeroFactura)
)
Go

Create table Ventas (
IdVenta int identity(1,1) not null,
IdCliente Int not null,
FechaVenta date not null,
TotalVenta float,
Estado bit not null constraint DF_Ventas_Estado Default 1,
Constraint PK_Ventas_IdVenta Primary key(IdVenta),
Constraint FK_Ventas_IdCliente Foreign Key(IdCliente) references Clientes(IdCliente)
)
go

Create table DetallesVentas(
IdDetalleVenta int identity(1,1) not null ,
IdVenta int not null, 
IdProducto int not null, 
CantidadVenta int not null,
subtotalVenta float,
Constraint PK_DetallesVentas_IdDetalleVenta primary key(IdDetalleVenta),
Constraint FK_DetallesVentas_IdVenta foreign key(IdVenta) references Ventas(IdVenta),
Constraint FK_DetallesVentas_IdProdcuto foreign key(IdProducto) references Producto(IdProducto),
)
GO
Create table FacturasVentas(
IdFacturaVenta int not null identity (1,1),
NumeroFactura nvarchar(17) not null,
IdVenta int not null,
Total float,
FechaFactura date not null,
Constraint PK_FacturasVentas_IdFacturaVenta Primary key(IdFacturaVenta),
Constraint FK_FacturasVentas_IdVenta Foreign Key(IdVenta) references Ventas(IdVenta),
Constraint UQ_FacturasVentas_NumeroFactura Unique(NumeroFactura)
)
GO
Create table DevolucionesCompra(
IdDevolucionCompra int not null identity(1,1),
IdProveedor int not null,
FechaDevolucionCompra date not null,
Estado bit constraint DF_DevolucionesCompras_Estado default 1,
Constraint PK_DevolucionesCompras_IdDevolucionCompra primary key(IdDevolucionCompra),
Constraint FK_DevolucionesComptas_IdProveedor Foreign key(IdProveedor) references Proveedores(IdProveedor)
)
GO

Create table DevolucionesVentas(
IdDevolucionVenta int not null identity(1,1),
IdCliente int not null,
FechaDevolucionVenta date not null,
Estado bit constraint DF_DevolucionesVentas_Estado default 1,
Constraint PK_DevolucionesVentas_IdDevolucionVenta primary key(IdDevolucionVenta),
Constraint FK_DevolucionesVentas_IdClientes Foreign key(IdCliente) references Clientes(IdCliente)
)
GO

Create table RazonesDevolucion(
IdRazonDevolucion int identity(1,1) not null,
Motivo nvarchar (30),
Descripcion nvarchar (50),
Estado bit constraint DF_RazonesDevolucion_Estado Default 1,
Constraint PK_RazonesDevolucion_IdRazonDevolucion Primary key(IdRazonDevolucion),
Constraint UQ_RazonesDevolucion_Motivo Unique(Motivo),
)
Go

Create table DetalleDevolucionesCompras(
IdDetalleDevolucionCompra int identity(1,1) not null,
IdDevolucionCompra int not null,
IdProducto int not null,
CantidadDevuelta int not null,
IdRazonDevolucion int not null,
Constraint PK_DetalleDevolucionesCompras_IdDetallaDevolucionCompra Primary key(IdDetalleDevolucionCompra),
Constraint FK_DetalleDevolucionesCompras_IdDevolucionCompra foreign key(IdDevolucionCompra) references DevolucionesCompra(IdDevolucionCompra),
Constraint FK_DetalleDevolucionesCompras_IdProdcuto foreign key(IdProducto) references Producto(IdProducto),
Constraint FK_DetalleDevolucionesCompras_IdRazonDevolucion foreign key(IdRazonDevolucion) references RazonesDevolucion(IdRazonDevolucion),
)
GO
Create table DetalleDevolucionesVentas(
IdDetalleDevolucionVenta int identity(1,1) not null,
IdDevolucionVentas int not null,
IdProducto int not null,
CantidadDevuelta int not null,
IdRazonDevolucion int not null,
Constraint PK_DetalleDevolucionesVentas_IdDetallaDevolucionVenta Primary key(IdDetalleDevolucionVenta),
Constraint FK_DetalleDevolucionesVentas_IdDevolucionVenta foreign key(IdDevolucionVentas) references DevolucionesVentas(IdDevolucionVenta),
Constraint FK_DetalleDevolucionesVentas_IdProdcuto foreign key(IdProducto) references Producto(IdProducto),
Constraint FK_DetalleDevolucionesVentas_IdRazonDevolucion foreign key(IdRazonDevolucion) references RazonesDevolucion(IdRazonDevolucion),
)
GO


/*****************************************************************
******************************************************************
**************CRUD Departamentos**********************************
******************************************************************/

--PROCEDIMIENTO ALMACENADO PARA AGREGAR Un Departamento
Create procedure NuevoDepartamento
@Nombre nvarchar(30)
as
declare @VerificarNombre as nvarchar(30)
set @VerificarNombre = (select NombreDepartamento from Departamentos where NombreDepartamento=@Nombre)
If (@Nombre = '')
Begin
	print 'Nombre no puede estar vacio'
end
Else
Begin
	if(@Nombre=@VerificarNombre)
	Begin
		print 'No puede repetir'
	End
	Else
	Begin
	insert into Departamentos(NombreDepartamento) values (@Nombre)
	End
End
Go
select * from Departamentos
go

NuevoDepartamento 'Chontales'
Go

--Eliminar Departamento
Create procedure EliminarDepartamento
@Identificador int
as
declare @IdDepartamento as int
set @IdDepartamento=(select IdDepartamento from Departamentos where IdDepartamento=@Identificador)
if(@Identificador=@IdDepartamento)
begin
  update Departamentos set Estado = 0 where IdDepartamento=@Identificador and Estado = 1
end
else
begin
   print 'Departamento no encontrado'
end
GO

EliminarDepartamento '6'
Go

--Actualizar Departamento
create procedure ActualizarDepartamento
@IdDepartamento int,
@NuevoNombreDepartamento nvarchar(30)
as
declare @IdentificadorID as int
set @IdentificadorID =(select IdDepartamento from Departamentos where IdDepartamento=@IdDepartamento)
declare @IdentificadorNombre as nvarchar(45)
set @IdentificadorNombre=(select NombreDepartamento from Departamentos where NombreDepartamento=@NuevoNombreDepartamento)

	if(@IdDepartamento=@IdentificadorID)
	begin
			if(@NuevoNombreDepartamento = '')
			begin
			print 'No puede estar en blanco'
			end
			else
			begin
				if(@NuevoNombreDepartamento = @IdentificadorNombre)
				begin
			 print 'no se puede duplicar'
			end
			else
			begin
			update Departamentos set NombreDepartamento=@NuevoNombreDepartamento 
			where IdDepartamento = @IdDepartamento and Estado = 1
			end
   end
end
else
begin
  print 'No se localizo'
end
Go
ActualizarDepartamento 5,'Matagalpaaa' 
Go
-- Listar Deptos Activos
create procedure ListarDepartamentos
as
select * from Departamentos where Estado = 1
Go
EXEC SP_HELPCONSTRAINT @OBJNAME = 'Proveedores'
GO
ListarDepartamentos
GO


/*********************************************
**procediminetos almacenados para municipio***
*********************************************/
CREATE PROCEDURE AgregarMunicipio
    @NombreMunicipio NVARCHAR(30),
    @IdDepartamento INT
AS
BEGIN
    -- Verificar si el departamento existe
    IF EXISTS (SELECT 1 FROM Departamentos WHERE IdDepartamento = @IdDepartamento)
    BEGIN
	If (@NombreMunicipio = '' or @IdDepartamento = '')
	Begin
		print 'Campo requerido vacio'
	End
		Else
		Begin
		-- Insertar el nuevo municipio
        INSERT INTO Municipios(NombreMunicipio, IdDepartamento)
        VALUES (@NombreMunicipio, @IdDepartamento);
		PRINT 'Municipio agregado exitosamente.';
		End
    END
    ELSE
    BEGIN
        PRINT 'El departamento no existe. No se pudo agregar el municipio.';
    END
END
GO

AgregarMunicipio 'Tisma',2
Go

Select * from Municipios
Go

--Actualizar Municipio
create procedure ActualizarMunicipio
@IdMunicipio int,
@NuevoNombreMunicipio nvarchar(30)
as
declare @IdentificadorID as int
set @IdentificadorID =(select IdMunicipio from Municipios where IdMunicipio=@IdMunicipio)
declare @IdentificadorNombre as nvarchar(45)
set @IdentificadorNombre=(select NombreMunicipio from Municipios where NombreMunicipio=@NuevoNombreMunicipio)

	if(@IdMunicipio=@IdentificadorID)
	begin
			if(@NuevoNombreMunicipio = '')
			begin
			print 'No puede estar en blanco'
			end
			else
			begin
				if(@NuevoNombreMunicipio = @IdentificadorNombre)
				begin
			 print 'no se puede duplicar'
			end
			else
			begin
			update Municipios set NombreMunicipio=@NuevoNombreMunicipio 
			where IdMunicipio = @IdMunicipio
			end
   end
end
else
begin
  print 'No se localizo'
end
Go
ActualizarMunicipio 10,'Tismaa' 
Go
-- Listar Deptos Activos y municipios
create procedure ListarMunicipio
AS
BEGIN
    -- Consulta para listar departamentos y sus municipios
    SELECT 
        D.NombreDepartamento AS NombreDepartamento,
        M.NombreMunicipio AS NombreMunicipio
    FROM
        Departamentos D
    INNER JOIN
        Municipios M ON D.IdDepartamento = M.IdDepartamento;
END

Go

ListarMunicipio
GO

/**********************************************************************
**********************************************************************
************************CRUD Proveedores***********************************
**********************************************************************/
--Agregar proveedor

GO
CREATE PROCEDURE AgregarProveedor
	@RazonSocial NVARCHAR(60),
    @RUC NVARCHAR(30),
    @NombreComercial NVARCHAR(50),
    @Representante NVARCHAR(50),
    @Direccion NVARCHAR(60),
    @IdMunicipio INT,
    @Telefono CHAR(8)
AS
BEGIN
    BEGIN TRY
        -- Verificar campos nulos
        IF (@RUC IS NULL OR @NombreComercial IS NULL OR @Telefono IS NULL OR @RazonSocial IS NULL OR @Direccion IS NULL OR @IdMunicipio IS NULL)
        BEGIN
            Print'Los campos RUC, Nombre Comercial, Teléfono y Razón Social no pueden ser nulos'
            RETURN; -- Salir del procedimiento
        END

        -- Verificar duplicados en RUC, Nombre Comercial, Teléfono y Razón Social
        IF EXISTS (SELECT 1 FROM Proveedores WHERE RUC = @RUC OR NombreComercial = @NombreComercial OR Telefono = @Telefono OR RazonSocial = @RazonSocial OR Direccion = @Direccion)
        BEGIN
            Print'El RUC, Nombre Comercial, Teléfono o Razón Social ya existen en la base de datos.' 
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Insertar el nuevo proveedor
        INSERT INTO Proveedores ( RazonSocial,RUC, NombreComercial,Representante, Direccion, IdMunicipio,Telefono)
        VALUES ( @RazonSocial,@RUC, @NombreComercial,  @Representante, @Direccion, @IdMunicipio,@Telefono);

        -- Confirmar la transacción
        COMMIT TRANSACTION;
        
        PRINT 'Proveedor agregado exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
GO
AgregarProveedor 'AJENICARAGUA','J0310000021619','','Bigcola','KM 3.5 CARRETERANORTESEMAFOROSLAROBELO150MTSALO',1, '87699500'
GO
AgregarProveedor 'FEMSA','J0310000004811','','COCACOLA','KM 4 1/2 CARRETERA NORTE',1, '22486600'
GO
AgregarProveedor 'BIMBO NICARAGUA','J0310000004080','ZEAS AYESTA PABLO JOSE','BIMBO','LINDA VISTA REPARTO LAS BRISAS',1, '22687783'
GO
AgregarProveedor 'LALA NICARAGUA','J0310000077678','00303197','LALA NICARAGUA','DE MONTOYA 2C O 1C',1, '22558948'
GO
GO

--DAR DE BAJA PROVEEDORES
go
CREATE PROCEDURE DarDeBajaProveedor
    @IdProveedor INT
AS
BEGIN
    BEGIN TRY
        -- Verificar si el proveedor existe
        IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE IdProveedor = @IdProveedor)
        BEGIN
           PRINT'El proveedor  no existe en la base de datos.'
           RETURN; -- Salir del procedimiento
        END
		ELSE
		BEGIN
		 -- Iniciar transacción
        BEGIN TRANSACTION;
        -- Actualizar el estado del proveedor a inactivo (0)
        UPDATE Proveedores SET Estado = 0 WHERE IdProveedor = @IdProveedor AND Estado = 1;
		PRINT 'Proveedor dado de baja exitosamente.';
        -- Confirmar la transacción
        COMMIT TRANSACTION;
		END
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
GO
DarDeBajaProveedor '11'
go
select * From Proveedores
go

--Actualizar proveedor
CREATE PROCEDURE ActualizarProveedor
    @IdProveedor INT,
    @NuevoRUC NVARCHAR(30),
    @NuevoNombreComercial NVARCHAR(50),
    @NuevoTelefono CHAR(8),
    @NuevoRazonSocial NVARCHAR(60),
    @NuevoRepresentante NVARCHAR(50),
    @NuevaDireccion NVARCHAR(60),
    @NuevoIdMunicipio INT
    
AS
BEGIN
    BEGIN TRY
        -- Verificar si el proveedor existe
        IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE IdProveedor = @IdProveedor)
        BEGIN
            PRINT 'El proveedor no existe en la base de datos.'
            RETURN; -- Salir del procedimiento
        END
        -- Verificar campos nulos en los nuevos valores
        IF (@NuevoRUC IS NULL OR @NuevoNombreComercial IS NULL OR @NuevoTelefono IS NULL OR @NuevoRazonSocial IS NULL)
        BEGIN
            PRINT'Los campos RUC, Nombre Comercial, Teléfono y Razón Social no pueden ser nulos.'
            RETURN; -- Salir del procedimiento
        END

        -- Verificar duplicados en RUC, Nombre Comercial, Teléfono y Razón Social
        IF EXISTS (SELECT 1 FROM Proveedores WHERE (RUC = @NuevoRUC OR NombreComercial = @NuevoNombreComercial OR Telefono = @NuevoTelefono OR RazonSocial = @NuevoRazonSocial) AND IdProveedor <> @IdProveedor)
        BEGIN
            PRINT 'El RUC, Nombre Comercial, Teléfono o Razón Social ya existen en la base de datos para otro proveedor.'
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Actualizar los datos del proveedor
        UPDATE Proveedores
        SET
            RazonSocial = @NuevoRazonSocial,
			RUC = @NuevoRUC,
            NombreComercial = @NuevoNombreComercial,
            Representante = @NuevoRepresentante,
            Direccion = @NuevaDireccion,
            IdMunicipio = @NuevoIdMunicipio,
			Telefono = @NuevoTelefono
            
        WHERE
            IdProveedor = @IdProveedor AND Estado = 1;

        -- Confirmar la transacción
        COMMIT;

        PRINT 'Proveedor actualizado exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
GO
ActualizarProveedor 9,'J0310000021618','BigCola','87699508','AJENICARAGUAA','','KM 3.5 CARRETERANORTESEMAFOROSLAROBELO150MTSAL',1

select * from Proveedores

/*************************************************************************
******************************CRUD Categoria***********************************
**************************************************************************/
--Agregar Categoria
GO
CREATE PROCEDURE AgregarCategoria
	@Nombre varchar(30),
	@Descripcion varchar(100)
AS
BEGIN
    BEGIN TRY
        -- Verificar campos nulos
        IF (@Nombre IS NULL OR @Descripcion IS NULL)
        BEGIN
            Print'Los campos Nombre y Descripcion no pueden ser nulos'
            RETURN; -- Salir del procedimiento
        END

        -- Verificar duplicados en RUC, Nombre Comercial, Teléfono y Razón Social
        IF EXISTS (SELECT 1 FROM Categorias WHERE Nombre = @Nombre or Descripcion = @Descripcion)
        BEGIN
            Print'Los campos Nombre y Descripcion ya existen.' 
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Insertar el nuevo proveedor
        INSERT INTO Categorias(Nombre,Descripcion)
        VALUES ( @Nombre,@Descripcion);

        -- Confirmar la transacción
        COMMIT TRANSACTION;
        
        PRINT 'Categoria agregada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
GO

AgregarCategoria 'Limpieza y aseo','Productos de limpieza y aseo'
GO
AgregarCategoria 'Abarrotes','alimentos, productos del hogar y otros productos básicos'
GO
AgregarCategoria 'Enlatados','Productos comestibles en latas'
GO

Select * from Categorias
GO

--Eliminar Categorias
Create procedure EliminarCategoria
@Identificador int
as
declare @IdCategoria int
set @IdCategoria=(select Id from Categorias where Id = @Identificador)
if(@Identificador=@IdCategoria)
begin
  update Categorias set Estado = 0 where Id=@Identificador and Estado = 1
end
else
begin
   print 'Caegoria no encontrado'
end
GO
EliminarCategoria '1'
go

--Actualizar Categoria 
Go
create procedure ActualizarCategoria
    @IdCategoria INT,
    @NuevoNombre NVARCHAR(50),
    @NuevaDescripcion NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        -- Verificar si la categoría existe y su estado es igual a 1
        IF NOT EXISTS (SELECT 1 FROM Categorias WHERE Id = @IdCategoria AND Estado = 1)
        BEGIN
            print 'La categoría con ID  no existe o su estado no es activo'
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Actualizar la categoría
        UPDATE Categorias
        SET
            Nombre = @NuevoNombre,
            Descripcion = @NuevaDescripcion
        WHERE
           Id = @IdCategoria;

        -- Confirmar la transacción
        COMMIT;

        PRINT 'Categoría actualizada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END

Go
Select * from Categorias
GO

ActualizarCategoria 2,'Limpieza','Productos para limpiar'
go


/****************************************************************************
********************************* CRUD Unidades de medidas*******************
*****************************************************************************/

CREATE PROCEDURE AgregarUnidadMedida
    @Nombre NVARCHAR(30),
    @Abreviatura NVARCHAR(5)
AS
BEGIN
    BEGIN TRY
        -- Verificar campos no nulos
        IF (@Nombre IS NULL OR @Abreviatura IS NULL)
        BEGIN
			print'Los campos Nombre y Abreviatura no pueden ser nulos.'
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Insertar la nueva unidad de medida
        INSERT INTO UnidadesMedida(Nombre, Abreviatura)
        VALUES (@Nombre, @Abreviatura);

        -- Confirmar la transacción
        COMMIT;

        PRINT 'Unidad de medida agregada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
go

AgregarUnidadMedida 'Litros','LT'
Go
AgregarUnidadMedida 'Libras','LB'
Go
AgregarUnidadMedida 'Unidades','UNIT'
Go
AgregarUnidadMedida 'Mililitros','ML'
Go
select * from UnidadesMedida
go

CREATE PROCEDURE DarDeBajaUnidadMedida
    @IdUnidadMedida INT
AS
BEGIN
    BEGIN TRY
        -- Verificar si la unidad de medida existe
        IF NOT EXISTS (SELECT 1 FROM UnidadesMedida WHERE IdMedida = @IdUnidadMedida)
        BEGIN
            print 'La unidad de medida  no existe en la base de datos.'
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Actualizar el estado de la unidad de medida a 0 (inactivo)
        UPDATE UnidadesMedida
        SET Estado = 0
        WHERE IdMedida = @IdUnidadMedida;

        -- Confirmar la transacción
        COMMIT;

        PRINT 'Unidad de medida dada de baja exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
GO
DarDeBajaUnidadMedida 1
go

CREATE PROCEDURE ActualizarUnidadMedida
    @IdUnidadMedida INT,
    @NuevoNombre NVARCHAR(50),
    @NuevaAbreviatura NVARCHAR(10)
AS
BEGIN
    BEGIN TRY
        -- Verificar si la unidad de medida existe y su estado es igual a 1
        IF NOT EXISTS (SELECT 1 FROM UnidadesMedida WHERE IdMedida = @IdUnidadMedida AND Estado = 1)
        BEGIN
            print 'La unidad de medida no existe'
            RETURN; -- Salir del procedimiento
        END

        -- Verificar campos no nulos
        IF (@NuevoNombre IS NULL OR @NuevaAbreviatura IS NULL)
        BEGIN
            print 'Los campos Nombre y Abreviatura no pueden ser nulos.'
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Actualizar la unidad de medida
        UPDATE UnidadesMedida
        SET
            Nombre = @NuevoNombre,
            Abreviatura = @NuevaAbreviatura
        WHERE
            IdMedida = @IdUnidadMedida;

        -- Confirmar la transacción
        COMMIT;

        PRINT 'Unidad de medida actualizada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
GO
ActualizarUnidadMedida 2, 'Unidad','UNIT'

/***********************************************************************************
************************************************************************************
************************* CRUD Producto ********************************************
************************************************************************************/


--procedimineto almacenar producto
GO
CREATE PROCEDURE InsertarProducto
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(50),
    @PrecioVenta FLOAT,
    @IDCategoria INT,
    @IDUnidadesMedida INT,
    @Existencia INT
AS
BEGIN
    -- Validar campos no nulos
    IF (@Nombre IS NULL OR @PrecioVenta IS NULL OR @IDCategoria IS NULL OR @IDUnidadesMedida IS NULL)
    BEGIN
        PRINT'Los campos Nombre, PrecioVenta, IDCategoria e IDUnidadesMedida no pueden ser nulos.'
        RETURN; -- Salir del procedimiento
    END

    -- Validar si el nombre ya existe
    IF EXISTS (SELECT 1 FROM Producto WHERE Nombre = @Nombre)
    BEGIN
        PRINT'Ya existe un producto con el mismo nombre.'
        RETURN; -- Salir del procedimiento
    END

    -- Insertar el nuevo producto
    INSERT INTO Producto (Nombre, Descripcion, PrecioVenta, IdCategoria, IdMedida, Existencia)
    VALUES (@Nombre, @Descripcion, @PrecioVenta, @IDCategoria, @IDUnidadesMedida, @Existencia)
END
GO
InsertarProducto 'Sardina','sardina picante',35,2,2,20

select * from Categorias
select * from UnidadesMedida
select * from Producto

GO
--procedimiento actualizar
CREATE PROCEDURE ActualizarProducto
    @IDProducto INT,
    @NuevoNombre NVARCHAR(50),
    @NuevaDescripcion NVARCHAR(50),
    @NuevoPrecioVenta float,
    @NuevaIDCategoria INT,
    @NuevaIDUnidadesMedida INT,
    @NuevaExistencia INT
AS
BEGIN
    -- Validar campos no nulos
    IF (@NuevoNombre IS NULL OR @NuevoPrecioVenta IS NULL OR @NuevaIDCategoria IS NULL OR @NuevaIDUnidadesMedida IS NULL)
    BEGIN
        PRINT 'Los campos Nombre, PrecioVenta, IDCategoria e IDUnidadesMedida no pueden ser nulos.'
        RETURN; -- Salir del procedimiento
    END

    -- Validar si el nuevo nombre ya existe (excluyendo el producto actual)
    IF EXISTS (SELECT 1 FROM Producto WHERE Nombre = @NuevoNombre AND IDProducto <> @IDProducto)
    BEGIN
        PRINT 'Ya existe un producto con el mismo nombre.'
        RETURN; -- Salir del procedimiento
    END

    -- Actualizar el producto
    UPDATE Producto
    SET
        Nombre = @NuevoNombre,
        Descripcion = @NuevaDescripcion,
        PrecioVenta = @NuevoPrecioVenta,
        IdCategoria = @NuevaIDCategoria,
        IdMedida= @NuevaIDUnidadesMedida,
        Existencia = @NuevaExistencia
    WHERE
        IDProducto = @IDProducto AND Estado = 1;
END
GO

ActualizarProducto 1,'Atun','Atun en aceite',60,2,2,50
GO
--Eliminar producto

CREATE PROCEDURE EliminarProducto
    @IDProducto INT
AS
BEGIN
    BEGIN TRY
        -- Verificar si el producto existe y su estado es igual a 1 (activo)
        IF NOT EXISTS (SELECT 1 FROM Producto WHERE IDProducto = @IDProducto AND Estado = 1)
        BEGIN
            PRINT 'El producto no existe o su estado no es activo.'
            RETURN; -- Salir del procedimiento
        END

        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Actualizar el estado del producto a 0 (inactivo)
        UPDATE Producto
        SET Estado = 0
        WHERE IDProducto = @IDProducto;

        -- Confirmar la transacción
        COMMIT;

        PRINT 'Producto eliminado exitosamente.';
    END TRY
    BEGIN CATCH
        -- Revertir la transacción en caso de error
        IF @@TRANCOUNT > 0
            ROLLBACK;

        PRINT 'Error: ' + ERROR_MESSAGE();
    END CATCH;
END
go

EliminarProducto 1
go

/***********************************************************************************************
************************************************************************************************
*************************************** CRUD COmpra*********************************************
************************************************************************************************
************************************************************************************************/

CREATE PROCEDURE AgregarCompraProveedor
    @IdProveedor INT,
    @FechaCompra DATE
AS
BEGIN
    -- Verificar si el proveedor existe
    IF NOT EXISTS (SELECT 1 FROM Proveedores WHERE IdProveedor = @IdProveedor)
    BEGIN
        PRINT 'El proveedor no existe.';
        RETURN; -- Salir del procedimiento sin agregar la compra
    END

    -- Insertar la compra en la tabla ComprasProveedor
    INSERT INTO Compras (IdProveedor, FechaCompra)
    VALUES (@IdProveedor, @FechaCompra);

    PRINT 'Compra agregada exitosamente.';
END
GO

select * from Compras
GO

AgregarCompraProveedor 9, '2023-06-07'
GO

select getdate()
go
--Procediineto dar de baja compra
CREATE PROCEDURE DarDeBajaCompraProveedor
    @IdCompra INT
AS
BEGIN
    -- Verificar si la compra existe
    IF EXISTS (SELECT 1 FROM Compras WHERE IdCompra = @IdCompra)
    BEGIN
        -- Actualizar el estado de la compra a "baja" (1 para activa, 0 para baja)
        UPDATE Compras
        SET Estado = 0
        WHERE IdCompra = @IdCompra;

        PRINT 'La compra  ha sido dada de baja exitosamente.'
    END
    ELSE
    BEGIN
        PRINT 'La compra  no existe o ya ha sido dada de baja previamente.'
    END
END;

/***************************************************************************
******************************* CRUD Detalle de compra*********************
***************************************************************************/
GO
CREATE PROCEDURE AgregarDetalleCompra
    @IdCompra INT,
    @IdProducto INT,
    @Cantidad INT,
    @Precio float
AS
BEGIN
    -- Verificar si la compra existe
    IF NOT EXISTS (SELECT 1 FROM Compras WHERE IdCompra = @IdCompra)
    BEGIN
        PRINT 'La compra  no existe.'
        RETURN; -- Salir del procedimiento sin agregar el detalle de compra
    END

    -- Calcular el subtotal
    DECLARE @Subtotal Float;
    SET @Subtotal = @Cantidad * @Precio;

    -- Insertar el detalle de compra en la tabla DetalleCompra
    INSERT INTO DetalleCompras (IdCompra, IdProducto, Cantidad, PrecioCompra, Subtotal)
    VALUES (@IdCompra, @IdProducto, @Cantidad, @Precio, @Subtotal);

    PRINT 'Detalle de compra agregado exitosamente.';
END
GO

AgregarDetalleCompra 1,2,20,20
go

--Actualizar detalle de compra
CREATE PROCEDURE ActualizarDetalleCompra
    @IdDetalleCompra INT,
    @NuevoIdProducto INT,
    @NuevaCantidad INT,
    @NuevoPrecio float,
    @NuevoSubtotal float
AS
BEGIN
    -- Verificar si el detalle de compra existe
    IF EXISTS (SELECT 1 FROM DetalleCompras WHERE IdDetalleCompra = @IdDetalleCompra)
    BEGIN
        -- Actualizar los valores del detalle de compra
        UPDATE DetalleCompras
        SET IdProducto = @NuevoIdProducto,
            Cantidad = @NuevaCantidad,
            PrecioCompra = @NuevoPrecio,
            Subtotal = @NuevoSubtotal
        WHERE IdDetalleCompra = @IdDetalleCompra;

        PRINT 'Detalle de compra ha sido actualizado exitosamente.';
    END
    ELSE
    BEGIN
        PRINT 'El detalle de compra no existe o no puede ser actualizado.';
    END
END;
--Genarar Factura de compra
GO
CREATE PROCEDURE GenerarFactura
    @IdCompra INT,
    @FechaFactura DATE
AS
BEGIN
    DECLARE @NumeroFactura NVARCHAR(50)
    DECLARE @Total DECIMAL(10, 2)

    -- Verificar si la compra existe y no ha sido facturada previamente
    IF NOT EXISTS (SELECT 1 FROM FacturasCompra WHERE IdCompra = @IdCompra)
    BEGIN
        -- Generar un número de factura único (puedes personalizar esto según tus necesidades)
        SET @NumeroFactura = 'FACT-' + CONVERT(NVARCHAR(10), @IdCompra) + '-' + REPLACE(CONVERT(NVARCHAR(30), GETDATE(), 120), '-', '')

        -- Calcular el total de la factura
        SELECT @Total = SUM(Subtotal) FROM DetalleCompras WHERE IdCompra = @IdCompra

        -- Insertar la factura en la tabla de facturas
        INSERT INTO FacturasCompra (NumeroFactura, IdCompra, FechaFactura, Total)
        VALUES (@NumeroFactura, @IdCompra, @FechaFactura, @Total)

        PRINT 'Factura generada exitosamente. Número de factura: ' + @NumeroFactura
    END
    ELSE
    BEGIN
        PRINT 'La compra c ya ha sido facturada previamente.'
    END
END;

GO

GO

SP_AgregarCargo 'Administrador',NULL, 495.03;
GO
SP_AgregarCargo 'Vendedor',NULL, 393;
GO
--ADMINISTRADOR
SP_AgregarEmpleado '401-101212-1002K', 'Silvia', NULL, 'Molina', NULL,1,'2023-09-02';
GO
--VENDEDOR
SP_AgregarEmpleado '001-010207-0002D', 'Nahomy', NULL, 'Molina', NULL,2,'2023-09-02';
GO
--LE CREAMOS UN USUARIO TEMPORAL SOLO PARA QUE INGRESE CON LA APP Y DESPUES PUEDA CAMBIAR SU CONTRASEÑA
SP_AgregarUsuario 1, 'admin', '123', 1
GO


SELECT * FROM cargos;
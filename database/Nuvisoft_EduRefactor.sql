CREATE DATABASE Nuvisoft_Educacion
GO

USE Nuvisoft_Educacion
GO

DROP DATABASE Nuvisoft_Educacion
CREATE TABLE [tb_rol] (
  [codRol] INT PRIMARY KEY,
  [rol] VARCHAR(20),
  CONSTRAINT Chk_TipoRol CHECK( [rol] IN ('administrador', 'estudiante', 'profesor'))
)
GO

/* Procedimientos Almacenados */
-- Rol

IF OBJECT_ID('SP_InsertRol') IS NOT NULL
DROP PROCEDURE SP_InsertRol
GO

CREATE PROCEDURE SP_InsertRol
@codRol INT,
@rol VARCHAR(20)
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tb_rol] VALUES(@codRol, @rol);
  END
GO

IF OBJECT_ID('SP_DeleteRol') IS NOT NULL
DROP PROCEDURE SP_DeleteRol
GO

CREATE PROCEDURE SP_DeleteRol
@codRol	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_rol] WHERE @codRol = codRol;
END
GO

IF OBJECT_ID('SP_UpdateRol') IS NOT NULL
DROP PROCEDURE SP_UpdateRol
GO

CREATE PROCEDURE SP_UpdateRol
@codRol INT,
@rol VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tb_rol] SET rol = @rol
                  WHERE codRol = @codRol
END
GO

IF OBJECT_ID('SP_SelectRol') IS NOT NULL
DROP PROCEDURE SP_SelectRol
GO

CREATE PROCEDURE SP_SelectRol
@codRol	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_rol] WHERE codRol = @codRol;
END
GO

IF OBJECT_ID('SP_SelectRolAll') IS NOT NULL
DROP PROCEDURE SP_SelectRolAll
GO

CREATE PROCEDURE SP_SelectRolAll
AS
		SELECT * FROM [tb_rol];
GO
/* Procedimientos Almacenados Terminados (Rol) */

CREATE TABLE [tba_privilegios] (
  [codPrivilegios] INT PRIMARY KEY,
  [codRol] INT,
  [codUsuario] INT
)
GO

/* Procedimientos Almacenados */
-- Privilegios

IF OBJECT_ID('SP_InsertPrivilegios') IS NOT NULL
DROP PROCEDURE SP_InsertPrivilegios
GO

CREATE PROCEDURE SP_InsertPrivilegios
@codPrivilegios INT,
@codRol INT,
@codUsuario INT
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tba_privilegios] VALUES(@codPrivilegios,@codRol, @codUsuario);
  END
GO

IF OBJECT_ID('SP_DeletePrivilegio') IS NOT NULL
DROP PROCEDURE SP_DeletePrivilegio
GO

CREATE PROCEDURE SP_DeletePrivilegio
@codPrivilegios	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tba_privilegios] WHERE @codPrivilegios = codPrivilegios;
END
GO

IF OBJECT_ID('SP_UpdatePrivilegios') IS NOT NULL
DROP PROCEDURE SP_UpdatePrivilegios
GO

CREATE PROCEDURE SP_UpdatePrivilegios
@codPrivilegios INT,
@codRol INT,
@codUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tba_privilegios] SET codRol = @codRol,
                        codUsuario = @codUsuario
                  WHERE codPrivilegios = @codPrivilegios
END
GO

IF OBJECT_ID('SP_SelectPrivilegio') IS NOT NULL
DROP PROCEDURE SP_SelectPrivilegio
GO

CREATE PROCEDURE SP_SelectPrivilegio
@codPrivilegios	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tba_privilegios] WHERE codPrivilegios = @codPrivilegios;
END
GO

IF OBJECT_ID('SP_SelectPrivilegiosAll') IS NOT NULL
DROP PROCEDURE SP_SelectPrivilegiosAll
GO

CREATE PROCEDURE SP_SelectPrivilegiosAll
AS
		SELECT * FROM [tba_privilegios];
GO
/* Procedimientos Almacenados Terminados (Privilegios) */

CREATE TABLE [tba_privilegios_asignatura] (
  [codPrivilegiosAsignatura] INT PRIMARY KEY,
  [codPrivilegios] INT,
  [codAsignatura] INT
)
GO

/* Procedimientos Almacenados */
-- Privilegios Asignatura

IF OBJECT_ID('SP_InsertPrivilegiosAsignatura') IS NOT NULL
DROP PROCEDURE SP_InsertPrivilegiosAsignatura
GO

CREATE PROCEDURE SP_InsertPrivilegiosAsignatura
@codPrivilegiosAsignatura INT,
@codPrivilegios INT,
@codAsignatura INT
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tba_privilegios_asignatura] VALUES(@codPrivilegiosAsignatura,@codPrivilegios, @codAsignatura);
  END
GO

IF OBJECT_ID('SP_DeletePrivilegioAsignatura') IS NOT NULL
DROP PROCEDURE SP_DeletePrivilegioAsignatura
GO

CREATE PROCEDURE SP_DeletePrivilegioAsignatura
@codPrivilegiosAsignatura	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tba_privilegios_asignatura] WHERE @codPrivilegiosAsignatura = codPrivilegiosAsignatura;
END
GO

IF OBJECT_ID('SP_UpdatePrivilegiosAsignatura') IS NOT NULL
DROP PROCEDURE SP_UpdatePrivilegiosAsignatura
GO

CREATE PROCEDURE SP_UpdatePrivilegiosAsignatura
@codPrivilegiosAsignatura INT,
@codPrivilegios INT,
@codAsignatura INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tba_privilegios_asignatura] SET codPrivilegios = @codPrivilegios,
                        codAsignatura = @codAsignatura
                  WHERE codPrivilegiosAsignatura = @codPrivilegiosAsignatura
END
GO

IF OBJECT_ID('SP_SelectPrivilegioAsignatura') IS NOT NULL
DROP PROCEDURE SP_SelectPrivilegioAsignatura
GO

CREATE PROCEDURE SP_SelectPrivilegioAsignatura
@codPrivilegiosAsignatura	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tba_privilegios_asignatura] WHERE codPrivilegiosAsignatura = @codPrivilegiosAsignatura;
END
GO

IF OBJECT_ID('SP_SelectPrivilegiosAsignaturaAll') IS NOT NULL
DROP PROCEDURE SP_SelectPrivilegiosAsignaturaAll
GO

CREATE PROCEDURE SP_SelectPrivilegiosAsignaturaAll
AS
		SELECT * FROM [tba_privilegios_asignatura];
GO
/* Procedimientos Almacenados Terminados (Privilegios Asignatura) */

CREATE TABLE [tb_usuario] (
  [codUsuario] INT PRIMARY KEY,
  [codColegio] INT,
  [nombres] VARCHAR(120),
  [apellidos] VARCHAR(120),
  [email] VARCHAR(120),
  [usuario] VARCHAR(18),
  [contrasena] VARCHAR(25),
  [dni] VARCHAR(14)
)
GO

/* Procedimientos Almacenados */
-- Usuario

IF OBJECT_ID('SP_InsertUsuario') IS NOT NULL
DROP PROCEDURE SP_InsertUsuario
GO

CREATE PROCEDURE SP_InsertUsuario
@codUsuario INT,
@codColegio INT,
@nombres VARCHAR(120),
@apellidos VARCHAR(120),
@email VARCHAR(120),
@usuario VARCHAR(18),
@contrasena VARCHAR(25),
@dni VARCHAR(14)
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tb_usuario] VALUES(@codUsuario,@codColegio, @nombres, @apellidos, @email, @usuario, @contrasena,@dni);
  END
GO

IF OBJECT_ID('SP_DeleteUsuario') IS NOT NULL
DROP PROCEDURE SP_DeleteUsuario
GO

CREATE PROCEDURE SP_DeleteUsuario
@codUsuario	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_usuario] WHERE @codUsuario = codUsuario;
END
GO

IF OBJECT_ID('SP_UpdateUsuario') IS NOT NULL
DROP PROCEDURE SP_UpdateUsuario
GO

CREATE PROCEDURE SP_UpdateUsuario
@codUsuario INT,
@codColegio INT,
@nombres VARCHAR(120),
@apellidos VARCHAR(120),
@email VARCHAR(120),
@usuario VARCHAR(18),
@contrasena VARCHAR(25),
@dni VARCHAR(14)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tb_usuario] SET codColegio = @codColegio,
                        nombres = @nombres,
                        apellidos = @apellidos,
                        email = @email,
                        usuario = @usuario,
                        contrasena = @contrasena,
                        dni = @dni
                  WHERE codUsuario = @codUsuario
END
GO

IF OBJECT_ID('SP_SelectUsuario') IS NOT NULL
DROP PROCEDURE SP_SelectUsuario
GO

CREATE PROCEDURE SP_SelectUsuario
@codUsuario	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_usuario] WHERE codUsuario = @codUsuario;
END
GO

IF OBJECT_ID('SP_SelectUsuarioAll') IS NOT NULL
DROP PROCEDURE SP_SelectUsuarioAll
GO

CREATE PROCEDURE SP_SelectUsuarioAll
AS
		SELECT * FROM [tb_usuario];
GO
/* Procedimientos Almacenados Terminados (Usuario) */

CREATE TABLE [tb_colegio] (
  [codColegio] INT PRIMARY KEY,
  [nombre] VARCHAR(100),
  [descripcion] VARCHAR(255),
  [ubicacion] VARCHAR(180),
  [direccion] VARCHAR(180),
  [logotipo] VARCHAR(200),
  [correo] VARCHAR(50),
  [telefono] VARCHAR(12)
)
GO

/* Procedimientos Almacenados */
-- Colegio

IF OBJECT_ID('SP_InsertColegio') IS NOT NULL
DROP PROCEDURE SP_InsertColegio
GO

CREATE PROCEDURE SP_InsertColegio
@codColegio INT,
@nombre VARCHAR(100),
@descripcion VARCHAR(255),
@ubicacion VARCHAR(180),
@direccion VARCHAR(180),
@logotipo VARCHAR(200),
@correo VARCHAR(50),
@telefono VARCHAR(12)
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tb_colegio] VALUES(@codColegio, @nombre, @descripcion, @ubicacion, @direccion, @logotipo, @correo, @telefono);
  END
GO

IF OBJECT_ID('SP_DeleteColegio') IS NOT NULL
DROP PROCEDURE SP_DeleteColegio
GO

CREATE PROCEDURE SP_DeleteColegio
@codColegio	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_colegio] WHERE @codColegio = codColegio;
END
GO

IF OBJECT_ID('SP_UpdateColegio') IS NOT NULL
DROP PROCEDURE SP_UpdateColegio
GO

CREATE PROCEDURE SP_UpdateColegio
@codColegio INT,
@nombre VARCHAR(100),
@descripcion VARCHAR(255),
@ubicacion VARCHAR(180),
@direccion VARCHAR(180),
@logotipo VARCHAR(200),
@correo VARCHAR(50),
@telefono VARCHAR(12)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tb_colegio] SET nombre = @nombre,
                        descripcion = @descripcion,
                        ubicacion = @ubicacion,
                        direccion = @direccion,
                        logotipo = @logotipo,
                        correo = @correo,
                        telefono = @telefono
                  WHERE codColegio = @codColegio
END
GO

IF OBJECT_ID('SP_SelectColegio') IS NOT NULL
DROP PROCEDURE SP_SelectColegio
GO

CREATE PROCEDURE SP_SelectColegio
@codColegio	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_colegio] WHERE codColegio = @codColegio;
END
GO

IF OBJECT_ID('SP_SelectColegioAll') IS NOT NULL
DROP PROCEDURE SP_SelectColegioAll
GO

CREATE PROCEDURE SP_SelectColegioAll
AS
		SELECT * FROM [tb_colegio];
GO
/* Procedimientos Almacenados Terminados (Colegio) */

CREATE TABLE [tb_aranceles] (
  [codAranceles] INT PRIMARY KEY,
  [codUsuario] INT,
  [estado] VARCHAR (100),
  CONSTRAINT Chk_EstadoArancel CHECK ([estado] IN ('pagado', 'adeudo'))
)
GO

/* Procedimientos Almacenados */
-- Aranceles

IF OBJECT_ID('SP_InsertAranceles') IS NOT NULL
DROP PROCEDURE SP_InsertAranceles
GO

CREATE PROCEDURE SP_InsertAranceles
@codAranceles INT,
@codUsuario INT,
@estado VARCHAR(100),
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tb_aranceles] VALUES(@codAranceles, @codUsuario,@estado);
  END
GO

CREATE TABLE [tba_detalles] (
  [codArancelesDetalles] INT PRIMARY KEY,
  [codAranceles] INT,
  [estado] VARCHAR (100),
  [vencimiento] DATE,
  [cancelacion] BIT,
  [concepto] VARCHAR(255),
  [monto] INT,
  CONSTRAINT Chk_EstadoDet CHECK ([estado] IN ('pagado', 'adeudo')),
)
GO

CREATE TABLE [tb_asignatura] (
  [codAsignatura] INT PRIMARY KEY,
  [nombre] VARCHAR(80),
  [descripcion] VARCHAR(200)
)
GO

CREATE TABLE [tba_horario_asignatura] (
  [codHorarioAsig] INT PRIMARY KEY,
  [codAsignatura] INT,
  [codHorario] INT
)
GO

CREATE TABLE [tb_horario] (
  [codHorario] INT PRIMARY KEY,
  [nombre] VARCHAR(120),
  [modalidad] VARCHAR(100),
  CONSTRAINT Chk_ModalidadH CHECK ([modalidad] IN ('matutino', 'vespertino', 'nocturno', 'dominical', 'sabatino')),
)
GO

CREATE TABLE [tb_plantilla] (
  [codPlantilla] INT PRIMARY KEY,
  [titulo] VARCHAR(120),
  [tipo] VARCHAR(100),
  [descripcion] VARCHAR(220),
  [codAsignatura] INT,
  CONSTRAINT Chk_TipoP CHECK ([tipo] IN ('examen', 'sistematico', 'trabajo')),
)
GO


/* Procedimientos Almacenados */

-- Plantilla
IF OBJECT_ID('SP_InsertPlantilla') IS NOT NULL
DROP PROCEDURE SP_InsertPlantilla
GO

CREATE PROCEDURE SP_InsertPlantilla
@codPlantilla		INT,
@titulo		VARCHAR(120),
@tipo		VARCHAR (100),
@descripcion		VARCHAR (220),
@codAsignatura		INT
AS
BEGIN
		SET NOCOUNT ON;
		INSERT INTO [tb_plantilla] VALUES (@codPlantilla, @titulo, @tipo, @descripcion,@codAsignatura);
END
GO

IF OBJECT_ID('SP_DeletePlantilla') IS NOT NULL
DROP PROCEDURE SP_DeletePlantilla
GO

CREATE PROCEDURE SP_DeletePlantilla
@codPlantilla	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_plantilla] WHERE @codPlantilla = codPlantilla;
END
GO

IF OBJECT_ID('SP_UpdatePlantilla') IS NOT NULL
DROP PROCEDURE SP_UpdatePlantilla
GO

CREATE PROCEDURE SP_UpdatePlantilla
@codPlantilla		INT,
@titulo		VARCHAR(120),
@tipo		VARCHAR (100),
@descripcion		VARCHAR (220),
@codAsignatura		INT
AS
BEGIN
		SET NOCOUNT ON;
		UPDATE [tb_plantilla] SET titulo = @titulo,
								  tipo = @tipo,
								  descripcion = @descripcion,
								  codAsignatura = @codAsignatura
								  WHERE codPlantilla = @codPlantilla;
END
GO

IF OBJECT_ID('SP_SelectPlantilla') IS NOT NULL
DROP PROCEDURE SP_SelectPlantilla
GO

CREATE PROCEDURE SP_SelectPlantilla
@codPlantilla	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_plantilla] WHERE codPlantilla = @codPlantilla;
END
GO

IF OBJECT_ID('SP_SelectPlantillaAll') IS NOT NULL
DROP PROCEDURE SP_SelectPlantillaAll
GO

CREATE PROCEDURE SP_SelectPlantillaAll
AS
		SELECT * FROM [tb_plantilla];
GO

/* Procedimientos Almacenados Terminados (Plantilla) */

CREATE TABLE [tb_preguntas] (
  [codPregunta] INT PRIMARY KEY,
  [titulo] VARCHAR(120),
  [tipo] VARCHAR(100),
  [puntaje] INT,
  [autoContestado] BIT,
  [codPlantilla] INT
)
GO

/* Procedimientos Almacenados */
-- Preguntas
IF OBJECT_ID('SP_InsertPreguntas') IS NOT NULL
DROP PROCEDURE SP_InsertPreguntas
GO

CREATE PROCEDURE SP_InsertPreguntas
@codPregunta		INT,
@titulo		VARCHAR(120),
@tipo		VARCHAR (100),
@puntaje	INT,
@autoContestado	BIT,
@codPlantilla INT	
AS
BEGIN
		SET NOCOUNT ON;
		INSERT INTO [tb_preguntas] VALUES (@codPregunta, @titulo, @tipo, @puntaje,@autoContestado,@codPlantilla);
END
GO

IF OBJECT_ID('SP_DeletePreguntas') IS NOT NULL
DROP PROCEDURE SP_DeletePreguntas
GO

CREATE PROCEDURE SP_DeletePreguntas
@codPregunta	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_preguntas] WHERE @codPregunta = codPregunta;
END
GO

IF OBJECT_ID('SP_UpdatePreguntas') IS NOT NULL
DROP PROCEDURE SP_UpdatePreguntas
GO

CREATE PROCEDURE SP_UpdatePreguntas
@codPregunta		INT,
@titulo		VARCHAR(120),
@tipo		VARCHAR (100),
@puntaje	INT,
@autoContestado	BIT,
@codPlantilla INT	
AS
BEGIN
		SET NOCOUNT ON;
		UPDATE [tb_preguntas] SET titulo = @titulo,
								  tipo = @tipo,
								  puntaje = @puntaje,
								  autoContestado = @autoContestado,
								  codPlantilla = @codPlantilla
								  WHERE codPregunta = @codPregunta;
END
GO

IF OBJECT_ID('SP_SelectPregunta') IS NOT NULL
DROP PROCEDURE SP_SelectPregunta
GO

CREATE PROCEDURE SP_SelectPregunta
@codPregunta	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_preguntas] WHERE codPregunta = @codPregunta;
END
GO

IF OBJECT_ID('SP_SelectPreguntaAll') IS NOT NULL
DROP PROCEDURE SP_SelectPreguntaAll
GO

CREATE PROCEDURE SP_SelectPreguntaAll
AS
		SELECT * FROM [tb_preguntas];
GO
/* Procedimientos Almacenados Terminados (Plantilla) */

CREATE TABLE [tb_trabajo] (
  [codTrabajo] INT PRIMARY KEY,
  [inicio] DATETIME,
  [final] DATETIME,
  [codPlantilla] INT
)
GO

/* Procedimientos Almacenados */
-- Trabajo

IF OBJECT_ID('SP_InsertTrabajo') IS NOT NULL
DROP PROCEDURE SP_InsertTrabajo
GO

CREATE PROCEDURE SP_InsertTrabajo
@codTrabajo INT,
@inicio DATETIME,
@final DATETIME,
@codPlantilla INT
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tb_trabajo] VALUES(@codTrabajo,@inicio,@final,@codPlantilla);
  END
GO

IF OBJECT_ID('SP_DeleteTrabajo') IS NOT NULL
DROP PROCEDURE SP_DeleteTrabajo
GO

CREATE PROCEDURE SP_DeleteTrabajo
@codTrabajo	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_trabajo] WHERE @codTrabajo = codTrabajo;
END
GO

IF OBJECT_ID('SP_UpdateTrabajo') IS NOT NULL
DROP PROCEDURE SP_UpdatePreguntas
GO

CREATE PROCEDURE SP_UpdateTrabajo
@codTrabajo INT,
@inicio DATETIME,
@final DATETIME,
@codPlantilla INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tb_trabajo] SET inicio = @inicio,
                  final = @final,
                  codPlantilla = @codPlantilla
                  WHERE codTrabajo = @codTrabajo
END
GO

IF OBJECT_ID('SP_SelectTrabajo') IS NOT NULL
DROP PROCEDURE SP_SelectTrabajo
GO

CREATE PROCEDURE SP_SelectTrabajo
@codTrabajo	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_trabajo] WHERE codTrabajo = @codTrabajo;
END
GO

IF OBJECT_ID('SP_SelectTrabajoAll') IS NOT NULL
DROP PROCEDURE SP_SelectTrabajoAll
GO

CREATE PROCEDURE SP_SelectTrabajoAll
AS
		SELECT * FROM [tb_trabajo];
GO
/* Procedimientos Almacenados Terminados (Trabajo) */

CREATE TABLE [tb_respuestas] (
  [codRespuestas] INT PRIMARY KEY,
  [descripcion] VARCHAR(255),
  [correcta] BIT,
  [codPregunta] INT
)
GO

/* Procedimientos Almacenados */
-- Respuestas

IF OBJECT_ID('SP_InsertRespuesta') IS NOT NULL
DROP PROCEDURE SP_InsertRespuesta
GO

CREATE PROCEDURE SP_InsertRespuesta
@codRespuestas INT,
@descripcion VARCHAR(255),
@correcta BIT,
@codPregunta INT
AS
  BEGIN
      SET NOCOUNT ON
      INSERT INTO [tb_respuestas] VALUES(@codRespuestas,@descripcion,@correcta,@codPregunta);
  END
GO

IF OBJECT_ID('SP_DeleteRespuesta') IS NOT NULL
DROP PROCEDURE SP_DeleteRespuesta
GO

CREATE PROCEDURE SP_DeleteRespuesta
@codRespuestas	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM [tb_respuestas] WHERE @codRespuestas = codRespuestas;
END
GO

IF OBJECT_ID('SP_UpdateRespuestas') IS NOT NULL
DROP PROCEDURE SP_UpdateRespuestas
GO

CREATE PROCEDURE SP_UpdateRespuestas
@codRespuestas INT,
@descripcion VARCHAR(255),
@correcta BIT,
@codPregunta INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE [tb_respuestas] SET descripcion = @descripcion,
                  correcta = @correcta,
                  codPregunta = @codPregunta
                  WHERE codRespuestas = @codRespuestas
END
GO

IF OBJECT_ID('SP_SelectRespuesta') IS NOT NULL
DROP PROCEDURE SP_SelectRespuesta
GO

CREATE PROCEDURE SP_SelectRespuesta
@codRespuestas	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM [tb_respuestas] WHERE codRespuestas = @codRespuestas;
END
GO

IF OBJECT_ID('SP_SelectRespuestaAll') IS NOT NULL
DROP PROCEDURE SP_SelectRespuestaAll
GO

CREATE PROCEDURE SP_SelectRespuestaAll
AS
		SELECT * FROM [tb_respuestas];
GO
/* Procedimientos Almacenados Terminados (Respuestas) */

--Llaves Foraneas
ALTER TABLE [tba_privilegios] ADD FOREIGN KEY ([codRol]) REFERENCES [tb_rol] ([codRol])
GO

ALTER TABLE [tba_privilegios] ADD FOREIGN KEY ([codUsuario]) REFERENCES [tb_usuario] ([codUsuario])
GO

ALTER TABLE [tba_privilegios_asignatura] ADD FOREIGN KEY ([codPrivilegiosAsignatura]) REFERENCES [tba_privilegios] ([codPrivilegios])
GO

ALTER TABLE [tb_usuario] ADD FOREIGN KEY ([codColegio]) REFERENCES [tb_colegio] ([codColegio])
GO

ALTER TABLE [tb_aranceles] ADD FOREIGN KEY ([codUsuario]) REFERENCES [tb_usuario] ([codUsuario])
GO

ALTER TABLE [tba_detalles] ADD FOREIGN KEY ([codAranceles]) REFERENCES [tb_aranceles] ([codAranceles])
GO

ALTER TABLE [tba_privilegios_asignatura] ADD FOREIGN KEY ([codAsignatura]) REFERENCES [tb_asignatura] ([codAsignatura])
GO

ALTER TABLE [tb_plantilla] ADD FOREIGN KEY ([codAsignatura]) REFERENCES [tb_asignatura] ([codAsignatura])
GO

ALTER TABLE [tb_trabajo] ADD FOREIGN KEY ([codPlantilla]) REFERENCES [tb_plantilla] ([codPlantilla])
GO

ALTER TABLE [tb_preguntas] ADD FOREIGN KEY ([codPlantilla]) REFERENCES [tb_plantilla] ([codPlantilla])
GO

ALTER TABLE [tb_respuestas] ADD FOREIGN KEY ([codPregunta]) REFERENCES [tb_preguntas] ([codPregunta])
GO

ALTER TABLE [tba_horario_asignatura] ADD FOREIGN KEY ([codAsignatura]) REFERENCES [tb_asignatura] ([codAsignatura])
GO

ALTER TABLE [tba_horario_asignatura] ADD FOREIGN KEY ([codHorario]) REFERENCES [tb_horario] ([codHorario])
GO

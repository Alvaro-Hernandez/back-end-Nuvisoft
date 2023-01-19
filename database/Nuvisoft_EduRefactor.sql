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

CREATE TABLE [tba_privilegios] (
  [codPrivilegios] INT PRIMARY KEY,
  [codRol] INT,
  [codUsuario] INT
)
GO

CREATE TABLE [tba_privilegios_asignatura] (
  [codPrivilegiosAsignatura] INT PRIMARY KEY,
  [codPrivilegios] INT,
  [codAsignatura] INT
)
GO

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

CREATE TABLE [tb_aranceles] (
  [codAranceles] INT PRIMARY KEY,
  [codUsuario] INT,
  [estado] VARCHAR (100),
  CONSTRAINT Chk_EstadoArancel CHECK ([estado] IN ('pagado', 'adeudo'))
)
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

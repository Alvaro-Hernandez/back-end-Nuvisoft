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

CREATE TABLE [tb_preguntas] (
  [codPregunta] INT PRIMARY KEY,
  [titulo] VARCHAR(120),
  [tipo] VARCHAR(100),
  [puntaje] INT,
  [autoContestado] BIT,
  [codPlantilla] INT
)
GO

CREATE TABLE [tb_trabajo] (
  [codTrabajo] INT PRIMARY KEY,
  [inicio] DATETIME,
  [final] DATETIME,
  [codPlantilla] INT
)
GO

CREATE TABLE [tb_respuestas] (
  [codRespuestas] INT PRIMARY KEY,
  [descripcion] VARCHAR(255),
  [correcta] BIT,
  [codPregunta] INT
)
GO

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

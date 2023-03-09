DROP DATABASE IF EXISTS ApliClassDB;
CREATE DATABASE ApliClassDB;
GO

USE ApliClassDB;
GO

SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [usuarios] (
    [ID] int  NOT NULL ,
    [Nombre] varchar  NOT NULL ,
    [1Apellido] varchar  NOT NULL ,
    [2Apellido] varchar  NOT NULL ,
    [coreo] varchar  NOT NULL ,
    [TipodeUsuario] int  NOT NULL ,
    CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [TiposdeUsuarios] (
    [ID] int  NOT NULL ,
    --Los tipos serian:
    --Estudiante
    --Profesor
    --Administrador
    [Tipo] varchar  NOT NULL ,
    CONSTRAINT [PK_TiposdeUsuarios] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [Clases] (
    [ID] int  NOT NULL ,
    [Nombre] varchar  NOT NULL ,
    [Profesor] int  NOT NULL ,
    CONSTRAINT [PK_Clases] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [ListasdeEstudiantes] (
    [ID] int  NOT NULL ,
    [Estudiante] int  NOT NULL ,
    [Clase] int  NOT NULL ,
    CONSTRAINT [PK_ListasdeEstudiantes] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [ListasdeLecciones] (
    [ID] int  NOT NULL ,
    [Clase] int  NOT NULL ,
    [Numero] varchar  NOT NULL ,
    [Fecha] timestamp  NOT NULL ,
    CONSTRAINT [PK_ListasdeLecciones] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [Asistencias] (
    [ID] int  NOT NULL ,
    [Leccion] int  NOT NULL ,
    [Estudiante] int  NOT NULL ,
    [Estado] varchar  NOT NULL ,
    CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [TiposdeEstado] (
    [ID] int  NOT NULL ,
    -- Los tipos Estados serian:
    -- - Presente
    -- - Ausente
    -- - Tarde
    -- - Justificado
    [Tipo] varchar  NOT NULL ,
    CONSTRAINT [PK_TiposdeEstado] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

ALTER TABLE [usuarios] WITH CHECK ADD CONSTRAINT [FK_usuarios_TipodeUsuario] FOREIGN KEY([TipodeUsuario])
REFERENCES [TiposdeUsuarios] ([ID])

ALTER TABLE [usuarios] CHECK CONSTRAINT [FK_usuarios_TipodeUsuario]

ALTER TABLE [Clases] WITH CHECK ADD CONSTRAINT [FK_Clases_Profesor] FOREIGN KEY([Profesor])
REFERENCES [usuarios] ([ID])

ALTER TABLE [Clases] CHECK CONSTRAINT [FK_Clases_Profesor]

ALTER TABLE [ListasdeEstudiantes] WITH CHECK ADD CONSTRAINT [FK_ListasdeEstudiantes_Estudiante] FOREIGN KEY([Estudiante])
REFERENCES [usuarios] ([ID])

ALTER TABLE [ListasdeEstudiantes] CHECK CONSTRAINT [FK_ListasdeEstudiantes_Estudiante]

ALTER TABLE [ListasdeEstudiantes] WITH CHECK ADD CONSTRAINT [FK_ListasdeEstudiantes_Clase] FOREIGN KEY([Clase])
REFERENCES [Clases] ([ID])

ALTER TABLE [ListasdeEstudiantes] CHECK CONSTRAINT [FK_ListasdeEstudiantes_Clase]

ALTER TABLE [ListasdeLecciones] WITH CHECK ADD CONSTRAINT [FK_ListasdeLecciones_Clase] FOREIGN KEY([Clase])
REFERENCES [Clases] ([ID])

ALTER TABLE [ListasdeLecciones] CHECK CONSTRAINT [FK_ListasdeLecciones_Clase]

ALTER TABLE [Asistencias] WITH CHECK ADD CONSTRAINT [FK_Asistencias_Leccion] FOREIGN KEY([Leccion])
REFERENCES [ListasdeLecciones] ([ID])

ALTER TABLE [Asistencias] CHECK CONSTRAINT [FK_Asistencias_Leccion]

ALTER TABLE [Asistencias] WITH CHECK ADD CONSTRAINT [FK_Asistencias_Estudiante] FOREIGN KEY([Estudiante])
REFERENCES [usuarios] ([ID])

ALTER TABLE [Asistencias] CHECK CONSTRAINT [FK_Asistencias_Estudiante]

ALTER TABLE [Asistencias] WITH CHECK ADD CONSTRAINT [FK_Asistencias_Estado] FOREIGN KEY([Estado])
REFERENCES [TiposdeEstado] ([ID])

ALTER TABLE [Asistencias] CHECK CONSTRAINT [FK_Asistencias_Estado]

COMMIT TRANSACTION QUICKDBD
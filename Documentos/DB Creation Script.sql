DROP DATABASE IF EXISTS ApliClassDB;
CREATE DATABASE ApliClassDB;
GO

USE ApliClassDB;
GO



SET XACT_ABORT ON

BEGIN TRANSACTION QUICKDBD

CREATE TABLE [usuarios] (
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] VARCHAR(50) NOT NULL,
    [PrimerApellido] VARCHAR(50) NOT NULL,
    [SegundoApellido] VARCHAR(50) NOT NULL,
    [Correo] VARCHAR(50) NOT NULL,
    [TipodeUsuario] int  NOT NULL ,
)


CREATE TABLE [TiposdeUsuarios] (
    [ID] int  NOT NULL ,
    -- Los tipos serian:
    -- Estudiante
    -- Profesor
    -- Administrador
    [Tipo] varchar(50)  NOT NULL ,
    CONSTRAINT [PK_TiposdeUsuarios] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [Clases] (
    [ID] int  NOT NULL ,
    [Nombre] varchar(50)  NOT NULL ,
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
    [Numero] varchar(50)  NOT NULL ,
    [Fecha] timestamp  NOT NULL ,
    CONSTRAINT [PK_ListasdeLecciones] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [Asistencias] (
    [ID] int  NOT NULL ,
    [Leccion] int  NOT NULL ,
    [Estudiante] int  NOT NULL ,
    [Estado] int  NOT NULL ,
    CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED (
        [ID] ASC
    )
)

CREATE TABLE [TiposdeEstado] (
    [ID] int  NOT NULL ,
    -- Los tipos Estados serian:
    -- Presente
    -- Ausente
    -- Tarde
    -- Justificado
    [Tipo] varchar(50)  NOT NULL ,
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








USE ApliClassDB;

-- Insert demo entries into [TiposdeUsuarios] table
INSERT INTO [TiposdeUsuarios] ([ID], [Tipo])
VALUES (1, 'Estudiante'), (2, 'Profesor'), (3, 'Administrador'), (4, 'Asistente'), (5, 'Invitado');
GO

-- Insert demo entries into [usuarios] table
INSERT INTO [usuarios] ([Nombre], [PrimerApellido], [SegundoApellido], [Correo], [TipodeUsuario])
VALUES ('John', 'Doe', 'Smith', 'johndoe@mail.com', 1),
('Jane', 'Doe', 'Johnson', 'janedoe@mail.com', 1),
('Robert', 'Johnson', 'Taylor', 'robertjohnson@mail.com', 2),
('Sarah', 'Connor', 'Davis', 'sarahconnor@mail.com', 2),
('Admin', 'Admin', 'Admin', 'admin@mail.com', 3);
GO

-- Insert demo entries into [Clases] table
INSERT INTO [Clases] ([ID], [Nombre], [Profesor])
VALUES (1, 'Mathematics', 3), (2, 'English', 4), (3, 'History', 3), (4, 'Biology', 4), (5, 'Chemistry', 3);

-- Insert demo entries into [ListasdeEstudiantes] table
INSERT INTO [ListasdeEstudiantes] ([ID], [Estudiante], [Clase])
VALUES (1, 1, 1), (2, 2, 1), (3, 3, 2), (4, 4, 2), (5, 5, 3);

-- Insert demo entries into [ListasdeLecciones] table
INSERT INTO [ListasdeLecciones] ([ID], [Clase], [Numero], [Fecha])
VALUES (1, 1, 'Lesson 1', DEFAULT),
(2, 1, 'Lesson 2', DEFAULT),
(3, 2, 'Lesson 1', DEFAULT),
(4, 2, 'Lesson 2', DEFAULT),
(5, 3, 'Lesson 1', DEFAULT);

-- Insert demo entries into [TiposdeEstado] table
INSERT INTO [TiposdeEstado] ([ID], [Tipo])
VALUES (1, 'Presente'), (2, 'Ausente'), (3, 'Tarde'), (4, 'Justificado'), (5, 'Sin Registrar');

-- Insert demo entries into [Asistencias] table
INSERT INTO [Asistencias] ([ID], [Leccion], [Estudiante], [Estado])
VALUES (1, 1, 1, 1), (2, 1, 2, 2), (3, 2, 1, 3), (4, 2, 2, 1), (5, 3, 3, 4);
go


-- Insert demo entries into [usuarios] table
INSERT INTO [usuarios] ([ID], [Nombre], [PrimerApellido], [SegundoApellido], [Correo], [TipodeUsuario])
VALUES (11, 'John', 'Doe', 'Smith', 'johndoe@mail.com', 1),
(12, 'Jane', 'Doe', 'Johnson', 'janedoe@mail.com', 1),
(13, 'Robert', 'Johnson', 'Taylor', 'robertjohnson@mail.com', 2),
(14, 'Sarah', 'Connor', 'Davis', 'sarahconnor@mail.com', 2),
(15, 'Admin', 'Admin', 'Admin', 'admin@mail.com', 3);
GO
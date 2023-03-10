DROP DATABASE IF EXISTS ApliClassDB;
CREATE DATABASE ApliClassDB;
GO

USE ApliClassDB;
GO

CREATE TABLE [users]
(
    [ID]              int         NOT NULL,
    [Nombre]          varchar(50) NOT NULL,
    [PrimerApellido]  varchar(50) NOT NULL,
    [SegundoApellido] varchar(50) NULL,
    [Correo]          varchar(50) NOT NULL,
    [TipodeUsuario]   int         NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED (
                                                 [ID] ASC
        ),
    CONSTRAINT [UK_users_Correo] UNIQUE (
                                         [Correo]
        )
)

CREATE TABLE [UserTypes]
(
    -- The types would be:
    -- Student
    -- Teacher
    -- Administrator
    [ID]   int         NOT NULL,
    [Tipo] varchar(50) NOT NULL,
    CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED (
                                                     [ID] ASC
        ),
    CONSTRAINT [UK_UserTypes_Tipo] UNIQUE (
                                           [Tipo]
        )
)

CREATE TABLE [Classes]
(
    [ID]       int         NOT NULL,
    [Nombre]   varchar(50) NOT NULL,
    [Profesor] int         NOT NULL,
    CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED (
                                                   [ID] ASC
        )
)

CREATE TABLE [Students]
(
    [ID]         int NOT NULL,
    [Estudiante] int NOT NULL,
    [Clase]      int NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED (
                                                    [ID] ASC
        )
)

CREATE TABLE [Lessons]
(
    [ID]     int         NOT NULL,
    [Clase]  int         NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Fecha]  timestamp   NOT NULL,
    CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED (
                                                   [ID] ASC
        )
)

CREATE TABLE [Attendance]
(
    [ID]         int NOT NULL,
    [Lessons]    int NOT NULL,
    [Estudiante] int NOT NULL,
    [Estado]     int NOT NULL,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED (
                                                      [ID] ASC
        )
)

CREATE TABLE [TiposdeEstado]
(
    -- Los tipos Estados serian:
    -- Presente
    -- Ausente
    -- Tarde
    -- Justificado
    [ID]   int         NOT NULL,
    [Tipo] varchar(50) NOT NULL,
    CONSTRAINT [PK_TiposdeEstado] PRIMARY KEY CLUSTERED (
                                                         [ID] ASC
        ),
    CONSTRAINT [UK_TiposdeEstado_Tipo] UNIQUE (
                                               [Tipo]
        )
)

CREATE TABLE [Grades]
(
    [ID]         int         NOT NULL,
    [Students]   int         NOT NULL,
    [Classes]    int         NOT NULL,
    [Name]       varchar(50) NOT NULL,
    [Grade]      float       NOT NULL,
    [Persentace] float       NOT NULL,
    CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED (
                                                  [ID] ASC
        )
)

ALTER TABLE [users]
    WITH CHECK ADD CONSTRAINT [FK_users_TipodeUsuario] FOREIGN KEY ([TipodeUsuario])
        REFERENCES [UserTypes] ([ID])

ALTER TABLE [users]
    CHECK CONSTRAINT [FK_users_TipodeUsuario]

ALTER TABLE [Classes]
    WITH CHECK ADD CONSTRAINT [FK_Classes_Profesor] FOREIGN KEY ([Profesor])
        REFERENCES [users] ([ID])

ALTER TABLE [Classes]
    CHECK CONSTRAINT [FK_Classes_Profesor]

ALTER TABLE [Students]
    WITH CHECK ADD CONSTRAINT [FK_Students_Estudiante] FOREIGN KEY ([Estudiante])
        REFERENCES [users] ([ID])

ALTER TABLE [Students]
    CHECK CONSTRAINT [FK_Students_Estudiante]

ALTER TABLE [Students]
    WITH CHECK ADD CONSTRAINT [FK_Students_Clase] FOREIGN KEY ([Clase])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Students]
    CHECK CONSTRAINT [FK_Students_Clase]

ALTER TABLE [Lessons]
    WITH CHECK ADD CONSTRAINT [FK_Lessons_Clase] FOREIGN KEY ([Clase])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Lessons]
    CHECK CONSTRAINT [FK_Lessons_Clase]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_Lessons] FOREIGN KEY ([Lessons])
        REFERENCES [Lessons] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_Lessons]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_Estudiante] FOREIGN KEY ([Estudiante])
        REFERENCES [users] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_Estudiante]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_Estado] FOREIGN KEY ([Estado])
        REFERENCES [TiposdeEstado] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_Estado]

ALTER TABLE [Grades]
    WITH CHECK ADD CONSTRAINT [FK_Grades_Students] FOREIGN KEY ([Students])
        REFERENCES [users] ([ID])

ALTER TABLE [Grades]
    CHECK CONSTRAINT [FK_Grades_Students]

ALTER TABLE [Grades]
    WITH CHECK ADD CONSTRAINT [FK_Grades_Classes] FOREIGN KEY ([Classes])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Grades]
    CHECK CONSTRAINT [FK_Grades_Classes]  


USE ApliClassDB;

-- Insert UserTypes
INSERT INTO UserTypes (ID, Tipo)
VALUES (1, 'Student'), (2, 'Teacher'), (3, 'Administrator');

-- Insert users
INSERT INTO users (ID, Nombre, PrimerApellido, SegundoApellido, Correo, TipodeUsuario)
VALUES (1, 'John', 'Doe', NULL, 'johndoe@student.com', 1),
(2, 'Jane', 'Smith', NULL, 'janesmith@student.com', 1),
(3, 'Bob', 'Johnson', NULL, 'bobjohnson@teacher.com', 2),
(4, 'Sue', 'Anderson', NULL, 'sueanderson@teacher.com', 2),
(5, 'Tom', 'Wilson', NULL, 'tomwilson@admin.com', 3),
(6, 'Anna', 'Clark', NULL, 'annaclark@admin.com', 3);

-- Insert Classes
INSERT INTO Classes (ID, Nombre, Profesor)
VALUES (1, 'Mathematics', 3), (2, 'Physics', 3), (3, 'Biology', 4);

-- Insert Students
INSERT INTO Students (ID, Estudiante, Clase)
VALUES (1, 1, 1), (2, 1, 2), (3, 2, 1), (4, 2, 2);

-- Insert Lessons
INSERT INTO Lessons (ID, Clase, Numero, Fecha)
VALUES (1, 1, 'Lesson 1', DEFAULT),
(2, 1, 'Lesson 2',  DEFAULT),
(3, 2, 'Lesson 1', DEFAULT),
(4, 2, 'Lesson 2', DEFAULT) ;

-- Insert TiposdeEstado
INSERT INTO TiposdeEstado (ID, Tipo)
VALUES (1, 'Presente'), (2, 'Ausente'), (3, 'Tarde'), (4, 'Justificado');

-- Insert Attendance
INSERT INTO Attendance (ID, Lessons, Estudiante, Estado)
VALUES (1, 1, 1, 1), (2, 1, 2, 1), (3, 2, 1, 2), (4, 2, 2, 3);

-- Insert Grades
INSERT INTO Grades (ID, Students, Classes, Name, Grade, Persentace)
VALUES (1, 1, 1, 'Exam 1', 90.0, 0.4),
(2, 1, 1, 'Homework 1', 80.0, 0.3),
(3, 2, 1, 'Exam 1', 85.0, 0.4),
(4, 2, 1, 'Homework 1', 95.0, 0.3),
(5, 1, 2, 'Exam 1', 75.0, 0.4),
(6, 1, 2, 'Homework 1', 90.0, 0.3),
(7, 2, 2, 'Exam 1', 80.0, 0.4)
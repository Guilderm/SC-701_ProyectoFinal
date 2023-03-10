DROP DATABASE IF EXISTS ApliClassDB;
CREATE DATABASE ApliClassDB;
GO

USE ApliClassDB;
GO

CREATE TABLE [users]
(
    [ID]              INT IDENTITY (1,1) PRIMARY KEY,
    [Name]            varchar(50) NOT NULL,
    [PrimerApellido]  varchar(50) NOT NULL,
    [SegundoApellido] varchar(50) NULL,
    [Email]           varchar(50) NOT NULL,
    [UserType]        INT         NOT NULL,
    CONSTRAINT [UK_users_Email] UNIQUE ([Email])
)

CREATE TABLE [TypesOfUsers]
(
    -- The types would be:
    -- Student
    -- Teacher
    -- Administrator
    [ID]   INT IDENTITY (1,1) PRIMARY KEY,
    [Type] varchar(50) NOT NULL,
    CONSTRAINT [UQ_TypesOfUsers_Type] UNIQUE ([Type])
)

CREATE TABLE [Classes]
(
    [ID]    INT IDENTITY (1,1) PRIMARY KEY,
    [Name]  varchar(50) NOT NULL,
    Teacher int         NOT NULL,
)

CREATE TABLE [Students]
(
    [ID]      INT IDENTITY (1,1) PRIMARY KEY,
    [Student] int NOT NULL,
    [Class]   int NOT NULL,
)

CREATE TABLE [Lessons]
(
    [ID]     INT IDENTITY (1,1) PRIMARY KEY,
    [Class]  int         NOT NULL,
    [Number] varchar(50) NOT NULL,
    [Date]   timestamp   NOT NULL,
)

CREATE TABLE [Attendance]
(
    [ID]      INT IDENTITY (1,1) PRIMARY KEY,
    [Lesson] int NOT NULL,
    [Student] int NOT NULL,
    [State]   int NOT NULL,
)

CREATE TABLE [TypesOfStates]
(
-- The state types would be:
-- Present
-- Absent
-- Late
-- Justified
    [ID]   INT IDENTITY (1,1) PRIMARY KEY,
    [Type] varchar(50) NOT NULL,
    CONSTRAINT [UQ_TypesOfStates_Type] UNIQUE ([Type])
)

CREATE TABLE [Grades]
(
    [ID]         INT IDENTITY (1,1) PRIMARY KEY,
    [Students]   int         NOT NULL,
    [Classes]    int         NOT NULL,
    [Name]       varchar(50) NOT NULL,
    [Grade]      float       NOT NULL,
    [Percentage] float       NOT NULL
)

ALTER TABLE [users]
    WITH CHECK ADD CONSTRAINT [FK_users_TypesOfUsers] FOREIGN KEY ([UserType])
        REFERENCES [TypesOfUsers] ([ID])

ALTER TABLE [users]
    CHECK CONSTRAINT [FK_users_TypesOfUsers]

ALTER TABLE [Classes]
    WITH CHECK ADD CONSTRAINT [FK_Classes_Teacher] FOREIGN KEY ([Teacher])
        REFERENCES [users] ([ID])

ALTER TABLE [Classes]
    CHECK CONSTRAINT [FK_Classes_Teacher]

ALTER TABLE [Students]
    WITH CHECK ADD CONSTRAINT [FK_Students_Student] FOREIGN KEY ([Student])
        REFERENCES [users] ([ID])

ALTER TABLE [Students]
    CHECK CONSTRAINT [FK_Students_Student]

ALTER TABLE [Students]
    WITH CHECK ADD CONSTRAINT [FK_Students_Class] FOREIGN KEY ([Class])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Students]
    CHECK CONSTRAINT [FK_Students_Class]

ALTER TABLE [Lessons]
    WITH CHECK ADD CONSTRAINT [FK_Lessons_Class] FOREIGN KEY ([Class])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Lessons]
    CHECK CONSTRAINT [FK_Lessons_Class]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_Lessons] FOREIGN KEY ([Lesson])
        REFERENCES [Lessons] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_Lessons]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_Student] FOREIGN KEY ([Student])
        REFERENCES [users] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_Student]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_State] FOREIGN KEY ([State])
        REFERENCES [TypesOfStates] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_State]

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
INSERT INTO TypesOfUsers (Type)
VALUES ('Student'),
       ('Teacher'),
       ('Administrator');

-- Insert users
INSERT INTO users (Name, PrimerApellido, SegundoApellido, Email, UserType)
VALUES ('John', 'Doe', 'Smith', 'johndoe@student.com', 1),
('Jane', 'Smith', 'Johnson', 'janesmith@student.com', 1),
('Bob', 'Johnson', NULL, 'bobjohnson@teacher.com', 2),
('Sue', 'Anderson', 'Steven', 'sueanderson@teacher.com', 2),
('Tom', 'Wilson', 'Clark', 'tomwilson@admin.com', 3),
('Anna', 'Clark', 'Mcklaen', 'annaclark@admin.com', 3);

-- Insert Classes
INSERT INTO Classes (name, Teacher)
VALUES ('Mathematics', 3),
       ('Physics', 3),
       ('Biology', 4);

-- Insert Students
INSERT INTO Students (Student, Class)
VALUES (1, 1),
       (1, 2),
       (2, 1),
       (2, 2);

-- Insert Lessons
INSERT INTO Lessons (Class, Number, Date)
VALUES (1, 'Lesson 1', DEFAULT),
       (1, 'Lesson 2', DEFAULT),
       (2, 'Lesson 1', DEFAULT),
       (2, 'Lesson 2', DEFAULT);

-- Insert TypesOfStates
INSERT INTO TypesOfStates (Type)
VALUES ('Present'),
       ('Absent'),
       ('Late'),
       ('Justified');

-- Insert Attendance
INSERT INTO Attendance (Lesson, Student, State)
VALUES (1, 1, 1),
       (1, 2, 1),
       (2, 1, 2),
       (3, 2, 3);

-- Insert Grades
INSERT INTO Grades (Students, Classes, Name, Grade, Percentage)
VALUES (1, 1, 'Exam 1', 90.0, 0.4),
       (1, 1, 'Homework 1', 80.0, 0.3),
       (2, 1, 'Exam 1', 85.0, 0.4),
       (2, 1, 'Homework 1', 95.0, 0.3),
       (1, 2, 'Exam 1', 75.0, 0.4),
       (1, 2, 'Homework 1', 90.0, 0.3),
       (2, 2, 'Exam 1', 80.0, 0.4)
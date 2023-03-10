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
    -- StudentID
    -- Teacher
    -- Administrator
    [ID]   INT IDENTITY (1,1) PRIMARY KEY,
    [Type] varchar(50) NOT NULL,
    CONSTRAINT [UQ_TypesOfUsers_Type] UNIQUE ([Type])
)

CREATE TABLE [Classes]
(
    [ID]      INT IDENTITY (1,1) PRIMARY KEY,
    [Name]    varchar(50) NOT NULL,
    TeacherID int         NOT NULL,
)

CREATE TABLE [Students]
(
    [ID]        INT IDENTITY (1,1) PRIMARY KEY,
    [StudentID] int NOT NULL,
    [ClassID]   int NOT NULL,
)

CREATE TABLE [Lessons]
(
    [ID]      INT IDENTITY (1,1) PRIMARY KEY,
    [ClassID] int         NOT NULL,
    [Name]    varchar(50) NULL,
    [Date]    timestamp   NOT NULL,
)

CREATE TABLE [Attendance]
(
    [ID]        INT IDENTITY (1,1) PRIMARY KEY,
    [LessonID]  int NOT NULL,
    [StudentID] int NOT NULL,
    [StateID]   int NOT NULL,
)

CREATE TABLE [AttendanceStates]
(
-- The different state should be:
-- Present
-- Absent
-- Late
-- Justified
    [ID]    INT IDENTITY (1,1) PRIMARY KEY,
    [State] varchar(50) NOT NULL,
    CONSTRAINT [UQ_AttendanceStates_State] UNIQUE ([State])
)

CREATE TABLE [Grades]
(
    [ID]         INT IDENTITY (1,1) PRIMARY KEY,
    [StudentID]  int         NOT NULL,
    [ClassID]    int         NOT NULL,
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
    WITH CHECK ADD CONSTRAINT [FK_Classes_TeacherID] FOREIGN KEY ([TeacherID])
        REFERENCES [users] ([ID])

ALTER TABLE [Classes]
    CHECK CONSTRAINT [FK_Classes_TeacherID]

ALTER TABLE [Students]
    WITH CHECK ADD CONSTRAINT [FK_StudentID_StudentID] FOREIGN KEY ([StudentID])
        REFERENCES [users] ([ID])

ALTER TABLE [Students]
    CHECK CONSTRAINT [FK_StudentID_StudentID]

ALTER TABLE [Students]
    WITH CHECK ADD CONSTRAINT [FK_Students_Class] FOREIGN KEY ([ClassID])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Students]
    CHECK CONSTRAINT [FK_Students_Class]

ALTER TABLE [Lessons]
    WITH CHECK ADD CONSTRAINT [FK_Lessons_Class] FOREIGN KEY ([ClassID])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Lessons]
    CHECK CONSTRAINT [FK_Lessons_Class]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_Lessons] FOREIGN KEY ([LessonID])
        REFERENCES [Lessons] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_Lessons]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_StudentID] FOREIGN KEY ([StudentID])
        REFERENCES [users] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_StudentID]

ALTER TABLE [Attendance]
    WITH CHECK ADD CONSTRAINT [FK_Attendance_State] FOREIGN KEY ([StateID])
        REFERENCES [AttendanceStates] ([ID])

ALTER TABLE [Attendance]
    CHECK CONSTRAINT [FK_Attendance_State]

ALTER TABLE [Grades]
    WITH CHECK ADD CONSTRAINT [FK_Grades_StudentIDs] FOREIGN KEY ([StudentID])
        REFERENCES [users] ([ID])

ALTER TABLE [Grades]
    CHECK CONSTRAINT [FK_Grades_StudentIDs]

ALTER TABLE [Grades]
    WITH CHECK ADD CONSTRAINT [FK_Grades_Classes] FOREIGN KEY ([ClassID])
        REFERENCES [Classes] ([ID])

ALTER TABLE [Grades]
    CHECK CONSTRAINT [FK_Grades_Classes]


USE ApliClassDB;

-- Insert UserTypes
INSERT INTO TypesOfUsers (Type)
VALUES ('StudentID'),
       ('Teacher'),
       ('Administrator');

-- Insert users
INSERT INTO users (Name, PrimerApellido, SegundoApellido, Email, UserType)
VALUES ('John', 'Doe', 'Smith', 'johndoe@StudentID.com', 1),
       ('Jane', 'Smith', 'Johnson', 'janesmith@StudentID.com', 1),
       ('Bob', 'Johnson', NULL, 'bobjohnson@teacher.com', 2),
       ('Sue', 'Anderson', 'Steven', 'sueanderson@teacher.com', 2),
       ('Tom', 'Wilson', 'Clark', 'tomwilson@admin.com', 3),
       ('Anna', 'Clark', 'Mclaren', 'annaclark@admin.com', 3);

-- Insert Classes
INSERT INTO Classes (name, TeacherID)
VALUES ('Mathematics', 3),
       ('Physics', 3),
       ('Biology', 4);

-- Insert Students
INSERT INTO Students (StudentID, ClassID)
VALUES (1, 1),
       (1, 2),
       (2, 1),
       (2, 2);

-- Insert Lessons
INSERT INTO Lessons (ClassID, Name, Date)
VALUES (1, 'Lesson 1', DEFAULT),
       (1, 'Lesson 2', DEFAULT),
       (2, 'Lesson 1', DEFAULT),
       (2, 'Lesson 2', DEFAULT);

-- Insert AttendanceStates
INSERT INTO AttendanceStates (State)
VALUES ('Present'),
       ('Absent'),
       ('Late'),
       ('Justified');

-- Insert Attendance
INSERT INTO Attendance (LessonID, StudentID, StateID)
VALUES (1, 1, 1),
       (1, 2, 1),
       (2, 1, 2),
       (3, 2, 3);

-- Insert Grades
INSERT INTO Grades (StudentID, ClassID, Name, Grade, Percentage)
VALUES (1, 1, 'Exam 1', 90.0, 0.4),
       (1, 1, 'Homework 1', 80.0, 0.3),
       (2, 1, 'Exam 1', 85.0, 0.4),
       (2, 1, 'Homework 1', 95.0, 0.3),
       (1, 2, 'Exam 1', 75.0, 0.4),
       (1, 2, 'Homework 1', 90.0, 0.3),
       (2, 2, 'Exam 1', 80.0, 0.4)
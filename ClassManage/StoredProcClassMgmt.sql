USE master
GO
USE ClassManagement
GO
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetStudentsByClass')
BEGIN
   DROP PROCEDURE GetStudentsByClass
END
GO

CREATE PROCEDURE GetStudentsByClass(
    @ClassId int
)
AS
    SELECT * FROM Student
    WHERE Student.ClassId = @ClassId
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetClasses')
BEGIN
   DROP PROCEDURE GetClasses
END
GO
CREATE PROCEDURE GetClasses
    AS
    SELECT * From Class
GO
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddStudent')
BEGIN
   DROP PROCEDURE AddStudent
END
GO

CREATE PROCEDURE AddStudent(
    @StudentName varchar(50),
    @ClassId int
)
    AS
        INSERT INTO Student ([StudentName], ClassId)
        VALUES (@StudentName, @ClassId)
GO

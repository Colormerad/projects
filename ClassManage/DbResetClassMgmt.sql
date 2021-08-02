Use ClassManagement
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS

DELETE FROM Student;
DELETE FROM Class;

DBCC CHECKIDENT ('Student', RESEED, 0)
DBCC CHECKIDENT ('Class', RESEED, 0)

SET IDENTITY_INSERT Class ON
	INSERT INTO Class (Id, ClassName, Teacher)
	Values ('1', 'Algebra 1', 'Ms. Stephens'),
	('2', 'Algebra 2', 'Mr. Miles'),
	('3', 'English 101', 'Miss Trisha'),
	('4', 'World Literature', 'Mrs. Francis'),
	('5', 'French', 'Mrs. Elias');
	SET IDENTITY_INSERT Class OFF
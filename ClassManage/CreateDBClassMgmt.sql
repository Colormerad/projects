Use Master 
GO
DROP DATABASE IF EXISTS
 ClassManagement;
 GO
 CREATE DATABASE ClassManagement;
 GO
 USE ClassManagement
 GO

 IF EXISTS(SELECT * FROM sys.tables WHERE name ='Student')
	DROP TABLE Student
GO

  IF EXISTS(SELECT * FROM sys.tables WHERE name ='Class')
	DROP TABLE Class
GO

CREATE TABLE Class
(
 [Id] int NOT NULL IDENTITY(1, 1),
 [ClassName]        varchar(50) NOT NULL ,
 [Teacher]          varchar(50) NOT NULL 
 
 
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED ([Id])
);
GO



CREATE TABLE Student
(
 [Id] int NOT NULL IDENTITY(1, 1),
 [StudentName]              varchar(50) NOT NULL ,
 [ClassId]				int NOT NULL
 

 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Id])
 CONSTRAINT [FK_StudentClass] FOREIGN KEY ([ClassId]) REFERENCES [Class]([Id])
);
GO


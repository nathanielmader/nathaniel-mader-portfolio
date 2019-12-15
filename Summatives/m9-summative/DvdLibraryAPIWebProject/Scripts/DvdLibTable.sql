USE DvdLib
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
DROP TABLE Dvd
GO

CREATE TABLE Dvd(
	DvdId int identity(1,1) not null primary key,
	Title varchar(300) not null,
	ReleaseYear int not null,
	Director varchar(50) not null,
	Rating varchar(5) not null,
	Notes varchar(500) null
)
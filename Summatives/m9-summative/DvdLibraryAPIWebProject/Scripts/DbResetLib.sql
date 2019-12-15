--DvdLibrary reset.
--Purges table data, places in sample data in order to test functionality of database
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
WHERE ROUTINE_NAME = 'DbReset')
DROP PROCEDURE DbReset
GO

USE DvdLib
GO

CREATE PROCEDURE DbReset AS
BEGIN
	DELETE FROM Dvd;

	--Reset identity column in table
	DBCC CHECKIDENT ('Dvd', reseed, 1)

	SET IDENTITY_INSERT Dvd ON;
	INSERT INTO Dvd (DvdId, Title, ReleaseYear, Director, Rating, Notes)
	VALUES (1, 'The Lion King', 1992, 'Some Guy', 'PG', 'The best ever!'),
				(2, 'Up', 2010, 'Old Man Jenky', 'PG', 'Ehhhhh')
	SET IDENTITY_INSERT Dvd OFF;
END
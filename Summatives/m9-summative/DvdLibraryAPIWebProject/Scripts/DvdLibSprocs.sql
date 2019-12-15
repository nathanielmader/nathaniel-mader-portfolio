IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
WHERE ROUTINE_NAME = 'GetAllDvds')
DROP PROCEDURE GetAllDvds
GO

CREATE PROCEDURE GetAllDvds AS
BEGIN
	select DvdId, Title, ReleaseYear, Director, Rating, Notes
	from Dvd
END

GO
------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'CreateDvd')
			DROP PROCEDURE CreateDvd
GO

CREATE PROCEDURE CreateDvd(
			@DvdId int output,
			@Title varchar(300),
			@ReleaseYear int,
			@Director varchar(50),
			@Rating varchar(5),
			@Notes varchar(500)
) AS
BEGIN
	insert into Dvd (Title, ReleaseYear, Director, Rating, Notes)
	values (@Title, @ReleaseYear, @Director, @Rating, @Notes);

	set @DvdId = SCOPE_IDENTITY();
END

GO
-----------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'DeleteDvd')
			DROP PROCEDURE DeleteDvd
GO

CREATE PROCEDURE DeleteDvd(
			@DvdId int
) AS
BEGIN
		DELETE FROM Dvd WHERE DvdId = @DvdId;
END

GO
--------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'GetDvdByDirector')
			DROP PROCEDURE GetDvdByDirector
GO

CREATE PROCEDURE GetDvdByDirector(
			@Director varchar(50)
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE Director = @Director;
END

GO
----------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'GetDvdById')
			DROP PROCEDURE GetDvdById
GO

CREATE PROCEDURE GetDvdById(
			@DvdId int
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE DvdId = @DvdId;
END

GO
-----------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'GetDvdByRating')
			DROP PROCEDURE GetDvdByRating
GO

CREATE PROCEDURE GetDvdByRating(
			@Rating varchar(5)
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE Rating = @Rating;
END

GO
----------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'GetDvdByReleaseYear')
			DROP PROCEDURE GetDvdByReleaseYear
GO

CREATE PROCEDURE GetDvdByReleaseYear(
			@ReleaseYear int
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE ReleaseYear = @ReleaseYear;
END

GO
---------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'GetDvdByTitle')
			DROP PROCEDURE GetDvdByTitle
GO

CREATE PROCEDURE GetDvdByTitle(
			@Title varchar(300)
) AS
BEGIN
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd
	WHERE Title = @Title;
END

GO
---------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINEs
		WHERE ROUTINE_NAME = 'UpdateDvd')
			DROP PROCEDURE UpdateDvd
GO

CREATE PROCEDURE UpdateDvd(
			@DvdId int output,
			@Title varchar(300),
			@ReleaseYear int,
			@Director varchar(50),
			@Rating varchar(5),
			@Notes varchar(500)
) AS
BEGIN
			UPDATE Dvd SET
					Title = @Title,
					ReleaseYear = @ReleaseYear,
					Director = @Director,
					Rating = @Rating,
					Notes = @Notes
				WHERE DvdId = @DvdId
END

GO
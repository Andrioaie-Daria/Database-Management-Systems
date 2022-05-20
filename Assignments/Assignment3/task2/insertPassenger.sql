CREATE OR ALTER PROCEDURE usp_InsertPassenger @name VARCHAR(50),
	@cnp VARCHAR(50),
	@email VARCHAR(50),
	@date DATE,
	@status VARCHAR(50)
AS
BEGIN
BEGIN TRAN

BEGIN TRY
	IF (dbo.uf_ValidatePassengerName(@name) <> 1)
		RAISERROR('Passenger name is invalid',10,1)
	IF (dbo.uf_ValidatePassengerCNP(@cnp) <> 1)
		RAISERROR('Passenger cnp is invalid',10,1)
	IF (dbo.uf_validatePassengerEmail(@email) <> 1)
		RAISERROR('Passenger email is invalid',10,1)
	IF (dbo.uf_ValidatePassengerDateOfBirth(@date) <> 1)
		RAISERROR('Passenger dob is invalid',10,1)
	IF (dbo.uf_ValidatePassengerStatus(@status) <> 1)
		RAISERROR('Passenger status is invalid',10,1)

	INSERT INTO Passenger VALUES (@name, @cnp, @email, @date, @status)
	PRINT 'Inserted Passenger'
	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Commited', 'Success')
	COMMIT TRAN
	RETURN 0

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	PRINT 'Passenger insertion was rolledback.'
	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Rolledback', ERROR_MESSAGE())
	return -1

END CATCH
	
END

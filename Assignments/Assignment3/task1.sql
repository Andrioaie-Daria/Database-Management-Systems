DROP TABLE IF EXISTS ExecutionLogs
CREATE TABLE ExecutionLogs(
	Id INT IDENTITY PRIMARY KEY,
	Time DATETIME,
	Status VARCHAR(50),
	CHECK(Status IN ('Commited', 'Rolledback', 'Recovered')),
	Details VARCHAR(200)
)

SELECT * FROM Passenger
SELECT * FROM Passenger_Subscription
SELECT * FROM Subscription
SELECT * FROM Route

--- validation functions for the columns in Passenger

GO
CREATE OR ALTER FUNCTION uf_ValidatePassengerName (@name VARCHAR(50)) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1
	IF (@name IS NULL OR LEN(@name)<3)
		SET @return = 0

	IF (ASCII(LEFT(@name, 1)) NOT BETWEEN 65 AND 90)
		SET @return = 0

	RETURN @return
END

GO

CREATE OR ALTER FUNCTION uf_ValidatePassengerCNP (@cnp VARCHAR(50)) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1
	IF (@cnp IS NULL OR LEN(@cnp)<>13)
		SET @return = 0

	IF (ASCII(LEFT(@cnp, 13)) NOT BETWEEN 48 AND 57)
		SET @return = 0

	RETURN @return
END

GO

CREATE OR ALTER FUNCTION uf_validatePassengerEmail(@email varchar(50)) RETURNS int  as
BEGIN     
  DECLARE @return INT
  DECLARE @emailText varchar(50)

  SET @emailText=ltrim(rtrim(isnull(@email,'')))

  SET @return = case when @emailText = '' then 0
                          when @emailText like '% %' then 0
                          when @emailText like ('%["(),:;<>\]%') then 0
                          when substring(@emailText,charindex('@',@emailText),len(@emailText)) like ('%[!#$%&*+/=?^`_{|]%') then 0
                          when (left(@emailText,1) like ('[-_.+]') or right(@emailText,1) like ('[-_.+]')) then 0                                                                                    
                          when (@emailText like '%[%' or @emailText like '%]%') then 0
                          when @emailText LIKE '%@%@%' then 0
                          when @emailText NOT LIKE '_%@_%._%' then 0
                          else 1 
                      end
  RETURN @return
END 
GO

CREATE OR ALTER FUNCTION uf_ValidatePassengerDateOfBirth (@date DATE) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1
	IF (@date IS NULL)
		SET @return = 0
	RETURN @return
END

GO

CREATE OR ALTER FUNCTION uf_ValidatePassengerStatus (@status VARCHAR(50)) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1

	IF (@status IS NULL)
		SET @return = 0
	IF(@status NOT IN ('child', 'student', 'adult', 'retired'))
		SET @return = 0

	RETURN @return
END

GO

--- validation functions for the columns in Subscription

CREATE OR ALTER FUNCTION uf_ValidateSubscriptionRoute(@routeId INT) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1

	IF (@routeId IS NULL)
		SET @return = 0

	IF(@routeId NOT IN (SELECT RouteID FROM Route))
		SET @return = 0

	RETURN @return
END

GO

CREATE OR ALTER FUNCTION uf_ValidateSubscriptionDuration(@duration INT) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1

	IF (@duration IS NULL)
		SET @return = 0

	IF NOT ((@duration=(366) OR @duration=(183) OR @duration=(31) OR @duration=(7)))
		SET @return = 0

	RETURN @return
END

GO

CREATE OR ALTER FUNCTION uf_ValidateSubscriptionPrice(@price INT) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1

	IF (@price IS NULL OR @price <= 0)
		SET @return = 0

	RETURN @return
END

GO

CREATE OR ALTER FUNCTION uf_ValidateSubscriptionCurrency(@currency VARCHAR(50)) RETURNS INT AS
BEGIN
	DECLARE @return INT
	SET @return = 1

	IF (@currency IS NULL OR @currency NOT IN ('eur', 'ron', 'usd'))
		SET @return = 0

	RETURN @return
END

GO

CREATE OR ALTER PROCEDURE usp_InsertPassengerAndSubscription
	@name VARCHAR(50),
	@cnp VARCHAR(50),
	@email VARCHAR(50),
	@date DATE,
	@status VARCHAR(50), 
	@routeId INT,
	@duration INT,
	@price INT,
	@currenrcy VARCHAR(10)
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

	IF (dbo.uf_ValidateSubscriptionRoute(@routeId) <> 1)
		RAISERROR('Subscription route is invalid',11,1)
	IF (dbo.uf_ValidateSubscriptionDuration(@duration) <> 1)
		RAISERROR('Subscription duration is invalid',11,1)
	IF (dbo.uf_ValidateSubscriptionPrice(@price) <> 1)
		RAISERROR('Subscription price is invalid',11,1)
	IF (dbo.uf_ValidateSubscriptionCurrency(@currenrcy) <> 1)
		RAISERROR('Subscription currency is invalid',11,1)

	INSERT INTO Subscription VALUES (@routeId, @duration, @price, @currenrcy)
	PRINT 'Inserted Subscription'

	DECLARE @passengerId INT
	SET @passengerId = (SELECT IDENT_CURRENT('Passenger'))
	DECLARE @subscriptionId INT
	SET @subscriptionId = (SELECT IDENT_CURRENT('Subscription'))

	INSERT INTO Passenger_Subscription VALUES(@passengerId, @subscriptionId, GETDATE())
	PRINT 'Inserted Passenger_Subscription'

	COMMIT TRAN
	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Commited', 'Success')

END TRY

BEGIN CATCH
	ROLLBACK TRAN
	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Rolledback', ERROR_MESSAGE())
	PRINT 'All changes were rolledback.'
END CATCH
END

GO

DROP PROCEDURE usp_InsertPassengerAndSubscriptionWithRecovery
GO

/*CREATE OR ALTER PROCEDURE usp_InsertPassengerAndSubscriptionWithRecovery
	@name VARCHAR(50),
	@cnp VARCHAR(50),
	@email VARCHAR(50),
	@date DATE,
	@status VARCHAR(50), 
	@routeId INT,
	@duration INT,
	@price INT,
	@currenrcy VARCHAR(10)
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

	SAVE TRAN InsertedPassenger

	IF (dbo.uf_ValidateSubscriptionRoute(@routeId) <> 1)
		RAISERROR('Subscription route is invalid',11,1)
	IF (dbo.uf_ValidateSubscriptionDuration(@duration) <> 1)
		RAISERROR('Subscription duration is invalid',11,1)
	IF (dbo.uf_ValidateSubscriptionPrice(@price) <> 1)
		RAISERROR('Subscription price is invalid',11,1)
	IF (dbo.uf_ValidateSubscriptionCurrency(@currenrcy) <> 1)
		RAISERROR('Subscription currency is invalid',11,1)

	INSERT INTO Subscription VALUES (@routeId, @duration, @price, @currenrcy)
	PRINT 'Inserted Subscription'

	DECLARE @passengerId INT
	SET @passengerId = (SELECT IDENT_CURRENT('Passenger'))
	DECLARE @subscriptionId INT
	SET @subscriptionId = (SELECT IDENT_CURRENT('Subscription'))

	INSERT INTO Passenger_Subscription VALUES(@passengerId, @subscriptionId, GETDATE())
	PRINT 'Inserted Passenger_Subscription'

	COMMIT TRAN
	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Commited', 'Success')

END TRY

BEGIN CATCH
	DECLARE @severity INT
	SET @severity = (SELECT ERROR_SEVERITY())

	IF (@severity = 10)
	BEGIN
		ROLLBACK TRAN
		PRINT 'All changes were rolledback.'
	END
	IF (@severity = 11)
		BEGIN
		ROLLBACK TRAN InsertedPassenger
		PRINT 'The insert in Passenger was recovered'
		END

	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Rolledback', ERROR_MESSAGE())
	
END CATCH

END

GO 
*/



SELECT * FROM Passenger
SELECT * FROM Subscription
SELECT * FROM Route
SELECT * from ExecutionLogs

--- commits
EXEC usp_InsertPassengerAndSubscription 'Test', '0000000000000', 'test@gmail.com', '2000-01-01', 'adult', 34634, 31, 10, 'ron'

---- fails beacuse the currency of the subscription is not valid
EXEC usp_InsertPassengerAndSubscription 'Test', '0000000000001', 'test1@gmail.com', '2000-01-01', 'adult', 34634, 366, 10, 'invalid'

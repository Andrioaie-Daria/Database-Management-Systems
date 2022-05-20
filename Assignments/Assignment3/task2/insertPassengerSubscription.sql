CREATE OR ALTER PROCEDURE usp_LastPassengerSubscription
AS
BEGIN
	BEGIN TRAN 
	DECLARE @passengerId INT
	SET @passengerId = (SELECT IDENT_CURRENT('Passenger'))
	DECLARE @subscriptionId INT
	SET @subscriptionId = (SELECT IDENT_CURRENT('Subscription'))

	INSERT INTO Passenger_Subscription VALUES(@passengerId, @subscriptionId, GETDATE())
	PRINT 'Inserted Passenger_Subscription'
	INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Commited', 'Success')
	COMMIT TRAN
END

GO

CREATE OR ALTER PROCEDURE usp_InsertPassengerAndSubscriptionWithRecovery2
	@name VARCHAR(50),
	@cnp VARCHAR(50),
	@email VARCHAR(50),
	@date DATE,
	@status VARCHAR(50), 
	@routeId INT,
	@duration INT,
	@price INT,
	@currency VARCHAR(10)
AS
BEGIN
	declare @passenger int
	exec @passenger = usp_InsertPassenger @name, @cnp, @email, @date, @status
	
	declare @subscription int
	exec @subscription = usp_InsertSubscription @routeId, @duration, @price, @currency
	
	if (@subscription <> -1 AND @passenger <> -1)
			exec usp_LastPassengerSubscription
	
END

SELECT * FROM Passenger
SELECT * FROM Subscription
SELECT * FROM Passenger_Subscription
SELECT * FROM Route
SELECT * from ExecutionLogs

DELETE FROM Subscription

DELETE FROM Passenger
WHERE name = 'test'


--- commits 
EXEC usp_InsertPassengerAndSubscriptionWithRecovery2 'Test', '0000000000000', 'test@gmail.com', '2000-01-01', 'adult', 34634, 7, 10, 'ron'

---- fails beacuse the currency of the subscription is not valid
EXEC usp_InsertPassengerAndSubscriptionWithRecovery2 'Test', '0000000000001', 'test1@gmail.com', '2000-01-01', 'adult', 34634, 366, 10, 'invalid'


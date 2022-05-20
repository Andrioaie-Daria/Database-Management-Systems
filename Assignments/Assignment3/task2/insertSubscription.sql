CREATE OR ALTER PROCEDURE usp_InsertSubscription 
	@routeId INT,
	@duration INT,
	@price INT,
	@currency VARCHAR(10)
AS
BEGIN
	BEGIN TRAN
	BEGIN TRY
		IF (dbo.uf_ValidateSubscriptionRoute(@routeId) <> 1)
		RAISERROR('Subscription route is invalid',11,1)
		IF (dbo.uf_ValidateSubscriptionDuration(@duration) <> 1)
			RAISERROR('Subscription duration is invalid',11,1)
		IF (dbo.uf_ValidateSubscriptionPrice(@price) <> 1)
			RAISERROR('Subscription price is invalid',11,1)
		IF (dbo.uf_ValidateSubscriptionCurrency(@currency) <> 1)
			RAISERROR('Subscription currency is invalid',11,1)

		INSERT INTO Subscription VALUES (@routeId, @duration, @price, @currency)
		PRINT 'Inserted Subscription'
		INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Commited', 'Success')
		COMMIT TRAN
		RETURN 0

	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		PRINT 'Subscription insertion was rolledback.'
		INSERT INTO ExecutionLogs VALUES (GETDATE(), 'Rolledback', ERROR_MESSAGE())
		return -1
	END CATCH
END
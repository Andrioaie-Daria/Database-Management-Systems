--- phantom read
--- transaction 2 solved


SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRAN 

SELECT * FROM Passenger
WAITFOR DELAY '00:00:05'
SELECT * FROM Passenger
COMMIT TRAN

DELETE FROM Passenger WHERE name = 'teeest'

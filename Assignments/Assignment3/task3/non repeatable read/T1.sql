--- non repeatable read
--- transaction  1

BEGIN TRAN
WAITFOR DELAY '00:00:05'

UPDATE Passenger 
SET name = 'test'
WHERE Status = 'adult'

COMMIT TRAN

SELECT * FROM Passenger
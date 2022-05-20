---- dirty read

---- transaction 1

BEGIN TRANSACTION 

UPDATE Passenger
SET Name = 'test'
WHERE Status = 'adult'

WAITFOR DELAY '00:00:05'
ROLLBACK TRANSACTION


SELECT * FROM Passenger

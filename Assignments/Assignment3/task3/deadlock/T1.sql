-- deadlock 
-- transaction 1

BEGIN TRAN 
UPDATE Passenger
SET name = '!!!!!!' WHERE PassengerID = 285185

WAITFOR DELAY '00:00:05'

UPDATE Route
SET Destination = 'Viena' WHERE Source = 'Zurich'

COMMIT TRAN

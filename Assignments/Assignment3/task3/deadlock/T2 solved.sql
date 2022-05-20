-- deadlock 
-- transaction 2 unsolved


SET DEADLOCK_PRIORITY HIGH
BEGIN TRAN 

UPDATE Route
SET Destination = 'Milano' WHERE Source = 'Zurich'

WAITFOR DELAY '00:00:05'

UPDATE Passenger
SET name = 'bbbbbbbb' WHERE PassengerID = 285185

COMMIT TRAN
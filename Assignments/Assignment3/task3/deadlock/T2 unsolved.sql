-- deadlock 
-- transaction 2 unsolved

BEGIN TRAN 

UPDATE Route
SET Destination = 'Viena' WHERE Source = 'Zurich'

WAITFOR DELAY '00:00:05'

UPDATE Passenger
SET name = 'alalalalal' WHERE PassengerID = 285185

COMMIT TRAN

SELECT * FROM Passenger
SELECT * FROM Route
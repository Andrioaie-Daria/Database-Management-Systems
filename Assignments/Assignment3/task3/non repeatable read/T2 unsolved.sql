--- non repeatable read
-- -transaction 2 unsolved

--- under read committed, shared locks are released immediately after the select statement, 
-- so this allows T1 to acquire an exclusive lock and change the data between the two selects in T2 and the
--- update will be visible in the second select of T2

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN 

SELECT * FROM Passenger
WAITFOR DELAY '00:00:08'
SELECT * FROM Passenger

COMMIT TRAN 

UPDATE Passenger
SET Name = 'Anna'
WHERE PassengerID = 285149
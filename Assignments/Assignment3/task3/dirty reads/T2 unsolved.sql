--- dirty read 
--- transaction 2 unsolved


-- the dirty read happens because shared locks are not acquired when reading data under read uncommitted 
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
SELECT * FROM Passenger
WAITFOR DELAY '00:00:10'
SELECT * FROM Passenger 

COMMIT TRANSACTION


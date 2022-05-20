--- dirty read 
--- transaction 2 solved

-- under read commited, a shared lock is acquired when reading data and it is released immediately after the select statement
-- in this case, the 2 selects yield the unchanges rows because the shared lock blocked the transaction until T1 commited and released its exclusive lock 
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
SELECT * FROM Passenger
WAITFOR DELAY '00:00:10'
SELECT * FROM Passenger 

COMMIT TRANSACTION

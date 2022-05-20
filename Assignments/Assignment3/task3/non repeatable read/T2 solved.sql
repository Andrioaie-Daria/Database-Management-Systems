--- non repeatable read
--- transaction 2 solved

--- under repeatable read, shared and exclusive locks are released only at the end of the transaction, 
-- so this allows T2 acquires the shared lock and runs the 2 selects one after the other and only after T2 finishes, T1 acquires the lock and makes the changes

SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN

SELECT * FROM Passenger
WAITFOR DELAY '00:00:08'
SELECT * FROM Passenger

COMMIT TRAN 
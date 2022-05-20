--- update conflict
--- transaction 2


--- this should issue an error, because T1 obtained a lock on this table, so T1 can't update it at the same time

SET TRAN ISOLATION LEVEL SNAPSHOT
BEGIN TRAN
WAITFOR DELAY '00:00:05'

UPDATE Passenger SET name = 'alalala' WHERE Status = 'adult'
COMMIT TRAN
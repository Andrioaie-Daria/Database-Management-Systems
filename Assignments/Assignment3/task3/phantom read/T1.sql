--- phantom read
--- transaction 1

BEGIN TRAN 
WAITFOR DELAY '00:00:04'
INSERT INTO Passenger VALUES ('teeest', '000000000011', 'test@gmail.com', '2000-01-01', 'child')

COMMIT TRAN
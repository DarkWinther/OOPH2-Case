if not exists(SELECT * FROM sys.databases WHERE name = 'PostNummer')
BEGIN
	print 'Creating database PostNummer'
	CREATE database PostNummer
END
else
BEGIN
	print 'Database PostNummer allready exists'
END
go

use PostNummer
go

drop table if exists PostNrBy
go

CREATE table PostNrBy(
	PostNr int,
	Byen nvarchar(40)
)
go

BULK INSERT PostNrBy
FROM 'C:\Users\Tec\Desktop\Kap 7(Practice 1)\PostNr.txt'
WITH (
	datafiletype = 'widechar',
	fieldterminator = ',',
	rowterminator = '\n',
	maxerrors = 50,
	tablock,
	errorfile = 'C:\Users\Tec\Desktop\Kap 7(Practice 1)\error.txt'
)
go

SELECT * FROM PostNrBy
go

-- Do the following in PowerShell:
-- bcp PostNummer.dbo.PostNrBy out .\PostNrBCP.txt -w -S . -T -t ',' -r \n

drop table if exists PostNrByBCP
go

SELECT *
INTO PostNrByBCP
FROM PostNrBy
go

delete from PostNrByBCP
go

-- Do the following in PowerShell:
-- bcp PostNummer.dbo.PostNrByBCP in .\PostNrBCP.txt -w -S . -T -t ',' -r \n

--SELECT * FROM PostNrByBCP
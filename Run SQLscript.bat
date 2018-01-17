ECHO OFF
sqlcmd -S localhost -E -i "SQL Opret DB og Tabeller.sql"
ECHO Database og tabeller færdig.
bcp OOPH2.dbo.PostNr in ./PostNr.csv -w -S . -T -t , -r \n
ECHO PostNr udfyldt fra csv-fil.
PAUSE
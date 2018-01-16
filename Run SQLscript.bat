ECHO OFF
sqlcmd -S localhost -E -i "SQL Opret DB og Tabeller.sql"
ECHO Database og tabeller færdig.
bcp OOPH2.dbo.PostNr in ./PostNr.csv -c -S . -T -t , -r \n
ECHO PostNr ulfyldt fra csv-fil.
PAUSE
USE master;
GO

IF DB_ID('OOPH2') IS NOT NULL
	PRINT 'Datasen er allerede oprettet';
ELSE BEGIN
	CREATE DATABASE [OOPH2];
	PRINT 'Opretter databasen OOPH2';
END
GO

USE OOPH2;
GO

DROP TABLE IF EXISTS Transaktion;
DROP TABLE IF EXISTS Konto;
DROP TABLE IF EXISTS KontoType;
DROP TABLE IF EXISTS Kunde;
DROP TABLE IF EXISTS PostNr;
GO

CREATE TABLE PostNr (
	PostNr INT PRIMARY KEY,
	ByNavn NVARCHAR(100),
);
GO

CREATE TABLE Kunde (
	KundeNr INT PRIMARY KEY IDENTITY(1,1),
	Fornavn NVARCHAR(50) NOT NULL,
	Efternavn NVARCHAR(50) NOT NULL,
	PostNr INT NOT NULL FOREIGN KEY REFERENCES PostNr (PostNr),
	Adresse NVARCHAR(100) NOT NULL,
	TlfNr INT,
	OprettelsesDato SMALLDATETIME NOT NULL
);
GO

CREATE TABLE KontoType (
	TypeNr SMALLINT PRIMARY KEY IDENTITY(1,1),
	TypeNavn NVARCHAR(60),
	Rentesats FLOAT CHECK (Rentesats >= -5 AND Rentesats <= 5)
);
GO

CREATE TABLE Konto (
	KontoNr INT PRIMARY KEY IDENTITY(1,1),
	KontoType SMALLINT FOREIGN KEY REFERENCES KontoType (TypeNr) NOT NULL,
	KundeNr INT FOREIGN KEY REFERENCES Kunde (KundeNr) NOT NULL,
	Saldo MONEY NOT NULL,
	OprettelsesDato SMALLDATETIME NOT NULL
);
GO

CREATE TABLE Transaktion (
	TransaktionsNr BIGINT PRIMARY KEY IDENTITY(1,1),
	Bel�b MONEY NOT NULL,
	Dato SMALLDATETIME NOT NULL,
	KundeNr INT FOREIGN KEY REFERENCES Kunde (KundeNr)
);
GO
USE OOPH2
go

INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Kevin', 'Winther', 2820, 'Ermelundsvej 42', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('William', 'Johansen', 800, 'Memesvej 72', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Noah', 'Jensen', 900, 'Dankvej 38', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Lucas', 'Kirstensen', 917, 'Ugandavej 80', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Emil', 'Lolholm', 960, 'MLGvej 90', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Oliver', 'Hansen', 999, 'Pessantvej 120', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Oscar', 'Friss', 4592, 'Hurrdurrvej 102', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Victor', 'Salling', 4640, 'Min mor 32', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Malthe', 'Vinter', 4652, 'Julemandvej 23', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Alfred', 'Østergaard', 4571, 'Viharikkebørnvej 55', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Carl', 'Klien', 4673, 'Hellovej 66', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Frederik', 'Husain', 4683, 'Hvorforbliverjegvedvej 77', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Elias', 'Jonsen', 4682, 'Minvej 88', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Magnus', 'Carlsen', 5882, 'Canyoushowmedawehvej 99', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Valdemar', 'Pedersen', 5874, 'Amidoneyetvej 11', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Villads', 'Simonsen', 5960, 'Blyatvej 22', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Alexander', 'Sen', 5792, 'Cykavej 33', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Christian', 'Blyat', 5800, 'Davej 44', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('August', 'McMuffin', 5970, 'Nejvej 51', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Johan', 'McD', 2820, 'Ermelundsvej 1', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Felix', 'Von And', 2820, 'Ermelundsvej 2', CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES('Hans', 'Von Prank', 2820, 'Prankvej 69', CAST('2012-06-05 12:00' AS smalldatetime))
go 1000

INSERT INTO KontoType(TypeNavn, Rentesats) VALUES('Ingen rente Whoops vi mener du betale vi bruger', -0.5)
INSERT INTO KontoType(TypeNavn, Rentesats) VALUES('Lidt rente', 0.3)
go

INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 1, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 1, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 5, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 8, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 3, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 7, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 10, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 5, 5000, CAST('2012-06-05 12:00' AS smalldatetime))
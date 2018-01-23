USE OOPH2
go

INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Kevin', N'Winther', 2820, N'Ermelundsvej 42', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'William', N'Johansen', 800, N'Memesvej 72', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Noah', N'Jensen', 900, N'Dankvej 38', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Lucas', N'Kirstensen', 917, N'Ugandavej 80', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Emil', N'Lolholm', 960, N'MLGvej 90', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Oliver', N'Hansen', 999, N'Pessantvej 120', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Oscar', N'Friss', 4592, N'Hurrdurrvej 102', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Victor', N'Salling', 4640, N'Min mor 32', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Malthe', N'Vinter', 4652, N'Julemandvej 23', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Alfred', N'Østergaard', 4571, N'Viharikkebørnvej 55', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Carl', N'Klien', 4673, N'Hellovej 66', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Frederik', N'Husain', 4683, N'Hvorforbliverjegvedvej 77', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Elias', N'Jonsen', 4682, N'Minvej 88', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Magnus', N'Carlsen', 5882, N'Canyoushowmedawehvej 99', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Valdemar', N'Pedersen', 5874, N'Amidoneyetvej 11', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Villads', N'Simonsen', 5960, N'Blyatvej 22', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Alexander', N'Sen', 5792, N'Cykavej 33', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Christian', N'Blyat', 5800, N'Davej 44', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'August', N'McMuffin', 5970, N'Nejvej 51', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Johan', N'McD', 2820, N'Ermelundsvej 1', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Felix', N'Von And', 2820, N'Ermelundsvej 2', CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Kunde(Fornavn, Efternavn, PostNr, Adresse, OprettelsesDato) VALUES(N'Hans', N'Von Prank', 2820, N'Prankvej 69', CAST('2012-06-05 12:00' AS datetime))
go

INSERT INTO KontoType(TypeNavn, Rentesats) VALUES('Lønkonto', 0.2)
INSERT INTO KontoType(TypeNavn, Rentesats) VALUES('Opsparingskonto', 0.3)
go

INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 1, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 1, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 5, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 8, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 3, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 7, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(2, 10, 5000, CAST('2012-06-05 12:00' AS datetime))
INSERT INTO Konto(KontoType, KundeNr, Saldo, OprettelsesDato) VALUES(1, 5, 5000, CAST('2012-06-05 12:00' AS datetime))
go

INSERT INTO Transaktion (Beløb, Dato, KontoNr) VALUES (200, CAST('2018/01/23 12:40:00' AS DATETIME), 1);
INSERT INTO Transaktion (Beløb, Dato, KontoNr) VALUES (1800, CAST('2018/01/23 12:40:00' AS DATETIME), 1);
INSERT INTO Transaktion (Beløb, Dato, KontoNr) VALUES (500, CAST('2018/01/23 12:40:00' AS DATETIME), 3);
INSERT INTO Transaktion (Beløb, Dato, KontoNr) VALUES (400, CAST('2018/01/23 12:40:00' AS DATETIME), 4);
INSERT INTO Transaktion (Beløb, Dato, KontoNr) VALUES (800, CAST('2018/01/23 12:40:00' AS DATETIME), 5);
SELECT Person._PersonID, Person._ForNavn, Person._MellemNavn, Person._EfterNavn, Person._PersonType, ZIP._ZipID, ZIP._PostNummer, ZIP._Land, ZIP._By, Telefon._TelefonID, Telefon._TelefonType, Telefon._Nummer, Telefon._TeleSelskab, 
                  ZIPListe._ZIPListeID, ZIPListe._PostNummer AS Expr1, ZIPListe._Land AS Expr2, ZIPListe._By AS Expr3, AA.AlternativAdresse, AA._AAID, Noter._NoteID, Noter._Noter, Email._EmailID, Email._EmailAdresse, Adresse._AdresseID, 
                  Adresse._GadeNavn, Adresse._GadeNummer, Adresse._By AS Expr4, Adresse._AdresseType
FROM     Adresse INNER JOIN
                  Person ON Adresse._AdresseID = Person._AdresseID INNER JOIN
                  Email ON Person._PersonID = Email._PersonID INNER JOIN
                  Noter ON Person._PersonID = Noter._PersonID INNER JOIN
                  Telefon ON Person._PersonID = Telefon._PersonID INNER JOIN
                  ZIP ON Adresse._ZipID = ZIP._ZipID INNER JOIN
                  ZIPListe ON ZIP._ZIPListeID = ZIPListe._ZIPListeID INNER JOIN
                  AA ON Adresse._AdresseID = AA._AdresseID AND Person._PersonID = AA._PersonID

SELECT * FROM Person
GO
SELECT * FROM Telefon;
SELECT * FROM Adresse;
SELECT * FROM Email;
SELECT * FROM Noter;
SELECT * FROM AA;

INSERT INTO [dbo].[Person] ([_ForNavn],[_MellemNavn], [_EfterNavn], [_AdresseID], [_PersonType]) VALUES (N'Nina', N'Thanh Truc', N'Nguyen', 1, N'Vietnameser')
INSERT INTO [dbo].[Telefon]([_TeleSelskab], [_Nummer], [_TelefonType], [_PersonID]) VALUES (N'OiSTER', 28195388, N'Privat', 2)

DELETE FROM Person WHERE _PersonID = 10039;


--UPDATE Person
--SET _ForNavn = 'Frej', _MellemNavn = 'Scheurlein', _EfterNavn = 'Thorsen'
--WHERE _PersonID = 1;

--UPDATE Telefon
--SET _TeleSelskab = 'YouSee', _Nummer = 26851586, _TelefonType = 'Arbejde'
--WHERE _TelefonID = 1;
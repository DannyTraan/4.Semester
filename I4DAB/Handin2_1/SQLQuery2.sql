--
-- Create Table    : 'ZIPListe'   
-- _ZIPListeID     :  
-- _PostNummer     :  
-- _Land           :  
-- _By             :  
--
CREATE TABLE ZIPListe (
    _ZIPListeID    BIGINT IDENTITY(1,1) NOT NULL,
    _PostNummer    INT NOT NULL,
    _Land          NVARCHAR(50) NOT NULL,
    _By            NVARCHAR(50) NOT NULL,
CONSTRAINT pk_ZIPListe PRIMARY KEY CLUSTERED (_ZIPListeID))
GO

--
-- Create Table    : 'ZIP'   
-- _ZipID          :  
-- _PostNummer     :  
-- _Land           :  
-- _By             :  
-- _ZIPListeID     :  (references ZIPListe._ZIPListeID)
--
CREATE TABLE ZIP (
    _ZipID         BIGINT IDENTITY(1,1) NOT NULL,
    _PostNummer    INT NOT NULL,
    _Land          NVARCHAR(50) NOT NULL,
    _By            NVARCHAR(50) NOT NULL,
    _ZIPListeID    BIGINT NOT NULL,
CONSTRAINT pk_ZIP PRIMARY KEY CLUSTERED (_ZipID),
CONSTRAINT fk_ZIP FOREIGN KEY (_ZIPListeID)
    REFERENCES ZIPListe (_ZIPListeID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Adresse'   
-- _AdresseID      :  
-- _GadeNavn       :  
-- _GadeNummer     :  
-- _By             :  
-- _AdresseType    :  
-- _ZipID          :  (references ZIP._ZipID)
--
CREATE TABLE Adresse (
    _AdresseID     BIGINT IDENTITY(1,1) NOT NULL,
    _GadeNavn      NVARCHAR(50) NOT NULL,
    _GadeNummer    INT NOT NULL,
    _By            NVARCHAR(50) NOT NULL,
    _AdresseType   NVARCHAR(50) NOT NULL,
    _ZipID         BIGINT NOT NULL,
CONSTRAINT pk_Adresse PRIMARY KEY CLUSTERED (_AdresseID),
CONSTRAINT fk_Adresse FOREIGN KEY (_ZipID)
    REFERENCES ZIP (_ZipID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Person'   
-- _PersonID       :  
-- _ForNavn        :  
-- _MellemNavn     :  
-- _EfterNavn      :  
-- _AdresseID      :  (references Adresse._AdresseID)
-- _PersonType     :  
--
CREATE TABLE Person (
    _PersonID      BIGINT IDENTITY(1,1) NOT NULL,
    _ForNavn       NVARCHAR(50) NOT NULL,
    _MellemNavn    NVARCHAR(50) NOT NULL,
    _EfterNavn     NVARCHAR(50) NOT NULL,
    _AdresseID     BIGINT NULL,
    _PersonType    NVARCHAR(50) NOT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (_PersonID),
CONSTRAINT fk_Person FOREIGN KEY (_AdresseID)
    REFERENCES Adresse (_AdresseID)
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Telefon'   
-- _TelefonID      :  
-- _TelefonType    :  
-- _Nummer         :  
-- _TeleSelskab    :  
-- _PersonID       :  (references Person._PersonID)
--
CREATE TABLE Telefon (
    _TelefonID     BIGINT IDENTITY(1,1) NOT NULL,
    _TelefonType   NVARCHAR(50) NOT NULL,
    _Nummer        INT NOT NULL,
    _TeleSelskab   NVARCHAR(50) NOT NULL,
    _PersonID      BIGINT NOT NULL,
CONSTRAINT pk_Telefon PRIMARY KEY CLUSTERED (_TelefonID),
CONSTRAINT fk_Telefon FOREIGN KEY (_PersonID)
    REFERENCES Person (_PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Email'   
-- _EmailID        :  
-- _EmailAdresse   :  
-- _PersonID       :  (references Person._PersonID)
--
CREATE TABLE Email (
    _EmailID       BIGINT IDENTITY(1,1) NOT NULL,
    _EmailAdresse  NVARCHAR(50) NOT NULL,
    _PersonID      BIGINT NOT NULL,
CONSTRAINT pk_Email PRIMARY KEY CLUSTERED (_EmailID),
CONSTRAINT fk_Email FOREIGN KEY (_PersonID)
    REFERENCES Person (_PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'AA'   
-- _PersonID       :  (references Person._PersonID)
-- _AdresseID      :  (references Adresse._AdresseID)
-- AlternativAdresse :  
-- _AAID           :  
--
CREATE TABLE AA (
    _PersonID      BIGINT NOT NULL,
    _AdresseID     BIGINT NOT NULL,
    AlternativAdresse NVARCHAR(50) NOT NULL,
    _AAID          BIGINT IDENTITY(1,1) NOT NULL,
CONSTRAINT pk_AA PRIMARY KEY CLUSTERED (_PersonID,_AdresseID,_AAID),
CONSTRAINT fk_AA FOREIGN KEY (_PersonID)
    REFERENCES Person (_PersonID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
CONSTRAINT fk_AA2 FOREIGN KEY (_AdresseID)
    REFERENCES Adresse (_AdresseID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
GO

--
-- Create Table    : 'Noter'   
-- _NoteID         :  
-- _Noter          :  
-- _PersonID       :  (references Person._PersonID)
--
CREATE TABLE Noter (
    _NoteID        BIGINT IDENTITY(1,1) NOT NULL,
    _Noter         NVARCHAR(50) NOT NULL,
    _PersonID      BIGINT NOT NULL,
CONSTRAINT pk_Noter PRIMARY KEY CLUSTERED (_NoteID),
CONSTRAINT fk_Noter FOREIGN KEY (_PersonID)
    REFERENCES Person (_PersonID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO
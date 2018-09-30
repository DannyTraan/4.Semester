CREATE TABLE ZIPListe (
    ZIPListeID     BIGINT IDENTITY(1,1) NOT NULL,
    PostNummer     INT NOT NULL,
    Land           NVARCHAR(50) NOT NULL,
    ByNavn         NVARCHAR(50) NOT NULL,
CONSTRAINT pk_ZIPListe PRIMARY KEY CLUSTERED (ZIPListeID))
GO

--
-- Create Table    : 'ZIP'   
-- ZIPID           :  
-- PostNummer      :  
-- Land            :  
-- ByNavn          :  
-- ZIPListeID      :  (references ZIPListe.ZIPListeID)
--
CREATE TABLE ZIP (
    ZIPID          BIGINT IDENTITY(1,1) NOT NULL,
    PostNummer     INT NOT NULL,
    Land           NVARCHAR(50) NOT NULL,
    ByNavn         NVARCHAR(50) NOT NULL,
    ZIPListeID     BIGINT NOT NULL,
CONSTRAINT pk_ZIP PRIMARY KEY CLUSTERED (ZIPID),
CONSTRAINT fk_ZIP FOREIGN KEY (ZIPListeID)
    REFERENCES ZIPListe (ZIPListeID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Adresse'   
-- AdresseID       :  
-- GadeNavn        :  
-- HusNummer       :  
-- ByNavn          :  
-- AdresseType     :  
-- ZIPID           :  (references ZIP.ZIPID)
--
CREATE TABLE Adresse (
    AdresseID      BIGINT IDENTITY(1,1) NOT NULL,
    GadeNavn       NVARCHAR(50) NOT NULL,
    HusNummer      INT NOT NULL,
    ByNavn         NVARCHAR(50) NOT NULL,
    AdresseType    NVARCHAR(50) NOT NULL,
    ZIPID          BIGINT NOT NULL,
CONSTRAINT pk_Adresse PRIMARY KEY CLUSTERED (AdresseID),
CONSTRAINT fk_Adresse FOREIGN KEY (ZIPID)
    REFERENCES ZIP (ZIPID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Person'   
-- PersonID        :  
-- Noter           :  
-- Telefon         :  
-- Email           :  
-- Adresse         :  
-- ForNavn         :  
-- MellemNavn      :  
-- EfterNavn       :  
-- AdresseID       :  (references Adresse.AdresseID)
--
CREATE TABLE Person (
    PersonID       BIGINT IDENTITY(1,1) NOT NULL,
    Noter          NVARCHAR(50) NOT NULL,
    Telefon        NVARCHAR(50) NOT NULL,
    Email          NVARCHAR(50) NOT NULL,
    Adresse        NVARCHAR(50) NOT NULL,
    ForNavn        NVARCHAR(50) NOT NULL,
    MellemNavn     NVARCHAR(50) NOT NULL,
    EfterNavn      NVARCHAR(50) NOT NULL,
    AdresseID      BIGINT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (PersonID),
CONSTRAINT fk_Person FOREIGN KEY (AdresseID)
    REFERENCES Adresse (AdresseID)
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Telefon'   
-- TelefonID       :  
-- TelefonType     :  
-- TelefonNummer   :  
-- TeleSelskab     :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Telefon (
    TelefonID      BIGINT IDENTITY(1,1) NOT NULL,
    TelefonType    NVARCHAR(50) NOT NULL,
    TelefonNummer  INT NOT NULL,
    TeleSelskab    NVARCHAR(50) NOT NULL,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_Telefon PRIMARY KEY CLUSTERED (TelefonID),
CONSTRAINT fk_Telefon FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'Email'   
-- EmailID         :  
-- EmailAdresse    :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Email (
    EmailID        BIGINT IDENTITY(1,1) NOT NULL,
    EmailAdresse   NVARCHAR(50) NOT NULL,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_Email PRIMARY KEY CLUSTERED (EmailID),
CONSTRAINT fk_Email FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'AA'   
-- PersonID        :  (references Person.PersonID)
-- AdresseID       :  (references Adresse.AdresseID)
-- AlternativAdresse :  
--
CREATE TABLE AA (
    PersonID       BIGINT NOT NULL,
    AdresseID      BIGINT NOT NULL,
    AlternativAdresse NVARCHAR(50) NOT NULL,
CONSTRAINT pk_AA PRIMARY KEY CLUSTERED (PersonID,AdresseID,AlternativAdresse),
CONSTRAINT fk_AA FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_AA2 FOREIGN KEY (AdresseID)
    REFERENCES Adresse (AdresseID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO
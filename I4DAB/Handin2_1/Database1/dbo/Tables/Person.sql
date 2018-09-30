CREATE TABLE [dbo].[Person] (
    [PersonID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Noter]      NVARCHAR (50) NOT NULL,
    [Telefon]    NVARCHAR (50) NOT NULL,
    [Email]      NVARCHAR (50) NOT NULL,
    [Adresse]    NVARCHAR (50) NOT NULL,
    [ForNavn]    NVARCHAR (50) NOT NULL,
    [MellemNavn] NVARCHAR (50) NOT NULL,
    [EfterNavn]  NVARCHAR (50) NOT NULL,
    [AdresseID]  BIGINT        NULL,
    CONSTRAINT [pk_Person] PRIMARY KEY CLUSTERED ([PersonID] ASC),
    CONSTRAINT [fk_Person] FOREIGN KEY ([AdresseID]) REFERENCES [dbo].[Adresse] ([AdresseID]) ON UPDATE CASCADE
);


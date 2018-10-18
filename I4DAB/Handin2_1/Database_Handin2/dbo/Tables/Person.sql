CREATE TABLE [dbo].[Person] (
    [_PersonID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [_ForNavn]    NVARCHAR (50) NOT NULL,
    [_MellemNavn] NVARCHAR (50) NOT NULL,
    [_EfterNavn]  NVARCHAR (50) NOT NULL,
    [_AdresseID]  BIGINT        NULL,
    [_PersonType] NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_Person] PRIMARY KEY CLUSTERED ([_PersonID] ASC),
    CONSTRAINT [fk_Person] FOREIGN KEY ([_AdresseID]) REFERENCES [dbo].[Adresse] ([_AdresseID]) ON UPDATE CASCADE
);


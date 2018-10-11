CREATE TABLE [dbo].[Person] (
    [_PersonID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [_ForNavn]    NVARCHAR (50) NOT NULL,
    [_MellemNavn] NVARCHAR (50) NOT NULL,
    [_EfterNavn]  NVARCHAR (50) NOT NULL,
    [_AdresseID]  BIGINT        NULL,
    [_PersonType] NVARCHAR (50) NOT NULL,
    [_TelefonID]  BIGINT        NULL,
    [_NoteID]     BIGINT        NULL,
    [_EmailID]    BIGINT        NULL,
    CONSTRAINT [pk_Person] PRIMARY KEY CLUSTERED ([_PersonID] ASC),
    CONSTRAINT [fk_Person] FOREIGN KEY ([_AdresseID]) REFERENCES [dbo].[Adresse] ([_AdresseID]) ON UPDATE CASCADE,
    CONSTRAINT [fk_Person2] FOREIGN KEY ([_NoteID]) REFERENCES [dbo].[Noter] ([_NoteID]) ON UPDATE CASCADE,
    CONSTRAINT [fk_Person3] FOREIGN KEY ([_TelefonID]) REFERENCES [dbo].[Telefon] ([_TelefonID]) ON UPDATE CASCADE,
    CONSTRAINT [fk_Person4] FOREIGN KEY ([_EmailID]) REFERENCES [dbo].[Email] ([_EmailID]) ON UPDATE CASCADE
);


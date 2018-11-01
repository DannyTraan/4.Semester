CREATE TABLE [dbo].[Adresse] (
    [_AdresseID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [_GadeNavn]    NVARCHAR (50) NOT NULL,
    [_GadeNummer]  INT           NOT NULL,
    [_By]          NVARCHAR (50) NOT NULL,
    [_AdresseType] NVARCHAR (50) NOT NULL,
    [_ZipID]       BIGINT        NOT NULL,
    CONSTRAINT [pk_Adresse] PRIMARY KEY CLUSTERED ([_AdresseID] ASC),
    CONSTRAINT [fk_Adresse] FOREIGN KEY ([_ZipID]) REFERENCES [dbo].[ZIP] ([_ZipID]) ON UPDATE CASCADE
);


CREATE TABLE [dbo].[Adresse] (
    [AdresseID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [GadeNavn]    NVARCHAR (50) NOT NULL,
    [HusNummer]   INT           NOT NULL,
    [ByNavn]      NVARCHAR (50) NOT NULL,
    [AdresseType] NVARCHAR (50) NOT NULL,
    [ZIPID]       BIGINT        NOT NULL,
    CONSTRAINT [pk_Adresse] PRIMARY KEY CLUSTERED ([AdresseID] ASC),
    CONSTRAINT [fk_Adresse] FOREIGN KEY ([ZIPID]) REFERENCES [dbo].[ZIP] ([ZIPID]) ON UPDATE CASCADE
);


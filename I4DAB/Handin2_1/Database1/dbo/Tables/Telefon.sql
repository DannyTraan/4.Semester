CREATE TABLE [dbo].[Telefon] (
    [TelefonID]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [TelefonType]   NVARCHAR (50) NOT NULL,
    [TelefonNummer] INT           NOT NULL,
    [TeleSelskab]   NVARCHAR (50) NOT NULL,
    [PersonID]      BIGINT        NOT NULL,
    CONSTRAINT [pk_Telefon] PRIMARY KEY CLUSTERED ([TelefonID] ASC),
    CONSTRAINT [fk_Telefon] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]) ON UPDATE CASCADE
);


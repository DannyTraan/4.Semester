CREATE TABLE [dbo].[Telefon] (
    [_TelefonID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [_TelefonType] NVARCHAR (50) NOT NULL,
    [_Nummer]      INT           NOT NULL,
    [_TeleSelskab] NVARCHAR (50) NOT NULL,
    [_PersonID]    BIGINT        NOT NULL,
    CONSTRAINT [pk_Telefon] PRIMARY KEY CLUSTERED ([_TelefonID] ASC),
    CONSTRAINT [fk_Telefon] FOREIGN KEY ([_PersonID]) REFERENCES [dbo].[Person] ([_PersonID]) ON DELETE CASCADE ON UPDATE CASCADE
);


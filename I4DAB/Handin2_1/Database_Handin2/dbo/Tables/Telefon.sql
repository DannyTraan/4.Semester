CREATE TABLE [dbo].[Telefon] (
    [_TelefonID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [_TelefonType] NVARCHAR (50) NOT NULL,
    [_Nummer]      INT           NOT NULL,
    [_TeleSelskab] NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_Telefon] PRIMARY KEY CLUSTERED ([_TelefonID] ASC)
);


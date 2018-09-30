﻿CREATE TABLE [dbo].[ZIP] (
    [ZIPID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [PostNummer] INT           NOT NULL,
    [Land]       NVARCHAR (50) NOT NULL,
    [ByNavn]     NVARCHAR (50) NOT NULL,
    [ZIPListeID] BIGINT        NOT NULL,
    CONSTRAINT [pk_ZIP] PRIMARY KEY CLUSTERED ([ZIPID] ASC),
    CONSTRAINT [fk_ZIP] FOREIGN KEY ([ZIPListeID]) REFERENCES [dbo].[ZIPListe] ([ZIPListeID]) ON UPDATE CASCADE
);

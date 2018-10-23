CREATE TABLE [dbo].[ZIP] (
    [_ZipID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [_PostNummer] INT           NOT NULL,
    [_Land]       NVARCHAR (50) NOT NULL,
    [_By]         NVARCHAR (50) NOT NULL,
    [_ZIPListeID] BIGINT        NOT NULL,
    CONSTRAINT [pk_ZIP] PRIMARY KEY CLUSTERED ([_ZipID] ASC),
    CONSTRAINT [fk_ZIP] FOREIGN KEY ([_ZIPListeID]) REFERENCES [dbo].[ZIPListe] ([_ZIPListeID]) ON UPDATE CASCADE
);


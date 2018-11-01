CREATE TABLE [dbo].[ZIPListe] (
    [_ZIPListeID] BIGINT        IDENTITY (1, 1) NOT NULL,
    [_PostNummer] INT           NOT NULL,
    [_Land]       NVARCHAR (50) NOT NULL,
    [_By]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_ZIPListe] PRIMARY KEY CLUSTERED ([_ZIPListeID] ASC)
);


CREATE TABLE [dbo].[ZIPListe] (
    [ZIPListeID] BIGINT        IDENTITY (1, 1) NOT NULL,
    [PostNummer] INT           NOT NULL,
    [Land]       NVARCHAR (50) NOT NULL,
    [ByNavn]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_ZIPListe] PRIMARY KEY CLUSTERED ([ZIPListeID] ASC)
);


CREATE TABLE [dbo].[AA] (
    [_PersonID]         BIGINT        NOT NULL,
    [_AdresseID]        BIGINT        NOT NULL,
    [AlternativAdresse] NVARCHAR (50) NOT NULL,
    [_AAID]             BIGINT        IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [pk_AA] PRIMARY KEY CLUSTERED ([_PersonID] ASC, [_AdresseID] ASC, [_AAID] ASC),
    CONSTRAINT [fk_AA] FOREIGN KEY ([_PersonID]) REFERENCES [dbo].[Person] ([_PersonID]),
    CONSTRAINT [fk_AA2] FOREIGN KEY ([_AdresseID]) REFERENCES [dbo].[Adresse] ([_AdresseID])
);


CREATE TABLE [dbo].[Noter] (
    [_NoteID]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [_Noter]    NVARCHAR (50) NOT NULL,
    [_PersonID] BIGINT        NOT NULL,
    CONSTRAINT [pk_Noter] PRIMARY KEY CLUSTERED ([_NoteID] ASC),
    CONSTRAINT [fk_Noter] FOREIGN KEY ([_PersonID]) REFERENCES [dbo].[Person] ([_PersonID]) ON UPDATE CASCADE
);


CREATE TABLE [dbo].[Email] (
    [_EmailID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [_EmailAdresse] NVARCHAR (50) NOT NULL,
    [_PersonID]     BIGINT        NOT NULL,
    CONSTRAINT [pk_Email] PRIMARY KEY CLUSTERED ([_EmailID] ASC),
    CONSTRAINT [fk_Email] FOREIGN KEY ([_PersonID]) REFERENCES [dbo].[Person] ([_PersonID]) ON DELETE CASCADE ON UPDATE CASCADE
);


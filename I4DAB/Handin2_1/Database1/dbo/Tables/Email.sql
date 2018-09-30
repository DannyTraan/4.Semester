CREATE TABLE [dbo].[Email] (
    [EmailID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [EmailAdresse] NVARCHAR (50) NOT NULL,
    [PersonID]     BIGINT        NOT NULL,
    CONSTRAINT [pk_Email] PRIMARY KEY CLUSTERED ([EmailID] ASC),
    CONSTRAINT [fk_Email] FOREIGN KEY ([PersonID]) REFERENCES [dbo].[Person] ([PersonID]) ON UPDATE CASCADE
);


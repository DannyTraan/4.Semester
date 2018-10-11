CREATE TABLE [dbo].[Email] (
    [_EmailID]      BIGINT        IDENTITY (1, 1) NOT NULL,
    [_EmailAdresse] NVARCHAR (50) NOT NULL,
    CONSTRAINT [pk_Email] PRIMARY KEY CLUSTERED ([_EmailID] ASC)
);


IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TimeEntries] (
    [Id] uniqueidentifier NOT NULL,
    [ProjectName] nvarchar(max) NOT NULL,
    [StartUtc] datetime2 NOT NULL,
    [EndUtc] datetime2 NULL,
    [CreatedAtOtc] datetime2 NOT NULL,
    [UpdatedUtc] datetime2 NULL,
    CONSTRAINT [PK_TimeEntries] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241029230051_InitialCreate', N'8.0.10');
GO

COMMIT;
GO


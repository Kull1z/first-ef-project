IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [ReleaseDate] datetime2 NOT NULL,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Actors] (
    [Id] int NOT NULL IDENTITY,
    [Birthday] datetime2 NOT NULL,
    [MovieId] int NULL,
    [Name] nvarchar(max) NULL,
    [Nationality] nvarchar(max) NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Actors_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Quotes] (
    [Id] int NOT NULL IDENTITY,
    [ActorId] int NOT NULL,
    [Text] nvarchar(max) NULL,
    CONSTRAINT [PK_Quotes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Quotes_Actors_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Actors_MovieId] ON [Actors] ([MovieId]);

GO

CREATE INDEX [IX_Quotes_ActorId] ON [Quotes] ([ActorId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180306114557_init', N'2.0.1-rtm-125');

GO

ALTER TABLE [Actors] DROP CONSTRAINT [FK_Actors_Movies_MovieId];

GO

DROP INDEX [IX_Actors_MovieId] ON [Actors];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Actors') AND [c].[name] = N'MovieId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Actors] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Actors] DROP COLUMN [MovieId];

GO

CREATE TABLE [MovieActor] (
    [ActorId] int NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_MovieActor] PRIMARY KEY ([ActorId], [MovieId]),
    CONSTRAINT [FK_MovieActor_Actors_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [Actors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieActor_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_MovieActor_MovieId] ON [MovieActor] ([MovieId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180308085006_MovieActor', N'2.0.1-rtm-125');

GO

CREATE TABLE [TomatoRating] (
    [Id] int NOT NULL IDENTITY,
    [AudienceScore] int NOT NULL,
    [MovieId] int NOT NULL,
    [TomatoMeter] int NOT NULL,
    CONSTRAINT [PK_TomatoRating] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TomatoRating_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movies] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_TomatoRating_MovieId] ON [TomatoRating] ([MovieId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180308092824_TomatoRating', N'2.0.1-rtm-125');

GO


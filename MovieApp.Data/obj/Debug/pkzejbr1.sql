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


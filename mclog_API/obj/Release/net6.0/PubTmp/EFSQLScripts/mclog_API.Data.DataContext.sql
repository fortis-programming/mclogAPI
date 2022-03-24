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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(200) NOT NULL,
        [LastName] nvarchar(200) NOT NULL,
        [MiddleName] nvarchar(200) NOT NULL,
        [BirthDate] nvarchar(200) NOT NULL,
        [Province] nvarchar(200) NOT NULL,
        [Region] nvarchar(200) NOT NULL,
        [City] nvarchar(200) NOT NULL,
        [Baranggay] nvarchar(200) NOT NULL,
        [Gender] nvarchar(200) NOT NULL,
        [Password] nvarchar(200) NOT NULL,
        [PhoneNumber] nvarchar(200) NOT NULL,
        [Age] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [UserHealthStatus] (
        [Id] int NOT NULL IDENTITY,
        [DateTime] datetime NOT NULL,
        [UserId] int NOT NULL,
        [Temperature] float NULL,
        CONSTRAINT [PK_UserHealthStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [ActivityLogs] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ActivityDate] datetime NOT NULL,
        [Status] nvarchar(255) NOT NULL,
        [HealthStatusId] int NOT NULL,
        [BuildingId] int NOT NULL,
        CONSTRAINT [PK_ActivityLogs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [Symptoms] (
        [Id] int NOT NULL IDENTITY,
        [SymptomName] nvarchar(255) NOT NULL,
        [UserHealthStatusId] int NOT NULL,
        CONSTRAINT [PK_Symptoms] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [Buildings] (
        [Id] int NOT NULL IDENTITY,
        [BuildingName] nvarchar(255) NOT NULL,
        [Address] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_Buildings] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220210050457_InitialCreate', N'6.0.2');
END;
GO

COMMIT;
GO


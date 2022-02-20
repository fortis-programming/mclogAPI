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
        [BirthDate] int NOT NULL,
        [Province] nvarchar(200) NOT NULL,
        [Region] nvarchar(200) NOT NULL,
        [City] nvarchar(200) NOT NULL,
        [Baranggay] nvarchar(200) NOT NULL,
        [Gender] nvarchar(200) NOT NULL,
        [Password] nvarchar(200) NOT NULL,
        [PhoneNumber] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [UserHealthStatus] (
        [Id] int NOT NULL IDENTITY,
        [SymptomOne] nvarchar(200) NOT NULL,
        [SymptomTwo] nvarchar(200) NOT NULL,
        [SymptomThree] nvarchar(200) NOT NULL,
        [SymptomFour] nvarchar(200) NOT NULL,
        [Date] datetime NOT NULL,
        [UserId] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_UserHealthStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220210050457_InitialCreate')
BEGIN
    CREATE TABLE [ActivityLogs] (
        [Id] int NOT NULL IDENTITY,
        [TimeIn] datetime NOT NULL,
        [TImeOut] datetime NOT NULL,
        [BuildingName] nvarchar(255) NOT NULL,
        [Status] nvarchar(255) NOT NULL,
        [UserId] nvarchar(255) NOT NULL,
        CONSTRAINT [PK_ActivityLogs] PRIMARY KEY ([Id])
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


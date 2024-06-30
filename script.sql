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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630020100_Initial'
)
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] varchar(50) NOT NULL,
        [LastName] varchar(50) NOT NULL,
        [Gender] varchar(10) NOT NULL,
        [Phone] varchar(11) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630020100_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240630020100_Initial', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630170536_Sec'
)
BEGIN
    CREATE TABLE [ProductCategories] (
        [Id] int NOT NULL IDENTITY,
        [CategoryName] varchar(50) NOT NULL,
        [CategoryDescription] varchar(150) NOT NULL,
        CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630170536_Sec'
)
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Discount] decimal(18,2) NOT NULL,
        [ProductImage] nvarchar(max) NOT NULL,
        [SKU] int NOT NULL,
        [ProductCategoryId] int NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_ProductCategories_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategories] ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630170536_Sec'
)
BEGIN
    CREATE INDEX [IX_Products_ProductCategoryId] ON [Products] ([ProductCategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630170536_Sec'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240630170536_Sec', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    ALTER TABLE [Products] DROP CONSTRAINT [FK_Products_ProductCategories_ProductCategoryId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    DROP INDEX [IX_Products_ProductCategoryId] ON [Products];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ProductCategoryId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Products] DROP COLUMN [ProductCategoryId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    ALTER TABLE [Products] ADD [CategoryId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE TABLE [CategoryVariations] (
        [Id] int NOT NULL IDENTITY,
        [CategoryId] int NOT NULL,
        [VariationName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_CategoryVariations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE TABLE [Regions] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Regions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE TABLE [Shippers] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [EmailId] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [ContactPerson] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Shippers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE TABLE [VariationValues] (
        [Id] int NOT NULL IDENTITY,
        [CategoryId] int NOT NULL,
        [Value] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_VariationValues] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_VariationValues_CategoryVariations_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [CategoryVariations] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE TABLE [ShipperRegions] (
        [RegionId] int NOT NULL,
        [ShipperId] int NOT NULL,
        CONSTRAINT [PK_ShipperRegions] PRIMARY KEY ([RegionId], [ShipperId]),
        CONSTRAINT [FK_ShipperRegions_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ShipperRegions_Shippers_ShipperId] FOREIGN KEY ([ShipperId]) REFERENCES [Shippers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE TABLE [ProductVariationValues] (
        [ProductId] int NOT NULL,
        [VariationValueId] int NOT NULL,
        CONSTRAINT [PK_ProductVariationValues] PRIMARY KEY ([ProductId], [VariationValueId]),
        CONSTRAINT [FK_ProductVariationValues_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProductVariationValues_VariationValues_VariationValueId] FOREIGN KEY ([VariationValueId]) REFERENCES [VariationValues] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE INDEX [IX_ProductVariationValues_VariationValueId] ON [ProductVariationValues] ([VariationValueId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE INDEX [IX_ShipperRegions_ShipperId] ON [ShipperRegions] ([ShipperId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    CREATE INDEX [IX_VariationValues_CategoryId] ON [VariationValues] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_ProductCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategories] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630184303_Third'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240630184303_Third', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190246_Fourth'
)
BEGIN
    ALTER TABLE [ProductCategories] ADD [ParentCategoryId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190246_Fourth'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240630190246_Fourth', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    ALTER TABLE [ProductCategories] ADD [ProductCategoryId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    ALTER TABLE [CategoryVariations] ADD [ProductCategoryId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    CREATE INDEX [IX_ProductCategories_ProductCategoryId] ON [ProductCategories] ([ProductCategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    CREATE INDEX [IX_CategoryVariations_ProductCategoryId] ON [CategoryVariations] ([ProductCategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    ALTER TABLE [CategoryVariations] ADD CONSTRAINT [FK_CategoryVariations_ProductCategories_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategories] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    ALTER TABLE [ProductCategories] ADD CONSTRAINT [FK_ProductCategories_ProductCategories_ProductCategoryId] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategories] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630190822_Fifth'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240630190822_Fifth', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    ALTER TABLE [CategoryVariations] DROP CONSTRAINT [FK_CategoryVariations_ProductCategories_ProductCategoryId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    ALTER TABLE [ProductCategories] DROP CONSTRAINT [FK_ProductCategories_ProductCategories_ProductCategoryId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    DROP INDEX [IX_ProductCategories_ProductCategoryId] ON [ProductCategories];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    DROP INDEX [IX_CategoryVariations_ProductCategoryId] ON [CategoryVariations];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductCategories]') AND [c].[name] = N'ProductCategoryId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProductCategories] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProductCategories] DROP COLUMN [ProductCategoryId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CategoryVariations]') AND [c].[name] = N'ProductCategoryId');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [CategoryVariations] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [CategoryVariations] DROP COLUMN [ProductCategoryId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    CREATE INDEX [IX_ProductCategories_ParentCategoryId] ON [ProductCategories] ([ParentCategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    CREATE INDEX [IX_CategoryVariations_CategoryId] ON [CategoryVariations] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    ALTER TABLE [CategoryVariations] ADD CONSTRAINT [FK_CategoryVariations_ProductCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategories] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    ALTER TABLE [ProductCategories] ADD CONSTRAINT [FK_ProductCategories_ProductCategories_ParentCategoryId] FOREIGN KEY ([ParentCategoryId]) REFERENCES [ProductCategories] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240630192854_Six'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240630192854_Six', N'8.0.6');
END;
GO

COMMIT;
GO


BEGIN TRANSACTION;
GO

CREATE TABLE [Warehouses] (
    [Id] bigint NOT NULL,
    [Code] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [AuthorizedPerson] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [IsActive] bit NOT NULL,
    [RowVersion] rowversion NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CreatedUserId] bigint NOT NULL,
    [ModifiedDate] datetime2 NULL,
    [ModifiedUserId] bigint NULL,
    [IsDeleted] bit NOT NULL,
    [DeletedDate] datetime2 NULL,
    [DeletedUserId] bigint NULL,
    CONSTRAINT [PK_Warehouses] PRIMARY KEY ([Id])
);
GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036493+03:00'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036508+03:00'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036509+03:00'
WHERE [Id] = CAST(3 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036511+03:00'
WHERE [Id] = CAST(4 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036512+03:00'
WHERE [Id] = CAST(5 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036513+03:00'
WHERE [Id] = CAST(6 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036514+03:00'
WHERE [Id] = CAST(7 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036522+03:00'
WHERE [Id] = CAST(8 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036523+03:00'
WHERE [Id] = CAST(9 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036510+03:00'
WHERE [Id] = CAST(10 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036532+03:00'
WHERE [Id] = CAST(11 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036534+03:00'
WHERE [Id] = CAST(12 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036515+03:00'
WHERE [Id] = CAST(13 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036516+03:00'
WHERE [Id] = CAST(14 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036517+03:00'
WHERE [Id] = CAST(15 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036518+03:00'
WHERE [Id] = CAST(16 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036519+03:00'
WHERE [Id] = CAST(17 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036520+03:00'
WHERE [Id] = CAST(18 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036521+03:00'
WHERE [Id] = CAST(19 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036530+03:00'
WHERE [Id] = CAST(20 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036533+03:00'
WHERE [Id] = CAST(21 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036534+03:00'
WHERE [Id] = CAST(22 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036535+03:00'
WHERE [Id] = CAST(23 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036536+03:00'
WHERE [Id] = CAST(24 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036537+03:00'
WHERE [Id] = CAST(25 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036538+03:00'
WHERE [Id] = CAST(26 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036539+03:00'
WHERE [Id] = CAST(27 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036540+03:00'
WHERE [Id] = CAST(28 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036541+03:00'
WHERE [Id] = CAST(29 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036542+03:00'
WHERE [Id] = CAST(30 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036543+03:00'
WHERE [Id] = CAST(31 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036544+03:00'
WHERE [Id] = CAST(32 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:36:01.6036545+03:00'
WHERE [Id] = CAST(33 AS bigint);
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Warehouses_Code] ON [Warehouses] ([Code]);
GO

CREATE INDEX [IX_Warehouses_CreatedDate] ON [Warehouses] ([CreatedDate]);
GO

CREATE INDEX [IX_Warehouses_IsActive] ON [Warehouses] ([IsActive]);
GO

CREATE INDEX [IX_Warehouses_IsDeleted] ON [Warehouses] ([IsDeleted]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260818113602_AddWarehouseTable', N'8.0.30');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_Warehouses_Code] ON [Warehouses];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Warehouses]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Warehouses] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Warehouses] ALTER COLUMN [Name] nvarchar(150) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Warehouses]') AND [c].[name] = N'Description');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Warehouses] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Warehouses] ALTER COLUMN [Description] nvarchar(500) NOT NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Warehouses]') AND [c].[name] = N'Code');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Warehouses] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Warehouses] ALTER COLUMN [Code] nvarchar(50) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Warehouses]') AND [c].[name] = N'AuthorizedPerson');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Warehouses] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Warehouses] ALTER COLUMN [AuthorizedPerson] nvarchar(150) NOT NULL;
GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105359+03:00'
WHERE [Id] = CAST(1 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105373+03:00'
WHERE [Id] = CAST(2 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105375+03:00'
WHERE [Id] = CAST(3 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105377+03:00'
WHERE [Id] = CAST(4 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105378+03:00'
WHERE [Id] = CAST(5 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105379+03:00'
WHERE [Id] = CAST(6 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105380+03:00'
WHERE [Id] = CAST(7 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105388+03:00'
WHERE [Id] = CAST(8 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105389+03:00'
WHERE [Id] = CAST(9 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105376+03:00'
WHERE [Id] = CAST(10 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105391+03:00'
WHERE [Id] = CAST(11 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105393+03:00'
WHERE [Id] = CAST(12 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105381+03:00'
WHERE [Id] = CAST(13 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105382+03:00'
WHERE [Id] = CAST(14 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105383+03:00'
WHERE [Id] = CAST(15 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105384+03:00'
WHERE [Id] = CAST(16 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105385+03:00'
WHERE [Id] = CAST(17 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105386+03:00'
WHERE [Id] = CAST(18 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105387+03:00'
WHERE [Id] = CAST(19 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105390+03:00'
WHERE [Id] = CAST(20 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105392+03:00'
WHERE [Id] = CAST(21 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105394+03:00'
WHERE [Id] = CAST(22 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105395+03:00'
WHERE [Id] = CAST(23 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105396+03:00'
WHERE [Id] = CAST(24 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105397+03:00'
WHERE [Id] = CAST(25 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105398+03:00'
WHERE [Id] = CAST(26 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105399+03:00'
WHERE [Id] = CAST(27 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105400+03:00'
WHERE [Id] = CAST(28 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105404+03:00'
WHERE [Id] = CAST(29 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105406+03:00'
WHERE [Id] = CAST(30 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105407+03:00'
WHERE [Id] = CAST(31 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105408+03:00'
WHERE [Id] = CAST(32 AS bigint);
SELECT @@ROWCOUNT;

GO

UPDATE [Units] SET [CreatedDate] = '2026-08-18T14:57:07.6105409+03:00'
WHERE [Id] = CAST(33 AS bigint);
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_Warehouses_Code] ON [Warehouses] ([Code]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260818115708_UpdateWarehouseConstraints', N'8.0.30');
GO

COMMIT;
GO


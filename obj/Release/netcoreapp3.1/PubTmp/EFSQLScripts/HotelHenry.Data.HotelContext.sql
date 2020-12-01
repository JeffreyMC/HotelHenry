IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE TABLE [Habitacions] (
        [IdHabitacion] int NOT NULL IDENTITY,
        [Tipo] nvarchar(max) NULL,
        CONSTRAINT [PK_Habitacions] PRIMARY KEY ([IdHabitacion])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE TABLE [Paises] (
        [IdPais] int NOT NULL IDENTITY,
        [Nombre] int NOT NULL,
        CONSTRAINT [PK_Paises] PRIMARY KEY ([IdPais])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE TABLE [Rols] (
        [IdRol] int NOT NULL IDENTITY,
        [TipoRol] nvarchar(max) NULL,
        CONSTRAINT [PK_Rols] PRIMARY KEY ([IdRol])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE TABLE [Usuarios] (
        [Correo] nvarchar(450) NOT NULL,
        [Nombre] nvarchar(max) NULL,
        [Apellidos] nvarchar(max) NULL,
        [Telefono] int NOT NULL,
        [PaisIdPais] int NULL,
        [Password] nvarchar(max) NULL,
        [RolIdRol] int NULL,
        CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Correo]),
        CONSTRAINT [FK_Usuarios_Paises_PaisIdPais] FOREIGN KEY ([PaisIdPais]) REFERENCES [Paises] ([IdPais]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Usuarios_Rols_RolIdRol] FOREIGN KEY ([RolIdRol]) REFERENCES [Rols] ([IdRol]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE TABLE [Reservacions] (
        [IdReserva] int NOT NULL IDENTITY,
        [Correo1] nvarchar(450) NULL,
        [FechaIngreso] datetime2 NOT NULL,
        [FechaSalida] datetime2 NOT NULL,
        [TipoHabitacionIdHabitacion] int NULL,
        [CantHabitaciones] int NOT NULL,
        [PaisIdPais] int NULL,
        [RolIdRol] int NULL,
        CONSTRAINT [PK_Reservacions] PRIMARY KEY ([IdReserva]),
        CONSTRAINT [FK_Reservacions_Usuarios_Correo1] FOREIGN KEY ([Correo1]) REFERENCES [Usuarios] ([Correo]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Reservacions_Paises_PaisIdPais] FOREIGN KEY ([PaisIdPais]) REFERENCES [Paises] ([IdPais]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Reservacions_Rols_RolIdRol] FOREIGN KEY ([RolIdRol]) REFERENCES [Rols] ([IdRol]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Reservacions_Habitacions_TipoHabitacionIdHabitacion] FOREIGN KEY ([TipoHabitacionIdHabitacion]) REFERENCES [Habitacions] ([IdHabitacion]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE INDEX [IX_Reservacions_Correo1] ON [Reservacions] ([Correo1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE INDEX [IX_Reservacions_PaisIdPais] ON [Reservacions] ([PaisIdPais]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE INDEX [IX_Reservacions_RolIdRol] ON [Reservacions] ([RolIdRol]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE INDEX [IX_Reservacions_TipoHabitacionIdHabitacion] ON [Reservacions] ([TipoHabitacionIdHabitacion]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE INDEX [IX_Usuarios_PaisIdPais] ON [Usuarios] ([PaisIdPais]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    CREATE INDEX [IX_Usuarios_RolIdRol] ON [Usuarios] ([RolIdRol]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200805045206_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200805045206_InitialCreate', N'3.1.6');
END;

GO


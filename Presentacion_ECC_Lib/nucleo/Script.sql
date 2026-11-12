/*
CREATE DATABASE db_horarios;
GO 
USE db_horarios;
GO 

CREATE TABLE [Asignaciones] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Codigo] NVARCHAR(20) NOT NULL,
    [Nombre] NVARCHAR(50) NOT NULL,
    [Lugar] NVARCHAR(20) NOT NULL,
    [Inicio] SMALLDATETIME NOT NULL,
    [Final] SMALLDATETIME NOT NULL,
    [Notas] NVARCHAR(500) NOT NULL,
);
*/
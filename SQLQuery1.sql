-- Crear la base de datos
CREATE DATABASE KonectaDB;
GO

-- Usar la base de datos creada
USE KonectaDB;
GO

CREATE TABLE Area (
    IdArea INT IDENTITY(1,1) PRIMARY KEY,
    NombreArea NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Sexo (
    IdSexo INT IDENTITY(1,1) PRIMARY KEY,
    NombreSexo NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Colaborador (
    IdColaborador INT IDENTITY(1,1) PRIMARY KEY,
    NumeroIdentificacion NVARCHAR(50) NOT NULL UNIQUE,
    Nombres NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Direccion NVARCHAR(200),
    Email NVARCHAR(100),
    Telefono NVARCHAR(50),
    Salario DECIMAL(18,2),
    FechaIngreso DATE,
    IdArea INT NOT NULL,
    IdSexo INT NOT NULL,
    CONSTRAINT FK_Colaborador_Area FOREIGN KEY (IdArea) REFERENCES Area(IdArea),
    CONSTRAINT FK_Colaborador_Sexo FOREIGN KEY (IdSexo) REFERENCES Sexo(IdSexo)
);

-- �reas
INSERT INTO Area (NombreArea) VALUES ('Recursos Humanos');
INSERT INTO Area (NombreArea) VALUES ('Tecnologia');
INSERT INTO Area (NombreArea) VALUES ('Administracion');

-- Sexo
INSERT INTO Sexo (NombreSexo) VALUES ('Masculino');
INSERT INTO Sexo (NombreSexo) VALUES ('Femenino');
INSERT INTO Sexo (NombreSexo) VALUES ('Otro');

INSERT INTO Colaborador 
    (NumeroIdentificacion, Nombres, Apellidos, Direccion, Email, Telefono, Salario, FechaIngreso, IdArea, IdSexo)
VALUES
    ('12345678', 'Luis', 'Torres', 'Calle 123', 'luis.torres@konecta.com', '3001234567', 2500000, '2025-08-16', 2, 1);


		
-- Tabla Usuario
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Contraseña NVARCHAR(255) NOT NULL,
    Preferencias NVARCHAR(500) NULL
);
GO

-- Tabla Lugar
CREATE TABLE Lugares (
    IdLugar INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Latitud FLOAT NOT NULL,
    Longitud FLOAT NOT NULL,
    Calificacion FLOAT NOT NULL
);
GO

-- Tabla Clima
CREATE TABLE Climas (
    IdClima INT PRIMARY KEY IDENTITY(1,1),
    Temperatura FLOAT NOT NULL,
    Humedad FLOAT NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    IdLugar INT NOT NULL,
    CONSTRAINT FK_Climas_Lugares FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar)
);
GO

-- Tabla Ruta
CREATE TABLE Rutas (
    IdRuta INT PRIMARY KEY IDENTITY(1,1),
    Origen NVARCHAR(100) NOT NULL,
    Destino NVARCHAR(100) NOT NULL,
    Distancia FLOAT NOT NULL,
    TiempoEstimado FLOAT NOT NULL
);
GO

-- Tabla PuntoRuta
CREATE TABLE PuntosRuta (
    IdPuntoRuta INT PRIMARY KEY IDENTITY(1,1),
    Orden INT NOT NULL,
    IdLugar INT NOT NULL,
    IdRuta INT NOT NULL,
    CONSTRAINT FK_PuntosRuta_Lugares FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar),
    CONSTRAINT FK_PuntosRuta_Rutas FOREIGN KEY (IdRuta) REFERENCES Rutas(IdRuta)
);
GO

-- Tabla Favorito
CREATE TABLE Favoritos (
    IdFavorito INT PRIMARY KEY IDENTITY(1,1),
    FechaAgregado DATETIME NOT NULL DEFAULT GETDATE(),
    IdUsuario INT NOT NULL,
    IdLugar INT NOT NULL,
    CONSTRAINT FK_Favoritos_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT FK_Favoritos_Lugares FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar)
);
GO

-- Tabla Comentario
CREATE TABLE Comentarios (
    IdComentario INT PRIMARY KEY IDENTITY(1,1),
    Texto NVARCHAR(500) NOT NULL,
    Calificacion FLOAT NOT NULL,
    IdUsuario INT NOT NULL,
    IdLugar INT NOT NULL,
    CONSTRAINT FK_Comentarios_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT FK_Comentarios_Lugares FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar)
);
GO

-- Tabla HistorialBusqueda
CREATE TABLE HistorialesBusqueda (
    IdHistorial INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    BusquedaRealizada NVARCHAR(200) NOT NULL,
    IdUsuario INT NOT NULL,
    CONSTRAINT FK_HistorialesBusqueda_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);
GO

-- Crear índices para mejorar el rendimiento
CREATE INDEX IX_Climas_IdLugar ON Climas(IdLugar);
CREATE INDEX IX_PuntosRuta_IdLugar ON PuntosRuta(IdLugar);
CREATE INDEX IX_PuntosRuta_IdRuta ON PuntosRuta(IdRuta);
CREATE INDEX IX_Favoritos_IdUsuario ON Favoritos(IdUsuario);
CREATE INDEX IX_Favoritos_IdLugar ON Favoritos(IdLugar);
CREATE INDEX IX_Comentarios_IdUsuario ON Comentarios(IdUsuario);
CREATE INDEX IX_Comentarios_IdLugar ON Comentarios(IdLugar);
CREATE INDEX IX_HistorialesBusqueda_IdUsuario ON HistorialesBusqueda(IdUsuario);
CREATE INDEX IX_Usuarios_Email ON Usuarios(Email); -- Para búsquedas por email
CREATE INDEX IX_Lugares_Nombre ON Lugares(Nombre); -- Para búsquedas por nombre de lugar
GO

-- Insertar datos de ejemplo en Usuarios
INSERT INTO Usuarios (Nombre, Email, Contraseña, Preferencias)
VALUES 
    ('Administrador', 'admin@turismoapp.com', 'Admin123$', 'Todas las notificaciones activadas'),
    ('Usuario Demo', 'demo@turismoapp.com', 'Demo123$', 'Notificaciones de promociones');
GO

-- Insertar datos de ejemplo en Lugares
INSERT INTO Lugares (Nombre, Tipo, Latitud, Longitud, Calificacion)
VALUES 
    ('Playa del Carmen', 'Playa', 20.6296, -87.0739, 4.8),
    ('Machu Picchu', 'Sitio histórico', -13.1631, -72.5450, 4.9);
GO

-- Insertar datos de ejemplo en Climas
INSERT INTO Climas (Temperatura, Humedad, Estado, IdLugar)
VALUES 
    (30.5, 75.0, 'Soleado', 1),  -- Playa del Carmen
    (15.2, 60.0, 'Parcialmente nublado', 2);  -- Machu Picchu
GO

-- Insertar datos de ejemplo en Rutas
INSERT INTO Rutas (Origen, Destino, Distancia, TiempoEstimado)
VALUES 
    ('Ciudad de México', 'Cancún', 1650.5, 16.5);
GO

-- Insertar datos de ejemplo en PuntosRuta
INSERT INTO PuntosRuta (Orden, IdLugar, IdRuta)
VALUES 
    (1, 1, 1);  -- Playa del Carmen como punto de la ruta Ciudad de México-Cancún
GO


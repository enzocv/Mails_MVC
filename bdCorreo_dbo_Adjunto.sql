CREATE TABLE bdCorreo.dbo.Adjunto
(
    idadjunto int PRIMARY KEY NOT NULL IDENTITY,
    idcorreo int NOT NULL,
    archivo varchar(250),
    CONSTRAINT FK__Adjunto__idcorre__3F466844 FOREIGN KEY (idcorreo) REFERENCES bdCorreo.dbo.Correo (idcorreo)
);
CREATE TABLE bdCorreo.dbo.Correo
(
    idcorreo int PRIMARY KEY NOT NULL IDENTITY,
    idpersona int NOT NULL,
    asunto varchar(20) NOT NULL,
    mensaje varchar(50),
    fecha date NOT NULL,
    hora date NOT NULL,
    importancia varchar(15) NOT NULL,
    CONSTRAINT FK__Correo__idperson__3C69FB99 FOREIGN KEY (idpersona) REFERENCES bdCorreo.dbo.Persona (idpersona)
);
CREATE TABLE bdCorreo.dbo.DetalleCorreo
(
    iddetalle int PRIMARY KEY NOT NULL,
    idcorreo int NOT NULL,
    idpersona int NOT NULL,
    CONSTRAINT FK__DetalleCo__idcor__4222D4EF FOREIGN KEY (idcorreo) REFERENCES bdCorreo.dbo.Correo (idcorreo),
    CONSTRAINT FK__DetalleCo__idper__4316F928 FOREIGN KEY (idpersona) REFERENCES bdCorreo.dbo.Persona (idpersona)
);
CREATE TABLE bdCorreo.dbo.Persona
(
    idpersona int PRIMARY KEY NOT NULL IDENTITY,
    codigo varchar(6) NOT NULL,
    dni varchar(8) NOT NULL,
    nombre varchar(100) NOT NULL,
    apellido varchar(100) NOT NULL,
    email varchar(50),
    sexo char(1),
    url varchar(250),
    celular varchar(10) NOT NULL,
    estado char(1) NOT NULL
);


CREATE TABLE bdCorreo.dbo.Usuario
(
    idusuario int PRIMARY KEY NOT NULL IDENTITY,
    idpersona int NOT NULL,
    nombre varchar(50) NOT NULL,
    clave varchar(100) NOT NULL,
    nivel varchar(30),
    estado char(1) NOT NULL,
    CONSTRAINT FK__Usuario__idperso__398D8EEE FOREIGN KEY (idpersona) REFERENCES bdCorreo.dbo.Persona (idpersona)
);

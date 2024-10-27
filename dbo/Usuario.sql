create table Usuario
(
    Id            int identity
        primary key,
    Nombre        varchar(100),
    Apellido      varchar(100),
    NombreUsuario varchar(100),
    Contrasena    varchar(200),
    Mail          varchar(100),
    Salt          varchar(500)
)
go


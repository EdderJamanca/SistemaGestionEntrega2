create table Venta
(
    Id         int identity
        primary key,
    comentario varchar(200),
    IdUsuario  int
        constraint FK_Venta_Usuario
            references Usuario
)
go


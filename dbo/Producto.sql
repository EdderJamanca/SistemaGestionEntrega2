create table Producto
(
    Id          int identity
        primary key,
    Descripcion varchar(100),
    Costo       decimal(18, 2),
    PrecioVenta decimal(18, 2),
    Stock       int,
    IdUsuario   int
        constraint FK_Producto_Usuario
            references Usuario
)
go


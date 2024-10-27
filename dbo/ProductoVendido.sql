create table ProductoVendido
(
    Id         int identity
        primary key,
    IdProducto int
        constraint FK_ProductoVendido_Producto
            references Producto,
    Stock      int,
    IdVenta    int
        constraint FK_ProductoVendido_Venta
            references Venta
)
go


using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.InterfaceDataAccess
{
    public interface IProductoVendidoDataAccess
    {
        ProductoVendido createProductoVendido(ProductoVendido productoVendido);
        void DeleteProductoVendido(int id);
        List<ProductoVendido> listaProductoVendido();
        void modificarProductoVendido(int id, ProductoVendido data);
        ProductoVendido ObtenerProductoVendido(int id);
        List<ProductoVendido> ObtenerProductosVendidos(int idventa);
    }
}

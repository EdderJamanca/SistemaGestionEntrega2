using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.InterfaceDataAccess
{
    public interface IProductosDataAccess
    {
        Producto createProducto(Producto producto);
        void DeleteProducto(int id);
        List<Producto> GetAllProductos();
        void modificarProducto(int id, Producto producto);
        Producto ObtenerProducto(int idproducto);
    }
}

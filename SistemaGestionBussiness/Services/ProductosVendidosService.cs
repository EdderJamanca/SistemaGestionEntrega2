using SistemaGestionData.DataAccess;
using SistemaGestionData.InterfaceDataAccess;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness.Services
{
    public interface IProductosVendidosService
    {
        ProductoVendido CreateProductoVendido(ProductoVendido productovendido);
        void DeleteProductoVendido(int id);
        ProductoVendido? GetOneProductoVendido(int id);
        List<ProductoVendido> GetProductsVendido();
        List<ProductoVendido> ObtenerProductosVendidos(int idventa);
        void UpdateProductoVendido(int id, ProductoVendido productovendido);
    }

    public class ProductosVendidosService : IProductosVendidosService
    {
        private IProductoVendidoDataAccess _productosVendidoDataAccess;

        public ProductosVendidosService(IProductoVendidoDataAccess productosVendidoDataAccess)
        {
            _productosVendidoDataAccess = productosVendidoDataAccess;
        }

        public List<ProductoVendido> GetProductsVendido()
        {
            return _productosVendidoDataAccess.listaProductoVendido();
        }
        public ProductoVendido? GetOneProductoVendido(int id)
        {
            return _productosVendidoDataAccess.ObtenerProductoVendido(id);
        }
        public ProductoVendido CreateProductoVendido(ProductoVendido productovendido)
        {
            return _productosVendidoDataAccess.createProductoVendido(productovendido);
        }
        public List<ProductoVendido> ObtenerProductosVendidos(int idventa)
        {
            return _productosVendidoDataAccess.ObtenerProductosVendidos(idventa);
        }

            public void UpdateProductoVendido(int id, ProductoVendido productovendido)
        {
            _productosVendidoDataAccess.modificarProductoVendido(id, productovendido);
        }
        public void DeleteProductoVendido(int id)
        {
            _productosVendidoDataAccess.DeleteProductoVendido(id);
        }
    }
}

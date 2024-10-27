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
    public interface IProductosService
    {
        Producto CreateProducto(Producto producto);
        void DeleteProducto(int id);
        Producto? GetOneProducto(int id);
        List<Producto> GetProducts();
        void UpdateProducto(int id, Producto producto);
    }

    public class ProductosService : IProductosService
    {
        private IProductosDataAccess _productosDataAccess;

        public ProductosService(IProductosDataAccess productosDataAccess)
        {
            _productosDataAccess = productosDataAccess;
        }

        public List<Producto> GetProducts()
        {
            return _productosDataAccess.GetAllProductos();
        }
        //public List<Producto> GetProductsFilter(string filtro)
        //{
        //    return _productosDataAccess.GetProductosFilter(filtro);
        //}
        public Producto? GetOneProducto(int id)
        {
            return _productosDataAccess.ObtenerProducto(id);
        }
        public Producto CreateProducto(Producto producto)
        {
            return _productosDataAccess.createProducto(producto);
        }

        public void UpdateProducto(int id, Producto producto)
        {
            _productosDataAccess.modificarProducto(id, producto);
        }
        public void DeleteProducto(int id)
        {
            _productosDataAccess.DeleteProducto(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SistemaGestionData.Context;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.DataAccess
{
    public class ProductosDataAccess
    {
        private readonly SistemaGestionContext _context;

        public ProductosDataAccess(SistemaGestionContext context)
        {
            _context = context;
        }


        public  List<Producto> GetAllProductos()
        {
                return _context.Productos
                .Include(x=>x.Usuario)
                .ToList();
        }

        //public List<Producto> GetProductosFilter(string filtro)
        //{
        //    return _context.Productos.Where(p=>p.Descripcion.Contains(filtro)).ToList();    
        //}

        public Producto createProducto(Producto producto)
        {

            // Agregar el producto al contexto
            _context.Productos.Add(producto);
            // Guardar los cambios en la base de datos
            _context.SaveChanges();
            return producto;

        }
        public  Producto ObtenerProducto(int idproducto)
        {

            Producto producto =  _context.Productos.FirstOrDefault(p => p.Id == idproducto);
            return producto;


        }

        public  void modificarProducto(int id, Producto producto)
        {

            Producto productoActual = ObtenerProducto(id);
            if (productoActual != null)
            {
                productoActual.Descripcion = producto.Descripcion;
                productoActual.Costo = producto.Costo;
                productoActual.PrecioVenta = producto.PrecioVenta;
                productoActual.Stock = producto.Stock;
                _context.Productos.Update(productoActual);
                _context.SaveChanges();
            }

        }
        // Método para eliminar un producto, también recibiendo el contexto
        public  void DeleteProducto(int id)
        {
             var producto = ObtenerProducto(id);
            _context.Productos.Remove(producto);
            _context.SaveChanges(); // Guardar cambios en la base de datos

        }
    }
}

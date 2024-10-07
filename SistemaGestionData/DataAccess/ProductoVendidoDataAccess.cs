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
    public class ProductoVendidoDataAccess
    {
        private readonly SistemaGestionContext _context;

        public ProductoVendidoDataAccess(SistemaGestionContext context)
        {
            _context = context;
        }

        public  List<ProductoVendido> listaProductoVendido()
        {

                return _context.ProductoVendidos
                .Include(x=>x.producto)
                .ThenInclude(x=>x.Usuario)
                .ToList();
        }

        public ProductoVendido createProductoVendido(ProductoVendido productoVendido)
        {

            _context.ProductoVendidos.Add(productoVendido);
            _context.SaveChanges();

            var producto = _context.Productos.Where(x=>x.Id == productoVendido.IdProducto).ToList();
            producto[0].Stock = producto[0].Stock - productoVendido.Stock;

            _context.Productos.Update(producto[0]);
            _context.SaveChanges();

            return productoVendido;

        }
        public  ProductoVendido ObtenerProductoVendido(int id)
        {

            ProductoVendido productoVendido = _context.ProductoVendidos.FirstOrDefault(p => p.Id == id);
            return productoVendido;

        }

        public  void modificarProductoVendido(int id, ProductoVendido data)
        {

            ProductoVendido productoVendidoActual = ObtenerProductoVendido(id);
            if (productoVendidoActual != null)
            {
                productoVendidoActual.Stock = data.Stock;

                _context.SaveChanges();

                var producto = _context.Productos.Where(x => x.Id == productoVendidoActual.IdProducto).ToList();
                producto[0].Stock = producto[0].Stock - productoVendidoActual.Stock;

                _context.Productos.Update(producto[0]);
                _context.SaveChanges();
            }

        }
        public  void DeleteProductoVendido(int id)
        {


                var prodcutoVendido = ObtenerProductoVendido(id);
                if (prodcutoVendido != null)
                {
                    _context.ProductoVendidos.Remove(prodcutoVendido);
                    _context.SaveChanges(); // Guardar cambios en la base de datos
                }
        
        }
    }
}

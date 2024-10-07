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
    public class VentaDataAccess
    {
        private readonly SistemaGestionContext _context;

        public VentaDataAccess(SistemaGestionContext context)
        {
            _context = context;
        }

        public  List<Venta> listaVenta()
        {
            return _context.Ventas
                .Include(x=>x.Usuario)
                .ToList();
        }

        public  Venta createVenta(Venta venta)
        {

            _context.Ventas.Add(venta);
            _context.SaveChanges();

            return venta;
            
        }
        public  Venta ObtenerVenta(int idventa)
        {

                Venta venta = _context.Ventas.FirstOrDefault(p => p.Id == idventa);
                return venta;
        }

        public async void modificarVenta(int id,Venta venta)
        {
            try
            {
                    Venta ventaActual = ObtenerVenta(id);
                    if (ventaActual != null)
                    {
                        ventaActual.Comentario = venta.Comentario;

                        _context.SaveChanges();
                    }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public  void DeleteVenta(int id)
        {
            try
            {

                var venta = ObtenerVenta(id);
                if (venta != null)
                {
                    _context.Ventas.Remove(venta);
                    _context.SaveChanges(); // Guardar cambios en la base de datos
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

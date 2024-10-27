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
    public interface IVentasService
    {
        Venta CreateVenta(Venta venta);
        void DeleteVenta(int id);
        Venta? GetOneVenta(int id);
        List<Venta> GetVentas();
        void UpdateVenta(int id, Venta venta);
    }

    public class VentasService : IVentasService
    {
        private IVentaDataAccess _ventaDataAccess;

        public VentasService(IVentaDataAccess ventaDataAccess)
        {
            _ventaDataAccess = ventaDataAccess;
        }

        public List<Venta> GetVentas()
        {
            return _ventaDataAccess.listaVenta();
        }
        public Venta? GetOneVenta(int id)
        {
            return _ventaDataAccess.ObtenerVenta(id);
        }
        public Venta CreateVenta(Venta venta)
        {
            return _ventaDataAccess.createVenta(venta);
        }

        public void UpdateVenta(int id, Venta venta)
        {
            _ventaDataAccess.modificarVenta(id, venta);
        }
        public void DeleteVenta(int id)
        {
            _ventaDataAccess.DeleteVenta(id);
        }
    }
}

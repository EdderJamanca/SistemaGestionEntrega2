using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.InterfaceDataAccess
{
    public interface IVentaDataAccess
    {
        Venta createVenta(Venta venta);
        void DeleteVenta(int id);
        List<Venta> listaVenta();
        void modificarVenta(int id, Venta venta);
        Venta ObtenerVenta(int idventa);
    }
}

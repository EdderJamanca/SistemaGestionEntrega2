using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Dto
{
    public class DetalleVentaDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string NameProducto { get; set; }
        public int Stock { get; set; }
        public decimal Total { get; set; }
        public decimal precioVenta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Dto
{
    public class FormularioVentaDto
    {
        public Venta Venta { get; set; } = new Venta();
        public Usuario Usuario { get; set; } = new Usuario();
        public Producto Producto { get; set; } = new Producto();
        public List<DetalleVentaDto>? detalleVenta { get; set; } = new List<DetalleVentaDto>();
    }
}

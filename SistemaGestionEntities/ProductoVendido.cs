using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    [Table("ProductoVendido")]
    public class ProductoVendido
    {
        [Key]
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int Stock { get; set; }
        public int IdVenta { get; set;}

        [ForeignKey("IdVenta")]
        public Venta? Venta { get; set;}

        [ForeignKey("IdProducto")]
        public Producto? producto { get; set;}   
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionEntities
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; } = "";
        public Decimal Costo { get; set; }
        public Decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
    }
}

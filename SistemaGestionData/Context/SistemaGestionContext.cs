using Microsoft.EntityFrameworkCore;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Context
{
    public class SistemaGestionContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ProductoVendido> ProductoVendidos  { get; set; }

        public SistemaGestionContext() : base() { }

        public SistemaGestionContext(DbContextOptions<SistemaGestionContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
               optionsBuilder.UseSqlServer("Data Source=EDDER05;Initial Catalog=DBCoderhouse;User ID=sa;Password=root;TrustServerCertificate=True");
            }
        }
    }
}


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData.Context;
using SistemaGestionData.DataAccess;
using SistemaGestionData.InterfaceDataAccess;

namespace SistemaGestionData
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureDataLayer(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<ISistemaGestionContext,SistemaGestionContext>(
                  optionBuilder => {
                      var connectionString = configuration.GetConnectionString("Coderhouse");
                      optionBuilder.UseSqlServer(connectionString);
                  }
              );
            services.AddDbContext<ISistemaGestionContext,SistemaGestionContext>();
            services.AddScoped<IProductosDataAccess,ProductosDataAccess>();
            services.AddScoped<IProductoVendidoDataAccess, ProductoVendidoDataAccess>();
            services.AddScoped<IUsuarioDataAccess,UsuarioDataAccess>();
            services.AddScoped<IVentaDataAccess, VentaDataAccess>();
           
            return services;
        }
    }
}

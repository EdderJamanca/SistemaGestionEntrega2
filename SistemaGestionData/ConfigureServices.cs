
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData.Context;
using SistemaGestionData.DataAccess;

namespace SistemaGestionData
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureDataLayer(this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<SistemaGestionContext>(
                  optionBuilder => {
                      var connectionString = configuration.GetConnectionString("Coderhouse");
                      optionBuilder.UseSqlServer(connectionString);
                  }
              );
            services.AddDbContext<SistemaGestionContext>();
            services.AddScoped<ProductosDataAccess>();
            services.AddScoped<ProductoVendidoDataAccess>();
            services.AddScoped<UsuarioDataAccess>();
            services.AddScoped<VentaDataAccess>();
            return services;
        }
    }
}

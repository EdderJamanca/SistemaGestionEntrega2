using SistemaGestionUI.Components;
using SistemaGestionUI.ClientServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using CurrieTechnologies.Razor.SweetAlert2;
namespace SistemaGestionUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // builder.Services.ConfigureBussinessLayer();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<AuthenticationStateProvider, AuthService>(provider => provider.GetRequiredService<AuthService>());
        builder.Services.AddScoped<ILoginServices, AuthService>(provider => provider.GetRequiredService<AuthService>());


        //builder.Services.AddTransient<AuthHeaderHandler>();

        builder.Services.AddTransient<UsuariosService>();
        builder.Services.AddTransient<ProductosService>();
        builder.Services.AddTransient<ProductoVendidoService>();
        builder.Services.AddTransient<VentasServices>();


        builder.Services.AddHttpClient<UsuariosService>(
            client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Usuarios/")
            );

        builder.Services.AddHttpClient<ProductosService>(
            client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Productos/")
            );
        builder.Services.AddHttpClient<ProductoVendidoService>(
            client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/ProductosVendidos/")
            );

        builder.Services.AddHttpClient<VentasServices>(
        client => client.BaseAddress = new Uri($"{builder.Configuration["ApiUrl"]}/api/Ventas/")
        );
        builder.Services.AddSweetAlert2();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}

using Microsoft.Extensions.Logging;
using ConsumodeAPIREST.Services;
using ConsumodeAPIREST.ViewModels;
using ConsumodeAPIREST.Views;

namespace ConsumodeAPIREST
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
            });
            builder.Services.AddSingleton<IApiService, ApiService>();

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<UsuariosViewModel>();
            builder.Services.AddTransient<DetalleUsuarioViewModel>();
            builder.Services.AddTransient<NuevoUsuarioViewModel>();

            builder.Services.AddSingleton<UsuariosPage>();
            builder.Services.AddTransient<DetalleUsuarioPage>();
            builder.Services.AddTransient<NuevoUsuarioPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

using ConsumodeAPIREST.Views;

namespace ConsumodeAPIREST;

public partial class AppShell : Shell
{
    public AppShell(UsuariosPage usuariosPage)
    {
        InitializeComponent();

        Items.Add(new ShellContent
        {
            Title = "Usuarios",
            Route = nameof(UsuariosPage),
            Content = usuariosPage
        });

        Routing.RegisterRoute(nameof(DetalleUsuarioPage), typeof(DetalleUsuarioPage));
        Routing.RegisterRoute(nameof(NuevoUsuarioPage), typeof(NuevoUsuarioPage));
    }
}

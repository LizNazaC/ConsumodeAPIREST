using ConsumodeAPIREST.ViewModels;

namespace ConsumodeAPIREST.Views;

public partial class UsuariosPage : ContentPage
{
    private readonly UsuariosViewModel viewModel;

    public UsuariosPage(UsuariosViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (viewModel.Usuarios.Count == 0)
            await viewModel.CargarUsuariosCommand.ExecuteAsync(null);
    }
}

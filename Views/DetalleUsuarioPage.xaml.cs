using ConsumodeAPIREST.ViewModels;

namespace ConsumodeAPIREST.Views;

public partial class DetalleUsuarioPage : ContentPage
{
    public DetalleUsuarioPage(DetalleUsuarioViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

using ConsumodeAPIREST.ViewModels;

namespace ConsumodeAPIREST.Views;

public partial class NuevoUsuarioPage : ContentPage
{
    public NuevoUsuarioPage(NuevoUsuarioViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

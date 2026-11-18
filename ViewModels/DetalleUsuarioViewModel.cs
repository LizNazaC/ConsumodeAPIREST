using CommunityToolkit.Mvvm.ComponentModel;
using ConsumodeAPIREST.Models;
using ConsumodeAPIREST.Services;

namespace ConsumodeAPIREST.ViewModels;

[QueryProperty(nameof(Id), "id")]
public partial class DetalleUsuarioViewModel(IApiService apiService) : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private Usuario? usuario;

    [ObservableProperty]
    private bool isBusy;

    partial void OnIdChanged(int value)
    {
        if (value > 0)
            _ = CargarUsuarioAsync(value);
    }

    private async Task CargarUsuarioAsync(int usuarioId)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            Usuario = await apiService.ObtenerUsuarioAsync(usuarioId);
        }
        catch (HttpRequestException)
        {
            await Shell.Current.DisplayAlert("Conexión", "No se pudo conectar con el servicio.", "Aceptar");
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Se produjo un error al cargar el usuario.", "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }
    }
}

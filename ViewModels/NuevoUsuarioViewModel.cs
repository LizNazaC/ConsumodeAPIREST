using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsumodeAPIREST.Models;
using ConsumodeAPIREST.Services;

namespace ConsumodeAPIREST.ViewModels;

public partial class NuevoUsuarioViewModel(IApiService apiService) : ObservableObject
{
    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string phone = string.Empty;

    [ObservableProperty]
    private string website = string.Empty;

    [ObservableProperty]
    private string? createdMessage;

    [ObservableProperty]
    private bool isBusy;

    [RelayCommand]
    private async Task EnviarAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var usuario = await apiService.CrearUsuarioAsync(new Usuario
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                Website = Website
            });

            CreatedMessage = usuario is null
                ? "No se recibió el usuario creado."
                : $"Usuario creado con Id: {usuario.Id}";

            if (usuario is not null)
                await Shell.Current.DisplayAlert("Éxito", CreatedMessage, "Aceptar");
        }
        catch (HttpRequestException)
        {
            await Shell.Current.DisplayAlert("Conexión", "No se pudo conectar con el servicio.", "Aceptar");
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Se produjo un error al crear el usuario.", "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }
    }
}

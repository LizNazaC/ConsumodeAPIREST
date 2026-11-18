using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsumodeAPIREST.Models;
using ConsumodeAPIREST.Services;

namespace ConsumodeAPIREST.ViewModels;

public partial class UsuariosViewModel(IApiService apiService) : ObservableObject
{
    public ObservableCollection<Usuario> Usuarios { get; } = [];

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private bool isRefreshing;

    [ObservableProperty]
    private Usuario? selectedUsuario;

    [RelayCommand]
    private async Task CargarUsuariosAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var usuarios = await apiService.ObtenerUsuariosAsync();
            Usuarios.Clear();
            foreach (var usuario in usuarios)
                Usuarios.Add(usuario);
        }
        catch (HttpRequestException)
        {
            await Shell.Current.DisplayAlert("Conexión", "No se pudo conectar con el servicio.", "Aceptar");
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Se produjo un error al cargar los usuarios.", "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task RefrescarUsuariosAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsRefreshing = true;
            var usuarios = await apiService.ObtenerUsuariosAsync();
            Usuarios.Clear();
            foreach (var usuario in usuarios)
                Usuarios.Add(usuario);
        }
        catch (HttpRequestException)
        {
            await Shell.Current.DisplayAlert("Conexión", "No se pudo conectar con el servicio.", "Aceptar");
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "Se produjo un error al actualizar los usuarios.", "Aceptar");
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    private async Task SeleccionarUsuarioAsync(Usuario? usuario)
    {
        if (usuario is null)
            return;

        SelectedUsuario = null;
        await Shell.Current.GoToAsync($"DetalleUsuarioPage?id={usuario.Id}");
    }

    [RelayCommand]
    private async Task IrANuevoUsuarioAsync()
    {
        await Shell.Current.GoToAsync("NuevoUsuarioPage");
    }
}

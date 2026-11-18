using ConsumodeAPIREST.Models;

namespace ConsumodeAPIREST.Services;

public interface IApiService
{
    Task<List<Usuario>> ObtenerUsuariosAsync();
    Task<Usuario?> ObtenerUsuarioAsync(int id);
    Task<Usuario?> CrearUsuarioAsync(Usuario usuario);
}

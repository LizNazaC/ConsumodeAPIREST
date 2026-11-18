using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ConsumodeAPIREST.Models;

namespace ConsumodeAPIREST.Services;

public class ApiService(HttpClient httpClient) : IApiService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<List<Usuario>> ObtenerUsuariosAsync()
    {
        using var response = await httpClient.GetAsync("users");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<Usuario>>(JsonOptions) ?? [];
    }

    public async Task<Usuario?> ObtenerUsuarioAsync(int id)
    {
        using var response = await httpClient.GetAsync($"users/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Usuario>(JsonOptions);
    }

    public async Task<Usuario?> CrearUsuarioAsync(Usuario usuario)
    {
        var json = JsonSerializer.Serialize(usuario, JsonOptions);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");
        using var response = await httpClient.PostAsync("users", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Usuario>(JsonOptions);
    }
}

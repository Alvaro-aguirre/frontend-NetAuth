using System.Net.Http.Json;
using frontendnet.Models;

namespace frontendnet.Services;

public class PedidosClientService(HttpClient client)
{
    public async Task PostAsync(Pedido pedido)
    {
        var response = await client.PostAsJsonAsync("api/pedidos", pedido);
        response.EnsureSuccessStatusCode();
    }
}

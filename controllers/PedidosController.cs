using System.Text.Json;
using System.Security.Claims;
using frontendnet.Models;
using frontendnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontendnet;

[Authorize(Roles = "Administrador")]
public class PedidosController(PedidosClientService pedidos,
                                ProductosClientService productos,
                                IConfiguration configuration) : Controller
{
    public async Task<IActionResult> Index(string? s)
    {
        List<PedidoJson> lista = [];
        try
        {
            lista = await pedidos.GetAsync(s); // este GetAsync ahora devuelve List<PedidoJson>
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return RedirectToAction("Salir", "Auth");
        }

        ViewBag.Url = configuration["UrlWebAPI"];
        return View(lista); // lista es List<PedidoJson>
    }



    /*
            public async Task<IActionResult> Detalle(int id)
            {
                Pedido? item = null;
                try
                {
                    item = await pedidos.GetAsync(id);
                    if (item == null) return NotFound();
                }
                catch (HttpRequestException ex)
                {
                    if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        return RedirectToAction("Salir", "Auth");
                }
                ViewBag.Url = configuration["UrlWebAPI"];
                return View(item);
            }*/
}
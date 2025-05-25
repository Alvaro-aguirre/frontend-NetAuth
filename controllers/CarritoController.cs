using System.Text.Json;
using frontendnet.Models;
using frontendnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontendnet;

[Authorize(Roles = "Usuario")]
public class CarritoController(ProductosClientService productos) : Controller
{
    private const string SessionKey = "Carrito";

    public async Task<IActionResult> Index()
    {
        var carrito = ObtenerCarrito();
        return View(carrito);
    }

    [HttpPost]
    public async Task<IActionResult> Agregar(int id)
    {
        var producto = await productos.GetAsync(id);
        if (producto == null) return NotFound();

        var carrito = ObtenerCarrito();
        var existente = carrito.FirstOrDefault(p => p.ProductoId == id);

        if (existente != null)
        {
            existente.Cantidad++;
        }
        else
        {
            carrito.Add(new Carrito
            {
                ProductoId = producto.ProductoId,
                Titulo = producto.Titulo,
                Precio = producto.Precio,
                Cantidad = 1,
                ArchivoId = producto.ArchivoId
            });
        }

        GuardarCarrito(carrito);
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(int id)
    {
        var carrito = ObtenerCarrito();
        var item = carrito.FirstOrDefault(c => c.ProductoId == id);
        if (item != null)
        {
            carrito.Remove(item);
            GuardarCarrito(carrito);
        }

        return RedirectToAction("Index");
    }

    private List<Carrito> ObtenerCarrito()
    {
        var data = HttpContext.Session.GetString(SessionKey);
        return data == null
            ? new List<Carrito>()
            : JsonSerializer.Deserialize<List<Carrito>>(data)!;
    }

    [HttpPost]
    public IActionResult Actualizar(int id, int cantidad)
    {
        var carrito = ObtenerCarrito();
        var item = carrito.FirstOrDefault(p => p.ProductoId == id);

        if (item != null && cantidad > 0)
        {
            item.Cantidad = cantidad;
            GuardarCarrito(carrito);
        }

        return RedirectToAction("Index");
    }


    private void GuardarCarrito(List<Carrito> carrito)
    {
        HttpContext.Session.SetString(SessionKey, JsonSerializer.Serialize(carrito));
    }
}


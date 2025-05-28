using frontendnet.Models;
using frontendnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace frontendnet;

public class RegistroController(UsuariosClientService usuarios) : Controller
{
    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(UsuarioPwd item)
    {        
        
        if (ModelState.IsValid)
        {
            try
            {
                await usuarios.PostCompradorAsync(item);
                TempData["Mensaje"] = "¡Registro exitoso! Ahora puedes iniciar sesión.";
                return RedirectToAction("Index", "Auth");
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Ocurrió un error al registrar el usuario.");
                return RedirectToAction("Salir", "Auth");
            }
        }

        ModelState.AddModelError("Email", "No ha sido posible realizar la acción. Inténtelo nuevamente.");
        return View(item);
    }


}

using System.ComponentModel.DataAnnotations;

namespace frontendnet.Models;

public class Usuario
{
    [Display(Name = "Id")]
    public string? Id { get; set; }

   [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [EmailAddress(ErrorMessage = "El campo {0} no es un email válido")]
    [StringLength(254, ErrorMessage = "El correo no puede tener más de 254 caracteres")]
    [Display(Name = "Email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(254, ErrorMessage = "El nombre no puede tener más de 254 caracteres")]

    public required string Nombre { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public required string Rol { get; set; }
}

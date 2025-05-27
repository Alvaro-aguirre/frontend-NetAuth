using System.ComponentModel.DataAnnotations;

namespace frontendnet.Models;

public class Login
{
    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [EmailAddress(ErrorMessage = "El campo {0} no es un email válido")]
    [StringLength(254, ErrorMessage = "El correo no puede tener más de 50 caracteres")]
    [Display(Name = "Email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio")]
    [DataType(DataType.Password)]
    [StringLength(254, ErrorMessage = "La contraseña no puede tener más de 254 caracteres")]
    [Display(Name = "Contraseña")]
    public required string Password { get; set; }
}
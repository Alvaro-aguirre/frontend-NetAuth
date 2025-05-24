namespace frontendnet.Models;

public class AuthUser
{
    public required string Nombre { get; set; }
    public required string Email { get; set; }
    public required string Jwt { get; set; }
    public required string Rol { get; set; }
}
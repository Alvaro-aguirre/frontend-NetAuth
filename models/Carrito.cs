namespace frontendnet.Models;

public class Carrito
{
    public int? ProductoId { get; set; }
    public string Titulo { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public int? ArchivoId { get; set; }
}
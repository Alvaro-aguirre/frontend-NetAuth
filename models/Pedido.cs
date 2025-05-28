namespace frontendnet.Models;

public class Pedido
{
    public string usuarioid { get; set; } = "";
    public List<PedidoProducto> productos { get; set; } = [];
}

public class PedidoProducto
{
    public int productoid { get; set; }
    public int cantidad { get; set; }

    public Producto? producto { get; set; }
}
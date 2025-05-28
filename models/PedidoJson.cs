using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace frontendnet.Models;
public class PedidoJson
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("usuarioid")]
    public Guid UsuarioIdLower { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("usuario")]
    public UsuarioJson Usuario { get; set; }

    [JsonPropertyName("productos")]
    public List<ProductoJson> Productos { get; set; }
}

public class UsuarioJson
{
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; }
}

public class ProductoJson
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; }

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; }

    [JsonPropertyName("precio")]
    public string Precio { get; set; }

    [JsonPropertyName("archivoid")]
    public int? ArchivoIdLower { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("pedidoproducto")]
    public PedidoProductoJson PedidoProducto { get; set; }
}

public class PedidoProductoJson
{
    [JsonPropertyName("cantidad")]
    public int Cantidad { get; set; }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace frontendnet.Models
{
    public class Producto
    {
        [Display(Name = "Id")]
        public int? ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(254, ErrorMessage = "El nombre del producto no puede tener más de 254 caracteres")]

        public required string Titulo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(254, ErrorMessage = "La descripción no puede tener más de 254 caracteres")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; } = "Sin descripción";

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "El valor del campo debe ser un precio válido.")]
        [Range(1, 99999999.99, ErrorMessage = "El precio debe estar entre {1} y {2}.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Display(Name = "Portada")]
        public int? ArchivoId { get; set; }

        [Display(Name = "Eliminable")]
        public bool Protegida { get; set; } = false;

        [JsonPropertyName("categoria")]
        public ICollection<Categoria>? Categorias { get; set; }
    }
}
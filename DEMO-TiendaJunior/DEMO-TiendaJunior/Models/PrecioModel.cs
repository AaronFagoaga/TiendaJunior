using System;
using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class PrecioModel
    {
        public int Id_Precio { get; set; }

        [Required(ErrorMessage = "Seleccione un producto.")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El precio por unidad es obligatorio.")]
        [Range(0.25, 10000.00, ErrorMessage = "El precio por unidad debe ser un valor positivo y no mayor a 10,000.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe ser un número real con hasta dos decimales.")]
        public decimal PrecioUnidad { get; set; }

        public ProductoModel? Producto { get; set; } // Captura datos del modelo producto para obtener nombre
    }
}


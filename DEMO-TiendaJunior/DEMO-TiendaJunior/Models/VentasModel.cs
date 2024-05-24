using System;
using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class VentasModel
    {
        public int Id_Venta { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El formato de la fecha no es válido.")]
        public DateTime dFecha { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del cliente debe tener entre 3 y 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del cliente solo puede contener letras y espacios.")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "El nombre del encargado es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del encargado debe tener entre 3 y 100 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del encargado solo puede contener letras y espacios.")]
        public string Encargado { get; set; }

        [Required(ErrorMessage = "El total de la venta es obligatorio.")]
        [Range(0.01, 1000000.00, ErrorMessage = "El total de la venta debe ser un valor positivo y no mayor a 1,000,000.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El total de la venta solo puede contener números positivos y un único punto decimal.")]
        public double Total_Venta { get; set; }
    }
}



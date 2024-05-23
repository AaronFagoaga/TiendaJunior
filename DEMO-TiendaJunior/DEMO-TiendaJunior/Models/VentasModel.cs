using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class VentasModel
    {
        public int Id_Venta { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime dFecha { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del cliente solo puede contener letras y espacios.")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "El nombre del encargado es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del encargado solo puede contener letras y espacios.")]
        public string Encargado { get; set; }

        [Required(ErrorMessage = "El total de la venta es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El total de la venta solo puede contener números positivos y un único punto decimal.")]
        public double Total_Venta { get; set; }
    }
}

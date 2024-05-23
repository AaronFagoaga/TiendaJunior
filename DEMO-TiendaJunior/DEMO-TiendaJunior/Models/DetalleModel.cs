using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
	public class DetalleModel
	{
		public int Id_Detalle { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un número entero positivo.")]
        public int Cantidad { get; set; }
		
		public double SubTotal { get; set; }

        public int Id_Venta { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un producto.")]
        public int Id_Producto { get; set; }

		public PrecioModel? Precio { get; set; } //Captura datos del modelo precio para obtener el precio
		public ProductoModel? Producto { get; set; } //Captura datos del modelo precio para obtener el precio
	}
}

using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class ProductoModel
    {
        public int Id_Producto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre del producto solo puede contener letras y espacios.")]
        [MinLength(3, ErrorMessage = "El nombre producto debe tener al menos 3 letras.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        public string Nombre_Producto { get; set;}

        [Required(ErrorMessage = "La presentacion es obligatorio.")]
        [MinLength(2, ErrorMessage = "La presentacion debe tener al menos 2 letras.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener 30 caracteres.")]
        public string Presentacion { get; set;}

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El campo Stock debe ser un número entero no negativo.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El stock debe contener solo números.")]
        public string Stock { get; set;}

        [Required(ErrorMessage = "Seleccionar la categoria es obligatorio.")]
        public int IdCategoria { get; set; }
        public CategoriaModel? Categoria { get; set;} //Captura los datos del modelo de categoria para obtener el nombre
    }
}

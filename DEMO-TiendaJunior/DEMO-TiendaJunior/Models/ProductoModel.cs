using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class ProductoModel
    {
        public int Id_Producto { get; set; }

        public string Nombre_Producto { get; set;}

        public string Presentacion { get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El campo Stock debe ser un número entero no negativo.")]
        public int Stock { get; set;}

        public int IdCategoria { get; set; }
        public CategoriaModel? Categoria { get; set;} //Captura los datos del modelo de categoria para obtener el nombre
    }
}

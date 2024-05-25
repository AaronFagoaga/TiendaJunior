using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class CategoriaModel
    {
        public int Id_Categoria { get; set; }


        [Required(ErrorMessage = "El nombre categoria es obligatorio.")]
        [MinLength(5, ErrorMessage = "El nombre categoria debe tener al menos 5 letras.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre de la categoria solo puede contener letras y espacios.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        public string Nombre { get; set;}


        [Required(ErrorMessage = "La descripcion es obligatorio.")]
        [MinLength(15, ErrorMessage = "La descripción debe tener al menos 15 letras.")]
        [StringLength(75, ErrorMessage = "El nombre no puede tener más de 75 caracteres.")]
        public string Descripcion { get; set;}

    }
}

using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class UsuarioModel
    {
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad debe ser un número entero positivo.")]
        public int Edad {  get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio.")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El contacto debe ser un número telefónico en el formato ####-####.")]
        public string Contacto { get; set; }
        public int Id_Roles { get; set; }

        public RolesModel? Roles { get; set; }
    }
}

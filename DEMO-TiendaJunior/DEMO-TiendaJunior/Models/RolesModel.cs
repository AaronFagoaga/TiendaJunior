using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class RolesModel
    {
        public int Id_Roles { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El nivel de privilegios es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El nivel de privilegios debe ser un número mayor a 0.")]
        public int NivelPrivilegios { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace DEMO_TiendaJunior.Models
{
    public class LoginModel
    {
        public int Id_Login { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "El nombre de usuario solo puede contener letras y números, sin espacios ni caracteres especiales.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un usuario.")]
        public int Id_Usuario { get; set; }


        public int Id_Roles { get; set; }

        public UsuarioModel? Usuario { get; set; }
        public RolesModel? Rol { get; set; }
    }
}

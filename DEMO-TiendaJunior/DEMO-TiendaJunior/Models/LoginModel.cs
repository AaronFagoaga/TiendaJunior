namespace DEMO_TiendaJunior.Models
{
    public class LoginModel
    {
        public int Id_Login { get; set; }
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Rol { get; set; }

        public UsuarioModel? Usuario { get; set; }
        public RolesModel? Rol { get; set; }
    }
}

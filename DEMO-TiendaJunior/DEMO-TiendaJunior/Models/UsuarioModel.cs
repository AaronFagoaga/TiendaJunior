namespace DEMO_TiendaJunior.Models
{
    public class UsuarioModel
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public string Contacto { get; set; }
        public int Id_Roles { get; set; }

        public RolesModel? Roles { get; set; }
    }
}

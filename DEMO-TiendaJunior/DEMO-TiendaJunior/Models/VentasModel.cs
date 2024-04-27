namespace DEMO_TiendaJunior.Models
{
    public class VentasModel
    {
        public int Id_Venta { get; set; }
        public DateTime dFecha { get; set; }
        public string Cliente { get; set; }
        public string Encargado { get; set; }
        public double Total_Venta { get; set; }
    }
}

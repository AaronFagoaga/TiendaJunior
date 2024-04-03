namespace DEMO_TiendaJunior.Models
{
    public class PrecioModel
    {
        public int Id_Precio { get; set; }

        public int Id_Producto { get; set;}

        public double PrecioUnidad { get; set;}

        public ProductoModel? Producto { get; set; } //Captura datos del modelo producto para obtener nombre
    }
}

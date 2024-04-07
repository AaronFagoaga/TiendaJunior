namespace DEMO_TiendaJunior.Models
{
    public class ProductoModel
    {
        public int Id_Producto { get; set; }

        public string Nombre_Producto { get; set;}

        public string Presentacion { get; set;}

        public int Id_Categoria { get; set;}

        public string Stock { get; set;}

        public CategoriaModel? Categoria { get; set;} //Captura los datos del modelo de categoria para obtener el nombre
    }
}

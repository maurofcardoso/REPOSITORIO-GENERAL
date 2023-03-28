namespace Application.Models.CarritoProductoModels
{
    public class CarritoProductoResponse
    {
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public string Codigo { get; set; }

        public decimal Precio { get; set; }

        public string Image { get; set; }
    }
}

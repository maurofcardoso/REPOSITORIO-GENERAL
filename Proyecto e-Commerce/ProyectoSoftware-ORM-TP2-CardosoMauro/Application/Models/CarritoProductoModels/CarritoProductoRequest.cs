namespace Application.Models.CarritoProductoModels
{
    public class CarritoProductoRequest
    { 
        public int CarritoProductoId { get; set; }

        public int Cantidad { get; set; }

        public Guid CarritoId { get; set; }

        public int ProductoId { get; set; }
    }
}

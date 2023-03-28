using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Carrito
    {
        public Carrito()
        {
            this.ListCarritoProductos = new List<CarritoProducto>();
        }
        public Guid CarritoId { get; set; }

        public Boolean Estado { get; set; }
        [JsonIgnore]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }

        public List<CarritoProducto> ListCarritoProductos { get; set; }

        public Orden Orden { get; set; }
    }
}

using Application.Models.CarritoProductoModels;

namespace Application.Models.CarritoModels
{
    public class CarritoResponse
    {
        public CarritoResponse()
        {
            this.ListCarritoProductoResponse = new List<CarritoProductoResponse>();
        }
        public List<CarritoProductoResponse> ListCarritoProductoResponse { get; set; }
    }
}

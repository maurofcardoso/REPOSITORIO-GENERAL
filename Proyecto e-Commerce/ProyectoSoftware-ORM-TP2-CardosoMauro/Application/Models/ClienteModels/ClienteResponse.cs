using Application.Models.CarritoModels;

namespace Application.Models.ClienteModels
{
    public class ClienteResponse
    {
        //public ClienteResponse()
        //{
        //    this.ListCarritoResponse = new List<CarritoResponse>();
        //}

        public string dni { get; set; }

        public string name { get; set; }
        
        public string lastname { get; set; }
        
        public string address { get; set; }
        
        public string phoneNumber { get; set; }

        //public List<CarritoResponse> ListCarritoResponse { get; set; }
    }
}

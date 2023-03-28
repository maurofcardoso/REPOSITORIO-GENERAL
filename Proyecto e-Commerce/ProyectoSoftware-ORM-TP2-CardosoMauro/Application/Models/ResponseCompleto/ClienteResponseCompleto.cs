namespace Application.Models.ResponseCompleto
{
    public class ClienteResponseCompleto
    {
        public ClienteResponseCompleto()
        {
            this.ListCarritos = new List<CarritoResponseCompleto>();
        }

        public string dni { get; set; }

        public string name { get; set; }

        public string lastname { get; set; }

        public string address { get; set; }

        public string phoneNumber { get; set; }

        public List<CarritoResponseCompleto> ListCarritos { get; set; }
    }
}

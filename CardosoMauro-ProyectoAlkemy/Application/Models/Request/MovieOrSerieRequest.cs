namespace Application.Models.Request
{
    public class MovieOrSerieRequest
    {
        public string Image { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public double Qualification { get; set; }
    }
}

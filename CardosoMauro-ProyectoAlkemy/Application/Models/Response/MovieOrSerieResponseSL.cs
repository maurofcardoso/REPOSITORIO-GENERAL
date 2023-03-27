namespace Application.Models.Response
{
    public class MovieOrSerieResponseSL
    {
        public int MovieOrSerieId { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public double Qualification { get; set; }

        public GenderResponseSL Gender { get; set; }
    }
}

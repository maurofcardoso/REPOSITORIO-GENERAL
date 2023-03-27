namespace Application.Models.Response
{
    public class MovieOrSerieResponse
    {
        public MovieOrSerieResponse()
        {
            this.CharacterAssociated = new List<CharacterResponseSL>();
        }
        public int MovieOrSerieId { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public double Qualification { get; set; }

        public GenderResponseSL Gender { get; set; }

        public IEnumerable<CharacterResponseSL> CharacterAssociated { get; set; }
    }
}

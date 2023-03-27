namespace Application.Models.Response
{
    public class CharacterResponse
    {
        public CharacterResponse()
        {
            this.MoviesOrSeriesAssociated = new List<MovieOrSerieResponseSL>();
        }
        public int CharacterId { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public string History { get; set; }

        public IEnumerable<MovieOrSerieResponseSL> MoviesOrSeriesAssociated { get; set; }
    }
}

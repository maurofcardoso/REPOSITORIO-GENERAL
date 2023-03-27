namespace Domain.Entities
{
    public class Character
    {
        public Character()
        {
            this.MoviesOrSeriesAssociated = new List<CharacterMovieOrSerie>();
        }
        public int CharacterId { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public string History { get; set; }

        public IEnumerable<CharacterMovieOrSerie> MoviesOrSeriesAssociated { get; set; }
    }
}

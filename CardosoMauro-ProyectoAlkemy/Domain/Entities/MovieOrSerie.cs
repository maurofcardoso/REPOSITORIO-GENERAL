namespace Domain.Entities
{
    public class MovieOrSerie
    {
        public MovieOrSerie()
        {
            this.CharacterAssociated = new List<CharacterMovieOrSerie>();
        }
        public int MovieOrSerieId { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public double Qualification { get; set; }

        public IEnumerable<CharacterMovieOrSerie> CharacterAssociated { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }
    }
}

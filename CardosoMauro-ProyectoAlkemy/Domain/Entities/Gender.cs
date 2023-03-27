namespace Domain.Entities
{
    public class Gender
    {
        public Gender()
        {
            this.MoviesOrSeriesAssociated = new List<MovieOrSerie>();
        }
        public int GenderId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public IEnumerable<MovieOrSerie> MoviesOrSeriesAssociated { get; set; }
    }
}
